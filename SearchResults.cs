using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Documents;

namespace SeachEngineTest
{
    public class SearchResults
    {
        private readonly Document _doc;

        public SearchResults(Document doc)
        {
            _doc = doc;

        }

        public string DescriptionPath { get; set; }
        public string LinkHref { get; set; }
        public string LinkText { get; set; }

        public void Parse(Action<Document> parseAction) {
            parseAction(_doc);

        }
    }
}
