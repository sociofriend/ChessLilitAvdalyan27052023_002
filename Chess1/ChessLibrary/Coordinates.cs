using ChessLibrary.Figures;

namespace ChessLibrary;

public class Coordinates
{
   #region - Properties
   public int Row { get; set; }  
   public int Colomn { get; set; }  
   public int Sum { get; set; }  
   public int Dif { get; set; }  
   public int FigureNumber { get; set; } //figure-specific property
   public string FigureString { get; set; }
   #endregion


   /// <summary>
   /// Initialises properties by assigning the respective values
   /// out of operations with coordinates.
   /// </summary>
   /// <param name="Coordinates">int type two-dimensional array</param>
   public void AssignValuesToLocalProperties(int[,] Coordinates)
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
               FigureNumber = ConvertCoordinatesToNumber(i, j); // tanel figures
               FigureString = ConvertCoordinatesToString(i, j);
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
   public int ConvertCoordinatesToNumber(int i, int j)
   {
     return int.Parse(string.Concat(i.ToString(), j.ToString()));
   }
   
   /// <summary>
   /// Creates a two-symbol string from two one-symbol integers.
   /// </summary>
   /// <param name="i"></param>
   /// <param name="j"></param>
   /// <returns></returns>
   public string ConvertCoordinatesToString(int i, int j)
   {
      return string.Concat(i.ToString(), j.ToString());
   }

   /// <summary>
   /// Generates two-dimensional array out of string input of Figure
   /// </summary>
   /// <param name="i">int type argument</param>
   /// <param name="j">int type argument</param>
   /// <returns>Returns two-dimensional array</returns>
   public int[,] Create2DArrayByCoordinates(int i, int j)
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
      //King king = new King();
      Knight knight = new Knight();
      //Queen queen = new Queen();
      //Rook rook = new Rook();
      #endregion
      
      switch (Figure)
      {
         case "b": 
            bishop.AddLegalSteps(Figure, Coordinates);
            break;
         // case "K":
         //    king.AddLegalSteps(Figure, Coordinates);
         //    break;
         case "N":
            knight.AddLegalSteps(Figure, Coordinates);
         break;
         // case "Q":
         //    queen.AddLegalSteps(Figure, Coordinates);
         //    break;
         // case "R":
         //    rook.AddLegalSteps(Figure, Coordinates);
         //    break;
      }
   }

   /// <summary>
   /// Compares user's destination coordinates with the coordinates of the legal steps of the figure with initial coordinates.
   /// </summary>
   /// <param name="userChoice">UserChoice type object.</param>
   /// <returns>Returns boolean value.</returns>
   public bool CheckLegalStep(UserChoice userChoice)
   {
      if (userChoice.InitialCoordinates == userChoice.DestinationCoordinates)
         return true;
      int[,] coordinates = userChoice.InitialCoordinates;
      AddLegalSteps(userChoice.Figure, coordinates);
      
      AssignValuesToLocalProperties(userChoice.DestinationCoordinates);
      int destFigureNumber = FigureNumber;
      
      for (int i = 0; i < 8; i++)
      {
         for (int j = 0; j < 8; j++)
         {
            if (ConvertCoordinatesToNumber(i, j) == FigureNumber && coordinates[i, j] == 2)
               return true;
         }
      }

      return false;
   }
   
   /// <summary>
   /// Creates and returns List type collection of legal steps' coordinates coverted to number.
   /// </summary>
   /// <param name="userChoice">UserChoice type object.</param>
   /// <returns>Returns List type collection.</returns>
   public List<int> CollectLegalStepsInList(UserChoice userChoice)
   {
      List<int> legalStepsNumbers = new List<int>();
      int[,] localInitialCoordiantes = userChoice.InitialCoordinates;
      AddLegalSteps(userChoice.Figure, localInitialCoordiantes);
      for (int i = 0; i < 8; i++)
      {
         for (int j = 0; j < 8; j++)
         {
            if (localInitialCoordiantes[i, j] == 2)
            {  
               legalStepsNumbers.Add(ConvertCoordinatesToNumber(i,j));
            }
         }
      }
      return legalStepsNumbers;
   }

   
   public List<int> CollectLegalStepsInList(string figure, int[,] array)
   {
      List<int> legalStepsNumbers = new List<int>();
      int[,] localInitialCoordiantes = array;
      AddLegalSteps(figure, localInitialCoordiantes);
      for (int i = 0; i < 8; i++)
      {
         for (int j = 0; j < 8; j++)
         {
            if (localInitialCoordiantes[i, j] == 2)
            {  
               legalStepsNumbers.Add(ConvertCoordinatesToNumber(i,j));
            }
         }
      }
      return legalStepsNumbers;
   }
}