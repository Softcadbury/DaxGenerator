namespace DaxGenerator.Filters
{
    public class FilterProperty
    {
        private readonly string _tableName;
        private readonly bool _isRelated;

        public FilterProperty(string tableName, bool isRelated)
        {
            _tableName = tableName;
            _isRelated = isRelated;
        }

        public FilterSymbol WithProperty(string propertyName)
        {
            return new FilterSymbol(_tableName, _isRelated, propertyName);
        }
    }
}