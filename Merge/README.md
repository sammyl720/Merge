# Merged Class Library

## Overview

The `Merged` library provides a simple utility for merging tags within a string. It's a .NET Standard library, making it compatible with a wide range of .NET implementations.

## Installation

### NuGet Package Manager

Run the following command in the Package Manager Console:

```bash
Install-Package Merged -Version 1.0.0
```

### .NET CLI

Alternatively, you can use the .NET CLI to install the package:

```bash
dotnet add package Merged --version 1.0.0
```

## Usage

Here's a quick example to get you started:

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

### Custom Tags

You can also use custom opening and closing tags:

```csharp
// Initialize the MergeTag object with custom tags
var mergeTag = new MergeTag(tags, "{", "}");

// Merge tags within a string
string result = mergeTag.Merge("Hello, {name}. You are {age} years old.");

// Output: "Hello, John. You are 30 years old."
Console.WriteLine(result);
```

## Contributing

If you'd like to contribute, please fork the repository and make changes as you'd like. Pull requests are warmly welcome.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
