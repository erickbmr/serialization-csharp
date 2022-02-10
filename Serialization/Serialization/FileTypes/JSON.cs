using System.Text;
using System.Text.Json;
using System.IO;
using Serialization.Interfaces;

namespace Serialization.FileTypes
{
    public class JSON : IBuilderString
    {
        public string FilePath { get; set; }

        public JSON(string filePath)
        {
            FilePath = filePath;
        }

        public bool CreateFile(object obj)
        {
            var objSerialized = Serialize(obj);
            using (var stream = File.Create(FilePath))
            {
                var jsonBytes = Encoding.ASCII.GetBytes(objSerialized);
                stream.Write(jsonBytes);
            }
            return true;
        }

        public object GetObjectFromFile()
        {
            var readBuffer = File.ReadAllBytes(FilePath);
            var jsonObject = Encoding.ASCII.GetString(readBuffer);
            
            return Deserialize(jsonObject);
        }

        private string Serialize(object obj)
        {
            var response = JsonSerializer.Serialize(obj);
            
            File.WriteAllText(FilePath, response);
            
            return response;
        }

        private object Deserialize(string obj)
        {
            return JsonSerializer.Deserialize<Client>(obj);
        }
    }
}
