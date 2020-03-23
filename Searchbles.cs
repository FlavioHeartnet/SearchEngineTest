using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeachEngineTest
{
    public abstract class Searchbles
    {
        public static readonly Dictionary<Field, string> FieldStrings = new Dictionary<Field, string>
        {
            {Field.Description, "Description"},
            {Field.DescriptionPath, "DescriptionPath"},
            {Field.Href, "Href"},
            {Field.Id, "Id"},
            {Field.Title, "Title"}
        };

        public static readonly Dictionary<Field, string> AnalyzedFields = new Dictionary<Field, string>
        {
            {Field.Description, FieldStrings[Field.Description] },
            {Field.Title, FieldStrings[Field.Title] }
        };

        public abstract string Description { get; }
        public abstract string DescriptionPath { get; }
        public abstract string Href { get; }
        public abstract int Id { get; }
        public abstract string Title { get; }

        public enum Field
        {
            Description,
            DescriptionPath,
            Href,
            Id,
            Title
        }

        public Lucene.Net.Documents.Field[] GetFields()
        {
            return new Lucene.Net.Documents.Field[]
            {
                new Lucene.Net.Documents.Field(AnalyzedFields[Field.Description], Description, Lucene.Net.Documents.Field.Store.NO, Lucene.Net.Documents.Field.Index.ANALYZED),
                new Lucene.Net.Documents.Field(AnalyzedFields[Field.Title], Title, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED){ Boost = 4.0f },
                new Lucene.Net.Documents.Field(FieldStrings[Field.Id], Id.ToString(), Lucene.Net.Documents.Field.Store.YES,Lucene.Net.Documents.Field.Index.ANALYZED),
                new Lucene.Net.Documents.Field(FieldStrings[Field.DescriptionPath], DescriptionPath, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED),
                new Lucene.Net.Documents.Field(FieldStrings[Field.Href], Href, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED)
            };
        }
    }
}
