# Dax Generator

## Description

This library will help you generate dynamic DAX queries

## Usage

```csharp
// Filter Creation
Filter.OnTable("User").WithProperty("Name").EqualsTo("Softcadbury");
Filter.OnRelatedTable("User").WithProperty("CreationDate").GreaterThan(new DateTime(2019, 1, 1));
```
