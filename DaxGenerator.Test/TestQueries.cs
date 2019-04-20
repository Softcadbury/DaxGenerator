namespace DaxGenerator.Test
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Queries;
    using Filters;

    public class TestQueries
    {
        private const string TABLE_NAME = "table";
        private const string PROPERTY_NAME = "property";

        [Test]
        public void SummarizeColumns()
        {
            var summarizeColumns = new SummarizeColumns(TABLE_NAME);
            summarizeColumns.AddFilter(Filter.OnTable(TABLE_NAME).WithProperty(PROPERTY_NAME).EqualsTo("Softcadbury"));
            Assert.AreEqual(
                $"EVALUATE SUMMARIZECOLUMNS (FILTER('{TABLE_NAME}', '{TABLE_NAME}'[{PROPERTY_NAME}] = \"Softcadbury\"))",
                summarizeColumns.ToString());
        }
    }
}