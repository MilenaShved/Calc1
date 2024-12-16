using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Calc.Storage
{
    public class Session
    {
        private readonly string path = "session.json";

        public async Task SaveAsync(List<Step> steps)
        {
            string json = JsonSerializer.Serialize(steps);
            await File.WriteAllTextAsync(path, json);
        }

        public async Task<List<Step>> LoadAsync()
        {
            if (File.Exists(path))
            {
                string json = await File.ReadAllTextAsync(path);
                var steps = JsonSerializer.Deserialize<List<Step>>(json) ?? new List<Step>();
                return steps;
            }
            else
            {
                return new List<Step>();
            }
        }
    }
}
