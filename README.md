
# Nutshell 🥜🐚

Generate Markdown (and beyond) simply by defining your content in JSON. 

Output is based on the natural structure of the JSON data itself, so that means there is no markup needed, nothing to learn - not even markdown.

## Overview

[Markdown](https://daringfireball.net/projects/markdown/syntax) is great. It lets anyone express entire articles and documents in an easy to handle, readable syntax.

Nutshell is another spin on marking up content, but without any syntax. Its purpose is to allow anyone to generate anything that Markdown can be used to generate (HTML, pdf, etc), by using the JSON/YAML format's naturally nested structure. 

Nutshell organises content into headings of varying levels based on how the content is nested in JSON/YAML.

It doesn't interfere with your content. Feel free to place whatever Markdown you like in JSON/YAML and Nutshell will pass it along to the output.

## Run Locally

Clone the project

```bash
  git clone https://github.com/samdanae/Nutshell.git
```

Go to the project directory

```bash
  cd Nutshell
```

Run the tests

```bash
  dotnet test
```

## Tech Stack

**JSON Deserialiser:** [SpanJson](https://github.com/Tornhoof/SpanJson) 🚀



## Authors

- [@samdanae](https://www.github.com/samdanae)
