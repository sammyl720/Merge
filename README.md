# Merge Solution

## Overview

The `Merge` solution is a C# project aimed at providing a utility for merging tags within a string. It consists of two projects:

1. **Merged**: A class library that contains the core functionality.
2. **MergeTests**: A test project that validates the functionality of the `Merged` library.

## Getting Started

### Prerequisites

- .NET SDK
- NUnit 3.13.3 or higher for running tests

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/sammyl720/Merge.git
    ```
2. Navigate to the project directory:
    ```bash
    cd Merge
    ```

3. Restore the NuGet packages:
    ```bash
    dotnet restore
    ```

### Usage

To use the `MergeTag` class in your project, add a reference to the `Merged` library.

Here's a simple example:

```csharp
using Merge;  // Make sure to include the namespace

// Initialize the tags dictionary
var tags = new Dictionary<string, object>
{
    { "name", "John" },
    { "age", 30 }
};

// Initialize the MergeTag object
var mergeTag = new MergeTag(tags);

// Merge tags within a string
string result = mergeTag.Merge("Hello, <name>. You are <age> years old.");

// Output: "Hello, John. You are 30 years old."
Console.WriteLine(result);
```

## Running Tests

To run the tests, navigate to the root directory and execute:

```bash
dotnet test
```

## Contributing

If you'd like to contribute, please fork the repository and make changes as you'd like. Pull requests are warmly welcome.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
