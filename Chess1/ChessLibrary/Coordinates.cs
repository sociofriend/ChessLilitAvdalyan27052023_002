using ChessLibrary.Figures;

namespace ChessLibrary;

public class Coordinates
{
   
   #region - Properties
   public int Row { get; set; }  
   public int Colomn { get; set; }  
   public int Sum { get; set; }  
   public int Dif { get; set; }  
   public int FigureNumber { get; set; }
   public string FigureString { get; set; }
   #endregion

   #region - Manipulations with coordinates
   /// <summary>
   /// Initialises properties by assigning the respective values
   /// out of operations with coordinates.
   /// </summary>
   /// <param name="Coordinates">int type two-dimensional array</param>
   public void AssignValues(int[,] Coordinates)
   {
      for (int i = 0; i < 8; i++)
      {
         for (int j = 0; j < 8; j++)
         {
            if (Coordinates[i, j] == 1)
            {
               Row = i;
               Colomn = j;
               Sum = i + j;
               Dif = i - j;
               FigureNumber = ConvertToNumber(i, j);
               FigureString = ConvertToString(i, j);
            }
         }
      }
   }

   /// <summary>
   /// Creates a two-symbol integer from two one-symbol integers.
   /// </summary>
   /// <param name="i">Integer type variable.</param>
   /// <param name="j">Integer type variable.</param>
   /// <returns>Integer.</returns>
   public int ConvertToNumber(int i, int j)
   {
     return int.Parse(string.Concat(i.ToString(), j.ToString()));
   }
   
   /// <summary>
   /// Creates a two-symbol string from two one-symbol integers.
   /// </summary>
   /// <param name="i"></param>
   /// <param name="j"></param>
   /// <returns></returns>
   public string ConvertToString(int i, int j)
   {
      return string.Concat(i.ToString(), j.ToString());
   }

   /// <summary>
   /// Generates two-dimensional array out of string input of Figure
   /// </summary>
   /// <param name="i">int type argument</param>
   /// <param name="j">int type argument</param>
   /// <returns>Returns two-dimensional array</returns>
   public int[,] CreateArray2D(int i, int j)
   {
      int[,] coordinates = new int[8, 8];
      coordinates[i, j] = 1;
      return coordinates;
   }

   /// <summary>
   /// Modifies array by assinging "2" value to coordinates' cells identified as legal step by respective class method.
   /// </summary>
   /// <param name="Figure">string type argument</param>
   /// <param name="Coordinates">2D type argument</param>
   /// <returns>Returns two-dimensional array with added legal steps.</returns>
   public void AddLegalSteps(string Figure, int[,] Coordinates)
   {
      #region Figure objects
      Bishop bishop = new Bishop();
      King king = new King();
      Knight knight = new Knight();
      Queen queen = new Queen();
      Rook rook = new Rook();
      #endregion
      
      switch (Figure)
      {
         case "b": 
            bishop.AddLegalSteps(Figure, Coordinates);
            break;
         case "K":
            king.AddLegalSteps(Figure, Coordinates);
            break;
         case "N":
            knight.AddLegalSteps(Figure, Coordinates);
         break;
         case "Q":
            queen.AddLegalSteps(Figure, Coordinates);
            break;
         // case "R":
         //    rook.AddLegalSteps(Figure, Coordinates);
         //    break;
      }
   }
   #endregion
}