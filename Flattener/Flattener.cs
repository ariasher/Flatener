using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flattener;

public class Flattener : IFlattener
{
    public IDictionary<string, string> Flatten(IDictionary<string, object> data)
    {
        throw new NotImplementedException();
    }

    public IDictionary<string, T?> Flatten<T>(IDictionary<string, object> data)
    {
        throw new NotImplementedException();
    }
}
