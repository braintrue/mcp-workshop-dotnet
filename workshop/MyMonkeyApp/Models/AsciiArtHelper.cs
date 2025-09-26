namespace MyMonkeyApp.Models;

public static class AsciiArtHelper
{
    private static readonly string[] ArtList = new[]
    {
        @"  __,="""=,__
 ( o o )
 /  V  \",
        @"   w  c( .. )o   (
    \\__( - )    ,
        /    )
       (__)__)",
        @"   (o\_/o)
  (='.'=)
  (( )_( ))",
        @"   (o.o)
   (> <)
  (     )",
    };
    private static readonly Random random = new();

    public static string GetRandomArt()
    {
        return ArtList[random.Next(ArtList.Length)];
    }
}
