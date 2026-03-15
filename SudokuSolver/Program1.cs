public class Solution
{
    //samle to test other methods before implementing the main logic of the solution
    public static void Main1()
    {
        char[][] board = new char[][]
        {
            new char[] {'5','3','.','.','7','.','.','.','.'},
            new char[] {'6','.','.','1','9','5','.','.','.'},
            new char[] {'.','9','8','.','.','.','.','6','.'},
            new char[] {'8','.','.','.','6','.','.','.','3'},
            new char[] {'4','.','.','8','.','3','.','.','1'},
            new char[] {'7','.','.','.','2','.','.','.','6'},
            new char[] {'.','6','.','.','.','.','2','8','.'},
            new char[] {'.','.','.','4','1','9','.','.','5'},
            new char[] {'.','.','.','.','8','.','.','7','9'}
        };
        Solution solution = new Solution();
        solution.SolveSudoku(board);
    }
    public void SolveSudoku(char[][] board)
    {    
        char[][] result = board;
        char currentChar = '.';
        DisplaySudoku(board);

        // To process
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                currentChar = board[i][j];
                ////Console.WriteLine("=================| " + currentChar + " |==================");
                List<int> row = GetNonEmptyRawList(board[i]);
                List<int> column = GetNonEmptyColumnList(board, j);
                List<int> matrix = GetNonEmptyMatrixValues(board, i, j);
                ////Console.WriteLine("Row non-empty values: {" + string.Join(", ", row)+ "}");
                ////Console.WriteLine("Columns non-empty values: {" + string.Join(", ", column) + "}");
                ////Console.WriteLine("Matrix non-empty values: {" + string.Join(", ", matrix) + "}");
                ////Console.WriteLine("=================| - |==================");

                if (currentChar == '.')
                {
                    
                }
            }
            Console.WriteLine();
        }
        DisplaySudoku(result);
    }

    List<int> GetNonEmptyRawList(char[] board)
    {
        List<int> nonEmpty = new();

        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] != '.')
            {
                nonEmpty.Add(Convert.ToInt32(board[i].ToString()));
            }
        }
        return nonEmpty;
    }

    List<int> GetNonEmptyColumnList(char[][] board, int index)
    {
        List<int> column = new();
        for (int l = 8; l >= 0; l--)
        {
            if (board[l][index] != '.')
            {
                column.Add(Convert.ToInt32(board[l][index].ToString()));
            }
        }
        return column;
    }

    List<int> GetNonEmptyMatrixValues(char[][] board, int rowIndex, int columnIndex)
    {
        List<int> matrixVals = new();
        int startRowIndex = 0;
        int startColumnIndex = 0;
        int endRowIndex = 2;
        int endColumnIndex = 2;
        if (rowIndex > 2 & rowIndex < 6)
        {
            endRowIndex = 5;
            startRowIndex = 3;
        }
        else if (rowIndex > 5 & rowIndex < 9)
        {
            endRowIndex = 8;
            startRowIndex = 6;
        }

        if (columnIndex > 2 & columnIndex < 6)
        {
            endColumnIndex = 5;
            startColumnIndex = 3;
        }
        else if (columnIndex > 5 & columnIndex < 9)
        {
            endColumnIndex = 8;
            startColumnIndex = 6;
        }

        for (int i = startRowIndex; i <= endRowIndex; i++)
        {
            for (int j = startColumnIndex; j <= endColumnIndex; j++)
            {
                if (board[i][j] !='.')
                    matrixVals.Add(Convert.ToInt32(board[i][j].ToString()));
            }
        }
        return matrixVals;
    }

    void DisplaySudoku(char[][] result)
    {
         for (int i = 0; i < result.Length; i++)
        {
            for (int j = 0;  result[i]!=null && j < result[i].Length; j++)
            {
                Console.Write(" " + result[i][j]);
                if ((j + 1) % 3 == 0)
                    Console.Write("|");
            }           
            Console.WriteLine();
            if ((i + 1) % 3 == 0)
                Console.WriteLine("---------------------");
        }
    }

}