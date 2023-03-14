using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphss
{
    public partial class DialogSize : Form
    {

        string textSize;
        int radius;

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public DialogSize()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            
            //AllocConsole();
            int n;
            if (int.TryParse(textSize, out n))
            {
                radius = n;
                if (radius >= 30 && radius <= 80)
                {
                    WriteToFile(radius);

                    this.Close();
                }
                else
                {
                    string message = "Введіть інше значення";
                    string title = "Помилка";
                    MessageBox.Show(message, title);
                }
            }
            else
            {
                string message = "Невірне значення";
                string title = "Помилка";
                MessageBox.Show(message, title);
            }
            
        }

        public void WriteToFile(int x)
        {
            //output(matrix);

            string tmpTextFilePath = @"C:\Users\Dana\Documents\inf\size_ver.txt";
            File.WriteAllText(tmpTextFilePath, "");

            using (StreamWriter tmpWriter = new StreamWriter(tmpTextFilePath))
            {
                string tmpTextToWrite = String.Empty;
                tmpWriter.WriteLine(x);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            textSize = objTextBox.Text;
        }
    }
}
