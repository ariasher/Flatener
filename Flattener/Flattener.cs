using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flattener;

public class Flattener : IFlattener
{
    private IDictionary<string, string> _result;

    public async Task<IDictionary<string, string>> FlattenAsync(IDictionary<string, object> data)
    {
        _result = new Dictionary<string, string>();

        foreach (var item in data)
        {
            string key = item.Key;
            await FlattenDictionaryAsync(key, item.Value);
        }

        return _result;
    }

    private async Task FlattenDictionaryAsync(string parentKey, object data, List<Task> tasks = null)
    {
        string finalKey = string.Empty;
        string value = string.Empty;
        tasks ??= new List<Task>();

        if (data is not IDictionary<string, object> || data == null)
        {
            finalKey = parentKey;
            value = JsonSerializer.Serialize(data);

            _result.Add(finalKey, value);
            return;
        }

        foreach (var d in (Dictionary<string, object>)data)
        {
            string key = $"{parentKey}:{d.Key}";
            var result = FlattenDictionaryAsync(key, d.Value, tasks);
            tasks.Add(result);
        }

        await Task.WhenAll(tasks);
    }
}
