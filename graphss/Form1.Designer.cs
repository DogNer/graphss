namespace graphss
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteedgMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orientedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dfsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вершиниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ребраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 25;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 24;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 24;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.otherToolStripMenuItem,
            this.functionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.previousMenuItem,
            this.sizeToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.mainToolStripMenuItem.Text = "Основне";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vertexToolStripMenuItem,
            this.edgeToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.colorToolStripMenuItem.Text = "Колір";
            // 
            // vertexToolStripMenuItem
            // 
            this.vertexToolStripMenuItem.Name = "vertexToolStripMenuItem";
            this.vertexToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.vertexToolStripMenuItem.Text = "Вершина";
            this.vertexToolStripMenuItem.Click += new System.EventHandler(this.vertexToolStripMenuItem_Click_1);
            // 
            // edgeToolStripMenuItem
            // 
            this.edgeToolStripMenuItem.Name = "edgeToolStripMenuItem";
            this.edgeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.edgeToolStripMenuItem.Text = "Ребро";
            this.edgeToolStripMenuItem.Click += new System.EventHandler(this.edgeToolStripMenuItem_Click_1);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.saveToolStripMenuItem.Text = "Зберегти";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // previousMenuItem
            // 
            this.previousMenuItem.Enabled = false;
            this.previousMenuItem.Name = "previousMenuItem";
            this.previousMenuItem.Size = new System.Drawing.Size(139, 22);
            this.previousMenuItem.Text = "Попередній";
            this.previousMenuItem.Click += new System.EventHandler(this.previousToolStripMenuItem_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sizeToolStripMenuItem.Text = "Розмір";
            this.sizeToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.clearToolStripMenuItem.Text = "Очистити";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteverMenuItem,
            this.deleteedgMenuItem,
            this.orientedMenuItem,
            this.weightMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.otherToolStripMenuItem.Text = "Функції";
            // 
            // deleteverMenuItem
            // 
            this.deleteverMenuItem.Name = "deleteverMenuItem";
            this.deleteverMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deleteverMenuItem.Text = "Видалення вершини";
            this.deleteverMenuItem.Click += new System.EventHandler(this.deleteverToolStripMenuItem_Click);
            // 
            // deleteedgMenuItem
            // 
            this.deleteedgMenuItem.Name = "deleteedgMenuItem";
            this.deleteedgMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deleteedgMenuItem.Text = "Видалення ребра";
            this.deleteedgMenuItem.Click += new System.EventHandler(this.deleteedgeToolStripMenuItem_Click);
            // 
            // orientedMenuItem
            // 
            this.orientedMenuItem.Name = "orientedMenuItem";
            this.orientedMenuItem.Size = new System.Drawing.Size(187, 22);
            this.orientedMenuItem.Text = "Орієнтований";
            this.orientedMenuItem.Click += new System.EventHandler(this.orientedToolStripMenuItem_Click);
            // 
            // weightMenuItem
            // 
            this.weightMenuItem.Name = "weightMenuItem";
            this.weightMenuItem.Size = new System.Drawing.Size(187, 22);
            this.weightMenuItem.Text = "Зважений";
            this.weightMenuItem.Click += new System.EventHandler(this.weightToolStripMenuItem_Click);
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dfsMenuItem,
            this.eulerToolStripMenuItem});
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.functionToolStripMenuItem.Text = "Інще";
            // 
            // dfsMenuItem
            // 
            this.dfsMenuItem.Name = "dfsMenuItem";
            this.dfsMenuItem.Size = new System.Drawing.Size(171, 22);
            this.dfsMenuItem.Text = "Пошук у глибину";
            this.dfsMenuItem.Click += new System.EventHandler(this.dfsToolStripMenuItem_Click);
            // 
            // eulerToolStripMenuItem
            // 
            this.eulerToolStripMenuItem.Name = "eulerToolStripMenuItem";
            this.eulerToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.eulerToolStripMenuItem.Text = "euler";
            this.eulerToolStripMenuItem.Click += new System.EventHandler(this.eulerToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // вершиниToolStripMenuItem
            // 
            this.вершиниToolStripMenuItem.Name = "вершиниToolStripMenuItem";
            this.вершиниToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // ребраToolStripMenuItem
            // 
            this.ребраToolStripMenuItem.Name = "ребраToolStripMenuItem";
            this.ребраToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "label1";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.MaximumSize = new System.Drawing.Size(1080, 720);
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.draw_vertex2);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ColorDialog colorDialog1;
        private Button button3;
        private Button button4;
        private Button button5;
        private System.Windows.Forms.Timer timer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem вершиниToolStripMenuItem;
        private ToolStripMenuItem ребраToolStripMenuItem;
        private ToolStripMenuItem mainToolStripMenuItem;
        private ToolStripMenuItem colorToolStripMenuItem;
        private ToolStripMenuItem vertexToolStripMenuItem;
        private ToolStripMenuItem edgeToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem sizeToolStripMenuItem;
        private ToolStripMenuItem previousMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem otherToolStripMenuItem;
        private ToolStripMenuItem deleteverMenuItem;
        private ToolStripMenuItem deleteedgMenuItem;
        private ToolStripMenuItem orientedMenuItem;
        private ToolStripMenuItem weightMenuItem;
        private ToolStripMenuItem functionToolStripMenuItem;
        private ToolStripMenuItem dfsMenuItem;
        private FontDialog fontDialog1;
        private Label label1;
        private ToolStripMenuItem eulerToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
    }
}