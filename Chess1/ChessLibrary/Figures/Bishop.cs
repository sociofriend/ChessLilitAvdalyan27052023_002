using System.IO;
namespace ChessLibrary.Figures;

public class Bishop
{
    
    public void PrintBoardWithLegalSteps()
    {
        Console.WriteLine("  A B C D E F G H  ");
        for (int i = 0; i < 8; i++)
        {
            Console.Write(" " + (i + 1));
            for (int j = 0; j < 8; j++)
            {
                if (coordinates[i, j] == 1)
                    ChessLib.Chess.BackgroundSetter((figure + " "), i, j);
                else if ((coordinates[i, j] != 1) && ((i == row) || (j == coloumn)))
                    ChessLib.Chess.BackgroundSetter("**", i, j);
                else
                    ChessLib.Chess.BackgroundSetter("  ", i, j);
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(i + 1);
        }
        Console.WriteLine("  A B C D E F G H  ");
    }
    
    /// <summary>
    ///Recieves two-dimensional array of integers identifying the place of the
    ///figure, assignes the value of "2" to coordinates matching the legal steps' requirements.
    /// </summary>
    /// <param name="figure">String type variable.</param>
    /// <param name="coordinates">Two-dimensional array of integers.</param>
    public void AddLegalSteps(string Figure, int[,] Coordinates)
    { 
        Coordinates coordinates = new Coordinates();
        coordinates.AssignValues(Coordinates);

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((Coordinates[i, j] != 1) && ((i+j == coordinates.Sum) || (i-j == coordinates.Dif)))
                    Coordinates[i, j] = 2;
            }
        }
    }
}