namespace ApplicationConfiger
{
    partial class Form1
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
            this.txtF1 = new System.Windows.Forms.TextBox();
            this.txtF2 = new System.Windows.Forms.TextBox();
            this.txtF3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.txtP3 = new System.Windows.Forms.TextBox();
            this.txtT1 = new System.Windows.Forms.TextBox();
            this.txtT3 = new System.Windows.Forms.TextBox();
            this.txtT2 = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.fldBD = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtF1
            // 
            this.txtF1.Location = new System.Drawing.Point(32, 101);
            this.txtF1.Name = "txtF1";
            this.txtF1.Size = new System.Drawing.Size(245, 21);
            this.txtF1.TabIndex = 0;
            // 
            // txtF2
            // 
            this.txtF2.Location = new System.Drawing.Point(32, 147);
            this.txtF2.Name = "txtF2";
            this.txtF2.Size = new System.Drawing.Size(245, 21);
            this.txtF2.TabIndex = 1;
            // 
            // txtF3
            // 
            this.txtF3.Location = new System.Drawing.Point(32, 192);
            this.txtF3.Name = "txtF3";
            this.txtF3.Size = new System.Drawing.Size(245, 21);
            this.txtF3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "整句内容";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "识别内容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "未识别部分预留时间(ms)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtP1
            // 
            this.txtP1.Location = new System.Drawing.Point(310, 101);
            this.txtP1.Name = "txtP1";
            this.txtP1.Size = new System.Drawing.Size(128, 21);
            this.txtP1.TabIndex = 0;
            // 
            // txtP2
            // 
            this.txtP2.Location = new System.Drawing.Point(310, 147);
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(128, 21);
            this.txtP2.TabIndex = 0;
            // 
            // txtP3
            // 
            this.txtP3.Location = new System.Drawing.Point(310, 192);
            this.txtP3.Name = "txtP3";
            this.txtP3.Size = new System.Drawing.Size(128, 21);
            this.txtP3.TabIndex = 0;
            // 
            // txtT1
            // 
            this.txtT1.Location = new System.Drawing.Point(459, 101);
            this.txtT1.Name = "txtT1";
            this.txtT1.Size = new System.Drawing.Size(57, 21);
            this.txtT1.TabIndex = 0;
            // 
            // txtT3
            // 
            this.txtT3.Location = new System.Drawing.Point(459, 192);
            this.txtT3.Name = "txtT3";
            this.txtT3.Size = new System.Drawing.Size(57, 21);
            this.txtT3.TabIndex = 0;
            // 
            // txtT2
            // 
            this.txtT2.Location = new System.Drawing.Point(459, 147);
            this.txtT2.Name = "txtT2";
            this.txtT2.Size = new System.Drawing.Size(57, 21);
            this.txtT2.TabIndex = 0;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(125, 21);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(313, 21);
            this.txtFile.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "执行文件目录：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(444, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "浏览...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 300);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(484, 154);
            this.textBox1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 488);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtF3);
            this.Controls.Add(this.txtF2);
            this.Controls.Add(this.txtT3);
            this.Controls.Add(this.txtP3);
            this.Controls.Add(this.txtT1);
            this.Controls.Add(this.txtT2);
            this.Controls.Add(this.txtP2);
            this.Controls.Add(this.txtP1);
            this.Controls.Add(this.txtF1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtF1;
        private System.Windows.Forms.TextBox txtF2;
        private System.Windows.Forms.TextBox txtF3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.TextBox txtP3;
        private System.Windows.Forms.TextBox txtT1;
        private System.Windows.Forms.TextBox txtT3;
        private System.Windows.Forms.TextBox txtT2;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog fldBD;
        private System.Windows.Forms.TextBox textBox1;
    }
}

