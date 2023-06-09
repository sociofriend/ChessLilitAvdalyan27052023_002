using ChessLibrary;
using ChessLibrary.GameFigures;
using static System.Console;

namespace ChessProject;

public class GameLogic
{
    //List<FigureParameters>
    public void AssignFigureParameters(UserDataHandlerGame obj)
    {
        //assign White King initial parameters
        WriteLine("Please select parameters for White King: ");
        UserDataHandlerGame userWK = new UserDataHandlerGame("WK");
        WhiteKing whiteKing = new WhiteKing(userWK.Name, userWK.Coordinates, 
            userWK.Number, userWK.Row, userWK.Colomn, userWK.LegalSteps);
        
        //assign White Queen initial parameters
        WriteLine("Please select parameters for White Queen: ");
        UserDataHandlerGame userWQ = new UserDataHandlerGame("WQ");
        WhiteQueen whiteQueen = new WhiteQueen(userWQ.Name, userWQ.Coordinates, 
            userWQ.Number, userWQ.Row, userWQ.Colomn, userWQ.LegalSteps);
        
        //assign White Rook1 initial parameters
        WriteLine("Please select parameters for White Rook 1: ");
        UserDataHandlerGame userWR1 = new UserDataHandlerGame("WR1");
        WhiteRook1 whiteRook1 = new WhiteRook1(userWR1.Name, userWR1.Coordinates, 
            userWR1.Number, userWR1.Row, userWR1.Colomn, userWR1.LegalSteps);

        //assign White Rook2 initial parameters
        UserDataHandlerGame userWR2 = new UserDataHandlerGame("WR2");
        WhiteRook1 whiteRook2 = new WhiteRook1(userWR2.Name, userWR2.Coordinates, 
            userWR2.Number, userWR2.Row, userWR2.Colomn, userWR2.LegalSteps);

        //assign Black King initial parameters
        WriteLine("Please select parameters for Black King: ");
        UserDataHandlerGame userBK = new UserDataHandlerGame("bK");
        BlackKing blackKing = new BlackKing(userBK.Name, userBK.Coordinates, userBK.Number, 
            userBK.Row, userBK.Colomn, userBK.LegalSteps);
        
        
        /* ALGORITHM */
        
        //methods
        // isShakh() - board method / static
        // isShakh&Mate() - board method / static
        // hasLegalStep(); - all figure
        // bool isPat() // if  !hasLegalStep() && !isCheck() -board method / static
        // replaceFigure() - ջնջել հին կոորդինատները, ավելացնել նորերը (figure object) - all figures/interface
        // IsUnderAttack() -- all figures (the figure coordinates is included in BK.Legal Steps)
        // IsProtected() bool method - in all figures / interface - if the figure coordinages is in
        // legal steps of at least on figure
        // AddLegalSteps after adding all figures to the board
        
        
        s
        
        
        //Properties
        // String[,] board -> wk, wq, wr1, wr2, bk  and nulls
        // List<figure> figures, foreach(figure obj in figures) -> 
        
        //Logic: կտրում ենք երկու թագավորներին իրարից, բաժանում ենք տախտակը երկու սեգմենտի, որ հասկանանք
        //row -+ անենք, հետո նայում ենք երեքից որն ա ամենահեռու սյան մեջ գտնվում, քինգի տակի տող ենք տանում
        // հաջորդին մի սյուն վերև կամ ներքև ու տենց մինչև 
        //հաջորք քայլով աբստրակցիաներն ենք գրում
        //king has the color, and has checkshakh  method(currentboard, destination coordinate), returns bool
        
        

        
        

    }
}
