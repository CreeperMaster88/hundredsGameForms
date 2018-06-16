using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace hundredsGame
{
    public partial class Form1 : Form
    {
        Bitmap canvas;
        Graphics gfx;
        List<bouncyball> balls = new List<bouncyball>();
        //bouncyball ball;
        int cw;
        int ch;
        Random ballPlacement = new Random();
        bool ball1move = true;
        int mouseX;
        int mouseY;
        int speedUp = 0;
        int ball1w = 20;
        int ball1h = 20;
        Rectangle rectangle = new Rectangle(0, 0, 2, 2);

        public Form1()
        {
            InitializeComponent();
            canvas = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            gfx = Graphics.FromImage(canvas);
            cw = ClientSize.Width;
            ch = ClientSize.Height;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 50; i++)
            {
                balls.Add(new bouncyball(Brushes.White, ballPlacement.Next(10, 1500), ballPlacement.Next(10, 800), ball1w, ball1h, 2, 2, true));
            }

        }

        private void gameRunner_Tick(object sender, EventArgs e)
        {
            gfx.DrawRectangle(Pens.Red, rectangle);
            mainPictureBox.Image = canvas;
            gfx.Clear(BackColor);

            foreach (bouncyball ball in balls)
            {

                ball.Draw(gfx);
                ball.Move(cw, ch, ball1move);
                if (ball.Intersects(rectangle.X, rectangle.Y, 0))
                {
                   
                    ball.width += 1;
                    ball.height += 1;
                }

                foreach (bouncyball ball2 in balls)
                {

                    if (ball.Intersects(rectangle.X, rectangle.Y, 0))
                    {
                        if (ball != ball2 && ball.Intersects(ball2.x, ball2.y, ball2.width / 2))
                        {
                            gameRunner.Enabled = false;
                        }

                    }
                    if (ball != ball2 && ball.Intersects(ball2.x, ball2.y, ball2.width / 2))
                    {
                        ball.xSpeed *= -1;
                        ball.ySpeed *= -1;
                        ball2.xSpeed *= -1;
                        ball2.ySpeed *= -1;
                        speedUp++;
                        if(speedUp == 1000)
                        {
                            ball.xSpeed += 1;
                            ball.ySpeed += 1;
                            ball2.xSpeed += 1;
                            ball2.ySpeed += 1;
                            speedUp = 0;
                        }
                    }
                }
                if (ball.x < 0)
                {
                    ball.x = 0;
                }
                if (ball.x + ball.width > ClientSize.Width)
                {
                    ball.x -= 20; ;
                }
                if (ball.y < 0)
                {
                    ball.y = 20;
                }
                if (ball.y + ball.height > ClientSize.Height)
                {
                    ball.y -= 20;
                }
            }

        }



        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {


        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            rectangle.X = e.X;
            rectangle.Y = e.Y;

        }
    }
}
