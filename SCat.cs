using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Running_Shadow
{
    class SCat
    {
        public Random r = new Random();

        int[] rand = {-10 ,-5 ,0, 5, 10};

        public Image imageUp = Properties.Resources.ShadowCat;

        public RectangleF[] rectUp;
        public RectangleF[] lines;

        public SCat(float x, float y)
        {
            imageUp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            rectUp = new RectangleF[10];
            lines = new RectangleF[100];

            for (int n = 0; n < 10; n++)
            {
                int j = rand[r.Next(0, rand.Length)];
                rectUp[n] = new RectangleF(x + n * 600, y - 10, 60, 60);
                
            }
            for (int n = 0; n < 100; n++)
            {
                lines[n] = new RectangleF(0 + n * 100, y + 90, 50, 10);  
            }
        }

        public void Draw(Graphics g)
        {
            

            for (int i = 0; i < 10; i++)
            {
                g.DrawImage(imageUp, rectUp[i]);
                
            }
            for (int i = 0; i < 100; i++)
            {
                g.FillRectangle(Brushes.White, lines[i]);
            }
        }
    }
}
