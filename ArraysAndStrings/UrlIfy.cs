using System.Text.RegularExpressions;

namespace CtciExercises.ArraysAndStrings
{
   public static class UrlIfy
   {
      public static int FindLastChar(string input)
      {
         const string pattern = " *$";
         var regex = new Regex(pattern);
         return regex.Match(input).Index;
      }
   }
}