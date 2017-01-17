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
using System.Windows.Shapes;

namespace LevelUp
{
    /// <summary>
    /// Interaction logic for addSkillView.xaml
    /// </summary>
    public partial class addSkillView : Window
    {
        public string textValue { get; set; }
        public bool creativeValue { get; set; }
        public bool strengthValue { get; set; }
        public bool intellectValue { get; set; }

        public bool intellectStatus = false;
        public bool strengthStatus = false;
        public bool creativeStatus = false;
        Button intelligenceLabelButton;
        Button strengthLabelButton;
        Button creativeLabelButton;

        DataManager dataManager;

        public addSkillView()
        {
            InitializeComponent();

            dataManager = new DataManager();

            ImageBrush intelligencePic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/int_icon_grey.png")));
            Button intelligenceButton = new Button();
            intelligenceButton.Click += new RoutedEventHandler(intelligenceClick);
            intelligenceButton.MouseEnter += new MouseEventHandler(intelligenceMouseEnter);
            intelligenceButton.MouseLeave += new MouseEventHandler(intelligenceMouseLeave);
            intelligenceButton.Height = 48;
            intelligenceButton.Width = 48;
            intelligenceButton.Background = intelligencePic;
            Canvas.SetTop(intelligenceButton, 10);

            intelligenceLabelButton = new Button();
            intelligenceLabelButton.Content = "Intelligence";
            intelligenceLabelButton.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#Munro");
            intelligenceLabelButton.FontSize = 26;
            intelligenceLabelButton.Click += new RoutedEventHandler(intelligenceClick);
            intelligenceLabelButton.MouseEnter += new MouseEventHandler(intelligenceMouseEnter);
            intelligenceLabelButton.MouseLeave += new MouseEventHandler(intelligenceMouseLeave);
            Canvas.SetLeft(intelligenceLabelButton, 54);
            Canvas.SetTop(intelligenceLabelButton, 17);

            ImageBrush strengthPic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/str_icon_grey.png")));
            Button strengthButton = new Button();
            strengthButton.Click += new RoutedEventHandler(strengthClick);
            strengthButton.MouseEnter += new MouseEventHandler(strengthMouseEnter);
            strengthButton.MouseLeave += new MouseEventHandler(strengthMouseLeave);
            strengthButton.Height = 48;
            strengthButton.Width = 48;
            strengthButton.Background = strengthPic;
            Canvas.SetTop(strengthButton, 65);

            strengthLabelButton = new Button();
            strengthLabelButton.Content = "Strength";
            strengthLabelButton.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#Munro");
            strengthLabelButton.FontSize = 26;
            strengthLabelButton.Click += new RoutedEventHandler(strengthClick);
            strengthLabelButton.MouseEnter += new MouseEventHandler(strengthMouseEnter);
            strengthLabelButton.MouseLeave += new MouseEventHandler(strengthMouseLeave);
            Canvas.SetLeft(strengthLabelButton, 54);
            Canvas.SetTop(strengthLabelButton, 72);

            ImageBrush creativePic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/crt_icon_grey.png")));
            Button creativeButton = new Button();
            creativeButton.Click += new RoutedEventHandler(creativeClick);
            creativeButton.MouseEnter += new MouseEventHandler(creativeMouseEnter);
            creativeButton.MouseLeave += new MouseEventHandler(creativeMouseLeave);
            creativeButton.Height = 48;
            creativeButton.Width = 48;
            creativeButton.Background = creativePic;
            Canvas.SetTop(creativeButton, 120);

            creativeLabelButton = new Button();
            creativeLabelButton.Content = "Creative";
            creativeLabelButton.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#Munro");
            creativeLabelButton.FontSize = 26;
            creativeLabelButton.Click += new RoutedEventHandler(creativeClick);
            creativeLabelButton.MouseEnter += new MouseEventHandler(creativeMouseEnter);
            creativeLabelButton.MouseLeave += new MouseEventHandler(creativeMouseLeave);
            Canvas.SetLeft(creativeLabelButton, 54);
            Canvas.SetTop(creativeLabelButton, 127);


            checkboxCanvas.Children.Add(intelligenceButton);
            checkboxCanvas.Children.Add(intelligenceLabelButton);
  
            checkboxCanvas.Children.Add(strengthButton);
            checkboxCanvas.Children.Add(strengthLabelButton);


            checkboxCanvas.Children.Add(creativeButton);
            checkboxCanvas.Children.Add(creativeLabelButton);

            
        }


