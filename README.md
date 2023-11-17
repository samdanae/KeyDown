# KeyDown 
Generate readable markdown from json.

## How it Works
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

## Run Locally

Clone the project

```bash
  git clone https://github.com/samdanae/KeyDown.git
```

Go to the project directory

```bash
  cd KeyDown
```

Run the tests

```bash
  dotnet test
```

## Authors

- [@samdanae](https://www.github.com/samdanae)
