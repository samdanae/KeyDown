namespace UnitTests.ConversionServiceTests;

public class TestData
{
    public static IEnumerable<object[]> Convert_Outputs_HeadingAndBody =>
        new List<object[]>
        {
            new object[] { "{\"Name\": \"Samdanae Imran\"}", "# Name\nSamdanae Imran\n" },
            new object[] { "{\"Name\": \"Samdanae Imran\", \"Occupation\": \"Software Engineer\"}", "# Name\nSamdanae Imran\n# Occupation\nSoftware Engineer\n" },
        };
    
    public static IEnumerable<object[]> Convert_Throws_Exception_With_Invalid_Input_Data =>
        new List<object[]>
        {
            new object[] { "This is not valid json" },
        };
}