using Serialization.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Serialization.FileTypes
{
    public class YAML : IBuilder
    {
        public string FilePath { get; set; }

        public YAML(string filePath)
        {
            FilePath = filePath;
        }

        public bool CreateFile(object obj)
        {
            string clientSerialized = Serialize(obj);
            using (FileStream stream = File.Create(FilePath))
            {
                byte[] yamlBt = Encoding.ASCII.GetBytes(clientSerialized);
                stream.Write(yamlBt);
            }
            return true;
        }
        public object GetObjectFromFile()
        {
            string objYaml = "";
            using (StreamReader reader = new StreamReader(FilePath))
                objYaml = reader.ReadToEnd();

            return Deserialize(objYaml);
        }

        public string Serialize(object obj)
        {
            ISerializer yamlSerializer = new SerializerBuilder().Build();
            return yamlSerializer.Serialize(obj);
        }

        public object Deserialize(string obj)
        {
            IDeserializer yamlDeserializer = new DeserializerBuilder().Build();
            return yamlDeserializer.Deserialize<Client>(obj);
        }

    }
}
