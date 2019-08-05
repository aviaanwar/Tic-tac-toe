using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using System.Media;
using System.Threading.Tasks;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public static Random RANDOM = new Random();
        public SoundPlayer player = new SoundPlayer(Properties.Resources.Click_Cut);
        public SoundPlayer player2 = new SoundPlayer(Properties.Resources.Woosh_Cut);
        Board bo = new Board();
        Task task;
        public List<RectangleShape> rects;
        public Form1()
        {
            InitializeComponent();
        }

        public void setinfo(string str)
        {
            textBox1.AppendText(str);
            textBox1.AppendText(Environment.NewLine);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            rects = getRects();
            bo.initBoard();
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Do you want to play first?", "Player Choice", buttons);
            drawBoard();
            for (int i = 0; i < 9; i++)
            {
                rects[i].Enabled = true;
            }
            if (result == DialogResult.No)
            {
                Point p = new Point(RANDOM.Next(3), RANDOM.Next(3));
                bo.placeAMove(p, Board.PLAYER_X);
                player2.Play();
                drawBoard();
            }
            else textBox1.AppendText("[Info] Waiting For Move..." + Environment.NewLine);
        }

        public void computerTurn()
        {
            if (checkStats()) return;
            bo.setText = setinfo;
            bo.minimax(0, Board.PLAYER_X);
            textBox1.AppendText("[Info] Computer Chose Position: " + bo.computerMove + Environment.NewLine);
            bo.placeAMove(bo.computerMove, Board.PLAYER_X);
            task.Wait(400);
            player2.Play();
            drawBoard();
            if (checkStats()) return;
            textBox1.AppendText("[Info] Waiting For Move..." + Environment.NewLine);
        }

        public bool checkStats()
        {
            bool check = true;
            if (bo.hasPlayerWon(Board.PLAYER_X))
            {
                textBox1.AppendText("Game is Over!!" + Environment.NewLine);
                for (int i = 0; i < 9; i++)
                {
                    rects[i].Enabled = false;
                }
                MessageBox.Show("You Lost!!", "Info");
            }
            else if (bo.hasPlayerWon(Board.PLAYER_O))
            {
                textBox1.AppendText("Game is Over!!" + Environment.NewLine);
                for (int i = 0; i < 9; i++)
                {
                    rects[i].Enabled = false;
                }
                MessageBox.Show("You Won!!", "Info");
            }
            else if (bo.isGameOver())
            {
                textBox1.AppendText("Game is Over!!" + Environment.NewLine);
                for (int i = 0; i < 9; i++)
                {
                    rects[i].Enabled = false;
                }
                MessageBox.Show("Draw!!", "Info");
            }
            else check = false;
            return check;
        }

        public List<RectangleShape> getRects()
        {
            List<RectangleShape> shapes = new List<RectangleShape>();
            shapes.Add(rectangleShape1);
            shapes.Add(rectangleShape4);
            shapes.Add(rectangleShape5);
            shapes.Add(rectangleShape2);
            shapes.Add(rectangleShape6);
            shapes.Add(rectangleShape7);
            shapes.Add(rectangleShape3);
            shapes.Add(rectangleShape8);
            shapes.Add(rectangleShape9);
            return shapes;
        }

        public void drawBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (bo.board[i, j] == Board.NO_PLAYER) rects[(3 * i) + j].BackgroundImage = Resource1.white;
                    else if (bo.board[i, j] == Board.PLAYER_X) rects[(3 * i) + j].BackgroundImage = Resource1.X;
                    else if (bo.board[i, j] == Board.PLAYER_O) rects[(3 * i) + j].BackgroundImage = Resource1.O;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {
            Point userMove = new Point(0, 0);
            if (!bo.placeAMove(userMove, Board.PLAYER_O))
            {
                textBox1.AppendText("[Info] Cell is already filled!!" + Environment.NewLine);
                return;
            }
            player.Play();
            drawBoard();
            task = new Task(() => computerTurn());
            task.Start();
        }

        private void rectangleShape4_Click(object sender, EventArgs e)
        {
            Point userMove = new Point(0, 1);
            if (!bo.placeAMove(userMove, Board.PLAYER_O))
            {
                textBox1.AppendText("[Info] Cell is already filled!!" + Environment.NewLine);
                return;
            }
            player.Play();
            drawBoard();
            task = new Task(() => computerTurn());
            task.Start();
        }

        private void rectangleShape5_Click(object sender, EventArgs e)
        {
            Point userMove = new Point(0, 2);
            if (!bo.placeAMove(userMove, Board.PLAYER_O))
            {
                textBox1.AppendText("[Info] Cell is already filled!!" + Environment.NewLine);
                return;
            }
            player.Play();
            drawBoard();
            task = new Task(() => computerTurn());
            task.Start();
        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {
            Point userMove = new Point(1, 0);
            if (!bo.placeAMove(userMove, Board.PLAYER_O))
            {
                textBox1.AppendText("[Info] Cell is already filled!!" + Environment.NewLine);
                return;
            }
            player.Play();
            drawBoard();
            task = new Task(() => computerTurn());
            task.Start();
        }

        private void rectangleShape6_Click(object sender, EventArgs e)
        {
            Point userMove = new Point(1, 1);
            if (!bo.placeAMove(userMove, Board.PLAYER_O))
            {
                textBox1.AppendText("[Info] Cell is already filled!!" + Environment.NewLine);
                return;
            }
            player.Play();
            drawBoard();
            task = new Task(() => computerTurn());
            task.Start();
        }

        private void rectangleShape7_Click(object sender, EventArgs e)
        {
            Point userMove = new Point(1, 2);
            if (!bo.placeAMove(userMove, Board.PLAYER_O))
            {
                textBox1.AppendText("[Info] Cell is already filled!!" + Environment.NewLine);
                return;
            }
            player.Play();
            drawBoard();
            task = new Task(() => computerTurn());
            task.Start();
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {
            Point userMove = new Point(2, 0);
            if (!bo.placeAMove(userMove, Board.PLAYER_O))
            {
                textBox1.AppendText("[Info] Cell is already filled!!" + Environment.NewLine);
                return;
            }
            player.Play();
            drawBoard();
            task = new Task(() => computerTurn());
            task.Start();
        }

        private void rectangleShape8_Click(object sender, EventArgs e)
        {
            Point userMove = new Point(2, 1);
            if (!bo.placeAMove(userMove, Board.PLAYER_O))
            {
                textBox1.AppendText("[Info] Cell is already filled!!" + Environment.NewLine);
                return;
            }
            player.Play();
            drawBoard();
            task = new Task(() => computerTurn());
            task.Start();
        }

        private void rectangleShape9_Click(object sender, EventArgs e)
        {
            Point userMove = new Point(2, 2);
            if (!bo.placeAMove(userMove, Board.PLAYER_O))
            {
                textBox1.AppendText("[Info] Cell is already filled!!" + Environment.NewLine);
                return;
            }
            player.Play();
            drawBoard();
            task = new Task(() => computerTurn());
            task.Start();
        }
    }
}
