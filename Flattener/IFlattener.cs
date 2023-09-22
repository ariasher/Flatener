using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flattener;

public interface IFlattener
{
    Task<IDictionary<string, string>> FlattenAsync(IDictionary<string, object> data);
    //Task<IDictionary<string, T?>> Flatten<T>(IDictionary<string, object> data);
}
