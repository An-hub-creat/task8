using System;

class Program
{
    static int[,] board = new int[8, 8];
    static int[] moveRow = { 2, 1, -1, -2, -2, -1, 1, 2 };
    static int[] moveCol = { 1, 2, 2, 1, -1, -2, -2, -1 };
    static int moveCount = 1;

    static void Main(string[] args)
    {
        int startRow = 0; // Starting row position of the knight
        int startCol = 0; // Starting column position of the knight

        MoveKnight(startRow, startCol);
        DisplayBoard();
    }

    static void MoveKnight(int row, int col)
    {
        board[row, col] = moveCount;

        while (moveCount < 64) // 64 is the total number of squares on the chessboard
        {
            int minMoves = int.MaxValue;
            int nextRow = -1;
            int nextCol = -1;

            for (int i = 0; i < 8; i++)
            {
                int newRow = row + moveRow[i];
                int newCol = col + moveCol[i];

                if (IsValidMove(newRow, newCol) && board[newRow, newCol] == 0)
                {
                    int moves = CountValidMoves(newRow, newCol);

                    if (moves < minMoves)
                    {
                        minMoves = moves;
                        nextRow = newRow;
                        nextCol = newCol;
                    }
                }
            }

            if (nextRow == -1 || nextCol == -1)
                break;

            moveCount++;
            row = nextRow;
            col = nextCol;
            board[row, col] = moveCount;
        }
    }

    static bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

    static int CountValidMoves(int row, int col)
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            int newRow = row + moveRow[i];
            int newCol = col + moveCol[i];

            if (IsValidMove(newRow, newCol) && board[newRow, newCol] == 0)
                count++;
        }

        return count;
    }

    static void DisplayBoard()
    {
        Console.WriteLine("Knight's Tour:");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(board[i, j].ToString().PadLeft(3));
            }
            Console.WriteLine();
        }
    }
}