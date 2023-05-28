namespace ChessLibrary.Figures;

public class Knight
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
        coordinates.AssignValuesToLocalProperties(Coordinates);
        
        int[] numbers = { -8, -12, -19, -21, 8, 12, 19, 21 };
        
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((Coordinates[i, j] != 1) && (numbers.Contains(coordinates.FigureNumber - coordinates.ConvertCoordinatesToNumber(i, j))))
                    Coordinates[i, j] = 2;
            }
        }
    }
    
    public string[,] PrintBoardWithFigureSteps(UserChoice userChoice)
    {
        int[] numbers = { -8, -12, -19, -21, 8, 12, 19, 21 };
        
        //set local variables of chessboard and assign values from the main coordinates' array
        Coordinates coordinates = new Coordinates();
        coordinates.AssignValuesToLocalProperties(userChoice.InitialCoordinates);
        coordinates.AddLegalSteps(userChoice.Figure, userChoice.InitialCoordinates);
        int row = coordinates.Row;
        int coloumn = coordinates.Colomn;

        string[,] chessBoard = new string[10,10];
        List<int> localStepNumbers = coordinates.CollectLegalStepsInList(userChoice);

        
        //set first and last rows of the chess board
        chessBoard[0, 0] = chessBoard[0, 9] = chessBoard[9,0] = chessBoard[9,9] = "  ";
        
        for (int i=0; i < 9; i++)
        {
            chessBoard[0, i] = chessBoard[9, i] = $"Convert.ToString(Convert.ToChar(65 + i)) ";
        }
        
        //set main chess board body
        for (int i = 0; i < 10; i++)
        {
            chessBoard[i, 0] = chessBoard[i, 9] = $" {i + 1}";
            for (int j = 1; j < 9; j++)
            {
                if (userChoice.InitialCoordinates[i, j] == 1)
                    chessBoard[i, j] = $"{userChoice.Figure} ";
                else if (userChoice.InitialCoordinates[i, j] == 2)
                    chessBoard[i, j] = "**";
                else
                    chessBoard[i, j] = "  ";
            }
        }
        return chessBoard;
    }

    public bool CheckAccessForDestinationCoordinate(UserChoice userChoice)
    {
        Coordinates coordinates = new Coordinates();
        return coordinates.CheckLegalStep(userChoice);
    }

    private int numberOfSteps = 1;
    public int FindMinimumNumberOfStepsToDestination(UserChoice userChoice)
    {
        int[,] figureStepsTooAllCells = new int[8,8];
        figureStepsTooAllCells = userChoice.InitialCoordinates;
        Coordinates coordinates = new Coordinates();
        coordinates.AssignValuesToLocalProperties(figureStepsTooAllCells);
        figureStepsTooAllCells[coordinates.Row, coordinates.Colomn] = 0;
        
        AddLegalSteps(userChoice.Figure, userChoice.InitialCoordinates);
        
        
    }
}