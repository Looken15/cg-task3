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
        Color fill_color = Color.Red;
        Color line_color = Color.Black;
        Image fill_image;

        private void Form1_Load(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
            pen = new Pen(line_color, 1.0f);
            //fill_image = Image.FromFile("321.jpg");
        }

        void fill_line_alg(Point point)
        {
            var fill_bitmap = new Bitmap(fill_image);
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

                while (x1 > 0 && x2 < b.Width)
                {
                    if (b1 && b2)
                        break;
                    if (b.GetPixel(x1, p.Y) != back_color && !b1)
                    {
                        b1 = true;
                        x1++;
                    }
                    if (b.GetPixel(x2, p.Y) != back_color && !b2)
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
                for (int i = x1; i < x2 + 1; ++i)
                {
                    if (button_fill.Enabled)
                        b.SetPixel(i, y, fill_bitmap.GetPixel(i % fill_bitmap.Width, y % fill_bitmap.Height));
                    else
                        b.SetPixel(i, y, fill_color);
                    q.Enqueue(new Point(i, y - 1));
                    q.Enqueue(new Point(i, y + 1));
                }

                pictureBox1.Image = b;
                //Thread.Sleep(100);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            if (button_fill.Enabled && button_fill_pic.Enabled)
                return;

            fill_line_alg(e.Location);
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

            var b = new Bitmap(pictureBox1.Image);
            var gr = Graphics.FromImage(b);

            gr.DrawLine(pen, prev_pos, e.Location);
            //gr.DrawRectangle(pen, new Rectangle(e.Location, new Size(1,1)));

            pictureBox1.Image = b;
            prev_pos = e.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_fill.Enabled = true;
            button_fill_pic.Enabled = true;
            button_draw.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
    }
}
