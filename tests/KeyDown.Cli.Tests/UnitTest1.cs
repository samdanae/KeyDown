using FluentAssertions;

namespace KeyDown.Cli.Tests;
using CliWrap;
    
public class ConverterTests
{
    [Fact]
    public async Task Test1()
    {
        var uniqueFileName = Guid.NewGuid().ToString();
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        var rootDirectory = Directory.GetParent(projectDirectory).Parent.FullName;
        var sutExecutable = Path.Combine(rootDirectory, @"src\KeyDown.Cli\bin\Debug\net7.0\KeyDown.Cli.exe");

        var inputFile = Path.Combine(projectDirectory, "input", $"normal.json");
        var outputFile = Path.Combine(projectDirectory, "actual", $"{uniqueFileName}.md");
        var outputDirectory = Path.Combine(projectDirectory, "actual");
        var expectedFile = Path.Combine(projectDirectory, "expected", $"normal.md");

        File.Exists(inputFile).Should().BeTrue();
        
        if (File.Exists(outputFile))
        {
            File.Delete(outputFile);
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }
        
        var result = await Cli.Wrap(sutExecutable)
            .WithArguments(new[] { "-i", inputFile, "-o", outputFile })
            .WithWorkingDirectory(projectDirectory)
            .ExecuteAsync();

        result.ExitCode.Should().Be(0);
        var expectedContent = File.ReadAllText(expectedFile);
        var actualContent = File.ReadAllText(outputFile);
        expectedContent.Should().Be(actualContent);
        
        if (File.Exists(outputFile))
        {
            File.Delete(outputFile);
        }
    }
}