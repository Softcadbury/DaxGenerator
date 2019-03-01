# Dax Generator

## Description

Data Analysis Expressions (DAX) is a query language for Power BI, SSAS and Power Pivot in Excel.
This library is here to help you generate these DAX queries dynamically.

## Usage

How to generate filters:
```csharp
// 'User'[Name] = "Softcadbury"
Filter.OnTable("User").WithProperty("Name").EqualsTo("Softcadbury");

// RELATED('User'[CreationDate]) > DATEVALUE("01/01/2019")
Filter.OnRelatedTable("User").WithProperty("CreationDate").GreaterThan(new DateTime(2019, 1, 1));

// 'User'[Age] In {30,31,32}
Filter.OnRelatedTable("User").WithProperty("Age").In(new List<int?> { 30,31,32 });
```