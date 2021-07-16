# Dax Generator

## Description

Data Analysis Expressions (DAX) is a query language for Power BI, SSAS and Power Pivot in Excel (https://docs.microsoft.com/en-us/dax/).
This library is here to help you generate these DAX queries dynamically.

## Usage

How to generate filters:
```csharp
// 'User'[Name] = "Softcadbury"
Filter.OnTable("User").WithProperty("Name").EqualsTo("Softcadbury");

// RELATED('User'[CreationDate]) > DATEVALUE("01/03/2019")
Filter.OnRelatedTable("User").WithProperty("CreationDate").GreaterThan(new DateTime(2019, 3, 1));

// 'User'[Age] In {30,31,32}
Filter.OnRelatedTable("User").WithProperty("Age").In(new List<int?> { 30,31,32 });
```

How to generate queries:
```csharp
// EVALUATE SUMMARIZECOLUMNS (FILTER('User', 'User'[Name] = "Softcadbury" && 'User'[Age] In {30,31,32}))
var summarizeColumns = new SummarizeColumns("User");
summarizeColumns.AddFilter(Filter.OnTable("User").WithProperty("Name").EqualsTo("Softcadbury"));
summarizeColumns.AddFilter(Filter.OnRelatedTable("User").WithProperty("Age").In(new List<int?> { 30,31,32 }));
```
