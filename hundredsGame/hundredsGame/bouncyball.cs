using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hundredsGame
{
    class bouncyball
    {

        public bool isMovable;
        public int x;
        public int xSpeed;
        public int y;
        public int ySpeed;
        public int width;
        public int height; 
        public Rectangle HitBox
        {
            get
            {
                return new Rectangle(x, y, width, height);
            }
        }

        public int Radius
        {
            get
            {
                return width / 2;
            }
        }
        Font font;



        Brush color;
        public bouncyball(Brush color, int x, int y, int w, int h, int xSpeed, int ySpeed, bool isMovable)
        {
            this.isMovable = isMovable;
            this.x = x;
            this.y = y;
            width = w;
            height = h;
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
            this.color = color;

            font = new Font("Arial", 12.75f);
        }
        public void Move(int ClientWidth, int ClientHeight, bool isMovable)
        {
            if (isMovable)
            {
                x += xSpeed;
                y += ySpeed;
                if (x + width >= ClientWidth)
                {
                    xSpeed *= -1;
                }
                else if (x <= 0)
                {
                    xSpeed *= -1;
                }
                if (y + height >= ClientHeight)
                {
                    ySpeed *= -1;
                }
                if (HitBox.Width > ClientWidth)
                {
                    x -= 10;
                }
                else if (y <= 0)
                {
                    ySpeed *= -1;
                }
            }
        }
        
        public bool Intersects(int x, int y, int radius)
        {
            int a = (this.x + Radius)- x + radius;
            int b = (this.y + Radius) - y + radius;
            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            if(Radius + radius > c)
            {
                return true;
            }
            return false;
        }




        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(color, x, y, Radius * 2, Radius * 2);                        

            gfx.DrawString($"{Radius - 10}", font, Brushes.Black, new Point(HitBox.Left + Radius - (int)(gfx.MeasureString($"{Radius -10}", font).Width / 2), HitBox.Bottom - Radius - (int)(gfx.MeasureString($"{Radius - 10}", font).Height / 2)));
            

        }
    }
}
