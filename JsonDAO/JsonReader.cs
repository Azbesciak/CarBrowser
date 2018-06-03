using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static Newtonsoft.Json.JsonConvert;

namespace Kups.CarBrowser.JsonDAO
{
    public class JsonReader<T>
    {
        private readonly string _sourcePath;

        public JsonReader(string sourcePath)
        {
            _sourcePath = sourcePath;
        }
        
        public List<T> LoadJsonList()
        {
            using (var r = new StreamReader(_sourcePath))
            {
                var json = r.ReadToEnd();
                return DeserializeObject<List<T>>(json);
            }
        }

        public delegate bool Modifier(List<T> toModify);
        public bool Update(Modifier modifier)
        {
            var jsonList = LoadJsonList();
            var modified = modifier(jsonList);
            if (!modified) return false;
            var serialized = SerializeObject(jsonList, Formatting.Indented);
            using (var f = new FileStream(_sourcePath, FileMode.Truncate))
            using(var w = new StreamWriter(f))
            {
                w.Write(serialized);
            }

            return true;
        }
    }
}