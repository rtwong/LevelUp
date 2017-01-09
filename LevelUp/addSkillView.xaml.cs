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

        public addSkillView()
        {
            InitializeComponent();
            ImageBrush intelligencePic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/int_icon_grey.png")));
            Button intelligenceButton = new Button();
            intelligenceButton.Click += new RoutedEventHandler(intelligenceClick);
            intelligenceButton.MouseEnter += new MouseEventHandler(intelligenceMouseEnter);
            intelligenceButton.MouseLeave += new MouseEventHandler(intelligenceMouseLeave);
            intelligenceButton.Height = 48;
            intelligenceButton.Width = 48;
            intelligenceButton.Background = intelligencePic;

            ImageBrush strengthPic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/str_icon_grey.png")));
            Button strengthButton = new Button();
            strengthButton.Click += new RoutedEventHandler(strengthClick);
            strengthButton.MouseEnter += new MouseEventHandler(strengthMouseEnter);
            strengthButton.MouseLeave += new MouseEventHandler(strengthMouseLeave);
            strengthButton.Height = 48;
            strengthButton.Width = 48;
            strengthButton.Background = strengthPic;
            Canvas.SetTop(strengthButton, 50);

            ImageBrush creativePic = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/crt_icon_grey.png")));
            Button creativeButton = new Button();
            creativeButton.Click += new RoutedEventHandler(creativeClick);
            creativeButton.MouseEnter += new MouseEventHandler(creativeMouseEnter);
            creativeButton.MouseLeave += new MouseEventHandler(creativeMouseLeave);
            creativeButton.Height = 48;
            creativeButton.Width = 48;
            creativeButton.Background = creativePic;
            Canvas.SetTop(creativeButton, 100);


            checkboxCanvas.Children.Add(intelligenceButton);
            checkboxCanvas.Children.Add(strengthButton);
            checkboxCanvas.Children.Add(creativeButton);

        }

        private void intelligenceClick(object sender, RoutedEventArgs e)
        {
            intellectStatus = !intellectStatus;
        }

        private void intelligenceMouseEnter(object sender, EventArgs e)
        {
            //intelligenceButton.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/int_icon.png")));
            Button enteredButton = (Button)sender;
            ImageBrush colouredIntelligence = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/int_icon.png")));
            enteredButton.Background = colouredIntelligence;
        }

        private void intelligenceMouseLeave(object sender, EventArgs e)
        {
            if (!intellectStatus)
            {
                //intelligenceButton.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/int_icon_grey.png")));
                Button enteredButton = (Button)sender;
                ImageBrush greyscaleIntelligence = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/int_icon_grey.png")));
                enteredButton.Background = greyscaleIntelligence;
            }
        }

        private void strengthClick(object sender, RoutedEventArgs e)
        {
            strengthStatus = !strengthStatus;
        }

        private void strengthMouseEnter(object sender, EventArgs e)
        {
            Button enteredButton = (Button)sender;
            ImageBrush colouredstrength = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/str_icon.png")));
            enteredButton.Background = colouredstrength;
        }

        private void strengthMouseLeave(object sender, EventArgs e)
        {
            if (!strengthStatus)
            {
                Button enteredButton = (Button)sender;
                ImageBrush greyscalestrength = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/str_icon_grey.png")));
                enteredButton.Background = greyscalestrength;
            }
        }

        private void creativeClick(object sender, RoutedEventArgs e)
        {
            creativeStatus = !creativeStatus;
        }

        private void creativeMouseEnter(object sender, EventArgs e)
        {
            Button enteredButton = (Button)sender;
            ImageBrush colouredcreative = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/crt_icon.png")));
            enteredButton.Background = colouredcreative;
        }

        private void creativeMouseLeave(object sender, EventArgs e)
        {
            if (!creativeStatus)
            {
                Button enteredButton = (Button)sender;
                ImageBrush greyscalecreative = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Icons/crt_icon_grey.png")));
                enteredButton.Background = greyscalecreative;
            }
        }

        private void addSkillButton_Click(object sender, EventArgs e)
        {
            textValue = addSkillTextBox.Text;
            creativeValue = creativeStatus;
            strengthValue = strengthStatus;
            intellectValue = intellectStatus;
            if ((intellectValue || strengthValue || creativeValue) && (textValue.Replace(" ", "").Length > 0))
            {
                DialogResult = true;

                Close();
            }
            else
            {
                MessageBox.Show("Invalid input.");
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