        private void intelligenceClick(object sender, RoutedEventArgs e)
        {
            intellectStatus = !intellectStatus;
        }

        private void intelligenceMouseEnter(object sender, EventArgs e)
        {
            Button enteredButton = (Button) checkboxCanvas.Children[0];
            ImageBrush colouredIntelligence = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/int_icon.png")));
            enteredButton.Background = colouredIntelligence;
            intelligenceLabelButton.Foreground = new SolidColorBrush(Color.FromRgb(112, 146, 190));
        }

        private void intelligenceMouseLeave(object sender, EventArgs e)
        {
            if (!intellectStatus)
            {
                Button enteredButton = (Button)checkboxCanvas.Children[0];
                ImageBrush greyscaleIntelligence = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/int_icon_grey.png")));
                enteredButton.Background = greyscaleIntelligence;
                intelligenceLabelButton.Foreground = new SolidColorBrush(Colors.Black);

            }
        }

        private void strengthClick(object sender, RoutedEventArgs e)
        {
            strengthStatus = !strengthStatus;
        }

        private void strengthMouseEnter(object sender, EventArgs e)
        {
            Button enteredButton = (Button)checkboxCanvas.Children[2];
            ImageBrush colouredstrength = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/str_icon.png")));
            enteredButton.Background = colouredstrength;
            strengthLabelButton.Foreground = new SolidColorBrush(Color.FromRgb(137, 27, 27));
        }

        private void strengthMouseLeave(object sender, EventArgs e)
        {
            if (!strengthStatus)
            {
                Button enteredButton = (Button)checkboxCanvas.Children[2];
                ImageBrush greyscalestrength = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/str_icon_grey.png")));
                enteredButton.Background = greyscalestrength;
                strengthLabelButton.Foreground = new SolidColorBrush(Colors.Black);

            }
        }

        private void creativeClick(object sender, RoutedEventArgs e)
        {
            creativeStatus = !creativeStatus;
        }

        private void creativeMouseEnter(object sender, EventArgs e)
        {
            Button enteredButton = (Button)checkboxCanvas.Children[4];
            ImageBrush colouredcreative = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/crt_icon.png")));
            enteredButton.Background = colouredcreative;
            creativeLabelButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 64, 0));
        }

        private void creativeMouseLeave(object sender, EventArgs e)
        {
            if (!creativeStatus)
            {
                Button enteredButton = (Button)checkboxCanvas.Children[4]; ;
                ImageBrush greyscalecreative = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/crt_icon_grey.png")));
                enteredButton.Background = greyscalecreative;
                creativeLabelButton.Foreground = new SolidColorBrush(Colors.Black);

            }
        }

        private void addSkillButton_Click(object sender, EventArgs e)
        {
            textValue = addSkillTextBox.Text;
            creativeValue = creativeStatus;
            strengthValue = strengthStatus;
            intellectValue = intellectStatus;
            
            foreach (Skill skill in dataManager.data)
            {
                if ((skill.name == textValue || (textValue.Replace(" ", "").Length <= 0)))
                {
                    DuplicateEmptyPopup duplicateEmptyPopup = new DuplicateEmptyPopup();
                    duplicateEmptyPopup.Owner = this;
                    duplicateEmptyPopup.Show();
                    return;
                }
            }
            
            if (intellectValue || strengthValue || creativeValue)
            {
                DialogResult = true;

                Close();
            }
            else
            {
                CategoryPopup categoryPopup = new CategoryPopup();
                categoryPopup.Owner = this;
                categoryPopup.Show();
            }
        }



        private void addSkillTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void addSkillCloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }


    }
}
