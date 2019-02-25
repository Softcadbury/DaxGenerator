namespace DaxGenerator.Filters
{
    public static class Filter
    {
        public static FilterProperty OnTable(string tableName)
        {
            return new FilterProperty(tableName, false);
        }

        public static FilterProperty OnRelatedTable(string tableName)
        {
            return new FilterProperty(tableName, true);
        }
    }
}