using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBeta
{
    public partial class GameBeta : Form
    {
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;

        public GameBeta()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            MotoBoy.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;   

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 550;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }

            if (MotoBoy.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                MotoBoy.Bounds.IntersectsWith(pipeTop.Bounds) ||
                MotoBoy.Bounds.IntersectsWith(ground.Bounds)
                )
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over !!!";
        }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }
    }
}
