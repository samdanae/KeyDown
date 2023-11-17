using ApplicationCore;
using CommandLine;

namespace KeyDown.Cli;

public class Program
{
    public class Options
    {
        [Option('i', "input", Required = true, HelpText = "Specify input json file")]
        public string? InputFile { get; set; }
            
        [Option('o', "output", Required = true, HelpText = "Specify output md file path")]
        public string? OutputFile { get; set; }
    }

    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args).WithParsed(o =>
        {
            Console.WriteLine($"Parsing {o.InputFile}...");
            var inputFileString = File.ReadAllText(o.InputFile ?? throw new InvalidOperationException());
            using var outputFileStream = File.AppendText(o.OutputFile ?? throw new InvalidOperationException());
                    
            IConversionService converter = new ConversionService();
            var markDown = converter.ConvertToMarkdown(inputFileString);
            outputFileStream.WriteAsync(markDown);
            Console.WriteLine($"Wrote output to {o.OutputFile}");
        });
    }
}