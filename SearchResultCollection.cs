using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeachEngineTest
{
    public class SearchResultCollection
    {
        private List<SearchResults> _data;

        public int Count { get; set; }
        public List<SearchResults> Data
        {
            get => _data ?? (_data = new List<SearchResults>());
            set => _data = value;

        }
    }
} 
