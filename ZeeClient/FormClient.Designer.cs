namespace ZeeClient
{
    partial class FormClient
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
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonD = new System.Windows.Forms.Button();
            this.buttonC = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.buttonA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRawData = new System.Windows.Forms.TextBox();
            this.bgWorkerProcessData = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(218, 47);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(29, 23);
            this.buttonRight.TabIndex = 19;
            this.buttonRight.Text = ">";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(183, 67);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(29, 23);
            this.buttonDown.TabIndex = 18;
            this.buttonDown.Text = "V";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(183, 24);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(29, 23);
            this.buttonUp.TabIndex = 17;
            this.buttonUp.Text = "/\\";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(148, 47);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(29, 23);
            this.buttonLeft.TabIndex = 16;
            this.buttonLeft.Text = "<";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonD
            // 
            this.buttonD.Location = new System.Drawing.Point(344, 24);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(29, 23);
            this.buttonD.TabIndex = 15;
            this.buttonD.Text = "D";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonC
            // 
            this.buttonC.Location = new System.Drawing.Point(344, 64);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(29, 23);
            this.buttonC.TabIndex = 14;
            this.buttonC.Text = "C";
            this.buttonC.UseVisualStyleBackColor = true;
            this.buttonC.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonB
            // 
            this.buttonB.Location = new System.Drawing.Point(293, 24);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(29, 23);
            this.buttonB.TabIndex = 13;
            this.buttonB.Text = "B";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonA
            // 
            this.buttonA.Location = new System.Drawing.Point(293, 64);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(29, 23);
            this.buttonA.TabIndex = 12;
            this.buttonA.Text = "A";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Raw data:";
            // 
            // textBoxRawData
            // 
            this.textBoxRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRawData.BackColor = System.Drawing.Color.Black;
            this.textBoxRawData.ForeColor = System.Drawing.Color.Lime;
            this.textBoxRawData.Location = new System.Drawing.Point(12, 119);
            this.textBoxRawData.Multiline = true;
            this.textBoxRawData.Name = "textBoxRawData";
            this.textBoxRawData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRawData.Size = new System.Drawing.Size(547, 191);
            this.textBoxRawData.TabIndex = 10;
            // 
            // bgWorkerProcessData
            // 
            this.bgWorkerProcessData.WorkerReportsProgress = true;
            this.bgWorkerProcessData.WorkerSupportsCancellation = true;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 322);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonD);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRawData);
            this.Name = "FormClient";
            this.Text = "Zee Client";
            this.Load += new System.EventHandler(this.FormClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRawData;
        private System.ComponentModel.BackgroundWorker bgWorkerProcessData;
    }
}

