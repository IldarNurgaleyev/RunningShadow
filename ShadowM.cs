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
    class Shadow
    {
        public Image image = Properties.Resources.Shadow;
        public bool b = false;

        public RectangleF rect;
        public float speed;
        public Shadow(float x, float y)
        {
            rect = new RectangleF(x / 2, y - 70, image.Width, image.Height);
        }

        public void Draw(Graphics g)
        {
                g.DrawImage(image, rect);
        }
    }
}
