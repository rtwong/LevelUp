namespace LevelUp
{
    partial class AddSkillView
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
            this.label1 = new System.Windows.Forms.Label();
            this.skillTextBox = new System.Windows.Forms.TextBox();
            this.intellectCheckbox = new System.Windows.Forms.CheckBox();
            this.strengthCheckbox = new System.Windows.Forms.CheckBox();
            this.creativeCheckbox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "INPUT SKILL";
            // 
            // skillTextBox
            // 
            this.skillTextBox.Location = new System.Drawing.Point(16, 55);
            this.skillTextBox.Name = "skillTextBox";
            this.skillTextBox.Size = new System.Drawing.Size(414, 20);
            this.skillTextBox.TabIndex = 1;
            // 
            // intellectCheckbox
            // 
            this.intellectCheckbox.AutoSize = true;
            this.intellectCheckbox.Location = new System.Drawing.Point(16, 118);
            this.intellectCheckbox.Name = "intellectCheckbox";
            this.intellectCheckbox.Size = new System.Drawing.Size(84, 17);
            this.intellectCheckbox.TabIndex = 2;
            this.intellectCheckbox.Text = "INTELLECT";
            this.intellectCheckbox.UseVisualStyleBackColor = true;
            this.intellectCheckbox.CheckedChanged += new System.EventHandler(this.intellectChanged);
            // 
            // strengthCheckbox
            // 
            this.strengthCheckbox.AutoSize = true;
            this.strengthCheckbox.Location = new System.Drawing.Point(185, 118);
            this.strengthCheckbox.Name = "strengthCheckbox";
            this.strengthCheckbox.Size = new System.Drawing.Size(86, 17);
            this.strengthCheckbox.TabIndex = 3;
            this.strengthCheckbox.Text = "STRENGTH";
            this.strengthCheckbox.UseVisualStyleBackColor = true;
            this.strengthCheckbox.CheckedChanged += new System.EventHandler(this.strengthChanged);
            // 
            // creativeCheckbox
            // 
            this.creativeCheckbox.AutoSize = true;
            this.creativeCheckbox.Location = new System.Drawing.Point(348, 118);
            this.creativeCheckbox.Name = "creativeCheckbox";
            this.creativeCheckbox.Size = new System.Drawing.Size(79, 17);
            this.creativeCheckbox.TabIndex = 4;
            this.creativeCheckbox.Text = "CREATIVE";
            this.creativeCheckbox.UseVisualStyleBackColor = true;
            this.creativeCheckbox.CheckedChanged += new System.EventHandler(this.creativeChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(222, 223);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelClick);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(348, 223);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okClick);
            // 
            // AddSkillView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 258);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.creativeCheckbox);
            this.Controls.Add(this.strengthCheckbox);
            this.Controls.Add(this.intellectCheckbox);
            this.Controls.Add(this.skillTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddSkillView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox skillTextBox;
        private System.Windows.Forms.CheckBox intellectCheckbox;
        private System.Windows.Forms.CheckBox strengthCheckbox;
        private System.Windows.Forms.CheckBox creativeCheckbox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}