using System;
using System.IO;
using ProtoBuf;
using Serialization.Interfaces;

namespace Serialization.FileTypes
{
    public class PB : IBuilderStream
    {
        public string FilePath { get; set; }
        public Type ObjType { get; set; }

        public PB(string filePath, Type objType)
        {
            FilePath = filePath;
            ObjType = objType;
        }

        public bool CreateFile(object obj)
        {
            using (var stream = File.Create(FilePath))
                Serializer.Serialize(stream, obj);

            return true;
        }

        public object GetObjectFromFile()
        {
            var array = File.ReadAllBytes(FilePath);
            var obj = Serializer.Deserialize(ObjType, new MemoryStream(array));
            return obj;
        }
    }
}
