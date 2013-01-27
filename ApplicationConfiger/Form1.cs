using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ApplicationConfiger
{
    public partial class Form1 : Form
    {
        string filePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fldBD.ShowDialog() == DialogResult.OK)
            {
                if(string.IsNullOrEmpty(fldBD.SelectedPath))
                    return;
                txtFile.Text = fldBD.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filePath = txtFile.Text + @"\bin\E.ROM.Bin";            
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(txtF1.Text);
                bw.Write(txtF2.Text);
                bw.Write(txtF3.Text);
                bw.Write(txtP1.Text);
                bw.Write(txtP2.Text);
                bw.Write(txtP3.Text);
                try
                {
                    bw.Write(int.Parse(txtT1.Text));
                    bw.Write(int.Parse(txtT2.Text));
                    bw.Write(int.Parse(txtT3.Text));
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("格式错误！"+Environment.NewLine+ex.Message);
                    return;
                }
                
                bw.Close();
                fs.Close();
            }
            readConfigData();
        }

        private void readConfigData()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);
                textBox1.Text = br.ReadString() + System.Environment.NewLine;
                textBox1.Text += br.ReadString() + System.Environment.NewLine;
                textBox1.Text += br.ReadString() + System.Environment.NewLine;
                textBox1.Text += br.ReadString() + System.Environment.NewLine;
                textBox1.Text += br.ReadString() + System.Environment.NewLine;
                textBox1.Text += br.ReadString() + System.Environment.NewLine;
                textBox1.Text += br.ReadInt32() + System.Environment.NewLine;
                textBox1.Text += br.ReadInt32() + System.Environment.NewLine;
                textBox1.Text += br.ReadInt32() + System.Environment.NewLine;                
                br.Close();
                fs.Close();
            }
        }
    }
}
