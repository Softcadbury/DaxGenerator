namespace DaxGenerator.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterSymbol
    {
        private readonly string _tableName;
        private readonly bool _isRelated;
        private readonly string _propertyName;

        internal FilterSymbol(string tableName, bool isRelated, string propertyName)
        {
            _tableName = tableName;
            _isRelated = isRelated;
            _propertyName = propertyName;
        }

        public string EqualsTo<T>(T value)
        {
            return GetFilter("=", value);
        }

        public string NotEqualsTo<T>(T value)
        {
            return GetFilter("<>", value);
        }

        public string GreaterThan<T>(T value)
        {
            return GetFilter(">", value);
        }

        public string LessThan<T>(T value)
        {
            return GetFilter("<", value);
        }

        public string In<T>(List<T> values)
        {
            return GetFilter("In", "{" + string.Join(",", values.Select(GetFormattedValue)) + "}", false);
        }

        private string GetFilter<T>(string symbol, T value, bool hasToFormatValue = true)
        {
            string filterValue = hasToFormatValue ? GetFormattedValue(value) : value.ToString();

            if (_isRelated)
            {
                return $"RELATED('{_tableName}'[{_propertyName}]) {symbol} {filterValue}";
            }

            return $"'{_tableName}'[{_propertyName}] {symbol} {filterValue}";
        }

        private string GetFormattedValue<T>(T value)
        {
            if (value == null)
            {
                if (typeof(T) == typeof(string))
                {
                    return "BLANK()";
                }

                if (typeof(T) == typeof(int?) || typeof(T) == typeof(long?))
                {
                    return "0";
                }
            }
            else
            {
                switch (value)
                {
                    case string stringValue:
                        return $"\"{stringValue.Replace("\\", "\\\\").Replace("\"", "\\\"")}\"";

                    case int _:
                    case long _:
                        return value.ToString();

                    case DateTime dateTimeValue:
                        return $"DATEVALUE(\"{dateTimeValue:MM'/'dd'/'yyyy}\")";
                }
            }

            throw new ArgumentOutOfRangeException($"Type: {typeof(T)} with value: {value} not handled");
        }
    }
}