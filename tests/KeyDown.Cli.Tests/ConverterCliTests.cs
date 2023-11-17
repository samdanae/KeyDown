using FluentAssertions;
namespace KeyDown.Cli.Tests;
    
public class ConverterTests
{
    [Fact]
    public void TestNormalInputProducesOutput()
    {
        var uniqueFileName = Guid.NewGuid().ToString();
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;

        if (projectDirectory == null)
        {
            Assert.Fail("Project directory should be present");
        }
        
        var inputFile = Path.Combine(projectDirectory, "input", $"normal.json");
        var outputFile = Path.Combine(Path.GetTempPath(), $"{uniqueFileName}.md");
        var expectedFile = Path.Combine(projectDirectory, "expected", $"normal.md");

        File.Exists(inputFile).Should().BeTrue();
        
        var args = new[] { "-i", inputFile, "-o", outputFile };
        Program.Main(args);

        var expectedContent = File.ReadAllText(expectedFile);
        var actualContent = File.ReadAllText(outputFile);
        expectedContent.Should().Be(actualContent);
        
        if (File.Exists(outputFile))
        {
            File.Delete(outputFile);
        }
    }
}