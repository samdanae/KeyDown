using ApplicationCore;
using FluentAssertions;

namespace UnitTests.ConversionServiceTests;

public class ConverterTests
{
    [Theory]
    [MemberData(nameof(TestData.HeadingAndBodyTestCase), MemberType= typeof(TestData))]
    [MemberData(nameof(TestData.NestedTestCase), MemberType= typeof(TestData))]
    [MemberData(nameof(TestData.ArrayWithKeyTestCase), MemberType= typeof(TestData))]
    [MemberData(nameof(TestData.TopLevelArrayTestCase), MemberType= typeof(TestData))]
    public void Convert_Outputs_HeadingAndBody(string input, string expectedOutput)
    {
        IConversionService converter = new ConversionService();

        var actual = converter.ConvertToMarkdown(input);
        actual.Should().Be(expectedOutput);
    }
    
    [Theory]
    [MemberData(nameof(TestData.InvalidInputData), MemberType= typeof(TestData))]
    public void Convert_Throws_Exception_With_Invalid_Input(string input)
    {
        IConversionService converter = new ConversionService();

        Action a = () => converter.ConvertToMarkdown(input);
        a.Should().Throw<System.Text.Json.JsonException>();
    }
}