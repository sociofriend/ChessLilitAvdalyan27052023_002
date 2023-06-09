using ChessLibrary;
using ChessLibrary.Figures;
using static System.Console;
namespace ChessProject;

public class BoardManipulations  //ditarkel statik methods
{
    //objects
    Bishop bishop = new Bishop();
    King king = new King();
    Knight knight = new Knight();
    Queen queen = new Queen();
    Rook rook = new Rook();

    /// <summary>
    /// Calls PrintBoardWithFigureSteps() parameterized method of respective class and
    /// transfers Userchoice type object.
    /// </summary>
    /// <param name="userChoice">UserChoice type object, which carries user data.</param>
    /// <returns>Returns string type two-dimensional array with board symbols.</returns>
    public string[,] PrintBoardWithFigureSteps(UserChoice userChoice)
    {
        string[,] array = new string[,]{};
        
        //switches to respective class method by user input
        switch (userChoice.Figure)
        {
            case "b":
                array = bishop.PrintBoardWithFigureSteps(userChoice);
                break;
             // case "K":
             //     king.PrintBoardWithFigureSteps(userChoice);
             //     break;
            case "N":
                array = knight.PrintBoardWithFigureSteps(userChoice);
                break;
            // case "Q":
            //     queen.PrintBoardWithFigureSteps(userChoice);
            //     break;
            // case "R":
            //     rook.PrintBoardWithFigureSteps(userChoice);
            //     break;
        }
        return array;
    }

    /// <summary>
    /// Calls CheckAccessForDestinationCoordinate() parameterized method of respective class and
    /// transfers UserChoice type object.
    /// </summary>
    /// <param name="userChoice">UserChoice type object, which carries user data.</param>
    /// <returns>Returns boolean value returned by the CheckAccessForDestinationCoordinate() method. </returns>
    public bool CheckAccessForDestinationCoordinate(UserChoice userChoice)
    {
        bool access = false;
        //switches to respective class method by user input
        switch (userChoice.Figure)
        {
            // case "b":
            //     access = bishop.CheckAccessForDestinationCoordinate(userChoice);
            //     break;
            // case "K":
            //     king.CheckAccessForDestinationCoordinate(userChoice);
            //     break;
            case "N":
                access = knight.CheckAccessForDestinationCoordinate(userChoice);
                break;
            // case "Q":
            //     queen.CheckAccessForDestinationCoordinate(userChoice);
            //     break;
            // case "R":
            //     rook.CheckAccessForDestinationCoordinate(userChoice);
            //     break;
        }
        return access;
    }

    /// <summary>
    /// Calls FindMinimumNumberOfStepsToDestination() parameterized method of respective class and
    /// transfers UserChoice type object.
    /// </summary>
    /// <param name="userChoice">UserChoice type object, which carries user data.</param>
    /// <returns>Returns integer returned by FindMinimumNumberOfStepsToDestination() method.</returns>
    public int FindMinimumNumberOfStepsToDestination(UserChoice userChoice)
    {
        int number = 0;
        
        //switches to respective class method by user input
        switch (userChoice.Figure)
        {
            case "N":
                number = knight.FindMinimumNumberOfStepsToDestination(userChoice);
                break;
        }
        return number;
    }

    /// <summary>
    /// Prints string type two-dimensional array passed as argument.
    /// </summary>
    /// <param name="array">String type two-dimensional array.</param>
    public void Print2DArray(string[,] array) // nshannerin guyn 
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (array[i, j] == "**")
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Write("   ");
                }
                else if (array[i, j] == "--")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Write("   ");
                }
                else if (array[i, j] == "ss")
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Write("   ");
                }
                else
                {
                    Console.ResetColor();
                    Write(array[i, j]+" ");
                }
            }
            Console.ResetColor();
            WriteLine();
        }
    }
}
