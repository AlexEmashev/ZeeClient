namespace ZeeClient
{
    partial class FormSettings
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
            this.numericUpDownDeadZone = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeadZone)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownDeadZone
            // 
            this.numericUpDownDeadZone.Location = new System.Drawing.Point(119, 12);
            this.numericUpDownDeadZone.Maximum = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.numericUpDownDeadZone.Name = "numericUpDownDeadZone";
            this.numericUpDownDeadZone.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownDeadZone.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Joystick dead zone:";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(223, 44);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownDeadZone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeadZone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownDeadZone;
        private System.Windows.Forms.Label label1;
    }
}