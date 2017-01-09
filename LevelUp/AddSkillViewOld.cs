using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelUp
{
    public partial class AddSkillViewOld : Form
    {
        public string textValue { get; set; }
        public bool creativeValue { get; set; }
        public bool strengthValue { get; set; }
        public bool intellectValue { get; set; }

        public bool intellectStatus = false;
        public bool strengthStatus = false;
        public bool creativeStatus = false;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        
        public AddSkillViewOld()
        {
            InitializeComponent();
        }

        private void cancelClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Close();
        }

        private void okClick(object sender, EventArgs e)
        {
            textValue = skillTextBox.Text;
            creativeValue = creativeStatus;
            strengthValue = strengthStatus;
            intellectValue = intellectStatus;
            //yourText.All(char.IsLetterOrDigit)
            if ((intellectValue || strengthValue || creativeValue) && (textValue.Replace(" ", "").Length > 0))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid input.");
            }
        }
        
        private void titleBarClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Close();
        }

        private void titleBarDragLabel_MouseDown(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
            
        }

        private void intellectCheckPic_Click(object sender, EventArgs e)
        {
            intellectStatus = !intellectStatus;
        }

        private void intellectCheckPic_MouseEnter(object sender, EventArgs e)
        {
            intellectCheckPic.Image = Properties.Resources.int_icon;
        }

        private void intellectCheckPic_MouseLeave(object sender, EventArgs e)
        {
            if (!intellectStatus)
            {
                intellectCheckPic.Image = Properties.Resources.int_icon_grey;
            }
        }

        private void strengthCheckPic_Click(object sender, EventArgs e)
        {
            strengthStatus = !strengthStatus;
        }

        private void strengthCheckPic_MouseEnter(object sender, EventArgs e)
        {
            strengthCheckPic.Image = Properties.Resources.str_icon;
        }

        private void strengthCheckPic_MouseLeave(object sender, EventArgs e)
        {
            if (!strengthStatus)
            {
                strengthCheckPic.Image = Properties.Resources.str_icon_grey;
            }
        }

        private void creativeCheckPic_Click(object sender, EventArgs e)
        {
            creativeStatus = !creativeStatus;
        }

        private void creativeCheckPic_MouseEnter(object sender, EventArgs e)
        {
            creativeCheckPic.Image = Properties.Resources.crt_icon;
        }

        private void creativeCheckPic_MouseLeave(object sender, EventArgs e)
        {
            if (!creativeStatus)
            {
                creativeCheckPic.Image = Properties.Resources.crt_icon_grey;
            }
        }
    }

}
