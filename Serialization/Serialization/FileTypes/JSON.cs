using System.Text;
using System.Text.Json;
using System.IO;
using Serialization.Helper;

namespace Serialization.FileTypes
{
    public class JSON : IBuilder
    {
        public string FilePath { get; set; }

        public JSON(string filePath)
        {
            FilePath = filePath;
        }

        public bool CreateFile(object obj)
        {
            string objSerialized = Serialize(obj);
            using (FileStream stream = File.Create(FilePath))
            {
                byte[] jsonBytes = Encoding.ASCII.GetBytes(objSerialized);
                stream.Write(jsonBytes);
            }
            return true;
        }

        public object GetObjectFromFile()
        {
            byte[] readBuffer = File.ReadAllBytes(FilePath);
            string jsonObject = Encoding.ASCII.GetString(readBuffer);
            
            return Deserialize(jsonObject);
        }

        public string Serialize(object obj)
        {
            string response = JsonSerializer.Serialize(obj);
            
            File.WriteAllText(FilePath, response);
            
            return response;
        }

        public object Deserialize(string obj)
        {
            return JsonSerializer.Deserialize<Client>(obj);
        }
    }
}
