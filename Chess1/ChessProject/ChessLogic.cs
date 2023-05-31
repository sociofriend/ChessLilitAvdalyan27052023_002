using static System.Console;
using ChessLibrary;
using Microsoft.VisualStudio.Services.Users;

namespace ChessProject;


public class ChessLogic
{
    //properties
    public string? Figure { get; set; }
    public int[,]? InitialCoordinates { get; set; }
    public int[,]? DestinationCoordinates { get; set; }
    public int ActionCode { get; set; }

    //creating object to store user input data
    UserDataHandler _userDataHandler = new UserDataHandler();
    
    /// <summary>
    /// Calls ChooseAction() method to get user input for further actions, then calls itself to restart the project automatically.
    /// </summary>
    public void RunChess()
    {
        ChooseAction();
        RunChess();
    }
    
    /// <summary>
    /// Gets user choice on further action.
    /// </summary>
    public void ChooseAction()
    {
        UserDataHandler userDataHandler = new UserDataHandler();
        
        //assigns user input for string value of figure to Figure local property
        Figure = userDataHandler.GetFigure();
        
        //assigns user input for initial and destination cells of the figure to local properties
        InitialCoordinates = userDataHandler.GetCoordinates();
        DestinationCoordinates = userDataHandler.GetCoordinates();
        
        //creates object carrying user input data
        UserChoice userChoice = new UserChoice(Figure, InitialCoordinates, DestinationCoordinates);
        
        WriteLine("Choose action for given coordinates and figure.\n" +
                  "\nPress 1 to print chess board with figure and legal steps" +
                  "\nPress 2 to identify access for the given destination coordinates" +
                  "\nPress 3 to find the minimum number of steps for the figure to get to destination coordinates");

        //get and validate input
        if(int.TryParse(Console.ReadLine(), out int result))
        {
            ActionCode = result;
        }
        else
        {
            WriteLine("WRONG INPUT: Please input 1, 2 or 3.\n");
            ChooseAction();
        }
        
        //calls respective methods by input value
        BoardManipulations boardManipulations = new BoardManipulations();
        switch (ActionCode)
        {
            case 1:
                boardManipulations.Print2DArray(boardManipulations.PrintBoardWithFigureSteps(userChoice));
                break;
            case 2 :
                WriteLine(boardManipulations.CheckAccessForDestinationCoordinate(userChoice));
                break;
            case 3:
                WriteLine((boardManipulations.FindMinimumNumberOfStepsToDestination(userChoice)));
                break;
        }
    }
}