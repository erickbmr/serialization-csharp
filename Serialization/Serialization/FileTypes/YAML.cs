using Serialization.Interfaces;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;

namespace Serialization.FileTypes
{
    public class YAML : IBuilderString
    {
        public string FilePath { get; set; }

        public YAML(string filePath)
        {
            FilePath = filePath;
        }

        public bool CreateFile(object obj)
        {
            var clientSerialized = Serialize(obj);
            using (var stream = File.Create(FilePath))
            {
                var yamlBt = Encoding.ASCII.GetBytes(clientSerialized);
                stream.Write(yamlBt);
            }
            return true;
        }
        public object GetObjectFromFile()
        {
            var objYaml = "";
            using (var reader = new StreamReader(FilePath))
                objYaml = reader.ReadToEnd();

            return Deserialize(objYaml);
        }

        private string Serialize(object obj)
        {
            var yamlSerializer = new SerializerBuilder().Build();
            return yamlSerializer.Serialize(obj);
        }

        private object Deserialize(string obj)
        {
            var yamlDeserializer = new DeserializerBuilder().Build();
            return yamlDeserializer.Deserialize<Client>(obj);
        }

    }
}
