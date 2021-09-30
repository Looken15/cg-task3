using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace task3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Point pos1;
        Color line_color = Color.Black;
        Graphics g;
        static int thick;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            button1.Enabled = false;
            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
            g = Graphics.FromImage(pictureBox1.Image);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pos1 = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!button1.Enabled)
                Bresenham(pos1, e.Location);
            else
                Wu(pos1, e.Location);


            pictureBox1.Refresh();
        }

        void Bresenham(Point p1, Point p2)
        {
            int x1 = p1.X;
            int x2 = p2.X;

            int y1 = p1.Y;
            int y2 = p2.Y;

            var change = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);
                                                             
            if (change)
            {
                (x1, y1) = (y1, x1);
                (x2, y2) = (y2, x2);
            }
            
            if (x1 > x2)
            {
                (x1, x2) = (x2, x1);
                (y1, y2) = (y2, y1);
            }
            int dx = x2 - x1;
            int dy = Math.Abs(y2 - y1);
            int error = dx / 2;
            int ystep = (y1 < y2) ? 1 : -1;
            int y = y1;
            for (int x = x1; x <= x2; x++)
            {
                DrawPoint(g, line_color, change, x, y, 255);
                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }

        void Wu(Point p1, Point p2)
        {
            int x1 = p1.X;
            int x2 = p2.X;

            int y1 = p1.Y;
            int y2 = p2.Y;

            var change = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            if (change)
            {
                (x1, y1) = (y1, x1);
                (x2, y2) = (y2, x2);
            }
            if (x1 > x2)
            {
                (x1, x2) = (x2, x1);
                (y1, y2) = (y2, y1);
            }

            DrawPoint(g, line_color, change, x1, y1, 255); 
            DrawPoint(g, line_color, change, x2, y2, 255); 
            float dx = x2 - x1;
            float dy = y2 - y1;
            float gradient = dy / dx;
            float y = y1 + gradient;
            for (var x = x1 + 1; x <= x2 - 1; x++)
            {
                DrawPoint(g, line_color, change, x, (int)y, (int)(255 * (1 - (y - (int)y))));
                DrawPoint(g, line_color, change, x, (int)y + 1, (int)(255 * (y - (int)y)));
                y += gradient;
            }
        }

        private static void DrawPoint(Graphics g, Color col, bool change, int x, int y, int alpha)
        {

            if (change)
            {
                (x, y) = (y, x);
            }
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, thick, thick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out thick))
                thick = 1;
        }
    }
}
