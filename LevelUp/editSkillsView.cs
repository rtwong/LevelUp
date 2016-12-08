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
    public partial class EditSkillsView : Form
    {
        DataManager dataManager;
        List<String> skillsToDelete;

        public EditSkillsView()
        {
            InitializeComponent();

            dataManager = new DataManager();
            skillsToDelete = new List<String>();
            
            foreach (Skill skill in dataManager.data)
            {
                populateSkill(skill);
            } 

        }

        private void populateSkill(Skill skill)
        {
            FlowLayoutPanel skillPanel = new FlowLayoutPanel();
            skillPanel.Tag = skill.identifier;

            TextBox skillName = new TextBox();
            skillName.Text = skill.name;
            
            Button deleteButton = new Button();
            deleteButton.Text = "DELETE";
            deleteButton.Tag = skill.identifier;
            deleteButton.Click += new EventHandler(deleteButtonClick);

            skillPanel.Controls.Add(skillName);
            skillPanel.Controls.Add(deleteButton);

            editSkillsContainer.Controls.Add(skillPanel);
        }

        private void deleteButtonClick(object sender, EventArgs e)
        {

            Button senderButton = (Button)sender;
            //dataManager.remove_data(senderButton.Tag.ToString());
            skillsToDelete.Add(senderButton.Tag.ToString());

        }

        private void editSkillsApplyButtonClick(object sender, EventArgs e)
        {
            //Console.Write(editSkillsContainer.Controls.ToString());
            
            foreach (FlowLayoutPanel skillPanel in editSkillsContainer.Controls.OfType<FlowLayoutPanel>())
            {
                Console.Write("qweqwe");
                List<TextBox> textBoxList = skillPanel.Controls.OfType<TextBox>().ToList();
                TextBox textBox = textBoxList[0];
                String newSkillName = textBox.Text;

                String identifier = (String) skillPanel.Tag;

                //parts.Find(x => x.PartName.Contains("seat")));

                Skill skillNameChange = dataManager.data.Find(x => x.name == identifier);
                dataManager.update_name(newSkillName, identifier);
            }

            foreach (String identifier in skillsToDelete)
            {
                dataManager.remove_data(identifier);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

        private void editSkillsCancelButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Close();
        }
    }
}
