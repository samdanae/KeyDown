using ApplicationCore;

namespace UnitTests;

using FluentAssertions;

public class ConverterTests
{
    [Theory]
    // [InlineData("{\"Name\": \"Samdanae Imran\", \"Name\": \"Samdanae Imran\"}", "# Name\nSamdanae Imran\n# Name\nSamdanae Imran\n")]
    [InlineData("{\"Name\": \"Samdanae Imran\"}", "# Name\nSamdanae Imran\n")]
    [InlineData("{\"Name\": \"Samdanae Imran\", \"Occupation\": \"Software Engineer\"}", "# Name\nSamdanae Imran\n# Occupation\nSoftware Engineer\n")]
    public void Convert_Outputs_HeadingAndBody(string input, string expectedOutput)
    {
        IConversionService converter = new ConversionService();

        var actual = converter.Convert(input);
        actual.Should().Be(expectedOutput);
    }
}