namespace Training119
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.flFire = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.flAnswer = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.flBegin = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmPlay = new System.Windows.Forms.Timer(this.components);
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flFire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flBegin)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pnlMain.Controls.Add(this.lblCount);
            this.pnlMain.Controls.Add(this.flFire);
            this.pnlMain.Controls.Add(this.flAnswer);
            this.pnlMain.Controls.Add(this.picMain);
            this.pnlMain.Controls.Add(this.flBegin);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1024, 768);
            this.pnlMain.TabIndex = 0;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.OrangeRed;
            this.lblCount.Font = new System.Drawing.Font("YouYuan", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCount.ForeColor = System.Drawing.Color.Gold;
            this.lblCount.Location = new System.Drawing.Point(433, 622);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 40);
            this.lblCount.TabIndex = 4;
            // 
            // flFire
            // 
            this.flFire.Enabled = true;
            this.flFire.Location = new System.Drawing.Point(728, 430);
            this.flFire.Name = "flFire";
            this.flFire.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flFire.OcxState")));
            this.flFire.Size = new System.Drawing.Size(345, 430);
            this.flFire.TabIndex = 3;
            // 
            // flAnswer
            // 
            this.flAnswer.Enabled = true;
            this.flAnswer.Location = new System.Drawing.Point(0, 0);
            this.flAnswer.Name = "flAnswer";
            this.flAnswer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flAnswer.OcxState")));
            this.flAnswer.Size = new System.Drawing.Size(425, 375);
            this.flAnswer.TabIndex = 0;
            // 
            // picMain
            // 
            this.picMain.BackColor = System.Drawing.SystemColors.Control;
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.ImageLocation = "H:\\王明强\\119Training\\119Training\\bin\\Debug\\pic\\bg.jpg";
            this.picMain.InitialImage = null;
            this.picMain.Location = new System.Drawing.Point(0, 0);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(1024, 768);
            this.picMain.TabIndex = 2;
            this.picMain.TabStop = false;
            this.picMain.Visible = false;
            // 
            // flBegin
            // 
            this.flBegin.Enabled = true;
            this.flBegin.Location = new System.Drawing.Point(0, 0);
            this.flBegin.Margin = new System.Windows.Forms.Padding(0);
            this.flBegin.Name = "flBegin";
            this.flBegin.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flBegin.OcxState")));
            this.flBegin.Size = new System.Drawing.Size(600, 500);
            this.flBegin.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmPlay
            // 
            this.tmPlay.Interval = 200;
            this.tmPlay.Tick += new System.EventHandler(this.tmPlay_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1022, 766);
            this.Controls.Add(this.pnlMain);
            this.Name = "MainForm";
            this.Text = "119模拟报警系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flFire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flBegin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private AxShockwaveFlashObjects.AxShockwaveFlash flBegin;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picMain;
        private AxShockwaveFlashObjects.AxShockwaveFlash flAnswer;
        private System.Windows.Forms.Timer tmPlay;
        private AxShockwaveFlashObjects.AxShockwaveFlash flFire;
        private System.Windows.Forms.Label lblCount;
    }
}

