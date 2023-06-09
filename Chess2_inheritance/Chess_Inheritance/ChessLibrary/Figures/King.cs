namespace ChessLibrary.Figures;

public class King: Figure
{
    private int[] numbers = {-11, -10, -9, -1, -1, 9, 10, 11};
    
    /// <summary>
    ///Receives two-dimensional array of integers identifying the place of the
    ///figure, assigns the value of "2" to coordinates matching the legal steps' requirements.
    /// </summary>
    /// <param name="figure">String type variable.</param>
    /// <param name="coordinates">Two-dimensional array of integers.</param>
    public override int[,] AddLegalSteps(UserData userData)
    {
        Coordinates coordinates = new Coordinates();
        coordinates.AssignValuesToLocalProperties(userData.InitialCoordinates);

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((userData.InitialCoordinates[i, j] != 1) && (numbers.Contains(coordinates.FigureNumber - 
                                                            coordinates.ConvertCoordinatesToNumber(i, j))))
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

    public int FindMinStepsToDestCoords(UserData userData)
    {
        throw new NotImplementedException();
    }
}