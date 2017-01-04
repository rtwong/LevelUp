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
    public partial class AddSkillView : Form
    {
        public string textValue { get; set; }
        public bool creativeValue { get; set; }
        public bool strengthValue { get; set; }
        public bool intellectValue { get; set; }

        
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        
        public AddSkillView()
        {
            InitializeComponent();
        }

        private void creativeChanged(object sender, EventArgs e)
        {
            Console.Write("Creative");
        }

        private void strengthChanged(object sender, EventArgs e)
        {
            Console.Write("Strength");
        }

        private void intellectChanged(object sender, EventArgs e)
        {
            Console.Write("Intellect");
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void cancelClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Close();
        }

        private void okClick(object sender, EventArgs e)
        {
            textValue = skillTextBox.Text;
            creativeValue = creativeCheckbox.Checked;
            strengthValue = strengthCheckbox.Checked;
            intellectValue = intellectCheckbox.Checked;
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
        
    }
}
