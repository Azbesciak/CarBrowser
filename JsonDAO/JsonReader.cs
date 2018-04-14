using System.Collections.Generic;
using System.IO;
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
    }
}