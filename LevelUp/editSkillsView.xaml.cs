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
    /// Interaction logic for editSkillsView.xaml
    /// </summary>
    public partial class editSkillsView : Window
    {
        DataManager dataManager;
        List<String> skillsToDelete;
        int offset = 0;

        //ImageBrush deletePic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/close_Icon.png")));


        public editSkillsView()
        {
            InitializeComponent();

            dataManager = new DataManager();
            skillsToDelete = new List<String>();

            foreach (Skill skill in dataManager.data)
            {
                populateSkill(skill, offset);
                offset += 40;
            }

        }

        private void populateSkill(Skill skill, int offset)
        {
            WrapPanel skillContainer = new WrapPanel();
            skillContainer.Tag = skill.identifier;
            Canvas.SetTop(skillContainer, offset);

            TextBox skillName = new TextBox();
            skillName.Text = skill.name;
            skillName.Height = 28;
            skillName.Width = 180;
            skillName.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#Munro");
            skillName.FontSize = 21;
            skillName.MaxLength = 13;
            skillName.Background = new SolidColorBrush(Color.FromRgb(255,212,160));

            ImageBrush deletePic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/all_icon.png")));
            Button deleteButton = new Button();
            deleteButton.Background = deletePic;
            deleteButton.Height = 15;
            deleteButton.Width = 15;
            //deleteButton.Content = "       ";
            deleteButton.Tag = skill.identifier;
            deleteButton.Click += new RoutedEventHandler(deleteButton_Click);


            skillContainer.Children.Add(skillName);
            skillContainer.Children.Add(deleteButton);

            editSkillsContainerCanvas.Children.Add(skillContainer);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = (Button)sender;
            skillsToDelete.Add(senderButton.Tag.ToString());
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (WrapPanel skillContainer in editSkillsContainerCanvas.Children.OfType<WrapPanel>())
            {
                List<TextBox> textBoxList = skillContainer.Children.OfType<TextBox>().ToList();
                TextBox textBox = textBoxList[0];
                String newSkillName = textBox.Text;

                String identifier = (String)skillContainer.Tag;

                dataManager.update_name(newSkillName, identifier);
            }

            foreach (String identifier in skillsToDelete)
            {
                dataManager.remove_data(identifier);
            }

            DialogResult = true;
            Close();

        }

        private void editSkillsCloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void editSkillsTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }


    }
}
