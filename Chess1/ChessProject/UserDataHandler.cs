using ChessLibrary;
using static System.Console;
namespace ChessProject;


public class UserDataHandler
{
    public string AlgebraicNotation { get; set; }

    /// <summary>
    /// Gets user input for figure, checks its validity:
    /// (R for rook, N for knight, B for bishop, K for king and Q for queen"),
    /// assigns the valid value to local public Property.
    /// </summary>
    /// <param name="Figure">string type Property</param>
    /// <returns>returns string type Property</returns>
    public string GetFigure()
    {
        //gets user input for figure, checks validity and returns
        WriteLine("Choose a figure: press R for rook, N " +
                  "for knight, B for bishop, K for king and Q for queen.");
        
        //assigns user input to string type local variable
        string figure = ReadLine().ToUpper();
        
        //checks input validity returns value if true or returns GetFigure() method;
        if(Enum.TryParse<HotKeys>(figure, out HotKeys result))
            return figure;
        else
        {
            WriteLine("WRONG INPUT: Please input a letter from the suggested options.");
            return GetFigure();
        }
    }
    
    /// <summary>
    /// Gets user string input and breaks into two integers for i,j coordinates.
    /// </summary>
    /// <returns>two-dimensional array of cooridnates</returns>
    public int[,] GetCoordinates()
    {
        Coordinates coordinates = new Coordinates();
        
        //get user input for initial coordinates
        WriteLine("Input command, where first symbol is a letter " +
                          "from ՛a՛ to ՛h՛ or 'A' to 'H' and second command is" +
                          " a number from ՛1՛ to ՛8՛ (ex.a8 or H1)");
        AlgebraicNotation  = ReadLine().ToUpper();

        //check validity of user input and return two-dimensional array
        if ((AlgebraicNotation.Length == 2) && (AlgebraicNotation[0] >= 65 && AlgebraicNotation[0] <= 72) &&
            (AlgebraicNotation[1] >= 49 && AlgebraicNotation[1] <= 56))
            return coordinates.Create2DArrayByCoordinates(((int)AlgebraicNotation[0] - 65),((int)AlgebraicNotation[1] - 49));
        else
        {
            WriteLine("WRONG INPUT: Please input two-symbol command");
            return GetCoordinates();
        }
    }   
}