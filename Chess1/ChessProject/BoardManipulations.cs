using ChessLibrary;
using ChessLibrary.Figures;
using static System.Console;
namespace ChessProject;

public class BoardManipulations
{
    Bishop bishop = new Bishop();
    // King king = new King();
    Knight knight = new Knight();
    // Queen queen = new Queen();
    // Rook rook = new Rook();

    
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

    public bool CheckAccessForDestinationCoordinate(UserChoice userChoice)
    {
        bool access = false;
        //switches to respective class method by user input
        switch (userChoice.Figure)
        {
            case "b":
                access = bishop.CheckAccessForDestinationCoordinate(userChoice);
                break;
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

    public int FindMinimumNumberOfStepsToDestination(UserChoice userChoice)
    {
        int number = 0;
        //switches to respective class method by user input
        switch (userChoice.Figure)
        {
            // case "b":
            //     bishop.CheckAccessForDestinationCoordinate(userChoice);
            //     break;
            // case "K":
            //     king.CheckAccessForDestinationCoordinate(userChoice);
            //     break;
            case "N":
                number = knight.CheckAccessForDestinationCoordinate(userChoice);
                break;
            // case "Q":
            //     queen.CheckAccessForDestinationCoordinate(userChoice);
            //     break;
            // case "R":
            //     rook.CheckAccessForDestinationCoordinate(userChoice);
            //     break;
        }
    }

    public void Print2DArray(string[,] array)
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Write(array[i,j]);
            }
            WriteLine();
        }
    }
}
