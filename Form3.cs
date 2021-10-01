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

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(pictureBox1.Image);

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

            while (!rast_triang(new Point(x1, y1), new Point(x2, y2), new Point(x3, y2), cl1, cl2, cl3))
            {
                x1 = r.Next(0, pictureBox1.Width);
                y1 = r.Next(0, pictureBox1.Height);

                x2 = r.Next(0, pictureBox1.Width);
                x3 = r.Next(0, pictureBox1.Width);

                y2 = r.Next(0, pictureBox1.Height);
            }
        }

        private Color ColorFromDelta(Color cl1,  double dR, double dG, double dB, int steps)
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
            if (p2.Y != p3.Y)
                return false;
            if (p3.X < p2.X)
                return false;
            if (p1.X < p2.X || p1.X > p3.X)
                return false;
            if (p1.Y > p2.Y)
                return false;
            int width = (p3.X - p2.X);
            int heigth = (p2.Y - p1.Y);


            double left_delta_R = (c1.R - c2.R) * 1.0 / heigth;
            double left_delta_G = (c1.G - c2.G) * 1.0 / heigth;
            double left_delta_B = (c1.B - c2.B) * 1.0 / heigth;
            double right_delta_R = (c1.R - c3.R) * 1.0 / heigth;
            double right_delta_G = (c1.G - c3.G) * 1.0 / heigth;
            double right_delta_B = (c1.B - c3.B) * 1.0 / heigth;

            double tang_left = heigth*1.0 / (p1.X - p2.X);
            double tang_right = heigth*1.0 / (p3.X - p1.X);
            int xh = p1.X;
            for (int y = p2.Y; y >= p1.Y; y--)
            {
                int a1 = (int)((y - p1.Y) * 1.0 / tang_left);
                int a2 = (int)((y - p1.Y) * 1.0 / tang_right);
                int w = a1 + a2;
                int h = p2.Y - y;
                var left_color = ColorFromDelta(c2, left_delta_R, left_delta_G, left_delta_B, h);
                var right_color = ColorFromDelta(c3, right_delta_R, right_delta_G, right_delta_B, h);
                double delta_R = (left_color.R - right_color.R) * 1.0 / w;
                double delta_G = (left_color.G - right_color.G) * 1.0 / w;
                double delta_B = (left_color.B - right_color.B) * 1.0 / w;
                int left = xh - a1; int right = xh + a2;
                for (int x = left; x <= right; x++)
                    b.SetPixel(x, y, ColorFromDelta(right_color, delta_R,delta_G,delta_B,(x-left)));
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
    }
}
