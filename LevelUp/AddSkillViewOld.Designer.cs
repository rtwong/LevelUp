using System.Drawing;
using System.Drawing.Text;

namespace LevelUp
{

    partial class AddSkillViewOld
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
            this.skillTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.titleBarFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.titleBarDragLabel = new System.Windows.Forms.Label();
            this.titleBarClose = new System.Windows.Forms.PictureBox();
            this.intellectLabel = new System.Windows.Forms.Label();
            this.intellectCheckPic = new System.Windows.Forms.PictureBox();
            this.strengthCheckPic = new System.Windows.Forms.PictureBox();
            this.strengthLabel = new System.Windows.Forms.Label();
            this.creativeCheckPic = new System.Windows.Forms.PictureBox();
            this.creativeLabel = new System.Windows.Forms.Label();
            this.titleBarFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titleBarClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intellectCheckPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strengthCheckPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creativeCheckPic)).BeginInit();
            this.SuspendLayout();
            // 
            // skillTextBox
            // 
            this.skillTextBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.skillTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skillTextBox.Location = new System.Drawing.Point(16, 55);
            this.skillTextBox.Name = "skillTextBox";
            this.skillTextBox.Size = new System.Drawing.Size(271, 13);
            this.skillTextBox.TabIndex = 1;
            /*
            System.Drawing.Text.PrivateFontCollection modernFont = new System.Drawing.Text.PrivateFontCollection();
            string fullPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/../../Fonts/Munro.ttf";
            System.Console.WriteLine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            modernFont.AddFontFile(fullPath);
            this.skillTextBox.Font = new Font(modernFont.Families[0], 30);
            */

            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Location = new System.Drawing.Point(167, 274);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelClick);
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.Transparent;
            this.okButton.Location = new System.Drawing.Point(68, 274);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "ADD SKILL";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okClick);
            // 
            // titleBarFlowLayoutPanel
            // 
            this.titleBarFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.titleBarFlowLayoutPanel.Controls.Add(this.titleBarDragLabel);
            this.titleBarFlowLayoutPanel.Controls.Add(this.titleBarClose);
            this.titleBarFlowLayoutPanel.Location = new System.Drawing.Point(2, 3);
            this.titleBarFlowLayoutPanel.Name = "titleBarFlowLayoutPanel";
            this.titleBarFlowLayoutPanel.Size = new System.Drawing.Size(298, 19);
            this.titleBarFlowLayoutPanel.TabIndex = 7;
            // 
            // titleBarDragLabel
            // 
            this.titleBarDragLabel.Location = new System.Drawing.Point(3, 0);
            this.titleBarDragLabel.Name = "titleBarDragLabel";
            this.titleBarDragLabel.Size = new System.Drawing.Size(253, 19);
            this.titleBarDragLabel.TabIndex = 0;
            this.titleBarDragLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBarDragLabel_MouseDown);
            // 
            // titleBarClose
            // 
            this.titleBarClose.BackgroundImage = global::LevelUp.Properties.Resources.close_Icon;
            this.titleBarClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.titleBarClose.InitialImage = global::LevelUp.Properties.Resources.close_Icon;
            this.titleBarClose.Location = new System.Drawing.Point(259, 0);
            this.titleBarClose.Margin = new System.Windows.Forms.Padding(0);
            this.titleBarClose.Name = "titleBarClose";
            this.titleBarClose.Size = new System.Drawing.Size(39, 24);
            this.titleBarClose.TabIndex = 2;
            this.titleBarClose.TabStop = false;
            this.titleBarClose.Click += new System.EventHandler(this.titleBarClose_Click);
            // 
            // intellectLabel
            // 
            this.intellectLabel.AutoSize = true;
            this.intellectLabel.BackColor = System.Drawing.Color.Transparent;
            this.intellectLabel.Location = new System.Drawing.Point(71, 107);
            this.intellectLabel.Name = "intellectLabel";
            this.intellectLabel.Size = new System.Drawing.Size(65, 13);
            this.intellectLabel.TabIndex = 9;
            this.intellectLabel.Text = "INTELLECT";


            // 
            // intellectCheckPic
            // 
            this.intellectCheckPic.BackColor = System.Drawing.Color.Transparent;
            this.intellectCheckPic.BackgroundImage = global::LevelUp.Properties.Resources.int_icon_grey;
            this.intellectCheckPic.Location = new System.Drawing.Point(12, 92);
            this.intellectCheckPic.Name = "intellectCheckPic";
            this.intellectCheckPic.Size = new System.Drawing.Size(48, 48);
            this.intellectCheckPic.TabIndex = 8;
            this.intellectCheckPic.TabStop = false;
            this.intellectCheckPic.Click += new System.EventHandler(this.intellectCheckPic_Click);
            this.intellectCheckPic.MouseEnter += new System.EventHandler(this.intellectCheckPic_MouseEnter);
            this.intellectCheckPic.MouseLeave += new System.EventHandler(this.intellectCheckPic_MouseLeave);
            // 
            // strengthCheckPic
            // 
            this.strengthCheckPic.BackColor = System.Drawing.Color.Transparent;
            this.strengthCheckPic.BackgroundImage = global::LevelUp.Properties.Resources.str_icon_grey;
            this.strengthCheckPic.Location = new System.Drawing.Point(12, 142);
            this.strengthCheckPic.Name = "strengthCheckPic";
            this.strengthCheckPic.Size = new System.Drawing.Size(48, 48);
            this.strengthCheckPic.TabIndex = 10;
            this.strengthCheckPic.TabStop = false;
            this.strengthCheckPic.Click += new System.EventHandler(this.strengthCheckPic_Click);
            this.strengthCheckPic.MouseEnter += new System.EventHandler(this.strengthCheckPic_MouseEnter);
            this.strengthCheckPic.MouseLeave += new System.EventHandler(this.strengthCheckPic_MouseLeave);
            // 
            // strengthLabel
            // 
            this.strengthLabel.AutoSize = true;
            this.strengthLabel.BackColor = System.Drawing.Color.Transparent;
            this.strengthLabel.Location = new System.Drawing.Point(71, 155);
            this.strengthLabel.Name = "strengthLabel";
            this.strengthLabel.Size = new System.Drawing.Size(67, 13);
            this.strengthLabel.TabIndex = 11;
            this.strengthLabel.Text = "STRENGTH";
            //this.strengthLabel.Font = new Font(modernFont.Families[0], 15);


            // 
            // creativeCheckPic
            // 
            this.creativeCheckPic.BackColor = System.Drawing.Color.Transparent;
            this.creativeCheckPic.BackgroundImage = global::LevelUp.Properties.Resources.crt_icon_grey;
            this.creativeCheckPic.Location = new System.Drawing.Point(12, 193);
            this.creativeCheckPic.Name = "creativeCheckPic";
            this.creativeCheckPic.Size = new System.Drawing.Size(48, 48);
            this.creativeCheckPic.TabIndex = 12;
            this.creativeCheckPic.TabStop = false;
            this.creativeCheckPic.Click += new System.EventHandler(this.creativeCheckPic_Click);
            this.creativeCheckPic.MouseEnter += new System.EventHandler(this.creativeCheckPic_MouseEnter);
            this.creativeCheckPic.MouseLeave += new System.EventHandler(this.creativeCheckPic_MouseLeave);
            // 
            // creativeLabel
            // 
            this.creativeLabel.AutoSize = true;
            this.creativeLabel.BackColor = System.Drawing.Color.Transparent;
            this.creativeLabel.Location = new System.Drawing.Point(74, 208);
            this.creativeLabel.Name = "creativeLabel";
            this.creativeLabel.Size = new System.Drawing.Size(60, 13);
            this.creativeLabel.TabIndex = 13;
            this.creativeLabel.Text = "CREATIVE";
            //this.creativeLabel.Font = new Font(modernFont.Families[0], 15);

            // 
            // AddSkillView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImage = global::LevelUp.Properties.Resources.addSkill_background;
            this.ClientSize = new System.Drawing.Size(300, 335);
            this.ControlBox = false;
            this.Controls.Add(this.creativeLabel);
            this.Controls.Add(this.creativeCheckPic);
            this.Controls.Add(this.strengthLabel);
            this.Controls.Add(this.strengthCheckPic);
            this.Controls.Add(this.intellectLabel);
            this.Controls.Add(this.intellectCheckPic);
            this.Controls.Add(this.titleBarFlowLayoutPanel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.skillTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddSkillView";
            this.Text = "Add Skill";
            this.titleBarFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.titleBarClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intellectCheckPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strengthCheckPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creativeCheckPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox skillTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.FlowLayoutPanel titleBarFlowLayoutPanel;
        private System.Windows.Forms.Label titleBarDragLabel;
        private System.Windows.Forms.PictureBox titleBarClose;
        private System.Windows.Forms.PictureBox intellectCheckPic;
        private System.Windows.Forms.Label intellectLabel;
        private System.Windows.Forms.PictureBox strengthCheckPic;
        private System.Windows.Forms.Label strengthLabel;
        private System.Windows.Forms.PictureBox creativeCheckPic;
        private System.Windows.Forms.Label creativeLabel;
    }

}