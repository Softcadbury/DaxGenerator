namespace DaxGenerator.Test
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Filters;

    public class TestFilters
    {
        private const string TABLE_NAME = "table";
        private const string PROPERTY_NAME = "property";
        private const string TEMPLATE_FILTER = "'{0}'[{1}] {2} {3}";
        private const string TEMPLATE_RELATED_FILTER = "RELATED('{0}'[{1}]) {2} {3}";

        [TestCase("value", "\"value\"")]
        [TestCase("  ", "\"  \"")]
        [TestCase("", "\"\"")]
        [TestCase(null, "BLANK()")]
        public void Filter_OnTable_Property_EqualsTo_StringValue(string value, string expectedValue)
        {
            string filter = Filter.OnTable(TABLE_NAME).WithProperty(PROPERTY_NAME).EqualsTo(value);
            AssertFilter(filter, "=", expectedValue);

            string relatedFilter = Filter.OnRelatedTable(TABLE_NAME).WithProperty(PROPERTY_NAME).EqualsTo(value);
            AssertRelatedFilter(relatedFilter, "=", expectedValue);
        }

        [TestCase("value", "\"value\"")]
        [TestCase("  ", "\"  \"")]
        [TestCase("", "\"\"")]
        [TestCase(null, "BLANK()")]
        public void Filter_OnTable_Property_NotEqualsTo_StringValue(string value, string expectedValue)
        {
            string filter = Filter.OnTable(TABLE_NAME).WithProperty(PROPERTY_NAME).NotEqualsTo(value);
            AssertFilter(filter, "<>", expectedValue);

            string relatedFilter = Filter.OnRelatedTable(TABLE_NAME).WithProperty(PROPERTY_NAME).NotEqualsTo(value);
            AssertRelatedFilter(relatedFilter, "<>", expectedValue);
        }

        [TestCase(123456789123456789, "123456789123456789")]
        [TestCase(0, "0")]
        [TestCase(null, "0")]
        public void Filter_OnTable_Property_GreaterThan_NullableLongValue(long? value, string expectedValue)
        {
            string filter = Filter.OnTable(TABLE_NAME).WithProperty(PROPERTY_NAME).GreaterThan(value);
            AssertFilter(filter, ">", expectedValue);

            string relatedFilter = Filter.OnRelatedTable(TABLE_NAME).WithProperty(PROPERTY_NAME).GreaterThan(value);
            AssertRelatedFilter(relatedFilter, ">", expectedValue);
        }

        [TestCase(123456789123456789, "123456789123456789")]
        [TestCase(0, "0")]
        public void Filter_OnTable_Property_GreaterThan_LongValue(long value, string expectedValue)
        {
            string filter = Filter.OnTable(TABLE_NAME).WithProperty(PROPERTY_NAME).GreaterThan(value);
            AssertFilter(filter, ">", expectedValue);

            string relatedFilter = Filter.OnRelatedTable(TABLE_NAME).WithProperty(PROPERTY_NAME).GreaterThan(value);
            AssertRelatedFilter(relatedFilter, ">", expectedValue);
        }

        [TestCase(123, "123")]
        [TestCase(0, "0")]
        [TestCase(null, "0")]
        public void Filter_OnTable_Property_GreaterThan_NullableIntValue(int? value, string expectedValue)
        {
            string filter = Filter.OnTable(TABLE_NAME).WithProperty(PROPERTY_NAME).GreaterThan(value);
            AssertFilter(filter, ">", expectedValue);

            string relatedFilter = Filter.OnRelatedTable(TABLE_NAME).WithProperty(PROPERTY_NAME).GreaterThan(value);
            AssertRelatedFilter(relatedFilter, ">", expectedValue);
        }

        [TestCase(123, "123")]
        [TestCase(0, "0")]
        public void Filter_OnTable_Property_GreaterThan_IntValue(int value, string expectedValue)
        {
            string filter = Filter.OnTable(TABLE_NAME).WithProperty(PROPERTY_NAME).GreaterThan(value);
            AssertFilter(filter, ">", expectedValue);

            string relatedFilter = Filter.OnRelatedTable(TABLE_NAME).WithProperty(PROPERTY_NAME).GreaterThan(value);
            AssertRelatedFilter(relatedFilter, ">", expectedValue);
        }

        [Test]
        public void Filter_OnTable_Property_LessThan_DateTimeValue()
        {
            DateTime valueDateTime = new DateTime(1, 1, 1);

            string filter = Filter.OnTable(TABLE_NAME).WithProperty(PROPERTY_NAME).LessThan(valueDateTime);
            AssertFilter(filter, "<", "DATEVALUE(\"01/01/0001\")");

            string relatedFilter = Filter.OnRelatedTable(TABLE_NAME).WithProperty(PROPERTY_NAME).LessThan(valueDateTime);
            AssertRelatedFilter(relatedFilter, "<", "DATEVALUE(\"01/01/0001\")");
        }

        [Test]
        public void Filter_OnTable_Property_In_NullableIntListValue()
        {
            List<int?> value = new List<int?> { null, 12, 34 };
            string expectedValue = "{0,12,34}";

            string filter = Filter.OnTable(TABLE_NAME).WithProperty(PROPERTY_NAME).In(value);
            AssertFilter(filter, "In", expectedValue);

            string relatedFilter = Filter.OnRelatedTable(TABLE_NAME).WithProperty(PROPERTY_NAME).In(value);
            AssertRelatedFilter(relatedFilter, "In", expectedValue);
        }

        private void AssertFilter(string result, string symbol, string value)
        {
            string expected = string.Format(TEMPLATE_FILTER, TABLE_NAME, PROPERTY_NAME, symbol, value);
            Assert.AreEqual(expected, result);
        }

        private void AssertRelatedFilter(string result, string symbol, string value)
        {
            string expected = string.Format(TEMPLATE_RELATED_FILTER, TABLE_NAME, PROPERTY_NAME, symbol, value);
            Assert.AreEqual(expected, result);
        }
    }
}