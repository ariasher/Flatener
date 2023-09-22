using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flattener;

public interface IFlattener
{
    IDictionary<string, string> Flatten(IDictionary<string, object> data);
    IDictionary<string, T?> Flatten<T>(IDictionary<string, object> data);
}
