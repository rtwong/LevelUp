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
            Canvas skillContainer = new Canvas();
            skillContainer.Tag = skill.identifier;
            Canvas.SetTop(skillContainer, offset);


            TextBox skillName = new TextBox();
            Canvas.SetLeft(skillName, 8);
            skillName.Text = skill.name;
            skillName.Height = 34;
            skillName.Width = 180;
            skillName.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#Munro");
            skillName.FontSize = 21;
            skillName.MaxLength = 12;
            skillName.Background = new SolidColorBrush(Color.FromRgb(255,212,160));
            skillName.Visibility = System.Windows.Visibility.Hidden;
            skillName.MouseLeave += new MouseEventHandler(skillTextBoxMouseLeave);
            skillName.Padding = new Thickness(2, 4, 0, 0);



            Label skillLabel = new Label();
            Canvas.SetLeft(skillLabel, 8);
            skillLabel.Content = skill.name;
            skillLabel.Height = 33;
            skillLabel.Width = 180;
            skillLabel.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/Fonts/#Munro");
            skillLabel.FontSize = 21;
            skillLabel.MouseEnter += new MouseEventHandler(skillLabelMouseEnter);
            skillLabel.MouseLeave += new MouseEventHandler(skillLabelMouseLeave);
            skillLabel.Tag = skill.identifier;
            //skillLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));



            ImageBrush deletePic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/delete_icon.png")));
            Button deleteButton = new Button();
            Canvas.SetLeft(deleteButton, 200);
            deleteButton.Background = deletePic;
            deleteButton.Height = 25;
            deleteButton.Width = 25;
            deleteButton.Tag = skill.identifier;
            deleteButton.Click += new RoutedEventHandler(deleteButton_Click);
            deleteButton.MouseEnter += new MouseEventHandler(deleteMouseEnter);
            deleteButton.MouseLeave += new MouseEventHandler(deleteMouseLeave);


            skillContainer.Children.Add(skillLabel);
            skillContainer.Children.Add(skillName);

            skillContainer.Children.Add(deleteButton);

            editSkillsContainerCanvas.Children.Add(skillContainer);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = (Button)sender;
            String deleteTag = senderButton.Tag.ToString();

            Canvas wp = (Canvas)(VisualTreeHelper.GetParent(senderButton) as UIElement);
            List<TextBox> textBoxList = wp.Children.OfType<TextBox>().ToList();
            TextBox textBox = textBoxList[0];

            List<Label> labelList = wp.Children.OfType<Label>().ToList();
            Label label = labelList[0];

            if (skillsToDelete.Contains<String>(deleteTag))
            {
                skillsToDelete.Remove(deleteTag);

                textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                label.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            }
            else
            {
                skillsToDelete.Add(deleteTag);
                textBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                label.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            }
        }

        private void deleteMouseEnter(object sender, EventArgs e)
        {
            Button enteredButton = (Button)sender;
            enteredButton.Height = 27;
            enteredButton.Width = 27;
        }


        private void deleteMouseLeave(object sender, EventArgs e)
        {
            if (true)
            {
                Button enteredButton = (Button)sender;
                enteredButton.Height = 25;
                enteredButton.Width = 25;
            }
        }

        private void skillTextBoxMouseLeave(object sender, EventArgs e)
        {
            TextBox enteredTextBox = (TextBox)sender;

            Canvas wp = (Canvas)(VisualTreeHelper.GetParent(enteredTextBox) as UIElement);
            List<Label> LabelList = wp.Children.OfType<Label>().ToList();

            Label textLabel = LabelList[0];
            textLabel.Content = enteredTextBox.Text;

            enteredTextBox.Visibility = Visibility.Hidden;


        }

        private void skillLabelMouseEnter(object sender, EventArgs e)
        {
            Label enteredLabel = (Label)sender;

            Canvas wp = (Canvas)(VisualTreeHelper.GetParent(enteredLabel) as UIElement);
            List<TextBox> textBoxList = wp.Children.OfType<TextBox>().ToList();
            TextBox textBox = textBoxList[0];
            textBox.Visibility = Visibility.Visible;

        }

        private void skillLabelMouseLeave(object sender, EventArgs e)
        {
            
            Label enteredLabel = (Label)sender;

            Canvas wp = (Canvas)(VisualTreeHelper.GetParent(enteredLabel) as UIElement);
            List<TextBox> textBoxList = wp.Children.OfType<TextBox>().ToList();
            TextBox textBox = textBoxList[0];
            //textBox.Visibility = Visibility.Hidden;
            

        }


        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (Canvas skillContainer in editSkillsContainerCanvas.Children.OfType<Canvas>())
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
