using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Security;
using System.IO;
namespace ApplicationConfiger
{
    public partial class Security : Form
    {
        public Security()
        {
            InitializeComponent();
        }

        private void btnCrypto_Click(object sender, EventArgs e)
        {
            label2.Text = string.Empty;
            string result  = Training119Helper.HashHelper.Hash(txtSN.Text.Trim());

            fdSave.Filter = "Data File(*.dat)|*.dat";
            if (fbdResult.ShowDialog() == DialogResult.OK)
            {
                string filePath = fbdResult.SelectedPath + Path.DirectorySeparatorChar + "A_Rom.bin";

                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    BinaryWriter bw = new BinaryWriter(fs);                    
                    char[] results = result.ToCharArray();
                    byte[] bytes = Encoding.ASCII.GetBytes(result);
                    foreach (byte item in bytes)
                    {
                        bw.Write(item*10);                        
                    }
                    bw.Close();
                    label2.Text = "文件成功保存到：\n"+filePath;

                }
                /* for debug
                using (FileStream fs1 = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {

                    BinaryReader br = new BinaryReader(fs1);

                    byte[] rBytes = new byte[40];
                    for (int i = 0; i < rBytes.Length; i++)
                    {
                        rBytes[i] = (byte)(br.ReadInt32()/10);
                    }
                    label2.Text = Encoding.ASCII.GetString(rBytes);

                    br.Close();                    
                }
                 */

                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("把该程序生成的加密文件拷贝到Training119.exe下面的bin目录下");
        }

       
    }


}

