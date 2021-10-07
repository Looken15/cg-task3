using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3
{
    public partial class Form3 : Form
    {
        Graphics gr;
        Color cl1 = Color.Red;
        Color cl2 = Color.Green;
        Color cl3 = Color.Blue;
        Random r = new Random();

        Point pp1; Point pp2; Point pp3;
        int count_click = 0;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(pictureBox1.Image);
            Text = "bipka";

            button_cl1.BackColor = cl1;
            button_cl2.BackColor = cl2;
            button_cl3.BackColor = cl3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            var x1 = r.Next(0, pictureBox1.Width);
            var y1 = r.Next(0, pictureBox1.Height);

            var x2 = r.Next(0, pictureBox1.Width);
            var x3 = r.Next(0, pictureBox1.Width);

            var y2 = r.Next(0, pictureBox1.Height);
            var y3 = r.Next(0, pictureBox1.Height);

            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);
            var p3 = new Point(x3, y3);


            (var p4, var cl4) = split_triangle(ref p1, ref p2, ref p3);

            gr.DrawRectangle(new Pen(Color.Red), new Rectangle(p1.X, p1.Y, 5, 5));
            gr.DrawRectangle(new Pen(Color.Green), new Rectangle(p2.X, p2.Y, 5, 5));
            gr.DrawRectangle(new Pen(Color.Blue), new Rectangle(p3.X, p3.Y, 5, 5));


            gr.DrawRectangle(new Pen(Color.Yellow), new Rectangle(p4.X, p4.Y, 5, 5));

            pictureBox1.Refresh();


            rast_triang(p1, p4, p2, cl1, cl2, cl4);

            rast_triang(p3, p2,p4, cl3, cl4, cl2);
        }

        private (Point, Color) split_triangle(ref Point p1, ref Point p2, ref Point p3)
        {
            if (p1.Y == p2.Y)
            {
                (p1, p3) = (p3, p1);
                (cl1, cl3) = (cl3, cl1);
                if (p2.X > p3.X)
                {
                    (p2, p3) = (p3, p2);
                    (cl2, cl3) = (cl3, cl2);
                }

                return (new Point(0, 0), Color.Red);
            }
            if (p2.Y == p3.Y)
            {
                if (p2.X > p3.X)
                {
                    (p2, p3) = (p3, p2);
                    (cl2, cl3) = (cl3, cl2);
                }

                return (new Point(0, 0), Color.Red);
            }

            var max_y = Math.Max(p1.Y, Math.Max(p2.Y, p3.Y));
            var min_y = Math.Min(p1.Y, Math.Min(p2.Y, p3.Y));
            if (p2.Y == min_y)
                if (p1.Y == max_y)
                {
                    (p2, p3) = (p3, p2);
                    (cl2, cl3) = (cl3, cl2);
                }
                else
                {
                    (p2, p1) = (p1, p2);
                    (cl2, cl1) = (cl1, cl2);
                }
            if (p2.Y == max_y)
                if (p1.Y == min_y)
                {
                    (p2, p3) = (p3, p2);
                    (cl2, cl3) = (cl3, cl2);
                }
                else
                {
                    (p2, p1) = (p1, p2);
                    (cl2, cl1) = (cl1, cl2);
                }
            if (p1.Y > p3.Y)
            {
                (p1, p3) = (p3, p1);
                (cl1, cl3) = (cl3, cl1);
            }

            double tang = (p3.Y - p1.Y) * 1.0 / (p3.X - p1.X);
            double a1 = p2.Y - p1.Y;
            double b1 = a1 / tang;
            int new_x = p1.X + (int)b1;

            var p = new Point(new_x, p2.Y);

            double delta_R = (cl1.R - cl3.R) * 1.0 / (p3.Y - p1.Y);
            double delta_G = (cl1.G - cl3.G) * 1.0 / (p3.Y - p1.Y);
            double delta_B = (cl1.B - cl3.B) * 1.0 / (p3.Y - p1.Y);

            var cl = ColorFromDelta(cl3, delta_R, delta_G, delta_B, p3.Y - p2.Y);

            if (p1.Y > p2.Y || p1.Y > p3.Y || p2.Y > p3.Y)
                throw new Exception("перепутал");

            return (p, cl);
        }

        private Color ColorFromDelta(Color cl1, double dR, double dG, double dB, int steps)
        {
            int R = cl1.R + (int)(dR * steps);
            R = R > 255 ? 255 : R; R = R < 0 ? 0 : R;
            int G = cl1.G + (int)(dG * steps);
            G = G > 255 ? 255 : G; G = G < 0 ? 0 : G;
            int B = cl1.B + (int)(dB * steps);
            B = B > 255 ? 255 : B; B = B < 0 ? 0 : B;
            return Color.FromArgb(R, G, B);
        }

        private bool rast_triang(Point p1, Point p2, Point p3, Color c1, Color c2, Color c3)
        {
            var b = new Bitmap(pictureBox1.Image);
            if (p2.Y != p3.Y && p1.Y != p2.Y && p3.Y != p1.Y)
                return false;

            if (p2.Y == p1.Y)
            {
                (p1, p3) = (p3, p1);
                (c1, c3) = (c3, c1);
            }
            else if (p3.Y == p1.Y)
            {
                (p1, p2) = (p2, p1);
                (c1, c2) = (c2, c1);
            }
            if (p3.X < p2.X)
            {
                (p3, p2) = (p2, p3);
                (c3, c2) = (c2, c3);
            }


            //int width = (p3.X - p2.X);
            int heigth = Math.Abs(p2.Y - p1.Y);


            double left_delta_R = (c1.R - c2.R) * 1.0 / heigth;
            double left_delta_G = (c1.G - c2.G) * 1.0 / heigth;
            double left_delta_B = (c1.B - c2.B) * 1.0 / heigth;
            double right_delta_R = (c1.R - c3.R) * 1.0 / heigth;
            double right_delta_G = (c1.G - c3.G) * 1.0 / heigth;
            double right_delta_B = (c1.B - c3.B) * 1.0 / heigth;

            double tang_left = heigth * 1.0 / Math.Abs(p1.X - p2.X);
            double tang_right = heigth * 1.0 / Math.Abs(p3.X - p1.X);

            //double tang_left = heigth * 1.0 / p1.X - p2.X;
            //double tang_right = heigth * 1.0 / p3.X - p1.X;

            int xh = p1.X;
            var min_y = p2.Y < p1.Y ? p2.Y : p1.Y;
            var max_y = p1.Y > p2.Y ? p1.Y : p2.Y;
            if (p1.Y < p2.Y)
                for (int y = max_y; y >= min_y; y--)
                {
                    int a1 = (int)((y - min_y) * 1.0 / tang_left);
                    int a2 = (int)((y - min_y) * 1.0 / tang_right);
                    int w = a1 + a2;
                    if (p1.X < p2.X || p1.X > p3.X)
                        w = Math.Abs(a2 - a1);
                    int h = max_y - y;
                    var left_color = ColorFromDelta(c2, left_delta_R, left_delta_G, left_delta_B, h);
                    var right_color = ColorFromDelta(c3, right_delta_R, right_delta_G, right_delta_B, h);
                    double delta_R = (left_color.R - right_color.R) * 1.0 / w;
                    double delta_G = (left_color.G - right_color.G) * 1.0 / w;
                    double delta_B = (left_color.B - right_color.B) * 1.0 / w;
                    int left = xh - a1; int right = xh + a2;
                    if (p1.X < p2.X)
                        (left, right) = (xh + a1, xh + a2);
                    if (p1.X > p3.X)
                        (left, right) = (xh - a1, xh - a2);
                    for (int x = left; x <= right; x++)
                        b.SetPixel(x, y, ColorFromDelta(right_color, delta_R, delta_G, delta_B, (x - left)));
                }
            else for (int y = min_y; y <= max_y; ++y)
                {
                    int a1 = (int)((max_y - y) * 1.0 / tang_left);
                    int a2 = (int)((max_y - y) * 1.0 / tang_right);
                    int w = a1 + a2;
                    if (p1.X < p2.X || p1.X > p3.X)
                        w = Math.Abs(a2 - a1);
                    int h = y - min_y;
                    var left_color = ColorFromDelta(c2, left_delta_R, left_delta_G, left_delta_B, h);
                    var right_color = ColorFromDelta(c3, right_delta_R, right_delta_G, right_delta_B, h);
                    double delta_R = (left_color.R - right_color.R) * 1.0 / w;
                    double delta_G = (left_color.G - right_color.G) * 1.0 / w;
                    double delta_B = (left_color.B - right_color.B) * 1.0 / w;
                    int left = xh - a1; int right = xh + a2;
                    if (p1.X < p2.X)
                        (left, right) = (xh + a1, xh + a2);
                    if (p1.X > p3.X)
                        (left, right) = (xh - a1, xh - a2);
                    for (int x = left; x <= right; x++)
                        b.SetPixel(x, y, ColorFromDelta(right_color, delta_R, delta_G, delta_B, (x - left)));
                }
            pictureBox1.Image = b;
            gr = Graphics.FromImage(b);
            pictureBox1.Refresh();

            return true;
        }

        private void button_cl1_Click(object sender, EventArgs e)
        {
            var DR = colorDialog1.ShowDialog();
            if (DR == DialogResult.OK)
                cl1 = colorDialog1.Color;
            button_cl1.BackColor = cl1;
        }

        private void button_cl2_Click(object sender, EventArgs e)
        {
            var DR = colorDialog1.ShowDialog();
            if (DR == DialogResult.OK)
                cl2 = colorDialog1.Color;
            button_cl2.BackColor = cl2;
        }

        private void button_cl3_Click(object sender, EventArgs e)
        {
            var DR = colorDialog1.ShowDialog();
            if (DR == DialogResult.OK)
                cl3 = colorDialog1.Color;
            button_cl3.BackColor = cl3;
        }

        private void button_get_triang_Click(object sender, EventArgs e)
        {
            button_get_triang.Enabled = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (button_get_triang.Enabled)
                return;
            if (count_click == 0)
            {
                gr.Clear(Color.White);
                count_click++;
                pp1 = e.Location;
                gr.DrawRectangle(new Pen(cl1), new Rectangle(pp1.X, pp1.Y, 10, 10));
                pictureBox1.Refresh();
            }
            else if (count_click == 1)
            {
                count_click++;
                pp2 = e.Location;
                gr.DrawRectangle(new Pen(cl2), new Rectangle(pp2.X, pp2.Y, 10, 10));
                pictureBox1.Refresh();
            }
            else if (count_click == 2)
            {
                count_click = 0;
                pp3 = e.Location;
                (var pp4, var cl4) = split_triangle(ref pp1, ref pp2, ref pp3);

                gr.DrawRectangle(new Pen(cl3), new Rectangle(pp3.X, pp3.Y, 10, 10));
                gr.DrawRectangle(new Pen(cl4), new Rectangle(pp4.X, pp4.Y, 10, 10));

                pictureBox1.Refresh();


                rast_triang(pp1, pp4, pp2, cl1, cl2, cl4);

                rast_triang(pp3, pp2, pp4, cl3, cl4, cl2);
            }
        }
    }
}
