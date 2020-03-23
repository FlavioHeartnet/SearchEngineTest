using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Microsoft.AspNetCore.Hosting;

namespace SeachEngineTest
{
    public class SearchManeger : ISearchManeger
    {
        private static FSDirectory _directory;
        private readonly IHostingEnvironment _env;

        public SearchManeger(IHostingEnvironment env)
        {
            _env = env;
        }

        private FSDirectory Directory
        {
            get
            {
                if (_directory != null)
                {
                    return _directory;
                }

                var info = System.IO.Directory.CreateDirectory(LuceneDir);
                return _directory = FSDirectory.Open(info);
            }
        }

        private string LuceneDir => Path.Combine(_env.ContentRootPath, "Lucene_Index");

        public void AddToIndex(params Searchbles[] searchables)
        {
            UseWriter(x =>
            {
                foreach (var searchable in searchables)
                {
                    var doc = new Document();
                    foreach (var field in searchable.GetFields())
                    {
                        doc.Add(field);
                    }
                    x.AddDocument(doc);
                }
            });
        }
        private void UseWriter(Action<IndexWriter> action)
        {
            using (var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_CURRENT))
            {
                using (var writer = new IndexWriter(Directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
                {
                    action(writer);
                    writer.Commit();
                }
            }
        }
    }
}
