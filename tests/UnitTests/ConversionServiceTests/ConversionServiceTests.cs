using ApplicationCore;
using FluentAssertions;

namespace UnitTests.ConversionServiceTests;

public class ConverterTests
{
    [Theory]
    [MemberData(nameof(TestData.Convert_Outputs_HeadingAndBody), MemberType= typeof(TestData))]
    public void Convert_Outputs_HeadingAndBody(string input, string expectedOutput)
    {
        IConversionService converter = new ConversionService();

        var actual = converter.Convert(input);
        actual.Should().Be(expectedOutput);
    }
    
    [Theory]
    [MemberData(nameof(TestData.Convert_Throws_Exception_With_Invalid_Input_Data), MemberType= typeof(TestData))]
    public void Convert_Outputs_Blank_With_Invalid_Input(string input, string expectedOutput)
    {
        IConversionService converter = new ConversionService();

        var actual = converter.Convert(input);
        actual.Should().Be(expectedOutput);
    }
}