using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Block : PictureBox
    {

        float x = 0;
        float y = 0;
        int vx = 0;
        int vy = 0;
        int ax = 0;
        int ay = 1;
        int jumpForce = 10;

        public bool onGround = false;

        public Block(int x, int y, int sizex, int sizey, Color color, Form form)
        {

            Point location = new Point(x, y);
            this.Size = new Size(sizex, sizey);
            this.Location = location;
            this.BackColor = color;
            form.Controls.Add(this);
        }

        public void updadeLocation(List<Obstacle> obstacles)
        {
            vx = vx + ax;
            vy = vy + ay;

            Point newLocation = new Point(this.Location.X + vx, this.Location.Y + vy);


            float t = 100;
            foreach (Obstacle ob in obstacles){
                Rectangle b = ob.Bounds;
                Rectangle thisb = this.Bounds;
                thisb.Location = newLocation;
                if (b.IntersectsWith(thisb))
                {
                    int lx1 = this.Bounds.Location.X;
                    int sx1 = this.Bounds.Size.Width;
                    int lx2 = ob.Bounds.Location.X;
                    int sx2 = ob.Bounds.Size.Width;
                    int dx;
                    if (lx1<lx2){
                        dx = lx2 - (lx1+sx1);
                    }else{
                        dx = (lx2+sx2) - lx1;
                    }

                    int ly1 = this.Bounds.Location.Y;
                    int sy1 = this.Bounds.Size.Height;
                    int ly2 = ob.Bounds.Location.Y;
                    int sy2 = ob.Bounds.Size.Height;
                    int dy;
                    if (ly1<ly2){
                        dy = ly2 - (ly1+sy1);
                    }else{
                        dy = (ly2+sy2) - ly1;
                    }


                    float tx;
                    if (vx == 0)
                    {
                        tx = 2;
                    }
                    else
                    {
                        tx = dx / vx;
                    }

                    float ty;
                    if (vy == 0)
                    {
                        ty = 2;
                    }
                    else
                    {
                        ty = dy / vy;
                    }

                    if (ty > tx)
                    {
                        if (tx < t)
                        {
                            newLocation = new Point(roundDown(vx * tx), roundDown(vy * tx));
                            t = tx;
                        }
                    }
                    else
                    {
                        if (ty < t)
                        {
                            newLocation = new Point(this.Location.X + roundDown(vx * ty), this.Location.Y + roundDown(vy * ty));
                            t = ty;
                            if (vy > 0)
                            {
                                this.onGround = true;
                            }
                            vy = 0;
                            int at = ob.Attrition;
                            if (vx < 0)
                            {
                                if (-vx < at)
                                {
                                    vx = 0;
                                }
                                else
                                {
                                    vx = vx + at;
                                }
                                vx += ob.Attrition;
                            }
                            if (vx > 0)
                            {
                                if (vx < at)
                                {
                                    vx = 0;
                                }
                                else
                                {
                                    vx = vx + at;
                                }
                            }
                        }
                    }


                }
            }

            if (vy != 0)
            {
                this.onGround = false;
            }

            this.Location = newLocation;
        }

        public void jump()
        {
            if (onGround)
            {
                vy = vy - jumpForce;
            }
        }

        int roundDown(double number)
        {
            return Convert.ToInt32(Math.Round(number - number % Math.Pow(10, 0)));
        }


    }
}
