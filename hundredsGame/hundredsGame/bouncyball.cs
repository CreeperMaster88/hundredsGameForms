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
            int a = (this.x + this.width / 2)- x + radius;
            int b = (this.y + this.height / 2) - y + radius;
            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            if(width / 2 + radius > c)
            {
                return true;
            }
            return false;
        }




        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(color, HitBox);

        }
    }
}
