using System.Collections;
using FluentAssertions;
namespace KeyDown.Cli.Tests;
    
public class ConverterTests
{
    [Theory]
    [ClassData(typeof(ConverterTestData))]
    private static void TestFileWithName(string testFileName)
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;
        var uniqueFileName = Guid.NewGuid().ToString();
        
        if (projectDirectory == null)
        {
            Assert.Fail("Project directory should be present");
        }
        
        var inputFile = Path.Combine(projectDirectory, "input", $"{testFileName}.json");
        var outputFile = Path.Combine(Path.GetTempPath(), $"{uniqueFileName}.md");
        var expectedFile = Path.Combine(projectDirectory, "expected", $"{testFileName}.md");

        File.Exists(inputFile).Should().BeTrue($"{inputFile} should exist in the input folder");
        File.Exists(expectedFile).Should().BeTrue($"{expectedFile} should exist in the expected folder");

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

public class ConverterTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;

        if (projectDirectory == null)
        {
            yield break;
        }
        
        var inputFolder = Path.Combine(projectDirectory, "input");
        
        foreach (var file in Directory.GetFiles(inputFolder, "*.json"))
        {
            yield return new object[] { Path.GetFileNameWithoutExtension(file) };
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}