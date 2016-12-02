using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

    }
}
