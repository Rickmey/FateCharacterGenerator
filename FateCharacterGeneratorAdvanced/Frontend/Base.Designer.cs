namespace FateCharacterGeneratorAdvanced
{
    partial class Base
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.generateButton = new System.Windows.Forms.Button();
            this.chooseGenderIcon = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.loadOnStartCheckbox = new System.Windows.Forms.CheckBox();
            this.HideSkillsCheckbox = new System.Windows.Forms.CheckBox();
            this.MinValueTextBox = new System.Windows.Forms.TextBox();
            this.MaxValueTextBox = new System.Windows.Forms.TextBox();
            this.RandomThrowButton = new System.Windows.Forms.Button();
            this.RandomResultTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chooseGenderIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Location = new System.Drawing.Point(3, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(524, 486);
            this.tabControl.TabIndex = 0;
            this.tabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseClick);
            this.tabControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseDoubleClick);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(555, 22);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Random";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // chooseGenderIcon
            // 
            this.chooseGenderIcon.Location = new System.Drawing.Point(645, 22);
            this.chooseGenderIcon.Name = "chooseGenderIcon";
            this.chooseGenderIcon.Size = new System.Drawing.Size(48, 48);
            this.chooseGenderIcon.TabIndex = 6;
            this.chooseGenderIcon.TabStop = false;
            this.chooseGenderIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chooseGenderIcon_MouseClick);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(618, 464);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(618, 435);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 8;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.loadButton_MouseClick);
            // 
            // loadOnStartCheckbox
            // 
            this.loadOnStartCheckbox.AutoSize = true;
            this.loadOnStartCheckbox.Location = new System.Drawing.Point(535, 468);
            this.loadOnStartCheckbox.Name = "loadOnStartCheckbox";
            this.loadOnStartCheckbox.Size = new System.Drawing.Size(58, 17);
            this.loadOnStartCheckbox.TabIndex = 9;
            this.loadOnStartCheckbox.Text = "default";
            this.loadOnStartCheckbox.UseVisualStyleBackColor = true;
            // 
            // HideSkillsCheckbox
            // 
            this.HideSkillsCheckbox.AutoSize = true;
            this.HideSkillsCheckbox.Location = new System.Drawing.Point(555, 51);
            this.HideSkillsCheckbox.Name = "HideSkillsCheckbox";
            this.HideSkillsCheckbox.Size = new System.Drawing.Size(71, 17);
            this.HideSkillsCheckbox.TabIndex = 10;
            this.HideSkillsCheckbox.Text = "hide skills";
            this.HideSkillsCheckbox.UseVisualStyleBackColor = true;
            this.HideSkillsCheckbox.CheckedChanged += new System.EventHandler(this.HideSkillsCheckbox_CheckedChanged);
            // 
            // MinValueTextBox
            // 
            this.MinValueTextBox.Location = new System.Drawing.Point(555, 123);
            this.MinValueTextBox.Name = "MinValueTextBox";
            this.MinValueTextBox.Size = new System.Drawing.Size(138, 20);
            this.MinValueTextBox.TabIndex = 11;
            this.MinValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextBox_KeyPress);
            // 
            // MaxValueTextBox
            // 
            this.MaxValueTextBox.Location = new System.Drawing.Point(555, 150);
            this.MaxValueTextBox.Name = "MaxValueTextBox";
            this.MaxValueTextBox.Size = new System.Drawing.Size(138, 20);
            this.MaxValueTextBox.TabIndex = 12;
            this.MaxValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueTextBox_KeyPress);
            // 
            // RandomThrowButton
            // 
            this.RandomThrowButton.Location = new System.Drawing.Point(555, 177);
            this.RandomThrowButton.Name = "RandomThrowButton";
            this.RandomThrowButton.Size = new System.Drawing.Size(138, 23);
            this.RandomThrowButton.TabIndex = 13;
            this.RandomThrowButton.Text = "Random Throw";
            this.RandomThrowButton.UseVisualStyleBackColor = true;
            this.RandomThrowButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RandomThrowButton_MouseClick);
            // 
            // RandomResultTextBox
            // 
            this.RandomResultTextBox.Location = new System.Drawing.Point(555, 207);
            this.RandomResultTextBox.Name = "RandomResultTextBox";
            this.RandomResultTextBox.Size = new System.Drawing.Size(138, 20);
            this.RandomResultTextBox.TabIndex = 14;
            // 
            // Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 518);
            this.Controls.Add(this.RandomResultTextBox);
            this.Controls.Add(this.RandomThrowButton);
            this.Controls.Add(this.MaxValueTextBox);
            this.Controls.Add(this.MinValueTextBox);
            this.Controls.Add(this.HideSkillsCheckbox);
            this.Controls.Add(this.loadOnStartCheckbox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.chooseGenderIcon);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.tabControl);
            this.Name = "Base";
            this.Text = "FateCharcterGenerator";
            this.Load += new System.EventHandler(this.Base_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Base_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Base_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.chooseGenderIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.PictureBox chooseGenderIcon;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.CheckBox loadOnStartCheckbox;
        private System.Windows.Forms.CheckBox HideSkillsCheckbox;
        private System.Windows.Forms.TextBox MinValueTextBox;
        private System.Windows.Forms.TextBox MaxValueTextBox;
        private System.Windows.Forms.Button RandomThrowButton;
        private System.Windows.Forms.TextBox RandomResultTextBox;
    }
}

