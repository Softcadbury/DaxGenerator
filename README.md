# Dax Generator

## Description

This library will help you generate dynamic DAX queries

## Usage

```csharp
Filter.OnTable("User").WithProperty("Name").EqualsTo("Softcadbury");
// Return: 'User'[Name] = "Softcadbury"

Filter.OnRelatedTable("User").WithProperty("CreationDate").GreaterThan(new DateTime(2019, 1, 1));
// Return: RELATED('User'[CreationDate]) > DATEVALUE("01/01/2019")

Filter.OnRelatedTable("User").WithProperty("Age").In(new List<int?> { 30,31,32 });
// Return: 'User'[Age] In {30,31,32}
```
