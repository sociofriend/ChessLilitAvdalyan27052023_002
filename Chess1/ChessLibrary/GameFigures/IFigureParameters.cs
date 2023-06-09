namespace ChessLibrary.GameFigures;

public interface IFigureParameters //ինտերֆեյսը սարքել I տառով դիմացից
{
    string Name { get; set; }
    int[,] Coordinates { get; set; }
    int Number { get; set; }
    string NumberStr { get; set; }
    int Row { get; set; }
    int Colomn { get; set; }
    
    string StepSymbol { get; set; }
    List<int> LegalSteps { get; set; }

    // public bool Check(int[,] Array, int Number )
    // {
    //     for(int i = 0; i < 8; i ++)
    //     {
    //         for(int j = 0; j < 8; j++)
    //         {
    //             if ((Array[i, j] == 1) && (i == Number / 10) && (j == Number % 10))
    //             {
    //                 return true;
    //             }
    //         }
    //     }
    //
    //     return false;
    // }
}
