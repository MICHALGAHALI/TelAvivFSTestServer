using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace exHomeTest_server.helper
{
    public static class ConvertJsonToObject
    {
        public static void SaveJson<T>(string jsonFile, T item)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFile);
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.TypeNameHandling = TypeNameHandling.Auto;
                serializer.Serialize(file, item);
            }
        }
    }
}