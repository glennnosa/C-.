using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teacher_Fight_Hallway
{
    public partial class fightStage : Form
    {
        public fightStage()
        {
            InitializeComponent();
        }
        //
        //AI CODE
        //
        public void ai()
        {
            int p1y = player1.Left;
            if ((player2.Left - player1.Right) <= 20)
            {
                //ai punch
                player2.Image = Properties.Resources.Brosius_A_Punch_P2;
                var t = Task.Run(async delegate
                {
                    await Task.Delay(50);
                    return 42;
                });
                c1.p1Health = c1.p1Health - 50;
                while (player2.Left < (p1y + 40) & player1.Right <= 1032)
                {
                    player1.Left = player1.Left - 1;
                    t.Wait();
                }

                lblP1Health.Text = ("" + c1.p1Health);
            }
            //ai win code
            if (c1.p1Health <= 0)
            {
                MessageBox.Show("Player 2 Wins");
                mainMenu Form2 = new mainMenu();
                Form2.Show();
                this.Hide();
            }
            //ai movement
            if (player1.Right < player2.Left)
            {
                player2.Left = player2.Left - 10;
                var t = Task.Run(async delegate
                {
                    await Task.Delay(100);
                    return 42;
                });
                t.Wait();
            }
        }
        private void fightStage_Load(object sender, EventArgs e)
        {
           //sets player fighter sprites
            if (c1.player1Fighter == 1)
                player1.Image = Properties.Resources.BrosiusStandAP1;
            if (c1.player1Fighter == 2)
                player1.Image = Properties.Resources.BrosiusStandAP2;
            if (c1.player2Fighter == 1)
                player2.Image = Properties.Resources.BrosiusStandAP2;
            if (c1.player2Fighter == 2)
                player2.Image = Properties.Resources.BrosiusStandAP2;
            lblP1Health.Text = ("" + c1.p1Health);
            lblP2Health.Text = ("" + c1.p2Health);
            ai();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            player1.Image = Properties.Resources.BrosiusStandAP1;
            lblP1R.Text = ("" + player1.Right);
            lblP2L.Text = ("" + player2.Left);
            //walk to the left
            if (keyData == Keys.A & player1.Left > 0)
            {
                player1.Left = player1.Location.X - 10;
                return true;
            }
            //walk to the right
            if (keyData == Keys.D & (player1.Right) <= player2.Left)
            {
                player1.Left = player1.Location.X + 10;
                player1.Image = Properties.Resources.BrosiusWalkFowardAP1;
                return true;
            }
            //punch on space button
            if (keyData == Keys.Space)
            {
                c1.player1left = player1.Left;
                c1.player1top = player1.Top;
                c1.player2left = player2.Left;
                c1.player1right = player1.Right;
                c1.player2right = player2.Right;
                player1.Image = Properties.Resources.Brosius_A_Punch_P1;
                c1.punch();
                player1.Left = c1.player1left;
                player1.Top = c1.player1top;
                player2.Left = c1.player2left;
                return true;
            }
            //jump on W button
            if (keyData == Keys.W & player1.Location.Y == c1.player1Y)
            {
                c1.player1left = player1.Left;
                c1.player1top = player1.Top;
                c1.player2left = player2.Left;
                c1.player1right = player1.Right;
                c1.player2right = player2.Right;
                c1.jump();
                player1.Left = c1.player1left;
                player1.Top = c1.player1top;
                player2.Left = c1.player2left;
                return true;
            }
            if (c1.p2Health <= 0)
            {
                MessageBox.Show("Player 1 Wins");
                mainMenu Form2 = new mainMenu();
                Form2.Show();
                this.Hide();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        private void player2_Click(object sender, EventArgs e)
        {
        }
        private void btnBtn_Click(object sender, EventArgs e)
        {   
        }
        private void player1_Click(object sender, EventArgs e)
        {
        }
    }
}
