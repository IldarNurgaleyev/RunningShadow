using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Running_Shadow
{
    public partial class Form1 : Form
    {
        Shadow shad;
        SCat cat;

        Rectangle fl;

        SoundPlayer s;

        int score = 0;
        float gravity = 1;
        float pMove = 2;
        bool fall = false;




        public Form1()
        {
            InitializeComponent();
            shad = new Shadow(Width / 2, Height / 2);
            cat = new SCat(Width, Height / 2 + 50);

            fl = new Rectangle(0, Height - 110, Width, 100);

            s = new SoundPlayer(@"C:\Users\Ильдар\Downloads\Hero_Factory_Movie_-_Rise_of_the_Rookies[plus-musi.wav");

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            label1.Hide();
            button3.Hide();
            button3.Enabled = false;
            s.PlayLooping();
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (fall)
            {
                shad.image = Properties.Resources.Falling;
                shad.rect.Width = 200;
                shad.rect.Height = 200;
            }
            g.FillRectangle(Brushes.Gray, fl);
            shad.b = false;
            shad.Draw(g);
            cat.Draw(g);
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                shad.rect.Y -=20;
                shad.speed = 0;
                gravity = 1;


            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            score++;
            label1.Text = Convert.ToString(score);

            gravity = 1;

            if (!shad.rect.IntersectsWith(fl))
            {
                shad.image = Properties.Resources.JShadow;


            }

            if (shad.rect.IntersectsWith(fl))
            {
                shad.image = Properties.Resources.Shadow;
                gravity = 0;
                shad.speed = 0;
            }
            for (int i = 0; i < 10; i++)
            {
                if (shad.rect.IntersectsWith(cat.rectUp[i]))
                {
                    fall = true;

                    timer1.Stop();
                    timer2.Start();
                }
            }
            if (cat.rectUp[9].X < Width)
            { 
                timer1.Stop();
                timer3.Start();
            }

            for (int i = 0; i < 10; i++)
            {
                cat.rectUp[i].X -= pMove;
            }
            for (int i = 0; i < 100; i++)
            {
                cat.lines[i].X -= pMove;
            }
            shad.speed += gravity /  2;
            shad.rect.Y += shad.speed;
            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            shad.rect.Y--;
            shad.rect.X += 5;
            Invalidate();
            if (shad.rect.X > Width)
            {
                timer2.Stop();
                MessageBox.Show("Game over. Your score is "+score+".", "Cats bites you");
                button3.Enabled = true;
                button3.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Show();
            label2.Hide();
            button1.Hide();
            button2.Hide();
            button1.Enabled = false;
            button2.Enabled = false;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You - Shadow, you runinig in a sleaply city. But Shadow cats can prevent you! Press space key to jump! Good lucky!","Help provider");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
            button3.Hide();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (shad.rect.Y > 1)
            {
                shad.rect.Y -= 2;
            }
            if (shad.rect.Y < 1)
            {
                shad.rect.Y += 100; 
            }
            if (shad.rect.IntersectsWith(fl))
            {
                shad.rect.Width = 300;
                shad.rect.Height = 200;
                shad.image = Properties.Resources.CoolW; 
            }
            if (!shad.rect.IntersectsWith(fl))
            {
                shad.rect.Width = 200;
                shad.rect.Height = 200;
                shad.image = Properties.Resources.Win;
            }
            Invalidate();
        }
    }
}
