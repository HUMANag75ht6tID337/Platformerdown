using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Obstacle : PictureBox
    {

        public int Attrition = 0;

        public Obstacle(int x, int y, int sizex, int sizey, int attrition, Color color, Form form)
        {
            Point location = new Point(x, y);
            this.Size = new Size(sizex, sizey);
            this.Location = location;
            this.BackColor = color;
            this.Attrition = attrition;
            form.Controls.Add(this);
        }

    }
}
