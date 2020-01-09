using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESignature
{
    public partial class Form1 : Form
    {
        static Graphics g;

        static Point curr_point;
        static Point prev_point;

        static bool is_pressed = false;
        static Color color = Color.Black;

        static void painter()
        {
            Pen p = new Pen(Color.Black, 12);
            g.DrawLine(p, prev_point, curr_point);
        }

        public Form1()
        {
            InitializeComponent();
            g = pic_esign.CreateGraphics();
        }

        static int step = 0;

        private void btn_tyk_Click(object sender, EventArgs e)
        {
            dbconn.Connect();

            if (step < 3)
            {
                txt_name.Enabled = false;

                List<bool> key = new List<bool>();
                
                Rectangle r = pic_esign.RectangleToScreen(pic_esign.ClientRectangle);

                Bitmap bm = new Bitmap(r.Width, r.Height);

                Graphics g = Graphics.FromImage(bm);

                g.CopyFromScreen(r.Location, new Point(0, 0), r.Size);

                Bitmap lo = new Bitmap(bm, 8, 8);

                for (int i = 0; i < lo.Height; i++)
                    for (int j = 0; j < lo.Width; j++)
                    {
                        key.Add((lo.GetPixel(i, j) != Color.FromArgb(254, 254, 254, 254)) && (lo.GetPixel(i, j) != Color.FromArgb(255, 255, 255, 255)));
                        //MessageBox.Show(Convert.ToString(lo.GetPixel(i, j)));
                    }

                int check_key = 0;

                for (int i = 0; i < key.Count; i++)
                {
                    if (Convert.ToInt32(key[i]) == 1)
                        check_key++;
                }

                if (check_key >= (key.Count - key.Count * 1 / 100))
                {
                    MessageBox.Show("Да введи ты ключ по-нормальному!");
                    return;
                }

                if (step == 0)
                    dbconn.RegQuery(txt_name.Text, key, false);
                else if (step > 0)
                    dbconn.RegQuery(txt_name.Text, key, true);

                if (dbconn.should_return == true) { txt_name.Enabled = true; return; };

                pic_esign.Refresh();
                step++;

                if (step == 3)
                {
                    txt_name.Enabled = true;
                    step = 0;
                    MessageBox.Show("Регистрация прошла успешно");
                    return;
                }
                else MessageBox.Show("Подтвердите графический ключ. Осталось " + Convert.ToString(3 - step) + " раз");
            }
        }

        private void pic_esign_MouseDown(object sender, MouseEventArgs e)
        {
            is_pressed = true;
            curr_point = e.Location;
        }

        private void pic_esign_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_pressed)
            {
                prev_point = curr_point;
                curr_point = e.Location;
                painter();
            }
        }

        private void pic_esign_MouseUp(object sender, MouseEventArgs e)
        {
            is_pressed = false;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            pic_esign.Refresh();
        }
    }
}
