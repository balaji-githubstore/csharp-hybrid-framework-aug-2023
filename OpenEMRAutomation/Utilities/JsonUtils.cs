using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.Utilities
{
    public class JsonUtils
    {
        public static string GetValueFromJson(string path,string key)
        {
            StreamReader reader = new StreamReader(path);
            string jsonText = reader.ReadToEnd();
            Console.WriteLine(jsonText);
            dynamic json = JsonConvert.DeserializeObject(jsonText);

            return json[key];
        }
    }
}
