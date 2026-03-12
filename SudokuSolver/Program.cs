public class SudokuSolver
{
    public void SolveSudoku(char[][] board)
    {
        Backtrack(board);
    }

    private bool Backtrack(char[][] board)
    {
        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                if (board[r][c] == '.')
                {
                    for (char ch = '1'; ch <= '9'; ch++)
                    {
                        if (IsValid(board, r, c, ch))
                        {
                            board[r][c] = ch;
                            if (Backtrack(board))
                                return true;
                            board[r][c] = '.'; // undo move
                        }
                    }
                    return false; // no valid number found
                }
            }
        }
        return true; // solved
    }

    private bool IsValid(char[][] board, int row, int col, char ch)
    {
        // Check row
        for (int i = 0; i < 9; i++)
            if (board[row][i] == ch) return false;

        // Check column
        for (int i = 0; i < 9; i++)
            if (board[i][col] == ch) return false;

        // Check 3x3 sub-box
        int boxRow = (row / 3) * 3;
        int boxCol = (col / 3) * 3;
        for (int i = boxRow; i < boxRow + 3; i++)
            for (int j = boxCol; j < boxCol + 3; j++)
                if (board[i][j] == ch) return false;

        return true;
    }

    // Helper to print the board
    public void PrintBoard(char[][] board)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(board[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    public static void Main()
    {
        char[][] board = new char[][]
        {
            new char[] {'5','.','4','.','7','.','.','.','2'},
            new char[] {'6','.','.','1','9','5','.','.','.'},
            new char[] {'.','9','8','.','.','.','.','6','.'},
            new char[] {'8','.','.','.','6','.','.','.','3'},
            new char[] {'4','.','.','8','.','3','.','.','1'},
            new char[] {'7','.','.','.','2','.','.','.','6'},
            new char[] {'.','6','.','.','.','.','2','8','.'},
            new char[] {'.','.','.','4','1','9','.','.','5'},
            new char[] {'.','.','.','.','8','.','.','7','9'}
        };

        SudokuSolver solver = new SudokuSolver();
        Console.WriteLine("Original Board:");
        solver.PrintBoard(board);
        solver.SolveSudoku(board);
        Console.WriteLine("\nFilled Board:");
        solver.PrintBoard(board);
    }
}