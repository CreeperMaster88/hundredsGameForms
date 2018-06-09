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
        bouncyball hundredBall1;
        int cw;
        int ch;
        bool ball1move = true;
        int mouseX;
        int mouseY;
        int ball1w = 20;
        int ball1h = 20;
        Rectangle rectangle = new Rectangle(0,0,2,2); 

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
             hundredBall1 = new bouncyball(Brushes.White, 20, 20, ball1w, ball1h, 2, 2, true);
        }

        private void gameRunner_Tick(object sender, EventArgs e)
        {
            
            gfx.Clear(BackColor);
            hundredBall1.Draw(gfx);
            hundredBall1.Move(cw, ch, ball1move);
            gfx.DrawRectangle(Pens.Red,rectangle);
            mainPictureBox.Image = canvas;
            if (rectangle.IntersectsWith(hundredBall1.HitBox))
            {
                hundredBall1.width += 1;
                hundredBall1.height += 1;
            }
            if (hundredBall1.x < 0)
            {
                hundredBall1.x = 0;
            }
            if (hundredBall1.x + hundredBall1.width > ClientSize.Width)
            {
                hundredBall1.x -= 20; ;
            }
            if (hundredBall1.y < 0)
            {
                hundredBall1.y = 20;
            }
            if(hundredBall1.y + hundredBall1.height > ClientSize.Height)
            {
                hundredBall1.y -= 20 ;
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
