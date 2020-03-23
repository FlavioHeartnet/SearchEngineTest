using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeachEngineTest
{
    interface ISearchManeger
    {
        void AddToIndex(params Searchbles[] searchables);
    }
}
