using System;

class SudokuSolver
{
    private static int[,] board = new int[9, 9];

    
    static void InitializeBoard()
    {
        
        board = new int[,]
        {
            {5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };
    }

 
    static bool IsSafe(int row, int col, int num)
    {
      
        for (int x = 0; x < 9; x++)
        {
            if (board[row, x] == num)
                return false;
        }

 
        for (int y = 0; y < 9; y++)
        {
            if (board[y, col] == num)
                return false;
        }

  
        int startRow = row - row % 3;
        int startCol = col - col % 3;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i + startRow, j + startCol] == num)
                    return false;
            }
        }

        return true;
    }

  
    static bool SolveSudoku()
    {
        int row = -1;
        int col = -1;
        bool isEmpty = true;

        // Find the first empty cell
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i, j] == 0)
                {
                    row = i;
                    col = j;
                    isEmpty = false;
                    break;
                }
            }
            if (!isEmpty)
                break;
        }

        
        if (isEmpty)
            return true;

        
        for (int num = 1; num <= 9; num++)
        {
            if (IsSafe(row, col, num))
            {
                // Place the number in the empty cell
                board[row, col] = num;

                // Recursively try to solve the Sudoku
                if (SolveSudoku())
                    return true;

                // If the number doesn't lead to a solution, backtrack
                board[row, col] = 0;
            }
        }

        // Trigger backtracking
        return false;
    }

    // Print the solved Sudoku board
    static void PrintBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        InitializeBoard();

        if (SolveSudoku())
        {
            Console.WriteLine("Sudoku solved:");
            PrintBoard();
        }
        else
        {
            Console.WriteLine("No solution exists.");
        }

        Console.ReadLine(); // Keep the console window open
    }
}
