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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
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
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRight
            // 
            this.buttonRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRight.Image = global::ZeeClient.Properties.Resources.ArrowRight;
            this.buttonRight.Location = new System.Drawing.Point(118, 53);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(29, 23);
            this.buttonRight.TabIndex = 19;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDown.Image = global::ZeeClient.Properties.Resources.ArrowDown;
            this.buttonDown.Location = new System.Drawing.Point(74, 88);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(29, 23);
            this.buttonDown.TabIndex = 18;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonUp.Image")));
            this.buttonUp.Location = new System.Drawing.Point(71, 17);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(31, 23);
            this.buttonUp.TabIndex = 17;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeft.Image = global::ZeeClient.Properties.Resources.ArrowLeft;
            this.buttonLeft.Location = new System.Drawing.Point(34, 53);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(29, 23);
            this.buttonLeft.TabIndex = 16;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonD
            // 
            this.buttonD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonD.Location = new System.Drawing.Point(49, 142);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(73, 23);
            this.buttonD.TabIndex = 15;
            this.buttonD.Text = "D";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonC
            // 
            this.buttonC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonC.Location = new System.Drawing.Point(382, 171);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(73, 23);
            this.buttonC.TabIndex = 14;
            this.buttonC.Text = "C";
            this.buttonC.UseVisualStyleBackColor = true;
            this.buttonC.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonB
            // 
            this.buttonB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonB.Location = new System.Drawing.Point(382, 79);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(73, 23);
            this.buttonB.TabIndex = 13;
            this.buttonB.Text = "B";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // buttonA
            // 
            this.buttonA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonA.Location = new System.Drawing.Point(382, 33);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(73, 23);
            this.buttonA.TabIndex = 12;
            this.buttonA.Text = "A";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.Click += new System.EventHandler(this.hotKeySetup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Status:";
            // 
            // textBoxRawData
            // 
            this.textBoxRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRawData.BackColor = System.Drawing.Color.Black;
            this.textBoxRawData.ForeColor = System.Drawing.Color.Lime;
            this.textBoxRawData.Location = new System.Drawing.Point(58, 200);
            this.textBoxRawData.Multiline = true;
            this.textBoxRawData.Name = "textBoxRawData";
            this.textBoxRawData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRawData.Size = new System.Drawing.Size(430, 72);
            this.textBoxRawData.TabIndex = 10;
            // 
            // bgWorkerProcessData
            // 
            this.bgWorkerProcessData.WorkerReportsProgress = true;
            this.bgWorkerProcessData.WorkerSupportsCancellation = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ZeeClient";
            this.notifyIcon.Visible = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZeeClient.Properties.Resources.ZeePreview;
            this.pictureBox1.Location = new System.Drawing.Point(131, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 250);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(70, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Joystick";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Enabled = false;
            this.textBoxStatus.Location = new System.Drawing.Point(58, 287);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(428, 20);
            this.textBoxStatus.TabIndex = 22;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 322);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormClient";
            this.Text = "ZeeClient";
            this.Load += new System.EventHandler(this.FormClient_Load);
            this.Resize += new System.EventHandler(this.FormClient_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStatus;
    }
}

