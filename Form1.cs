using System;

using System.Windows.Forms;

namespace Birdie
{
    public partial class Birdie : Form
    {
        public Birdie()
        {
            InitializeComponent();
        }
        int gravity = 10;
        int score = 0;
        int speed = 25;


        private void Birdie_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                gravity = 20;
        }

        private void Birdie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                gravity = -20;
            else if (e.KeyCode == Keys.Enter)
                timer1.Start();
        }
        Random rnd = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeDown.Left -= speed;
            pipeTop.Left -= speed;
            sunShine.Left -= speed;
            lblScore.Text = $"Score: {score}";
            //Adding score
            if(pipeDown.Left < -170)
            {
                pipeDown.Left = rnd.Next(250, 600);
                score++;
            }
            if (pipeTop.Left < -170)
            {
                int top = rnd.Next(300, 700);
                pipeTop.Left = top;
                sunShine.Left = rnd.Next(top +100, 800);
                score++;
            }
            if (bird.Bounds.IntersectsWith(pipeDown.Bounds) | bird.Bounds.IntersectsWith(pipeTop.Bounds) | bird.Bounds.IntersectsWith(ground.Bounds))
            {
                timer1.Stop();
                lblScore.Text += " GAME OVER !!!! ";
            }
            if (score > 10)
                speed += 5;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
