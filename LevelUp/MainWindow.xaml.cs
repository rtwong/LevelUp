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

        public MainWindow()
        {
            InitializeComponent();
            dataManager = new DataManager();
            labels = new List<Label>();

            //  ADDING ITEMS
            List<Category> list1 = new List<Category> { Category.STR };
            List<Category> list2 = new List<Category> { Category.STR };
            List<Category> list3 = new List<Category> { Category.CRT };


            populate();
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
                remainder_xp = xp - (((current_level) / CONSTANT_TO_25) * ((current_level) / CONSTANT_TO_25));
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
                remainder_xp = xp - (((current_level - 25) / CONSTANT_TO_99) * ((current_level - 25) / CONSTANT_TO_99));
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

        private void addSkillButtonClick(object sender, RoutedEventArgs e)
        {
            AddSkillView dialog = new AddSkillView();
            dialog.ShowDialog();

            if (dialog.DialogResult == System.Windows.Forms.DialogResult.OK)
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

        private void populate()
        {
            skillContainer.Children.Clear();

            foreach (Skill entry in dataManager.data)
            {
                addSkillToView(entry);
            }
        }



        private void addSkillToView(Skill skillToAdd)
        {
            Tuple<double, double, double> level_and_xp = convert_to_level(skillToAdd.hours);


            WrapPanel skillPanel = new WrapPanel();
            skillPanel.Height = 58;
            skillPanel.Width = 685;

            Image skillPic = new Image();
            skillPic.Height = 48;
            skillPic.Width = 48;


            if (skillToAdd.category.Count > 0)
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

            Label levelLabel = new Label();
            levelLabel.Height = 48;
            levelLabel.Width = 48;
            levelLabel.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#Munro");
            levelLabel.FontSize = 40;
            levelLabel.Content = level_and_xp.Item1;


            Label skillLabel = new Label();
            skillLabel.Content = skillToAdd.name;
            //skillLabel.AutoSize = false;
            skillLabel.Height = 48;
            skillLabel.Width = 225;
            skillLabel.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#Munro");
            skillLabel.FontSize = 40;

            ProgressBar skillProgressBar = new ProgressBar();
            skillProgressBar.Height = 36;
            skillProgressBar.Width = 270;

            Button timeAddButton = new Button();
            timeAddButton.Click += new RoutedEventHandler(addHalfHour);
            timeAddButton.Name = skillToAdd.identifier;
            timeAddButton.Height = 48;
            timeAddButton.Width = 55;
            timeAddButton.Content = "+";

            skillPanel.Children.Add(skillPic);
            skillPanel.Children.Add(levelLabel);
            skillPanel.Children.Add(skillLabel);
            skillPanel.Children.Add(skillProgressBar);
            skillPanel.Children.Add(timeAddButton);


            skillContainer.Children.Add(skillPanel);

        }

        public void addHalfHour(object sender, RoutedEventArgs e)
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


    }
}
