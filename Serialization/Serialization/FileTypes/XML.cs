using Serialization.Interfaces;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialization.FileTypes
{
    public class XML : IBuilderStream
    {
        public string FilePath { get; set; }
        public Type ObjType { get; set; }

        public XML(string filePath, Type objType)
        {
            FilePath = filePath;
            ObjType = objType;
        }

        public bool CreateFile(object obj)
        {
            var serializer = new XmlSerializer(ObjType);
            using (var stream = File.Create(FilePath))
                serializer.Serialize(stream, obj);

            return true;
        }

        public object GetObjectFromFile()
        {
            object obj = null;
            var serializer = new XmlSerializer(ObjType);
            using (var stream = File.OpenRead(FilePath))
                obj = serializer.Deserialize(stream);

            return obj;
        }
    }
}
