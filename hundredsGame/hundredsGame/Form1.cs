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
        SoundPlayer soundPlayer;
        int cw;
        int ch;
        int totalScore = 0;
        Random ballPlacement = new Random();
        bool ball1move = true;
        int mouseX;
        bool reset = false;
        int mouseY;
        int speedUp = 0;
        int ball1w = 20;
        int ball1h = 20;
        int ballsCount = 4;
        int tmpxSpeed = 0;
        int tmpySpeed = 0;
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
            soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = "oof.wav";
            for (int i = 0; i < ballsCount; i++)
            {
              balls.Add(new bouncyball(Brushes.White, ballPlacement.Next(10, 1500), ballPlacement.Next(10, 800), ball1w, ball1h, ballPlacement.Next(1, 5), ballPlacement.Next(1,5), true));
            }
        }

        private void gameRunner_Tick(object sender, EventArgs e)
        {
            gfx.DrawRectangle(Pens.Red, rectangle);
            mainPictureBox.Image = canvas;
            gfx.Clear(BackColor);

            for(int i = 0; i < balls.Count; i++)
            //foreach (bouncyball ball in balls)
            {
                bool isGrowing = false;

                bouncyball ball = balls[i];
                ball.Draw(gfx);
                ball.Move(cw, ch, ball1move);
                if (ball.Intersects(rectangle.X, rectangle.Y, 0))
                {
                    isGrowing = true;
                    ball.width += 1;
                    ball.height += 1;
                    totalScore += 1;
                }
                if(totalScore / 2 == 101)
                {
                    balls.Clear();
                    ballsCount += 6;
                    //all balls must add to 100 not just one
                    for (int k = 0; i < ballsCount; i++)
                    {


                        balls.Add(new bouncyball(Brushes.White, ballPlacement.Next(10, 1500), ballPlacement.Next(10, 800), ball1w, ball1h, ballPlacement.Next(1, 5), ballPlacement.Next(1, 5), true));
                    }
                    totalScore = 0;
                }

                //foreach (bouncyball ball2 in balls)
                for (int j = 0; j < balls.Count; j++)
                {
                    bouncyball ball2 = balls[j];
                    if (isGrowing)
                    {
                        if (ball != ball2 && ball.HitBox.IntersectsWith(ball2.HitBox))
                        {
                            if (ball.Intersects(ball2.x, ball2.y, ball2.width / 2))
                            {
                                gameRunner.Enabled = false;
                                restartButton.Enabled = true;
                                restartButton.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (ball != ball2 && ball.HitBox.IntersectsWith(ball2.HitBox))
                        {
                            if (ball.Intersects(ball2.x, ball2.y, ball2.width / 2))
                            {
                                tmpxSpeed = ball.xSpeed;
                                ball.xSpeed = ball2.xSpeed;
                                ball2.xSpeed = tmpxSpeed;

                                tmpySpeed = ball.ySpeed;
                                ball.ySpeed = ball2.ySpeed;
                                ball2.ySpeed = tmpySpeed;
                                soundPlayer.Play();
                                //speedUp++;
                                //if(speedUp == 1000)
                                //{
                                //    ball.xSpeed += 1;
                                //    ball.ySpeed += 1;
                                //    ball2.xSpeed += 1;
                                //    ball2.ySpeed += 1;
                                //    speedUp = 0;
                                //}
                            }
                        }
                    }
                }
                if (ball.x < 0)
                {
                    ball.x = 0;
                }
                if (ball.x + ball.width > ClientSize.Width)
                {
                    ball.x -= 20;
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
            if(ballsCount >= 30)
            {
                youWin.Visible = true;
                gameRunner.Enabled = false;
                restartButton.Enabled = true;
                restartButton.Visible = true;
                ballsCount = 8;
            }
            totalLabel.Text = ($"{totalScore / 2}");
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

        private void resetButtonFlash_Tick(object sender, EventArgs e)
        {
            
            restartButton.BackColor = Color.Lime;
            restartButton.ForeColor = Color.Red;
            
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            restartButton.Enabled = false;
            restartButton.Visible = false;
            youWin.Visible = false;
            gameRunner.Enabled = true;
            balls.Clear();
            for (int i = 0; i < ballsCount / 2; i++)
            {
                

                balls.Add(new bouncyball(Brushes.White, ballPlacement.Next(10, 1500), ballPlacement.Next(10, 800), ball1w, ball1h, ballPlacement.Next(1, 5), ballPlacement.Next(1, 5), true));
            }
            ballsCount /= 2;
            totalScore = 0;
        }

        private void resetbuttonsflash_Tick(object sender, EventArgs e)
        {
            restartButton.BackColor = Color.Red;
            restartButton.ForeColor = Color.Lime;
        }

        private void resetbuttonflashagainSUCC_Tick(object sender, EventArgs e)
        {
            restartButton.BackColor = Color.Yellow;
            restartButton.ForeColor = Color.Blue;
        }

        private void totalLabel_Click(object sender, EventArgs e)
        {

        }

        private void youWin_Click(object sender, EventArgs e)
        {

        }
    }
}
