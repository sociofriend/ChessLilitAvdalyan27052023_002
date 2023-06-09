namespace ChessLibrary.Figures;

public class Knight: Figure
{
    int[] numbers = { -8, -12, -19, -21, 8, 12, 19, 21 };   //Initializing an integer type array of numbers
                                                            //identifying difference of the coordinates of the
                                                            //figure and potential legal steps.
                                                          
    private int figureNumber = 0; //i=1,j=2 => figureNumber = 12;
    private int numberOfSteps = 0; //required to get to destination coordinates
    private string[,] figureStepsToAllCells = new string[8, 8]; //initialising an empty array for writing count of
                                                                //steps for each cell from the initial coordinates
    private int returnNumber = 0;

    /// <summary>
    /// Creates string type two-dimensional array for the entire chess board.
    /// </summary>
    /// <param name="userData">UserData type object.</param>
    /// <returns>String type two-dimensional array.</returns>
    public string[,] PrintBoardWithFigureSteps(UserData userData)
    {
        //Assigning values describing the initial coordinates to local variables.
        Coordinates coordinates = new Coordinates();
        coordinates.AssignValuesToLocalProperties(userData.InitialCoordinates);
        int row = coordinates.Row;
        int coloumn = coordinates.Colomn;
        
        //Adding legal steps of the figure with transferred coordinates to initial coordinates.
        coordinates.AddLegalSteps(userData);
        
        //Initializes string type two-dimensional array for storing chess board symbols
        string[,] chessBoard = new string[10,10];
        
        //Initializing list of integers to store legal steps of the figure with transferred coordinates(by object).
        List<int> localStepNumbers = coordinates.CollectLegalStepsInList(userData);
        
        /*Assigning respective symbols to string type array describing the chess board.*/
        
        //Assigning empty spaces to board corners.
        chessBoard[0, 0] = chessBoard[0, 9] = chessBoard[9,0] = chessBoard[9,9] = "  ";
        
        //Setting first and last rows of the chess board.
        for (int i=1; i < 9; i++)
        {
            chessBoard[0, i] = chessBoard[9, i] = $" {Convert.ToString(Convert.ToChar(65 + i-1))}";
        }
        
        //Setting main chess board body.
        for (int i = 1; i < 9; i++)
        {
            chessBoard[i, 0] = chessBoard[i, 9] = $" {i}";
            
            for (int j = 1; j < 9; j++)
            {
                if (userData.InitialCoordinates[i-1, j-1] == 1)
                    chessBoard[i, j] = $" {userData.Figure}";
                
                else if (userData.InitialCoordinates[i-1, j-1] == 2)
                    chessBoard[i, j] = "ss";
                
                else if ((i + j) % 2 == 0)
                {
                    chessBoard[i, j] = "**";
                }
                else
                {
                    chessBoard[i, j] = "--";
                }
            }
        }
        
        return chessBoard;
   
    }


    /// <summary>
    ///Adds legal steps' coordinates to array. Receives two-dimensional array of integers identifying
    /// the place of the figure, assigns the "2" to coordinates matching the legal steps' requirements.
    /// </summary>
    /// <param name="figure">String type variable.</param>
    /// <param name="coordinates">Two-dimensional array of integers.</param>
    /// <returns>Integer type two-dimensional array.</returns>>
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
    /// Method identifies whether the string type array has an element with null value.
    /// </summary>
    /// <param name="array">String type two-dimensional array.</param>
    /// <returns>Boolean value.</returns>
    public bool ArrayIsFull(string[,] array)
    {
        bool isFull = true;

        for(int i =0; i < 8; i++)
        {
            for(int j=0; j<8; j++)
            {
                if (array[i, j] == null)
                {
                    isFull = false;
                    break;
                }
            }
        }
        return isFull;		
    }

    /// <summary>
    /// Creates a holistic chess board with figure and legal steps.
    /// </summary>
    /// <param name="stringArray">String type two-dimensional array.</param>
    /// <param name="cellValue">String type variable.</param>
    /// <returns>String type two-dimensional array.</returns>
    public string[,] CreateStringArrayFigureSteps(string[,] stringArray, string cellValue)
    {
        Coordinates coordinates = new Coordinates();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (stringArray[i, j]!= null && stringArray[i, j].Equals(cellValue))
                {
                    foreach (int element in numbers)
                    {
                        int stepNumber = coordinates.ConvertCoordinatesToNumber(i, j) - element;
                        int row = stepNumber / 10;
                        int colomn = stepNumber % 10;
                        if (row >= 0 && row < 8 && colomn >= 0 && colomn < 8)
                        {
                            try
                            {
                                if (stepNumber >= 0 && stringArray[row, colomn] == null)
                                {
                                    stringArray[stepNumber / 10, stepNumber % 10] =
                                        Convert.ToString(Convert.ToInt32(cellValue) + 1);
                                }
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine(
                                    "In Knight.AddLegalStepsString() methods check existence of the index");
                            }
                        }
                    }
                }
            }
        }

        return stringArray;
    }
    
    /// <summary>
    /// Calls CheckLegalStep() method of the Coordinates class transferring UserChoice type object.
    /// </summary>
    /// <param name="array"></param>
    /// <returns>Boolean type value.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public override bool CheckAccessForDestCoords(UserData userData)
    {
        Coordinates coordinates = new Coordinates();
        return coordinates.CheckLegalStep(userData);
    }

    /// <summary>
    /// Method identifies whether the string type array has an element with null value.
    /// </summary>
    /// <param name="userData">UserData type object.</param>
    /// <returns>Returns integer type value.</returns>
    public int FindMinStepsToDestCoords(UserData userData)
    {
        Coordinates coordinates = new Coordinates();
        coordinates.AddLegalSteps(userData);
        coordinates.AssignValuesToLocalProperties(userData.InitialCoordinates);
        
        figureStepsToAllCells[coordinates.Colomn, coordinates.Row] = numberOfSteps.ToString();
        
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (figureStepsToAllCells[i, j] != null)
                {
                    CreateStringArrayFigureSteps(figureStepsToAllCells, numberOfSteps.ToString());
                }
            }
        }

        while (numberOfSteps < 7)
        {
            numberOfSteps++;
            FindMinStepsToDestCoords(userData);
        }
            
        coordinates.AssignValuesToLocalProperties(userData.DestinationCoordinates);
        int row = coordinates.FigureNumber / 10;
        int colomn = coordinates.FigureNumber % 10;

        return Convert.ToInt32(figureStepsToAllCells[row, colomn]);
    }
}