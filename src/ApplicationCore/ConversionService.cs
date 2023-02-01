using System.Text;

namespace ApplicationCore;
using SpanJson;
public class ConversionService : IConversionService
{
    public string Convert(string jsonInput)
    {
        var deserialized = JsonSerializer.Generic.Utf16.Deserialize<Dictionary<string, string>>(jsonInput);
        var sb = new StringBuilder();
        foreach (var pair in deserialized)
        {
            sb.Append(ConvertToMarkdown(pair));
        }
        return sb.ToString();
    }
    
    private static string ConvertToMarkdown(KeyValuePair<string, string> kvp)
    {
        var key = kvp.Key;
        var value = kvp.Value;
        
        return $"# {key}\n{value}\n";
    }
}


// This JsonConstructorAttribute allows overwriting the matching names of the constructor parameter names to allow for different member names vs. constructor parameter names, order is important here
public readonly struct NamedDo
{
    [JsonConstructor(nameof(Key), nameof(Value))]
    public NamedDo(string first, string second)
    {
        Key = first;
        Value = second;
    }


    public string Key { get; }
    public string Value { get; }
}