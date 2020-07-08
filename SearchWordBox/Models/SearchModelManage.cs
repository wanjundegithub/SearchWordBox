using System.Collections.Generic;
using System.Data;

namespace SearchWordBox.Models
{
    public  class SearchModelManage
    {
        public SearchModelManage(string searchField)
        {
            _searchField = searchField;
            _searchRelativeResults = new List<string>();
        }

        private string _searchField { get; } 

        private List<string> _searchRelativeResults { get; }

        public List<string> GetSearchRelativeResults()
        {
            if(string.IsNullOrEmpty(_searchField))
                return null;
            var searchStr = _searchField.GetProcessString();
            if (string.IsNullOrEmpty(searchStr))
                return null;
            DataTable dataTable = DataHelper.GetRelativeResults(searchStr);
            if(dataTable.Rows.Count<=0)
            {
                return null;
            }
            for(int i=0;i<dataTable.Rows.Count;i++)
            {
                string item = dataTable.Rows[i][1].ToString();
                _searchRelativeResults.Add(item);
            }
            return _searchRelativeResults;
        }

    }
}
