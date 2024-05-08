using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultimediaProject
{
    public partial class Game : Form
    {
        bool goLeft, goRight, jumping, isGameOver;
        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;
        int horizontalSpeed = 5;
        int verticalSpeed = 3;
        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 3;
        public Game()
        {
            InitializeComponent();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox25_Click(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            player.Top += jumpSpeed;

            if(goLeft==true)
            {
                player.Left -= playerSpeed;
            }

            if (goRight==true)
            {
                player.Left += playerSpeed;
            }

            if(jumping==true && force<0)
            {
                jumping = false;
            }
            if(jumping==true)
            {
                jumpSpeed = -8;
                force -= 1;
            }
            else
            {
                jumpSpeed = 10;
            }

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if ((String)x.Tag=="platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;
                            if((string)x.Name == "HorizontalPlatorm " && (goLeft == false || (string)x.Name == "HorizontalPlatorm") && goRight == false)
                            {
                                player.Left -= horizontalSpeed;
                            }
                        }
                        x.BringToFront();
                    }
                    
                
            
          
                 
                    if ((string)x.Tag == "cost")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }
                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameTimer.Stop();
                            isGameOver = true;
                            txtScore.Text = "Score: " + score + Environment.NewLine + "You were killed in your journey!!";
                        }
                    }
                }
            }
            HorizontalPlatorm.Left -= horizontalSpeed;
            if (HorizontalPlatorm.Left < 0 || HorizontalPlatorm.Left + HorizontalPlatorm.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }
            VerticalPlatform.Top += verticalSpeed;
            if (VerticalPlatform.Top < 195 || VerticalPlatform.Top > 581)
            {
                verticalSpeed = -verticalSpeed;
            }
            enemyOne.Left -= enemyOneSpeed;
            if (enemyOne.Left < pictureBox5.Left || enemyOne.Left + enemyOne.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }
            enemyTwo.Left += enemyTwoSpeed;
            if (enemyTwo.Left < pictureBox1.Left || enemyTwo.Left + enemyTwo.Width > pictureBox1.Left + pictureBox1.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }
            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                GameTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + score + Environment.NewLine + "You fell to your death!";
            }
            if (player.Bounds.IntersectsWith(door.Bounds) && score == 22)
            {
                GameTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + score + Environment.NewLine + "Your request is complete!";
            }
            else
            {
                txtScore.Text = "Score: " + score + Environment.NewLine + "Collect all the coins";
            }
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                restartGame();
            }

        }

        private void restartGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;
            txtScore.Text = "Score: " + score;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }
            // reset the position of player, platform and enemies

            player.Left = 37;
            player.Top = 522;
            enemyOne.Left = 243;
            enemyTwo.Left = 333;
            HorizontalPlatorm.Left = 194;
            VerticalPlatform.Top = 425;
            GameTimer.Start();
        }
    }
}
