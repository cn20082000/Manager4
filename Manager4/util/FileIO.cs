using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager4.util
{
    public class FileIO
    {
        public static void WriteObject<T>(string path, T obj)
        {
            var commonPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            commonPath = Path.Combine(commonPath, "KM");
            if (!Directory.Exists(commonPath))
            {
                Directory.CreateDirectory(commonPath);
            }
            path = Path.Combine(commonPath, path);
            string content = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, content);
        }

        public static T ReadObject<T>(string path)
        {
            var commonPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            commonPath = Path.Combine(commonPath, "KM");
            if (!Directory.Exists(commonPath))
            {
                Directory.CreateDirectory(commonPath);
            }
            path = Path.Combine(commonPath, path);
            string content = File.ReadAllText(path);
            T obj = JsonConvert.DeserializeObject<T>(content);
            return obj;
        }
    }
}
