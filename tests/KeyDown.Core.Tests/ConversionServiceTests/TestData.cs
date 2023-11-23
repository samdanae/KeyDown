namespace UnitTests.ConversionServiceTests;

public class TestData
{
    public static IEnumerable<object[]> HeadingAndBodyTestCase =>
        new List<object[]>
        {
            new object[]
            {
                "{\"Name\" : \"\"}", 
                $"# Name{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}"
            },
            new object[]
            {
                "{ \"Name\": \"\", \"Employment Status\": \"\" }", 
                $"# Name{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}# Employment Status{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}"
            },
            new object[]
            {
                "{\"Name\": \"John Doe\"}", 
                $"# Name{Environment.NewLine}John Doe{Environment.NewLine}{Environment.NewLine}"
            },
            new object[]
            {
                "{\"Name\": \"John Doe\", \"Occupation\": \"Software Engineer\"}", 
                $"# Name{Environment.NewLine}John Doe{Environment.NewLine}{Environment.NewLine}# Occupation{Environment.NewLine}Software Engineer{Environment.NewLine}{Environment.NewLine}"
            },
        };
    
    public static IEnumerable<object[]> NestedTestCase =>
        new List<object[]>
        {
            new object[]
            {
                "{\"Name\": \"John Doe\",\"Employment Status\": \"Full-time\",\"Company\": {\"Name\": \"ACME Industries\",\"Size\": \"200+\"}}", 
                $"# Name{Environment.NewLine}John Doe{Environment.NewLine}{Environment.NewLine}# Employment Status{Environment.NewLine}Full-time{Environment.NewLine}{Environment.NewLine}# Company{Environment.NewLine}{Environment.NewLine}## Name{Environment.NewLine}ACME Industries{Environment.NewLine}{Environment.NewLine}## Size{Environment.NewLine}200+{Environment.NewLine}{Environment.NewLine}"
            },
        };
    
    public static IEnumerable<object[]> ArrayWithKeyTestCase =>
        new List<object[]>
        {
            new object[]
            {
                "{\"Conference Attendees\" : [{\"Name\": \"John Doe\", \"Occupation\": \"Technologist\"}, {\"Name\": \"Jane Doe\", \"Occupation\": \"Technician\"}]}", 
                $"# Conference Attendees{Environment.NewLine}{Environment.NewLine}## Name{Environment.NewLine}John Doe{Environment.NewLine}{Environment.NewLine}## Occupation{Environment.NewLine}Technologist{Environment.NewLine}{Environment.NewLine}***{Environment.NewLine}{Environment.NewLine}## Name{Environment.NewLine}Jane Doe{Environment.NewLine}{Environment.NewLine}## Occupation{Environment.NewLine}Technician{Environment.NewLine}{Environment.NewLine}***{Environment.NewLine}{Environment.NewLine}"
            },
        };    
    
    public static IEnumerable<object[]> TopLevelArrayTestCase =>
        new List<object[]>
        {
            new object[]
            {
                "[ { \"Name\": \"Team Core\", \"State\": \"Enabled\", \"User\": { \"Name\": \"John Doe\", \"Type\": \"User\" } }, { \"Name\": \"Cloud - Pre-production\", \"State\": \"Enabled\", \"User\": { \"Name\": \"Jane Doe\", \"Type\": \"User\" } }, { \"Name\": \"Automated Integration Test Subscription\", \"State\": \"Enabled\", \"User\": { \"Name\": \"Jane Doe\", \"Type\": \"User\" } }]", 
                $"# Name{Environment.NewLine}Team Core{Environment.NewLine}{Environment.NewLine}# State{Environment.NewLine}Enabled{Environment.NewLine}{Environment.NewLine}# User{Environment.NewLine}{Environment.NewLine}## Name{Environment.NewLine}John Doe{Environment.NewLine}{Environment.NewLine}## Type{Environment.NewLine}User{Environment.NewLine}{Environment.NewLine}***{Environment.NewLine}{Environment.NewLine}# Name{Environment.NewLine}Cloud - Pre-production{Environment.NewLine}{Environment.NewLine}# State{Environment.NewLine}Enabled{Environment.NewLine}{Environment.NewLine}# User{Environment.NewLine}{Environment.NewLine}## Name{Environment.NewLine}Jane Doe{Environment.NewLine}{Environment.NewLine}## Type{Environment.NewLine}User{Environment.NewLine}{Environment.NewLine}***{Environment.NewLine}{Environment.NewLine}# Name{Environment.NewLine}Automated Integration Test Subscription{Environment.NewLine}{Environment.NewLine}# State{Environment.NewLine}Enabled{Environment.NewLine}{Environment.NewLine}# User{Environment.NewLine}{Environment.NewLine}## Name{Environment.NewLine}Jane Doe{Environment.NewLine}{Environment.NewLine}## Type{Environment.NewLine}User{Environment.NewLine}{Environment.NewLine}***{Environment.NewLine}{Environment.NewLine}"
            },
        };
    
    public static IEnumerable<object[]> InvalidInputData =>
        new List<object[]>
        {
            new object[] { "This is not valid json" },
        };
}