namespace ChessLibrary.Figures;

public class Queen: Figure
{
    /// <summary>
    /// Receives two-dimensional array of integers identifying the place of the
    ///figure, assigns the value of "2" to coordinates matching the legal steps' requirements.
    /// </summary>
    /// <param name="array">Integer type two-dimensional array.</param>
    /// <returns>Integer type two-dimensional array.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public override int[,] AddLegalSteps(UserData userData)
    {
        Coordinates coordinates = new Coordinates();
        coordinates.AssignValuesToLocalProperties(userData.InitialCoordinates);
        
        for(int i=0; i<8; i++)
        {
            for(int j=0; j<8; j++)
            {
                if ((userData.InitialCoordinates[i, j] != 1) && ((i + j) == coordinates.Sum || 
                                                                 (i - j == coordinates.Dif) || 
                                                                 (i==coordinates.Row) || 
                                                                 (j==coordinates.Colomn)))
                    userData.InitialCoordinates[i, j] = 2;
            }
        }

        return userData.InitialCoordinates;
    }

    /// <summary>
    /// Calls CheckLegalStep() method of the Coordinates class transferring UserChoice type object.
    /// </summary>
    /// <param name="userData">UserData type object.</param>
    /// <returns>Boolean value.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public override bool CheckAccessForDestCoords(UserData userData)
    {
        Coordinates coordinates = new Coordinates();
        return coordinates.CheckLegalStep(userData);
    }
}

