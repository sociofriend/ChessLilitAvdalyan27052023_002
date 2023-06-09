using ChessLibrary;
namespace ChessLibrary.Figures;

public abstract class Figure
{
    public abstract int[,] AddLegalSteps(UserData userData);

    public abstract bool CheckAccessForDestCoords(UserData userData);
}
