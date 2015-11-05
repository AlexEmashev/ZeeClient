namespace ZeeClient
{
    partial class FormKeySetup
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
            this.comboBoxKey = new System.Windows.Forms.ComboBox();
            this.cbAlt = new System.Windows.Forms.CheckBox();
            this.cbShift = new System.Windows.Forms.CheckBox();
            this.cbCtrl = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBoxKey
            // 
            this.comboBoxKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKey.FormattingEnabled = true;
            this.comboBoxKey.Location = new System.Drawing.Point(169, 12);
            this.comboBoxKey.Name = "comboBoxKey";
            this.comboBoxKey.Size = new System.Drawing.Size(154, 21);
            this.comboBoxKey.TabIndex = 7;
            // 
            // cbAlt
            // 
            this.cbAlt.AutoSize = true;
            this.cbAlt.Location = new System.Drawing.Point(114, 14);
            this.cbAlt.Name = "cbAlt";
            this.cbAlt.Size = new System.Drawing.Size(38, 17);
            this.cbAlt.TabIndex = 6;
            this.cbAlt.Text = "Alt";
            this.cbAlt.UseVisualStyleBackColor = true;
            // 
            // cbShift
            // 
            this.cbShift.AutoSize = true;
            this.cbShift.Location = new System.Drawing.Point(61, 14);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(47, 17);
            this.cbShift.TabIndex = 5;
            this.cbShift.Text = "Shift";
            this.cbShift.UseVisualStyleBackColor = true;
            // 
            // cbCtrl
            // 
            this.cbCtrl.AutoSize = true;
            this.cbCtrl.Location = new System.Drawing.Point(12, 14);
            this.cbCtrl.Name = "cbCtrl";
            this.cbCtrl.Size = new System.Drawing.Size(41, 17);
            this.cbCtrl.TabIndex = 4;
            this.cbCtrl.Text = "Ctrl";
            this.cbCtrl.UseVisualStyleBackColor = true;
            // 
            // FormKeySetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 45);
            this.Controls.Add(this.comboBoxKey);
            this.Controls.Add(this.cbAlt);
            this.Controls.Add(this.cbShift);
            this.Controls.Add(this.cbCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormKeySetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormKeySetup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormKeySetup_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxKey;
        private System.Windows.Forms.CheckBox cbAlt;
        private System.Windows.Forms.CheckBox cbShift;
        private System.Windows.Forms.CheckBox cbCtrl;
    }
}