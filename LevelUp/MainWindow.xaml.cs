using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LevelUp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DataManager dataManager;
        List<Label> labels;
        List<Canvas> panels;

        public MainWindow()
        {
            InitializeComponent();
            dataManager = new DataManager();
            labels = new List<Label>();
            panels = new List<Canvas>();
            populate();


            ImageBrush addSkillPic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/addskill_default.png")));
            Button addSkillButton = new Button();
            addSkillButton.Click += new RoutedEventHandler(addSkillButtonClick);
            addSkillButton.Height = 36;
            addSkillButton.Width = 36;
            addSkillButton.Background = addSkillPic;
            Canvas.SetLeft(addSkillButton, 450);
            Canvas.SetTop(addSkillButton, 600);
            addSkillButton.MouseEnter += new MouseEventHandler(addSkillMouseEnter);
            addSkillButton.MouseLeave += new MouseEventHandler(addSkillMouseLeave);
            addSkillButton.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(addSkillMouseDown);
            addSkillButton.MouseLeftButtonUp += new MouseButtonEventHandler(addSkillMouseUp);
            buttonCanvas.Children.Add(addSkillButton);

            
            ImageBrush editSkillPic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/editskill_default.png")));
            Button editSkillButton = new Button();
            editSkillButton.Click += new RoutedEventHandler(editButtonClick);
            editSkillButton.Height = 36;
            editSkillButton.Width = 36;
            editSkillButton.Background = editSkillPic;
            Canvas.SetLeft(editSkillButton, 400);
            Canvas.SetTop(editSkillButton, 600);
            editSkillButton.MouseEnter += new MouseEventHandler(editMouseEnter);
            editSkillButton.MouseLeave += new MouseEventHandler(editMouseLeave);
            editSkillButton.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(editMouseDown);
            editSkillButton.MouseLeftButtonUp += new MouseButtonEventHandler(editMouseUp);
            buttonCanvas.Children.Add(editSkillButton);
            


        }


        private void populate()
        {
            skillContainer.Children.Clear();

            foreach (Skill entry in dataManager.data)
            {
                addSkillToView(entry);
            }
        }

    

        // returns levels, remainder xp, xp to next level
        private Tuple<double, double, double> convert_to_level(double hours)
        {
            double xp = hours * 60;
            double current_level = 0;
            double remainder_xp = 0;
            double xp_to_next_level = 0;


            // going to seperate leveling into multiple curves of form (level = constant * sqrt(XP), first curve gets you to level 25 in 100 hours
            // level 1-25 -> 100hours
            // about 0.32275
            double CONSTANT_TO_25 = 25 / Math.Sqrt(6000);


            // level 25-99 -> 4900 hours
            // about 0.13647655
            double CONSTANT_TO_99 = 74 / Math.Sqrt(294000);



            // if total xp is greater than first break point, we are at least level 25, with some remainder
            if (xp >= 6000)
            {
                current_level = 25;
                xp -= 6000;
            }
            else
            {
                current_level = Math.Floor(CONSTANT_TO_25 * Math.Sqrt(xp));
                xp_to_next_level = (((current_level + 1) / CONSTANT_TO_25) * ((current_level + 1) / CONSTANT_TO_25)) - xp;
                remainder_xp = 1 + xp - (((current_level) / CONSTANT_TO_25) * ((current_level) / CONSTANT_TO_25));
                return Tuple.Create(current_level, Math.Floor(remainder_xp), Math.Floor(xp_to_next_level));

            }

            if (xp >= 294000)
            {
                current_level += 74;
                xp -= 294000;
            }
            else
            {
                current_level += Math.Floor(CONSTANT_TO_99 * Math.Sqrt(xp));
                xp_to_next_level = (((current_level - 24) / CONSTANT_TO_99) * ((current_level - 24) / CONSTANT_TO_99)) - xp;
                remainder_xp = 1 + xp - (((current_level - 25) / CONSTANT_TO_99) * ((current_level - 25) / CONSTANT_TO_99));
                return Tuple.Create(current_level, Math.Floor(remainder_xp), Math.Floor(xp_to_next_level));

            }

            if (xp == 300000)
            {
                current_level += 1;
                xp -= 300000;
                remainder_xp = 0;
                xp_to_next_level = 0;

            }
            else
            {
                remainder_xp = xp;
                xp_to_next_level = 300000 - xp;
                return Tuple.Create(current_level, remainder_xp, Math.Floor(xp_to_next_level));

            }


            // TODO: apply exp curve to convert into a level, and remainder_xp
            return Tuple.Create(current_level, remainder_xp, xp_to_next_level);


        }

        private double progressBarPercent(double remainder_xp, double xp_to_next_level)
        {
            return ((remainder_xp) / (xp_to_next_level + remainder_xp)) * 100;
        }



        private void addSkillToView(Skill skillToAdd)
        {
            Tuple<double, double, double> level_and_xp = convert_to_level(skillToAdd.hours);


            Canvas skillPanel = new Canvas();
            skillPanel.Height = 58;
            skillPanel.Width = 685;
            skillPanel.Name = skillToAdd.identifier;
            panels.Add(skillPanel);


            Image skillPic = new Image();
            skillPic.Height = 36;
            skillPic.Width = 36;



            if (skillToAdd.category.Count > 0)
            {
                if(skillToAdd.category.Count == 3)
                {
                    skillPic.Source = new BitmapImage(new Uri("/Icons/all_icon.png", UriKind.RelativeOrAbsolute));
                }
                
                if(skillToAdd.category.Count == 2)
                {
                    if ((skillToAdd.category.Contains(Category.STR) && (skillToAdd.category.Contains(Category.INT)))){
                        skillPic.Source = new BitmapImage(new Uri("/Icons/str_int_icon.png", UriKind.RelativeOrAbsolute));
                    }

                    if ((skillToAdd.category.Contains(Category.STR) && (skillToAdd.category.Contains(Category.CRT))))
                    {
                        skillPic.Source = new BitmapImage(new Uri("/Icons/str_crt_icon.png", UriKind.RelativeOrAbsolute));
                    }

                    if ((skillToAdd.category.Contains(Category.INT) && (skillToAdd.category.Contains(Category.CRT))))
                    {
                        skillPic.Source = new BitmapImage(new Uri("/Icons/int_crt_icon.png", UriKind.RelativeOrAbsolute));
                    }

                }

                if (skillToAdd.category.Count == 1)
                {
                    if (skillToAdd.category[0] == Category.STR)
                    {
                        skillPic.Source = new BitmapImage(new Uri("/Icons/str_icon.png", UriKind.RelativeOrAbsolute));
                    }

                    if (skillToAdd.category[0] == Category.INT)
                    {
                        skillPic.Source = new BitmapImage(new Uri("/Icons/int_icon.png", UriKind.RelativeOrAbsolute));
                    }

                    if (skillToAdd.category[0] == Category.CRT)
                    {
                        skillPic.Source = new BitmapImage(new Uri("/Icons/crt_icon.png", UriKind.RelativeOrAbsolute));
                    }
                }

            }

            Label levelLabel = new Label();
            levelLabel.Height = 48;
            levelLabel.Width = 48;
            levelLabel.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#Munro");
            levelLabel.FontSize = 30;
            levelLabel.Content = level_and_xp.Item1;


            Label skillLabel = new Label();
            skillLabel.Content = skillToAdd.name;
            //skillLabel.AutoSize = false;
            skillLabel.Height = 48;
            skillLabel.Width = 200;
            skillLabel.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#Munro");
            skillLabel.FontSize = 30;

            Canvas progressBarCanvas = drawProgressBar(progressBarPercent(level_and_xp.Item2, level_and_xp.Item3));

            



            //BitmapImage test = new BitmapImage(new Uri("pack://application:,,,/Images/levelup_default.png"));
            ImageBrush levelUpPic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/levelup_default.png")));
            //levelUpPic.ImageSource = test;
            


            Button timeAddButton = new Button();
            timeAddButton.Click += new RoutedEventHandler(addHalfHour);
            timeAddButton.Name = skillToAdd.identifier;
            timeAddButton.Height = 20;
            timeAddButton.Width = 20;
            timeAddButton.Background = levelUpPic;
            timeAddButton.BorderThickness = new Thickness(0, 0, 0, 0);
            timeAddButton.MouseEnter += new MouseEventHandler(mouseEnter);
            timeAddButton.MouseLeave += new MouseEventHandler(mouseLeave);
            timeAddButton.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(mouseDown);
            timeAddButton.MouseLeftButtonUp += new MouseButtonEventHandler(mouseUp);


            Canvas.SetTop(skillPic, 3);
            Canvas.SetLeft(skillPic, 20);
            skillPanel.Children.Add(skillPic);

            Canvas.SetTop(levelLabel, 0);
            Canvas.SetLeft(levelLabel, 60);
            skillPanel.Children.Add(levelLabel);

            Canvas.SetTop(skillLabel, 0);
            Canvas.SetLeft(skillLabel, 90);
            skillPanel.Children.Add(skillLabel);

            Canvas.SetTop(progressBarCanvas, 10);
            Canvas.SetLeft(progressBarCanvas, 290);
            skillPanel.Children.Add(progressBarCanvas);

            Canvas.SetTop(timeAddButton, 10);
            Canvas.SetLeft(timeAddButton, 490);
            skillPanel.Children.Add(timeAddButton);



            skillContainer.Children.Add(skillPanel);

        }

        private Canvas drawProgressBar(double percentXP)
        {

            double floor = Math.Floor(percentXP);
            double filled = percentXP / 10;
            double remainder = percentXP % 10;

            Canvas progressBarCanvas = new Canvas();
            progressBarCanvas.Height = 48;
            progressBarCanvas.Width = 230;

            int paddingOffset = 0;

            for (int i = 0; i < 10; i++)
            {
                Image backgroundPic = new Image();
                backgroundPic.Height = 20;
                backgroundPic.Width = 15;
                backgroundPic.Source = new BitmapImage(new Uri("/Images/background.png", UriKind.RelativeOrAbsolute));
                backgroundPic.Margin = new Thickness(paddingOffset, 0, 0, 0);
                paddingOffset += 20;
                progressBarCanvas.Children.Add(backgroundPic);
            }

            paddingOffset = 0;
            for (int i = 0; i < filled - 1; i++)
            {
                Image foregroundPic = new Image();
                foregroundPic.Height = 20;
                foregroundPic.Width = 15;
                foregroundPic.Source = new BitmapImage(new Uri("/Images/foreground.png", UriKind.RelativeOrAbsolute));
                foregroundPic.Margin = new Thickness(paddingOffset, 0, 0, 0);
                paddingOffset += 20;
                progressBarCanvas.Children.Add(foregroundPic);
            }

            var fullImage = new BitmapImage(new Uri("/Images/foreground.png", UriKind.RelativeOrAbsolute));
            fullImage.BaseUri = BaseUriHelper.GetBaseUri(this);



            double remainderPixels = Math.Round((remainder / 10) * 15);

            if (remainderPixels == 0)
            {
                return progressBarCanvas;
            }
            var croppedImage = new CroppedBitmap(fullImage, new Int32Rect(0, 0, (int)remainderPixels, 20));

            Image progressBarPic = new Image();
            progressBarPic.Height = 20;
            progressBarPic.Width = 15;
            progressBarPic.Stretch = Stretch.None;
            progressBarPic.HorizontalAlignment = HorizontalAlignment.Left;
            progressBarPic.Source = croppedImage;
            progressBarPic.Margin = new Thickness(paddingOffset, 0, 0, 0);

            progressBarCanvas.Children.Add(progressBarPic);

            return progressBarCanvas;
        }

        private void addHalfHour(object sender, RoutedEventArgs e)
        {

            Button clickedButton = (Button)sender;
            foreach (Skill entry in dataManager.data)
            {
                if (clickedButton.Name == entry.identifier)
                {
                    dataManager.update_data(entry.identifier, 0.5);
                }
            }
            populate();
        }




        private void addSkillButtonClick(object sender, RoutedEventArgs e)
        {
            if (dataManager.data.Count >= 10)
            {
                MessageBox.Show("Too many skills.");
                return;
            }

            System.Console.WriteLine(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));

            //AddSkillView dialog = new AddSkillView();

            //dialog.ShowDialog();

            addSkillView dialog = new addSkillView();

            dialog.ShowDialog();

            if (dialog.DialogResult == true)
            {

                List<Category> category_list = new List<Category> { };

                if (dialog.creativeValue)
                {
                    category_list.Add(Category.CRT);
                }
                if (dialog.strengthValue)
                {
                    category_list.Add(Category.STR);
                }
                if (dialog.intellectValue)
                {
                    category_list.Add(Category.INT);
                }


                dataManager.add_data(dialog.textValue, 0, category_list);
                populate();
            }
            else
            {
                Console.Write("Cancel clicked");
            }
        }

        private void addSkillMouseEnter(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            ImageBrush addSkillPicPressed = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/addskill_hover.png")));
            pressedButton.Background = addSkillPicPressed;
        }

        private void addSkillMouseLeave(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            ImageBrush addSkillPicPressed = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/addskill_default.png")));
            pressedButton.Background = addSkillPicPressed;
        }

        private void addSkillMouseUp(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            ImageBrush addSkillPicPressed = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/addskill_default.png")));
            pressedButton.Background = addSkillPicPressed;
        }

        private void addSkillMouseDown(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            ImageBrush addSkillPicPressed = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/addskill_pressed.png")));
            pressedButton.Background = addSkillPicPressed;
        }



        private void editButtonClick(object sender, RoutedEventArgs e)
        {
            editSkillsView dialog = new editSkillsView();
            dialog.ShowDialog();

            //ONLY WORKS WHEN YOU CLICK APPLY
            dataManager.fetch();
            populate();

        }

        private void editMouseEnter(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            ImageBrush editPicPressed = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/editskill_hover.png")));
            pressedButton.Background = editPicPressed;
        }

        private void editMouseLeave(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            ImageBrush editPicPressed = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/editskill_default.png")));
            pressedButton.Background = editPicPressed;
        }

        private void editMouseUp(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            ImageBrush editPicPressed = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/editskill_default.png")));
            pressedButton.Background = editPicPressed;
        }

        private void editMouseDown(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            ImageBrush editPicPressed = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/editskill_pressed.png")));
            pressedButton.Background = editPicPressed;
        }



        private void mouseEnter(object sender, MouseEventArgs e)
        {
            Button hoveredButton = (Button)sender;
            ImageBrush levelUpPicHover = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/levelup_hover.png")));
            hoveredButton.Background = levelUpPicHover;
        }

        private void mouseLeave(object sender, MouseEventArgs e)
        {
            Button hoveredButton = (Button)sender;
            ImageBrush levelUpPicHover = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/levelup_default.png")));
            hoveredButton.Background = levelUpPicHover;
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            ImageBrush levelUpPicPressed = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/levelup_pressed.png")));
            pressedButton.Background = levelUpPicPressed;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            ImageBrush levelUpPicPressed = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/levelup_default.png")));
            pressedButton.Background = levelUpPicPressed;
        }



        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) {
                Application.Current.MainWindow.DragMove();
            }
        }
    }
}
