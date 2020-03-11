using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to clear these folders?", "Attention!", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes)
            {
                try
                {
                    List<string> listfordelete = new List<string>();
                    foreach (string i in richTextBox1.Lines)
                    {
                        listfordelete.Add(i);
                    }

                    for (int i = 0; i < listfordelete.Count; i++)
                    {
                        bool checker = Directory.Exists(listfordelete[i]);
                        if (checker == true)
                        {
                            DirectoryInfo dirInfo = new DirectoryInfo(listfordelete[i]);

                            foreach (FileInfo files in dirInfo.GetFiles())
                            {
                                files.Delete();
                            }

                            foreach (DirectoryInfo folders in dirInfo.GetDirectories())
                            {
                                folders.Delete();
                            }
                        }
                        else
                        {

                        }
                    }
                    MessageBox.Show("Done");
                }
                catch
                {

                }


            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.AppendText("C:\\OneDriveTemp\nC:\\Windows\\Temp\nC:\\Windows\\Downloaded Program Files");
        }
    }
}
