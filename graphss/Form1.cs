using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.DataFormats;

namespace graphss
{

    public partial class Form1 : Form
    {
        List<pos> list;


        public int[,] matrix = new int[110, 110];
        public bool ck = false;
        public object currObject;

        private Point MouseDownLocation;

        int position = -1;

        public bool check = true;
        public int lenght_arr = 0;

        public int cnt_ver = 0, cnt_ver_remove = 0;
        public pos vertex_first;

        string theText;
        public int radius = 40;

        public Color color_ver = Color.Black;
        public Color color_edges = Color.Red;

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        private List<int> visited_ver;
        private Stack<int> stack_ver;

        public int[,] arrays
        {
            get
            {
                return matrix;
            }
            set
            {
                matrix = value;
            }
        }

        public Form1()
        {
            list = new List<pos>();
            visited_ver = new List<int>();
            stack_ver = new Stack<int>();
            
            InitializeComponent();
        }

        public void dfs(int ver_ind)
        {
            bool check = true;
            visited_ver.Add(ver_ind);
            
            for (int i = list.Count; i >= 1; i--){
                if (matrix[ver_ind, i] != 0 && in_not_list_of_visited(i - 1))
                {
                    stack_ver.Push(i - 1);
                    check = false;
                }
            }
            if (check)
                visited_ver.Add(-1);
            if (stack_ver.Count <= 0) return;

            int index = stack_ver.Peek();
            stack_ver.Pop();
            dfs(index);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AllocConsole();
            //output(matrix);
            dfs(0);

            for (int i = 0; i < visited_ver.Count; ++i) 
            {
                Console.Write(visited_ver[i] + 1 + " ");
            }
        }

        private bool in_not_list_of_visited(int ver_ind)
        {
            for (int i = 0; i < visited_ver.Count; ++i)
                if (ver_ind == visited_ver[i]) return false;
            return true;
        }

        private void draw_vertex2(object sender, MouseEventArgs e)
        {
            if (e.X < 250) return;
            pos obj;
            obj.point = e.Location;
            if (list.Count == 0) obj.cnt = 0;
            else obj.cnt = list[list.Count - 1].cnt + 1;


            if (e.Button == MouseButtons.Left)
            {
                if (!inList(obj.point.X, obj.point.Y))
                {
                    list.Add(obj);
                    draw_vertex(e.X, e.Y, list.Count);
                    matrix[obj.cnt, 0] = obj.cnt + 1;
                }
                else if (inList(obj.point.X, obj.point.Y) && isWeighted.Checked == true)
                {
                    //CustomDialog d = new CustomDialog(matrix, PointinList(obj).cnt, list.Count);
                    using (var frm = new CustomDialog(matrix, PointinList(obj).cnt, list.Count, isOrien.Checked))
                    {
                        frm.ShowDialog();
                    }
                    //d.ShowDialog();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                //AllocConsole();
                if (inList(obj.point.X, obj.point.Y) && checkBox1.Checked != true && checkBox2.Checked != true)
                {
                    if (cnt_ver == 0)
                    {
                        vertex_first = PointinList(obj);
                        cnt_ver++;
                    }
                    else if (!equal(PointinList(obj), vertex_first))
                    {
                        pos a;
                        a = PointinList(obj);
                        a.cnt = PointinList(obj).cnt;
                        matrix[vertex_first.cnt, a.cnt + 1] = 1;
                        if (!isOrien.Checked)
                            matrix[a.cnt, vertex_first.cnt + 1] = 1;
                        draw_edge(vertex_first, a, matrix[vertex_first.cnt, a.cnt + 1]);
                        //output();
                        cnt_ver = 0;
                    }


                    //Console.WriteLine(vertex_first.point.X + " " + vertex_first.point.Y);
                }
                else if (!inList(obj.point.X, obj.point.Y) && checkBox1.Checked != true && checkBox2.Checked != true)
                {
                    pos tmp = new pos();
                    vertex_first = tmp;
                    //Console.WriteLine(vertex_first.point.X + " " + vertex_first.point.Y);
                    cnt_ver = 0;
                }
                else if (inList(obj.point.X, obj.point.Y) && checkBox1.Checked == true && checkBox2.Checked != true)
                {
                    pos indexs = list[posInList(e.X, e.Y)];
                    trans_ver(indexs);
                    remove_edge(indexs);
                    list.RemoveAt(list.Count - 1);
                    Refresh();
                    draw_tree();
                }
                else if (inList(obj.point.X, obj.point.Y) && checkBox1.Checked != true && checkBox2.Checked == true)
                {
                    if (cnt_ver_remove == 0)
                    {
                        vertex_first = PointinList(obj);
                        cnt_ver_remove++;
                    }
                    else if (!equal(PointinList(obj), vertex_first))
                    {
                        pos a;
                        a = PointinList(obj);
                        a.cnt = PointinList(obj).cnt;
                        matrix[vertex_first.cnt, a.cnt + 1] = 0;
                        if (!isOrien.Checked)
                            matrix[a.cnt, vertex_first.cnt + 1] = 0;
                        Refresh();
                        draw_tree();
                        //output();
                        cnt_ver_remove = 0;
                    }
                }
                else
                {
                    pos tmp = new pos();
                    vertex_first = tmp;
                }
            }

        }

        public void WriteToFile(List<pos> list)
        {
            string tmpTextFilePath = @"C:\Users\Dana\Documents\inf\poi.txt";
            File.WriteAllText(tmpTextFilePath, "");

            using (StreamWriter tmpWriter = new StreamWriter(tmpTextFilePath))
            {
                string tmpTextToWrite = String.Empty;
                for (int i = 0; i < list.Count; i++)
                {
                    pos tmpEntry = list[i];
                    tmpTextToWrite += tmpEntry.point.X + ";" + tmpEntry.point.Y + ";" + tmpEntry.cnt + ";";
                }
                tmpWriter.WriteLine(tmpTextToWrite);
            }
        }

        public void WriteToFileMas(int[,] arr)
        {
            //output(matrix);

            string tmpTextFilePath = @"C:\Users\Dana\Documents\inf\saveArr.txt";
            File.WriteAllText(tmpTextFilePath, "");

            using (StreamWriter tmpWriter = new StreamWriter(tmpTextFilePath))
            {
                string tmpTextToWrite = String.Empty;
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j <= list.Count; j++)
                    {
                        if (j == list.Count) tmpTextToWrite += arr[i, j];
                        else tmpTextToWrite += arr[i, j] + ";";
                    }
                    tmpTextToWrite += ".";
                }
                tmpWriter.WriteLine(tmpTextToWrite);
            }
        }

