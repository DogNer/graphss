using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace graphss
{
    public partial class CustomDialog : Form
    {
        int cnt = 0;
        int[,] vertex = new int[110, 110];
        int lenght = 0;
        bool isOriented = false;
        public TextBox[] textBox = new TextBox[110];

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public int count_ver = 1;


        public CustomDialog(int[,] matrix, int n, int len_mas, bool isOrie)
        {
            InitializeComponent();
            vertex = matrix;
            cnt = n;
            lenght= len_mas;
            isOriented = isOrie;
            
        }

        public CustomDialog() { }

        private void CustomDialog_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= lenght; i++)
            {
                if (vertex[cnt, i] >= 1)
                {
                    Label label1 = new Label();
                    label1.Location = new Point(10, 30 * count_ver);
                    label1.Text = i + "";
                    label1.Font = new Font("Arial", 18, FontStyle.Bold);
                    label1.Width = 45;
                    Controls.Add(label1);

                    TextBox tmpBox = new TextBox();
                    tmpBox.Location = new Point(60, 30 * count_ver + 5);
                    tmpBox.Text = "1";
                    tmpBox.Width = 100;
                    tmpBox.Height= 20;
                    tmpBox.Name = i + "";

                    textBox[count_ver] = tmpBox;
                    
                    count_ver++;
                }
            }

            for (int i = 1; i < count_ver; i++)
            {
                Controls.Add(textBox[i]);
            }

            this.Size = new Size(200, 30 * count_ver + 100);

            Button btn_close = new Button();
            btn_close.Name = "close";
            btn_close.Location = new Point(20, 30 * count_ver + 5);
            btn_close.Text = "Застосувати";
            Controls.Add(btn_close);
            btn_close.Click += new System.EventHandler(this.close_Clicked);

        }


        private void output()
        {
            AllocConsole();
            for (int i = 0; i < lenght; ++i)
            {
                for (int j = 0; j < lenght + 1; ++j)
                    Console.Write(vertex[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void close_Clicked(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.arrays = vertex;
            Label label2 = new Label();
            label2.Location = new Point(100, 100);
            label2.Font = new Font("Arial", 18, FontStyle.Bold);
            Controls.Add(label2);

            for (int i = 1; i < count_ver; ++i)
            {
                TextBox tmpBox = new TextBox();
                tmpBox = textBox[i];
                int n;

                if (int.TryParse(tmpBox.Text, out n))
                {
                    vertex[cnt, Int32.Parse(tmpBox.Name)] = n;
                    if (!isOriented)
                        vertex[Int32.Parse(tmpBox.Name) - 1, cnt + 1] = n;
                }
            }

            Hide();
        }
    }
}
