using static System.Console;
namespace ChessProject;


public class Chess
{

    // Properties
    public string Figure { get; set; }  
    public string AlgebraicNotation { get; set; }
    public int[,] Coordinates { get; set; }
    
    //methods
    public void RunChess()
    {
        
        Figure = ReadLine();
    }
    
}