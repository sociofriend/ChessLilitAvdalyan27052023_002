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

    public void ChooseProject()
    {
        Console.WriteLine("Choose project: 1 for board manipulations, 2 for the game.");
        if (int.TryParse(Console.ReadLine(), out int result))
        {
            if (result == 1)
            {
                ChooseAction();
                ChooseProject();
            }
            else if (result == 2)
            {
                //
            }
            else
            {
                Console.Write("Wrong input. Please follow the instructions. ");
                ChooseProject();
            }
        }
        else
        {
            Console.Write("Wrong input. Please follow the instructions. ");
            ChooseProject();
        }
    }
}