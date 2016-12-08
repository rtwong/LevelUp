namespace LevelUp
{
    partial class EditSkillsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.editSkillsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.editSkillsApplyButton = new System.Windows.Forms.Button();
            this.editSkillsCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editSkillsContainer
            // 
            this.editSkillsContainer.Location = new System.Drawing.Point(-1, -1);
            this.editSkillsContainer.Name = "editSkillsContainer";
            this.editSkillsContainer.Size = new System.Drawing.Size(556, 576);
            this.editSkillsContainer.TabIndex = 0;
            // 
            // editSkillsApplyButton
            // 
            this.editSkillsApplyButton.Location = new System.Drawing.Point(344, 581);
            this.editSkillsApplyButton.Name = "editSkillsApplyButton";
            this.editSkillsApplyButton.Size = new System.Drawing.Size(98, 47);
            this.editSkillsApplyButton.TabIndex = 1;
            this.editSkillsApplyButton.Text = "APPLY";
            this.editSkillsApplyButton.UseVisualStyleBackColor = true;
            this.editSkillsApplyButton.Click += new System.EventHandler(this.editSkillsApplyButtonClick);
            // 
            // editSkillsCancelButton
            // 
            this.editSkillsCancelButton.Location = new System.Drawing.Point(448, 581);
            this.editSkillsCancelButton.Name = "editSkillsCancelButton";
            this.editSkillsCancelButton.Size = new System.Drawing.Size(93, 47);
            this.editSkillsCancelButton.TabIndex = 2;
            this.editSkillsCancelButton.Text = "CANCEL";
            this.editSkillsCancelButton.UseVisualStyleBackColor = true;
            this.editSkillsCancelButton.Click += new System.EventHandler(this.editSkillsCancelButtonClick);
            // 
            // EditSkillsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 638);
            this.Controls.Add(this.editSkillsCancelButton);
            this.Controls.Add(this.editSkillsApplyButton);
            this.Controls.Add(this.editSkillsContainer);
            this.Name = "EditSkillsView";
            this.Text = "Edit Skills";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel editSkillsContainer;
        private System.Windows.Forms.Button editSkillsApplyButton;
        private System.Windows.Forms.Button editSkillsCancelButton;
    }
}