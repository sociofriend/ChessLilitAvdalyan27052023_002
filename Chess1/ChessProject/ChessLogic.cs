using static System.Console;
using ChessLibrary;
using Microsoft.VisualStudio.Services.Users;

namespace ChessProject;


public class ChessLogic
{
    UserDataHandler _userDataHandler = new UserDataHandler();
    #region Properties
    public string? Figure { get; set; }
    public int[,]? InitialCoordinates { get; set; }
    public int[,]? DestinationCoordinates { get; set; }
    public int ActionCode { get; set; }
    #endregion
    
    public void RunChess()
    {
        ChooseAction();
        RunChess();
    }
    

    public void ChooseAction()
    {
        UserDataHandler userDataHandler = new UserDataHandler();
        Figure = userDataHandler.GetFigure();
        InitialCoordinates = userDataHandler.GetCoordinates();
        DestinationCoordinates = userDataHandler.GetCoordinates();
        UserChoice userChoice = new UserChoice(Figure, InitialCoordinates, DestinationCoordinates);
        
        WriteLine("Choose action for given coordinates and figure.\n" +
                  "\nPress 1 to print chess board with figure and legal steps" +
                  "\nPress 2 to identify access for the given destination coordinates" +
                  "\nPress 3 to find the minimum number of steps for the figure to get to destination coordinates");

        if(int.TryParse(Console.ReadLine(), out int result))
        {
            ActionCode = result;
        }
        else
        {
            WriteLine("WRONG INPUT: Please input 1, 2 or 3.\n");
            ChooseAction();
        }

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