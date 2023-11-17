# KeyDown

## Transform JSON into Easy-to-Read Markdown 
 
```json
{
  "Name": "John Doe",
  "Employment Status": "Full-time",
  "Company": {
    "Name": "ACME Enterprises",
    "Size": "200+"
  }
}
```

results in

```markdown
# Name
John Doe

# Employment Status
Full-time

# Company

## Name
ACME Enterprises

## Size
200+
```

## How to Use the CLI Tool

This solution comes with a simple command line tool. 

The tool accepts a file containing json data and produces a file containing Markdown.

``` bash
KeyDown.Cli.exe -i .\input.json -o .\output.md
```


## Local Development

Follow these instructions to get set up to develop KeyDown locally. You'll need the .Net Core SDK.

1. Clone the project

```bash
  git clone https://github.com/samdanae/KeyDown.git
```

2. Go to the project directory

```bash
  cd KeyDown
```

3. Run the tests

```bash
  dotnet test
```

## Upcoming Features

- JSON Array support
- Link and Image rendering
- Support for other nested key/value formats such as yaml

## Author

- [@samdanae](https://www.github.com/samdanae)
