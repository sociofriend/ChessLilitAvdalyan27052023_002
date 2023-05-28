namespace ChessLibrary;

public class UserChoice
{
    //Properties
    public string Figure { get; set; }
    public int[,] InitialCoordinates { get; set; }
    public int[,] DestinationCoordinates { get; set; }
    
    //Constructors
    public UserChoice()
    {
        
    }
    
    public UserChoice(string figure, int[,] initialCoordinates, int[,] destinationCoordinates)
    {
        Figure = figure;
        InitialCoordinates = initialCoordinates;
        DestinationCoordinates = destinationCoordinates;
    }
}