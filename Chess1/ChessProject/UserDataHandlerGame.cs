using ChessLibrary.GameFigures;
using ChessLibrary;

namespace ChessProject;

public class UserDataHandlerGame
{
    public string Name { get; set; }
    public int[,] Coordinates { get; set; }
    public int Number { get; set; }
    public int Row { get; set; }
    public int Colomn { get; set; }
    public List<int> LegalSteps { get; set; }

    private UserDataHandler UserDataHandler = new UserDataHandler();
    private Coordinates coordinates = new Coordinates();
    
    public UserDataHandlerGame(string Figure)
    {
        Name = Figure;
        Coordinates = UserDataHandler.GetCoordinates();
        coordinates.AssignValuesToLocalProperties(Coordinates);
        Number = coordinates.FigureNumber;
        Colomn = coordinates.Colomn;
        Row = coordinates.Row;
        LegalSteps = coordinates.CollectLegalStepsInList(Figure, Coordinates);
    }
    
    
    
}