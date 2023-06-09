namespace ChessLibrary.GameFigures;

public class BlackKing : IFigureParameters
{
    public string Name { get; set; }
    public int[,] Coordinates { get; set; }
    public int Number { get; set; }
    public string NumberStr { get; set; }
    public int Row { get; set; }
    public int Colomn { get; set; }
    public List<int> LegalSteps { get; set; }

    public string StepSymbol { get; set; } = "bs";

    public BlackKing(string name, int[,] coordinates, int number, int row, int colomn, List<int> legalSteps)
    {
        Name = name;
        Coordinates = coordinates;
        Number = number;
        Row = row;
        Colomn = colomn;
        LegalSteps = legalSteps;
    }
}