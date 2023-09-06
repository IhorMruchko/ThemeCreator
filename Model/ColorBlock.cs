using System.Linq;
using System.Windows.Media;

namespace ThemeCreator.Model;

public class ColorBlock : IResourceDictionaryItem, ICodeGenerator
{
    public string Key { get; set; } = string.Empty;

    public Color Value { get; set; }

    public string Generate() 
        => $"<SolidColorBrush x:Key=\"{Key}\" Color=\"{Value}\"/>";

    public static explicit operator ColorBlock(string codePiece)
    {
        var splittedValue = codePiece.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
        var (key, value) = (splittedValue[1], splittedValue[2]);


        return new ColorBlock()
        {
            Key = string.Join(string.Empty, key.SkipWhile(letter => letter != '"').TakeWhile(letter => letter != '"')),
            // Value = (Color)ColorConverter.ConvertFromString(string.Join(string.Empty, value.SkipWhile(letter => letter != '"').TakeWhile(letter => letter != '"'))),
        };
    }
}
