public class Solution
{
    public static int[][] Transpose(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        int[][] result = new int[columns][];

        for (int i = 0; i < columns; i++)
        {
            result[i] = new int[rows];
            for (int j = 0; j < rows; j++)
            {
                int value = (int)matrix.GetValue(j, i);
                result[i][j] = value;
            }
        }

        return result;
    }


    public static void Main()
    {
        int[,] matrix = new int[,] {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        int[][] transposed = Transpose(matrix);
        Console.WriteLine("Transposed Matrix:");
        for (int i = 0; i < transposed.Length; i++)
        {
            for (int j = 0; j < transposed[i].Length; j++)
            {
                Console.Write( transposed[i][j]+ " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
