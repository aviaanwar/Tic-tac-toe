using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Board
    {
        public static int NO_PLAYER = 0;
        public static int PLAYER_X = 1;
        public static int PLAYER_O = 2;
        public int[,] board = new int[3, 3];
        public Action<String> setText;
        public Point computerMove;

        public bool isGameOver()
        {
            return hasPlayerWon(PLAYER_X) || hasPlayerWon(PLAYER_O) || isEmpty(getAvailableCells());
        }

        public bool hasPlayerWon(int player)
        {
            if((board[0,0] == board[1,1] && board[0,0] == board[2,2] && board[0,0] == player)
                || (board[0,2] == board[1,1] && board[0,2] == board[2,0] && board[0,2] == player)) return true;
            for(int i = 0; i < 3; i++)
            {
                if((board[i,0] == board[i,1] && board[i,0] == board[i,2] && board[i,0] == player)
                    || (board[0,i] == board[1,i] && board[0,i] == board[2,i] && board[0,i] == player)) return true;
            }
            return false;
        }

        public void initBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = NO_PLAYER;
                }
            }
        }

        public bool isEmpty(List<Point> cells)
        {
            if (cells.Count == 0) return true;
            else return false;
        }

        public List<Point> getAvailableCells()
        {
            List<Point> availableCells = new List<Point>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == NO_PLAYER) availableCells.Add(new Point(i, j));
                }
            }
            return availableCells;
        }

        public bool placeAMove(Point point, int player)
        {
            if (board[point.x,point.y] != NO_PLAYER) return false;
            board[point.x,point.y] = player;
            return true;
        }

        public int minimax(int depth, int turn)
        {
            if (hasPlayerWon(PLAYER_X)) return 1;
            if (hasPlayerWon(PLAYER_O)) return -1;

            List<Point> availableCells = getAvailableCells();
            if (isEmpty(availableCells)) return 0;

            int min = int.MaxValue;
            int max = int.MinValue;

            for(int i = 0; i < availableCells.Count; i++)
            {
                Point point = availableCells[i];
                if (turn == PLAYER_X)
                {
                    placeAMove(point, PLAYER_X);
                    int currentScore = minimax(depth + 1, PLAYER_O);
                    max = Math.Max(currentScore, max);

                    if (depth == 0)
                    {
                        setText("[Info] Computer Score for Position " + point.ToString() + " = " + currentScore.ToString());
                    }
                    if (currentScore >= 0)
                        if (depth == 0) computerMove = point;
                    if (currentScore == 1)
                    {
                        board[point.x, point.y] = NO_PLAYER;
                        break;
                    }

                    if (i == availableCells.Count - 1 && max < 0)
                        if (depth == 0) computerMove = point;

                }
                else if (turn == PLAYER_O)
                {
                    placeAMove(point, PLAYER_O);
                    int currentScore = minimax(depth + 1, PLAYER_X);
                    min = Math.Min(currentScore, min);

                    if (min == -1)
                    {
                        board[point.x, point.y] = NO_PLAYER;
                        break;
                    }
                }

                board[point.x, point.y] = NO_PLAYER;
            }
            return turn == PLAYER_X ? max : min;       
        }
    }
}
