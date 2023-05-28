using System.IO;
using System.Text;
using Microsoft.VisualStudio.Services.Users;

namespace ChessLibrary.Figures;

public class Bishop
{
    /// <summary>
    ///Recieves two-dimensional array of integers identifying the place of the
    ///figure, assignes the value of "2" to coordinates matching the legal steps' requirements.
    /// </summary>
    /// <param name="figure">String type variable.</param>
    /// <param name="coordinates">Two-dimensional array of integers.</param>
    public void AddLegalSteps(string Figure, int[,] Coordinates)
    { 
        Coordinates coordinates = new Coordinates();
        coordinates.AssignValuesToLocalProperties(Coordinates);

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((Coordinates[i, j] != 1) && ((i+j == coordinates.Sum) || (i-j == coordinates.Dif)))
                    Coordinates[i, j] = 2;
            }
        }
    }
    
    /// <summary>
    /// Receives UserChoice class objects, creates string type two-dimensional array
    /// for whole board.
    /// </summary>
    /// <param name="userChoice">UserChoice class object</param>
    /// <returns>String type two-dimensional array representing full chess board.</returns>
    public string[,] PrintBoardWithFigureSteps(UserChoice userChoice)
    {
        //set local variables of chessboard and assign values from the main coordinates' array
        Coordinates coordinates = new Coordinates();
        coordinates.AssignValuesToLocalProperties(userChoice.InitialCoordinates);
        coordinates.AddLegalSteps(userChoice.Figure, userChoice.InitialCoordinates);
        int row = coordinates.Row;
        int coloumn = coordinates.Colomn;        
        string[,] chessBoard = new string[10,10];

        //set first and last rows of the chess board
        chessBoard[0, 0] = chessBoard[0, 9] = chessBoard[9,0] = chessBoard[9,9] = "  ";
        
        for (int i=0; i < 9; i++)
        {
            chessBoard[0, i] = chessBoard[9, i] = $"Convert.ToString(Convert.ToChar(65 + i)) ";
        }
        
        //set main chess board body
        for (int i = 0; i < 10; i++)
        {
            chessBoard[i, 0] = chessBoard[i, 9] = $" {i + 1}";
            for (int j = 1; j < 9; j++)
            {
                if (userChoice.InitialCoordinates[i, j] == 1)
                    chessBoard[i,j] = $"{userChoice.Figure} ";
                else if (userChoice.InitialCoordinates[i, j] != 2)
                    chessBoard[i, j] = "**";
                else
                    chessBoard[i, j] = "  ";
            }
        }
        return chessBoard;
    }

    /// <summary>
    /// Checks whether the figure may move to a given coordinates' cell. 
    /// </summary>
    /// <param name="userChoice">USerChoice type object</param>
    /// <returns>boolean value</returns>
    public bool CheckAccessForDestinationCoordinate(UserChoice userChoice)
    {
        Coordinates coordinates = new Coordinates();
        return coordinates.CheckLegalStep(userChoice);
    }
 
}