namespace ChessLibrary.Figures;

public abstract class Figure
{
    public abstract void AddLegalSteps(string Figure, int[,] Coordinates);
}