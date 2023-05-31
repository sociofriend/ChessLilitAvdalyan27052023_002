namespace ChessLibrary;

public class UserChoice
{
    //Properties
    public string Figure { get; set; }
    public int[,] InitialCoordinates { get; set; }
    public int[,] DestinationCoordinates { get; set; }
    

    /// <summary>
    /// Default constructor.
    /// </summary>
    public UserChoice()
    {
        
    }
    
    /// <summary>
    /// Parameterized constructor initializing local properties and assigning them the argument values.
    /// </summary>
    /// <param name="figure">String type variable.</param>
    /// <param name="initialCoordinates">Integer type two-dimensional array with coordinates (equal to 1) of the initial cell
    /// of the figure.</param>
    /// <param name="destinationCoordinates">Integer type two-dimensional array with coordinates (equal to 1) of the destination
    /// cell of the figure.</param>
    public UserChoice(string figure, int[,] initialCoordinates, int[,] destinationCoordinates)
    {
        Figure = figure;
        InitialCoordinates = initialCoordinates;
        DestinationCoordinates = destinationCoordinates;
    }
}