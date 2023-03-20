using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphss
{
    public partial class DfsStart : Form
    {
        string num_ver = "";
        int index = 0;
        int count_ver = 0;
        public static DfsStart instance;

        public DfsStart(int cnt_ver)
        {
            InitializeComponent();
            this.count_ver = cnt_ver;
            instance= this;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            num_ver = objTextBox.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(num_ver, out n))
            {
                index = n;
            }
            if (index > 0 && index <= count_ver)
            {
                index--;
                Form1.instance.index_ver_st = index;

                Hide();
            }
            
        }
    }
}
