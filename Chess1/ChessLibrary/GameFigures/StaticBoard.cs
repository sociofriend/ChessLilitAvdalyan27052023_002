namespace ChessLibrary.GameFigures;

public class StaticBoard
{
    public static string[,] board = new string[,] { };
    
    public static string[,] Board(string figure, int[,] coordinates)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (coordinates[i, j] == 1)
                {
                    board[i, j] = figure;
                }
            }
        }

        return board;
    }
}