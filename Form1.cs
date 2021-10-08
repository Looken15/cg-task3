using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool IsMouseDown = false;
        Pen pen;
        Point prev_pos;
        Color init_color = Color.FromArgb(255, 255, 255);
        Color fill_color = Color.FromArgb(255, 0, 0);
        Color line_color = Color.FromArgb(0, 0, 0);
        Color border_color = Color.FromArgb(0, 255, 0);
        Image fill_image;
        Random rand = new Random();
        Graphics gr;

        private void Form1_Load(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //var bitmap = new Bitmap(Image.FromFile("temp.png"));
            gr = Graphics.FromImage(bitmap);
            gr.Clear(init_color);
            fill_image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
            pen = new Pen(line_color, 1.0f);
            DrawBox();
        }

        private void DrawBox()
        {
            var b = new Bitmap(pictureBox1.Image);

            for (int i = 100; i < 500; ++i)
            {
                b.SetPixel(i, 100, Color.Black);
                b.SetPixel(i, 500, Color.Black);
            }
            for (int j = 100; j < 500; ++j)
            {
                b.SetPixel(100, j, Color.Black);
                b.SetPixel(500, j, Color.Black);
            }


            b.SetPixel(100, 99,line_color);
            b.SetPixel(101, 99, line_color);
            b.SetPixel(101, 98, line_color);
            pictureBox1.Image = b;
        }

        void fill_line_alg(Point point)
        {
            var fill_bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var gr_back = Graphics.FromImage(fill_bitmap);
            var b = new Bitmap(pictureBox1.Image);
            var q = new Queue<Point>();
            var back_color = b.GetPixel(point.X, point.Y);
            q.Enqueue(point);

            while (q.Count > 0)
            {
                var p = q.Dequeue();
                var curr_color = b.GetPixel(p.X, p.Y);
                if (back_color == fill_color)
                    continue;
                if (back_color != curr_color)
                    continue;

                int x1 = p.X - 1, x2 = p.X + 1;
                bool b1 = false, b2 = false;

                while (true)
                {
                    if (b1 && b2)
                        break;
                    if ((x1 == 0 || b.GetPixel(x1, p.Y) != back_color) && !b1)
                    {
                        b1 = true;
                        x1++;
                    }
                    if ((x2 == b.Width || b.GetPixel(x2, p.Y) != back_color) && !b2)
                    {
                        b2 = true;
                        x2--;
                    }
                    if (!b1)
                        x1--;
                    if (!b2)
                        x2++;
                }
                int y = p.Y;
                if (button_fill.Enabled)
                    gr_back.DrawImage(fill_image, point);
                for (int i = x1; i < x2 + 1; ++i)
                {
                    if (button_fill.Enabled)
                    {
                        b.SetPixel(i, y, fill_bitmap.GetPixel(i % fill_bitmap.Width, y % fill_bitmap.Height));
                    }
                    else
                        b.SetPixel(i, y, fill_color);
                    if (y > 0)
                        q.Enqueue(new Point(i, y - 1));
                    if (y < b.Height - 1)
                        q.Enqueue(new Point(i, y + 1));
                }


            }
            gr_back.Clear(Color.White);
            pictureBox1.Image = b;
            gr = Graphics.FromImage(pictureBox1.Image);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            if (!button_fill.Enabled || !button_fill_pic.Enabled)
                fill_line_alg(e.Location);
            if (!button_take_border.Enabled)
                track_border_new(e.Location);
            //track_border_alg(e.X, e.Y);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            IsMouseDown = false;
            prev_pos = new Point(0, 0);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
            prev_pos = new Point(0, 0);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseDown || button_draw.Enabled)
                return;

            if (prev_pos == new Point(0, 0))
            {
                prev_pos = e.Location;
            }

            //var b = new Bitmap(pictureBox1.Image);
            //var gr = Graphics.FromImage(b);

            gr.DrawLine(pen, prev_pos, e.Location);
            //gr.DrawRectangle(pen, new Rectangle(e.Location, new Size(1,1)));

            //pictureBox1.Image = b;
            pictureBox1.Refresh();
            prev_pos = e.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_take_border.Enabled = true;
            button_fill.Enabled = true;
            button_fill_pic.Enabled = true;
            button_draw.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button_take_border.Enabled = true;
            button_draw.Enabled = true;
            button_fill_pic.Enabled = true;
            button_fill.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fill_color = colorDialog1.Color;
            }
        }

        private void button_fill_pic_Click(object sender, EventArgs e)
        {
            button_take_border.Enabled = true;
            button_draw.Enabled = true;
            button_fill.Enabled = true;
            button_fill_pic.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                fill_image = Image.FromFile(file);
            }
        }

        private void button_take_border_Click(object sender, EventArgs e)
        {
            button_take_border.Enabled = false;
            button_draw.Enabled = true;
            button_fill.Enabled = true;
            button_fill_pic.Enabled = true;


        }

        public class PointCmp : IComparer<Point>
        {
            public int Compare(Point a, Point b)
            {
                if (a.Y == b.Y)
                {
                    if (a.X < b.X)
                        return -1;
                    else if (a.X > b.X)
                        return 1;
                    return 0;
                }
                if (a.Y < b.Y)
                    return -1;
                return 1;
            }
        }

        private void track_border_alg(int a, int b)
        {
            var bmp = new Bitmap(pictureBox1.Image);
            var clr = bmp.GetPixel(a, b);
            var start_x = a; var start_y = b;
            if (clr != line_color)
                return;

            int k = 0;
            var lst = new SortedSet<Point>(new PointCmp());
            var x = start_x; var y = start_y;
            while (true)
            {
                if (x == start_x && y == start_y)
                    k++;
                if (k == 2)
                    break;
                lst.Add(new Point(x, y));
                pictureBox1.Image = bmp;
                pictureBox1.Refresh();
                bmp.SetPixel(x, y, border_color);

                if (bmp.GetPixel(x - 1, y) != init_color /*&& bmp.GetPixel(x - 1, y) != clr*/)
                {
                    if (bmp.GetPixel(x, y - 1) == clr && !lst.Contains(new Point(x, y - 1)))
                    {
                        y--;
                        continue;
                    }
                    if (bmp.GetPixel(x - 1, y - 1) == clr && !lst.Contains(new Point(x - 1, y - 1)))
                    {
                        y--; x--;
                        continue;
                    }
                    if (bmp.GetPixel(x - 1, y) == clr && !lst.Contains(new Point(x - 1, y)))
                    {
                        x--;
                        continue;
                    }
                    if (bmp.GetPixel(x - 1, y + 1) == clr && !lst.Contains(new Point(x - 1, y + 1)))
                    {
                        x--; y++;
                        continue;
                    }
                    if (bmp.GetPixel(x, y + 1) == clr && !lst.Contains(new Point(x, y + 1)))
                    {
                        y++;
                        continue;
                    }
                    if (bmp.GetPixel(x + 1, y + 1) == clr && !lst.Contains(new Point(x + 1, y + 1)))
                    {
                        y++; x++;
                        continue;
                    }
                    if (bmp.GetPixel(x + 1, y) == clr && !lst.Contains(new Point(x + 1, y)))
                    {
                        x++;
                        continue;
                    }
                    if (bmp.GetPixel(x + 1, y - 1) == clr && !lst.Contains(new Point(x + 1, y - 1)))
                    {
                        y--; x++;
                        continue;
                    }
                }
                if (bmp.GetPixel(x + 1, y) != init_color /*&& bmp.GetPixel(x + 1, y) != clr*/)
                {
                    if (bmp.GetPixel(x, y + 1) == clr && !lst.Contains(new Point(x, y + 1)))
                    {
                        y++;
                        continue;
                    }
                    if (bmp.GetPixel(x + 1, y + 1) == clr && !lst.Contains(new Point(x + 1, y + 1)))
                    {
                        y++; x++;
                        continue;
                    }
                    if (bmp.GetPixel(x + 1, y) == clr && !lst.Contains(new Point(x + 1, y)))
                    {
                        x++;
                        continue;
                    }
                    if (bmp.GetPixel(x + 1, y - 1) == clr && !lst.Contains(new Point(x + 1, y - 1)))
                    {
                        x++; y--;
                        continue;
                    }
                    if (bmp.GetPixel(x, y - 1) == clr && !lst.Contains(new Point(x, y - 1)))
                    {
                        y--;
                        continue;
                    }
                    if (bmp.GetPixel(x - 1, y - 1) == clr && !lst.Contains(new Point(x - 1, y - 1)))
                    {
                        y--; x--;
                        continue;
                    }
                    if (bmp.GetPixel(x - 1, y) == clr && !lst.Contains(new Point(x - 1, y)))
                    {
                        x--;
                        continue;
                    }
                    if (bmp.GetPixel(x - 1, y + 1) == clr && !lst.Contains(new Point(x - 1, y)))
                    {
                        y++; x--;
                        continue;
                    }
                }
                if (bmp.GetPixel(x, y - 1) != init_color /*&& bmp.GetPixel(x , y-1) != clr*/)
                {
                    if (bmp.GetPixel(x + 1, y) == clr && !lst.Contains(new Point(x + 1, y)))
                    {
                        x++;
                        continue;
                    }
                    if (bmp.GetPixel(x + 1, y - 1) == clr && !lst.Contains(new Point(x + 1, y - 1)))
                    {
                        y--; x++;
                        continue;
                    }
                    if (bmp.GetPixel(x, y - 1) == clr && !lst.Contains(new Point(x, y - 1)))
                    {
                        y--;
                        continue;
                    }
                    if (bmp.GetPixel(x - 1, y - 1) == clr && !lst.Contains(new Point(x - 1, y - 1)))
                    {
                        x--; y--;
                        continue;
                    }
                    if (bmp.GetPixel(x - 1, y) == clr && !lst.Contains(new Point(x - 1, y)))
                    {
                        x--;
                        continue;
                    }
                    if (bmp.GetPixel(x - 1, y + 1) == clr && !lst.Contains(new Point(x - 1, y + 1)))
                    {
                        y++; x--;
                        continue;
                    }
                    if (bmp.GetPixel(x, y + 1) == clr && !lst.Contains(new Point(x, y + 1)))
                    {
                        y++;
                        continue;
                    }
                    if (bmp.GetPixel(x + 1, y + 1) == clr && !lst.Contains(new Point(x + 1, y + 1)))
                    {
                        y++; x++;
                        continue;
                    }
                }
                if (bmp.GetPixel(x, y + 1) != init_color /*&& bmp.GetPixel(x , y+1) != clr*/)
                {
                    if (bmp.GetPixel(x - 1, y) == clr && !lst.Contains(new Point(x - 1, y)))
                    {
                        x--;
                        continue;
                    }
                    if (bmp.GetPixel(x - 1, y + 1) == clr && !lst.Contains(new Point(x - 1, y + 1)))
                    {
                        y++; x--;
                        continue;
                    }
                    if (bmp.GetPixel(x, y + 1) == clr && !lst.Contains(new Point(x, y + 1)))
                    {
                        y++;
                        continue;
                    }
                    if (bmp.GetPixel(x + 1, y + 1) == clr && !lst.Contains(new Point(x + 1, y + 1)))
                    {
                        x++; y++;
                        continue;
                    }
                    if (bmp.GetPixel(x + 1, y) == clr && !lst.Contains(new Point(x + 1, y)))
                    {
                        x++;
                        continue;
                    }
                    if (bmp.GetPixel(x + 1, y - 1) == clr && !lst.Contains(new Point(x + 1, y - 1)))
                    {
                        y--; x++;
                        continue;
                    }
                    if (bmp.GetPixel(x, y - 1) == clr && !lst.Contains(new Point(x, y - 1)))
                    {
                        y--;
                        continue;
                    }
                    if (bmp.GetPixel(x - 1, y - 1) == clr && !lst.Contains(new Point(x - 1, y - 1)))
                    {
                        y--; x--;
                        continue;
                    }
                }

                bmp.SetPixel(x, y, Color.Green);
                pictureBox1.Image = bmp;
                pictureBox1.Refresh();
                break;
            }



            foreach (var p in lst)
                bmp.SetPixel(p.X, p.Y, border_color);

            pictureBox1.Image = bmp;
            gr = Graphics.FromImage(pictureBox1.Image);
        }

        class PointNode
        {
            public PointNode next;
            public Point p;

            public PointNode(int x, int y, PointNode next)
            {
                p = new Point(x, y);
                this.next = next;
            }

            public PointNode(PointNode nd)
            {
                p = new Point(nd.p.X, nd.p.Y);
                next = nd.next;
            }
        }

        private (PointNode, PointNode, PointNode, PointNode) InitNodeCycle()
        {
            var p = new PointNode(0,1,null);
            var res = new List<PointNode>(); res.Add(p);
            var p1 = p;
            var p2 = new PointNode(1,1,null);
            p1.next = p2;
            p1 = p2;

            p2 = new PointNode(1, 0, null);
            p1.next = p2;
            p1 = p2;
            res.Add(p1);

            p2 = new PointNode(1, -1, null);
            p1.next = p2;
            p1 = p2;

            p2 = new PointNode(0, -1, null);
            p1.next = p2;
            p1 = p2;
            res.Add(p1);

            p2 = new PointNode(-1, -1, null);
            p1.next = p2;
            p1 = p2;

            p2 = new PointNode(-1, 0, null);
            p1.next = p2;
            p1 = p2;
            res.Add(p1);

            p2 = new PointNode(-1, 1, p);
            p1.next = p2;

            return (res[0], res[1], res[2], res[3]);
        }

        private Point FindNextPoint(Point cur, Point prev, PointNode cycle_start, Bitmap bmp, Color fill_clr)
        {
            var cycle = new PointNode(cycle_start);
            for (int i = 0; i< 8; i++)
            {
                var x = cur.X + cycle.p.X;
                var y = cur.Y + cycle.p.Y;
                if (bmp.GetPixel(x, y) == line_color && new Point(x, y) != prev)
                    if (prev.X != -1 || y < cur.Y)
                        if (is_border_pixel(fill_clr,bmp,x,y))
                            return new Point(x, y);
                cycle = cycle.next;
            }

            //throw new Exception("Не найден пиксель границы!");
            return new Point(-1, -1);
        }

        private bool is_border_pixel(Color fill_clr, Bitmap bmp, int x, int y)
        {
            if (bmp.GetPixel(x - 1, y) == fill_clr && bmp.GetPixel(x + 1, y) != fill_clr)
                return true;
            if (bmp.GetPixel(x - 1, y) != fill_clr && bmp.GetPixel(x + 1, y) == fill_clr)
                return true;
            if (bmp.GetPixel(x, y-1) != fill_clr && bmp.GetPixel(x, y+1) == fill_clr)
                return true;
            if (bmp.GetPixel(x, y + 1) != fill_clr && bmp.GetPixel(x, y - 1) == fill_clr)
                return true;
            return false;
        }

        private void track_border_new(Point click)
        {
            //var bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            var fill_clr = bmp.GetPixel(click.X, click.Y);
            (var fill_right, var fill_up, var fill_left, var fill_down) = InitNodeCycle();
            var lst = new List<Point>();

            var x = click.X; var y = click.Y;
            while (true)
            {
                if (x == 0)
                    return;
                if (bmp.GetPixel(x, y) == line_color && bmp.GetPixel(x-1, y) != line_color && bmp.GetPixel(x + 1, y) == fill_clr)
                    break;
                x--;
            }
            if (bmp.GetPixel(x, y) != line_color)
                return;

            var start = new Point(x, y); int count = 0;
            var cur = new Point(x, y); var prev = new Point(-1, -1);
            while (true)
            {
                if (cur == start && prev.X != -1)
                {
                    bmp.SetPixel(cur.X, cur.Y, border_color);
                    pictureBox1.Refresh();
                    break;
                }

                if (cur.Y == 101)
                    count++;
                if (cur.X == 499)
                    count++;
                if (cur != start)
                    bmp.SetPixel(cur.X, cur.Y, border_color);
                pictureBox1.Refresh();

                Point next; PointNode pn;
                if (bmp.GetPixel(cur.X + 1, cur.Y) == fill_clr)
                    pn = fill_right.next;
                else if (bmp.GetPixel(cur.X, cur.Y - 1) == fill_clr)
                    pn = fill_up.next;
                else if (bmp.GetPixel(cur.X - 1, cur.Y) == fill_clr)
                    pn = fill_left.next;
                else if (bmp.GetPixel(cur.X, cur.Y + 1) == fill_clr)
                    pn = fill_down.next;
                else
                    throw new Exception("Не найдена сторона заливки!");

                //for (int i = 0; i < count; i++)
                //    pn = pn.next;

                next = FindNextPoint(cur, prev, pn, bmp, fill_clr);
                if (next.X == -1)
                    break;
                /*
                if (next.X == -1 )
                {
                    if (count == 7)
                        throw new Exception("алгоритм зашёл не туда!");
                    if (count == 0)
                    {
                        bmp.SetPixel(cur.X, cur.Y, line_color);
                        lst.RemoveAt(lst.Count - 1);
                        cur = prev;
                        prev = lst[lst.Count - 1];
                    }
                    count++;
                    continue;
                }

                count = 0;*/
                lst.Add(cur);
                (cur, prev) = (next, cur);
            }

            //foreach (var p in lst)
            //    bmp.SetPixel(p.X, p.Y, border_color);
            //pictureBox1.Refresh();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            gr.Clear(init_color);
            pictureBox1.Refresh();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("f1.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
