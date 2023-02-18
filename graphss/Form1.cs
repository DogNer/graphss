using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace graphss
{

    public partial class Form1 : Form
    {
        List<pos> list, edges;

        Stack mStack = new Stack();
        Stack edge = new Stack();
        int[,] matrix = new int[110, 110];
        Graphics graphic;
        GraphicsPath path;
        public bool ck = false;

        private ArrayList myPts = new ArrayList();
        private Bitmap img = null;

        public Form1()
        {
            list = new List<pos>();
            edges = new List<pos>();
            InitializeComponent();
        }

        /*private void draw_vertex(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pos coord;
                coord.x = e.X;
                coord.y = e.Y;
                coord.cnt = mStack.Size() + 1;
                if (!mStack.inCircle(coord))
                {
                    var fontFamily = new FontFamily("Times New Roman");
                    var font = new Font(fontFamily, 32, FontStyle.Regular, GraphicsUnit.Pixel);
                    var solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));

                    Graphics myGraphics = base.CreateGraphics();
                    Pen myPen = new Pen(Color.Red);
                    SolidBrush mySolidBrush = new SolidBrush(Color.Red);
                    myGraphics.FillEllipse(mySolidBrush, e.X, e.Y, 50, 50);

                    myGraphics.DrawString(coord.cnt + 1 + "", font, solidBrush, new PointF(e.X + 11, e.Y + 5));

                    mStack.Push(coord);
                }
            }
            else
            {
                pos coord;
                coord.x = e.X;
                coord.y = e.Y;
                coord.cnt = 0;
                if (mStack.inCircle(coord))
                {
                    if (edge.Size() == 0)
                    {
                        edge.Push(coord);
                        Graphics myGraphics = base.CreateGraphics();
                        Pen myPen = new Pen(Color.Red);
                        SolidBrush mySolidBrush = new SolidBrush(Color.Red);
                        label3.Text += " Y ";
                        Point point1 = new Point(edge.get_i(0).x, edge.get_i(0).y);
                        Point point2 = new Point(edge.get_i(1).x, edge.get_i(1).y);
                        matrix[edge.get_i(0).cnt, edge.get_i(1).cnt] = 1;
                        myGraphics.DrawLine(myPen, point1, point2);
                        edge.clear();
                    }
                    else
                    {
                        edge.Push(coord);
                    }
                }
                else
                {
                    edge.clear();
                    label3.Text += " N ";
                }
            }

        }*/

        private void draw_vertex2(object sender, MouseEventArgs e)
        {
            pos obj;
            obj.point = e.Location;
            obj.cnt = 0;

            if (e.Button == MouseButtons.Left)
            {
                list.Add(obj);
                var fontFamily = new FontFamily("Times New Roman");
                var font = new Font(fontFamily, 32, FontStyle.Regular, GraphicsUnit.Pixel);
                var solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));

                Graphics myGraphics = base.CreateGraphics();
                Pen myPen = new Pen(Color.Red);
                SolidBrush mySolidBrush = new SolidBrush(Color.Red);
                myGraphics.FillEllipse(mySolidBrush, e.X, e.Y, 50, 50);

                //myGraphics.DrawString(obj.X + 1 + "", font, solidBrush, new PointF(e.X + 11, e.Y + 5));
            }
            else
            {
                if (inList(obj))
                {
                    if (edges.Count == 1)
                    {
                        edges.Add(obj);

                        Graphics myGraphics = base.CreateGraphics();
                        Pen myPen = new Pen(Color.Red);
                        SolidBrush mySolidBrush = new SolidBrush(Color.Red);

                        label3.Text += " Y ";
                        myGraphics.DrawLine(myPen, edges[0].point, edges[1].point);
                        edges.Clear();
                    }
                    else
                    {
                        edges.Add(obj);
                        label3.Text += " Y ";
                    }
                }
                else
                {
                    edges.Clear();
                    label3.Text += " N ";
                }
            }

        }

        private bool inList(pos p)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (Math.Pow(list[i].point.X - p.point.X, 2) + Math.Pow(list[i].point.Y - p.point.Y, 2) <= 2500) return true;
            }
            return false;
        }
    }

    public struct pos
    {
        public Point point;
        public int cnt;
    }

    /*internal class Stack
    {
        static readonly int MAX = 1000;
        int top;
        pos[] stack = new pos[110];

        public bool IsEmpty()
        {
            return (top < 0);
        }

        public Stack()
        {
            top = -1;
        }

        public int Size()
        {
            return top;
        }

        public bool Push(pos data)
        {
            if (top >= MAX)
            {
                Console.WriteLine("Stack Overflow");
                return false;
            }
            else
            {
                stack[++top] = data;
                return true;
            }
        }

        public pos Pop()
        {
            if (top < 0)
            {
                pos v;
                v.y = 0; v.x = 0; v.cnt = -1;
                Console.WriteLine("Stack Underflow");
                return v;
            }
            else
            {
                pos value = stack[top--];
                return value;
            }
        }

        public pos front()
        {
            if (top < 0)
            {
                pos v;
                v.y = 0; v.x = 0; v.cnt = -1;
                return v;
            }
            else
            {
                pos value = stack[top];
                return value;
            }
        }

        public pos get_i(int i)
        {
            return stack[i];
        }

        internal bool inCircle(pos coord)
        {
            if (top < 0)
            {
                return false;
            }
            else
            {
                for (int i = top; i >= 0; i--)
                {
                    if (Math.Pow(stack[i].x - coord.x, 2) + Math.Pow(stack[i].y - coord.y, 2) <= 2500) return true;
                }
                return false;
            }
        }

        internal pos pointInCircle(pos coord)
        {
            if (top < 0)
            {
                pos v;
                v.y = 0; v.x = 0; v.cnt = -1;
                return v;
            }
            else
            {
                for (int i = top; i >= 0; i--)
                {
                    if (Math.Pow(stack[i].x - coord.x, 2) + Math.Pow(stack[i].y - coord.y, 2) <= 2500) return stack[i];
                }
                pos v;
                v.y = 0; v.x = 0; v.cnt = -1;
                return v;
            }
        }

        public void clear()
        {
            top = -1;
        }
    }*/

    /*QGraphicsItem*/
}