        public void ReadFromFile()
        {
            //AllocConsole();
            List<pos> tmplist = new List<pos>();
            List<pos> tmplist2 = new List<pos>();
            tmplist2 = list;
            list = tmplist;

            string tmpTextFilePath = @"C:\Users\Dana\Documents\inf\poi.txt";
            using (StreamReader tmpReader = new StreamReader(tmpTextFilePath))
            {
                string tmpText = tmpReader.ReadLine();
                string tmpInput = String.Empty;
                pos tmp = new pos();
                int i = 0;
                foreach (char item in tmpText)
                {
                    if (item == ';')
                    {
                        if (i == 0)
                        {
                            tmp.point.X = Int32.Parse(tmpInput);
                            i++;
                            tmpInput = "";
                        }
                        else if (i == 1)
                        {
                            tmp.point.Y = Int32.Parse(tmpInput);
                            i++;
                            tmpInput = "";
                        }
                        else
                        {
                            i = 0;
                            tmp.cnt = Int32.Parse(tmpInput);
                            tmpInput = String.Empty;
                            list.Add(tmp);
                        }
                    }
                    else
                    {
                        tmpInput += item;
                    }
                }
            }

            Refresh();
            draw_tree();

        }

        private void output(int[,] arr)
        {
            AllocConsole();
            for (int i = 0; i < list.Count; ++i)
            {
                for (int j = 0; j <= list.Count; ++j)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void ReadFromFileArr()
        {

            int[,] tmparr = new int[110, 110];
            tmparr = matrix;

            /*AllocConsole();
            Console.WriteLine(list.Count);*/
            clear_matrix(matrix);


            string tmpTextFilePath = @"C:\Users\Dana\Documents\inf\saveArr.txt";
            using (StreamReader tmpReader = new StreamReader(tmpTextFilePath))
            {
                string tmpText = tmpReader.ReadLine();
                string tmpInput = String.Empty;

                int i = 0;
                int j = 0;

                foreach (char item in tmpText)
                {
                    if (item == ';')
                    {
                        matrix[i, j] = Int32.Parse(tmpInput);
                        j++;
                        tmpInput = "";
                    }
                    else if (item == '.')
                    {
                        matrix[i, j] = Int32.Parse(tmpInput);
                        i++;
                        j = 0;
                        tmpInput = "";
                    }
                    else
                    {
                        tmpInput += item;
                    }
                }
            }

            Refresh();
            draw_tree();
        }

        public void clear_matrix(int[,] matrix)
        {
            for (int i = 0; i <= list.Count; i++)
            {
                for (int j = 0; j <= list.Count; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }


        private void remove_edge(pos vertex) {
            for (int i = 1; i < list.Count + 1; i++)
            {
                matrix[vertex.cnt, i] = 0;
                matrix[i - 1, vertex.cnt + 1] = 0;
            }
            for (int i = vertex.cnt; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count + 1; ++j)
                    matrix[i, j] = matrix[i + 1, j];
            }
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = vertex.cnt + 1; j < list.Count; ++j)
                    matrix[i, j] = matrix[i, j + 1];
            }
            //output();
        }

        private void trans_ver(pos ver)
        {
            for (int i = ver.cnt; i < list.Count - 1; ++i)
            {
                list[i] = list[i + 1];
                pos tmp = list[i];
                tmp.cnt = i;
                list[i] = tmp;
            }
        }

        private bool equal(pos a, pos b)
        {
            if (a.point.X == b.point.X
                && a.point.Y == b.point.Y) return true;
            return false;
        }

        private bool inList(int x, int y)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if ((Math.Pow(list[i].point.X - x, 2) + Math.Pow(list[i].point.Y - y, 2) <= radius * radius) && i != position) return true;
            }
            return false;
        }

        private int posInList(int x, int y)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (Math.Pow(list[i].point.X - x, 2) + Math.Pow(list[i].point.Y - y, 2) <= radius * radius) return i;
            }
            return -1;
        }

        private void relpaceLoc(int x, int y)
        {
            Refresh();
            pos tmp = list[position];

            tmp.point.X = x;
            tmp.point.Y = y;
            list[position] = tmp;

            draw_tree();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && check)
            {
                if (!inList(e.X, e.Y))
                {
                    relpaceLoc(e.X, e.Y);
                    MouseDownLocation.X = list[posInList(e.X, e.Y)].point.X;
                    MouseDownLocation.Y = list[posInList(e.X, e.Y)].point.Y;
                } 
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && inList(e.X, e.Y))
            {
                MouseDownLocation.X = list[posInList(e.X, e.Y)].point.X;
                MouseDownLocation.Y = list[posInList(e.X, e.Y)].point.Y;

                position = posInList(e.X, e.Y);
                check = true;
            }
            else check = false;
        }

        private pos PointinList(pos p)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (Math.Pow(list[i].point.X - p.point.X, 2) + Math.Pow(list[i].point.Y - p.point.Y, 2) <= radius * radius)
                {
                    return list[i];
                }
            }
            pos v;
            v = new pos();
            return v;
        }

        private void draw_vertex(int x, int y, int index)
        {
            var fontFamily = new FontFamily("Times New Roman");
            var font = new Font(fontFamily, 32, FontStyle.Regular, GraphicsUnit.Pixel);

            Graphics myGraphics = base.CreateGraphics();
            Pen myPen = new Pen(color_ver);
            SolidBrush mySolidBrush = new SolidBrush(color_ver);
            myGraphics.FillEllipse(mySolidBrush, x, y, radius, radius);

            myGraphics.DrawString(index + "", font, mySolidBrush, new PointF(x - radius / 2, y - radius / 2));
        }

        private void draw_edge(pos point2, pos point1, int mass)
        {
            Graphics myGraphics = base.CreateGraphics();
            Pen myPen = new Pen(color_edges);
            SolidBrush mySolidBrush = new SolidBrush(color_edges);
            myPen.Width = 5;

            var fontFamily = new FontFamily("Times New Roman");
            var font = new Font(fontFamily, 32, FontStyle.Regular, GraphicsUnit.Pixel);

            if (!isOrien.Checked)
                myPen.CustomEndCap = new AdjustableArrowCap(5, 5);

            myPen.CustomStartCap = new AdjustableArrowCap(5, 5);
            myPen.Width = 2;

            point1.point.X += radius / 2;
            point1.point.Y += radius / 2;

            point2.point.X += radius / 2;
            point2.point.Y += radius / 2;

            myGraphics.DrawLine(myPen, point1.point, point2.point);
            if (isWeighted.Checked)
            {
                myGraphics.DrawString(mass + "", font, mySolidBrush, new PointF((point1.point.X + point2.point.X) / 2, (point1.point.Y + point2.point.Y) / 2));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(theText, out n))
            {
                radius = n;
                Refresh();
                draw_tree();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refresh();
            draw_tree();
        }

        private void isWeighted_Click(object sender, EventArgs e)
        {
            Refresh();
            draw_tree();
        }

        private void choose_color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            color_ver = cd.Color;
            Refresh();
            draw_tree();
        }

        private void color_edge_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            color_edges = cd.Color;
            Refresh();
            draw_tree();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WriteToFile(list);
            WriteToFileMas(matrix);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReadFromFileArr();
            ReadFromFile();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*if (File.ReadAllLines(@"C:\Users\Dana\Desktop\poi.txt").Length > 0)
            {
                ReadFromFile();
            }*/
        }

        private void isOrien_Click(object sender, EventArgs e)
        {
            clear_matrix(matrix);
            Refresh();
            draw_tree();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            position = -1;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            theText = objTextBox.Text;
        }

        private void draw_tree()
        {
            for (int i = 0; i < list.Count(); i++)
            {
                draw_vertex(list[i].point.X, list[i].point.Y, list[i].cnt + 1);
            }
            if (isOrien.Checked)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    for (int j = 0; j < list.Count(); j++)
                    {
                        if (matrix[i, j + 1] >= 1)
                            draw_edge(list[i], list[j], matrix[i, j + 1]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    for (int j = i + 1; j < list.Count(); j++)
                    {
                        if (matrix[i, j + 1] >= 1)
                            draw_edge(list[i], list[j], matrix[i, j + 1]);
                    }
                }
            }

            
        }
    }


    public struct pos
    {
        public Point point;
        public int cnt;

        public pos()
        {
            point.X = 0;
            point.Y = 0;
            cnt = 0;
        }
    }
}