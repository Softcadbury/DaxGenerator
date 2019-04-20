namespace DaxGenerator.Queries
{
    using System.Linq;
    using System.Collections.Generic;
    using Filters;

    public class SummarizeColumns
    {
        private readonly string _tableName;
        private readonly List<string> _filters;

        public SummarizeColumns(string tableName)
        {
            _tableName = tableName;
            _filters = new List<string>();
        }

        public void AddFilter(string filter)
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                _filters.Add(filter);
            }
        }

        public override string ToString()
        {
            string filters = string.Empty;

            if (_filters.Any())
            {
                filters = string.Join(Filter.And, _filters);
            }

            return $"EVALUATE SUMMARIZECOLUMNS (FILTER('{_tableName}', {filters}))";
        }
    }
}