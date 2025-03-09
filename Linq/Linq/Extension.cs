using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public static class Extension
    {
        public static IEnumerable<T> Take<T>(IEnumerable<T> collection)
        {
            return collection;
        }
    }
}
