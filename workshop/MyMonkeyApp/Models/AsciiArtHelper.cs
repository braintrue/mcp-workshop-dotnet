namespace MyMonkeyApp.Models;

public static class AsciiArtHelper
{
    private static readonly string[] ArtList = new[]
    {
@" (\_._/) 
 ( o o ) 
  > ^ < ",
@"  (\__/)
  (•ㅅ•)
  / 　 づ ",
@"   (o.o)
    (> <)
   (   )"
    };

    private static readonly Random random = new();

    public static string GetRandomArt()
    {
        return ArtList[random.Next(ArtList.Length)];
    }
}
