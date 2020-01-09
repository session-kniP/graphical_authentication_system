using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ESignature
{
    public partial class ESignature : Form
    {
        public ESignature()
        {

            InitializeComponent();
            g = pic_esign.CreateGraphics();
            dbconn.Connect();
        }

        static Color kayf_color = Color.Black;

        static bool is_pressed = false;

        static Point curr_point;
        static Point prev_point;

        static Graphics g; // У объекта класса есть метод DrawLine, который принимает на вход карандаш,
                           //начальную позицию, конечную позицию и рисукт между ними линию

        static void draw()
        {
            Pen p = new Pen(kayf_color, 12);
            g.DrawLine(p, curr_point, prev_point);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            is_pressed = true;
            curr_point = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_pressed)
            {
                prev_point = curr_point;
                curr_point = e.Location;
                draw();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            is_pressed = false;
        }

        private static string output_str = "";  //With Old GetHash

        static List<bool> GetHash(string src)   //OLD
        {

            List<bool> output = new List<bool>();

            Bitmap bm = new Bitmap(Image.FromFile(src), new Size(8, 8));

            for (int j = 0; j < bm.Height; j++)
            {
                for (int i = 0; i < bm.Width; i++)
                {
                    output_str += Convert.ToString(Convert.ToInt32((bm.GetPixel(i, j) != Color.FromArgb(255, 255, 255, 255)) 
                                                    && (bm.GetPixel(i, j) != Color.FromArgb(254, 254, 254, 254)))) + " ";
                }

            }
            return output;
        }

        static List<bool> GetHash(Bitmap img)
        {
            List<bool> output = new List<bool>();

            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    output.Add((img.GetPixel(i, j) != Color.FromArgb(255, 255, 255, 255)) && (img.GetPixel(i, j) != Color.FromArgb(254,254,254,254)));
                }
            }

            return output;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            pic_esign.Refresh();
        }

        //===================================================================


        //===================================================================

        private void btn_cmp_Click(object sender, EventArgs e)
        {
            Rectangle rect_img = pic_esign.RectangleToScreen(pic_esign.ClientRectangle);

            Bitmap img = new Bitmap(rect_img.Width, rect_img.Height);

            Graphics pic = Graphics.FromImage(img);

            pic.CopyFromScreen(rect_img.Location, new Point(0, 0), rect_img.Size);

            Bitmap lo = new Bitmap(img, new Size(8, 8));

            //pic_esign.Image = lo;

            List<bool> new_pic = GetHash(lo);

            string username = tb_name.Text;

            bool identity = false;

            //for (int i = 0; i < old_pic.Count; i++)
            //{
            //    if (old_pic[i] == new_pic[i])
            //        ++identity;
            //}
            //int equal_elem = old_pic.Zip(new_pic, (i, j) => i == j).Count(eq => eq);

            identity = dbconn.Comparator(username, new_pic);

            MessageBox.Show(Convert.ToString(identity));

        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            output_str = "";
        }
    }
}
