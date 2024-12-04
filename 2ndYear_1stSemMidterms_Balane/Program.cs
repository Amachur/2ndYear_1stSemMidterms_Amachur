using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndYear_1stSemMidterms_Balane
{
    class Program
    {
        static void Main()
        {
            Sudoku sudoku = new Sudoku();
            sudoku.Generate();
            sudoku.PrintBoard();
        }
    }

    class Sudoku
    {
        private const int Size = 9;
        private int[,] board = new int[Size, Size];

        public void Generate()
        {
            FillBoard();
            RemoveNumbers();
        }

        private bool FillBoard()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (board[row, col] == 0)
                    {
                        for (int num = 1; num <= Size; num++)
                        {
                            if (IsSafe(row, col, num))
                            {
                                board[row, col] = num;
                                if (FillBoard())
                                {
                                    return true;
                                }
                                board[row, col] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsSafe(int row, int col, int num)
        {
            for (int i = 0; i < Size; i++)
            {
                if (board[row, i] == num || board[i, col] == num)
                {
                    return false;
                }
            }

            int startRow = row - row % 3;
            int startCol = col - col % 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i + startRow, j + startCol] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void RemoveNumbers()
        {
            Random rand = new Random();
            int count = 40;
            while (count > 0)
            {
                int i = rand.Next(0, Size);
                int j = rand.Next(0, Size);
                if (board[i, j] != 0)
                {
                    board[i, j] = 0;
                    count--;
                }
            }
        }

        public void PrintBoard()
        {
            for (int row = 0; row < Size; row++)
            {
                if (row % 3 == 0 && row != 0)
                {
                    Console.WriteLine("---------------------");
                }
                for (int col = 0; col < Size; col++)
                {
                    if (col % 3 == 0 && col != 0)
                    {
                        Console.Write("| ");
                    }
                    Console.Write(board[row, col] == 0 ? ". " : board[row, col] + " ");
                }
                Console.WriteLine();
                Console.ReadKey();
                Console.Beep();
            }
        }
    }
}