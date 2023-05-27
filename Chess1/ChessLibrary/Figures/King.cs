namespace ChessLibrary.Figures;

public class King
{
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
        
        int[] numbers = { -11,-10, -9, -1, 1, 9, 10, 11  };
        
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((Coordinates[i, j] != 1) && (numbers.Contains(coordinates.FigureNumber - coordinates.ConvertToNumber(i, j))))
                    Coordinates[i, j] = 2;
            }
        }
        
    }
    
    
}