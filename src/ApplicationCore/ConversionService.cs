using System.Text;
using System.Text.Json;

namespace ApplicationCore;

public class ConversionService : IConversionService
{
    private static readonly string UpcomingHeadingNewLines = $"{Environment.NewLine}{Environment.NewLine}";

    private static string ConvertToMarkdown(JsonElement element, int level)
    {
        var sb = new StringBuilder();   
        var levelString = new string('#', level);
        
        foreach (var pair in element.EnumerateObject())
        {
            var key = pair.Name;
            var value = pair.Value;
            
            switch (value.ValueKind)
            {
                // All recursive paths should hit a dead-end at these JsonValueKinds, so only append a newline here, and nowhere else.  
                case JsonValueKind.String:
                case JsonValueKind.Number:
                case JsonValueKind.True:
                case JsonValueKind.False:
                    sb.Append($"{levelString} {key}{Environment.NewLine}{value}{UpcomingHeadingNewLines}");
                    break;
                case JsonValueKind.Object:
                    sb.Append($"{levelString} {key}{UpcomingHeadingNewLines}{ConvertToMarkdown(value, level + 1)}");
                    break;
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    sb.Append($"{levelString} {key}{Environment.NewLine}{UpcomingHeadingNewLines}");
                    break;
                case JsonValueKind.Array:
                    sb.Append($"{levelString} {key}{UpcomingHeadingNewLines}");
                    var arrayEnumerator = value.EnumerateArray();
                    foreach (var arrayElement in arrayEnumerator)
                    {
                        sb.Append(ConvertToMarkdown(arrayElement, level + 1));
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return sb.ToString();
    }

    public string ConvertToMarkdown(string jsonInput)
    {
        var input = JsonSerializer.Deserialize<JsonElement>(jsonInput);
        return ConvertToMarkdown(input, 1);
    }
}