using ChessLibrary.Figures;
namespace ChessLibrary;

public class Board
{
    public void PrintBoard(string Figure, int[,] Coordinates)
    {
        #region Figure objects
        Bishop bishop = new Bishop();
        King king = new King();
        Knight knight = new Knight();
        Queen queen = new Queen();
        Rook rook = new Rook();
        #endregion
        
        //switches to respective class method by user input
        switch (Figure)
        {
                case "b": 
                    bishop.PrintBoardWithLegalSteps(Coordinates);
                    break;
                case "K":
                    king.PrintBoardWithLegalSteps(Coordinates);
                    break;
                case "N":
                    knight.PrintBoardWithLegalSteps(Coordinates);
                    knight.FindMinimumStepsToDestination(Coordinates);
                    break;
                case "Q":
                    queen.PrintBoardWithLegalSteps(Coordinates);
                    break;
                case "R":
                    rook.PrintBoardWithLegalSteps(Coordinates);
                    break;
        }
    }
}