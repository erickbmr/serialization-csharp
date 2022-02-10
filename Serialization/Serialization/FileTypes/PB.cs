using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using Serialization.Helper;

namespace Serialization.FileTypes
{
    public class PB : IBuilder
    {
        /*
         * TODO
         * 
         * 
        public static bool CreateFile(Client client, string pbPath)
        {
            try
            {
                using (FileStream stream = File.Create(pbPath))
                    Serializer.Serialize(stream, client);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static Client GetObjectFromFile(string path)
        {
            try
            {
                byte[] array = File.ReadAllBytes(path);
                Client client = Serializer.Deserialize<Client>(new MemoryStream(array));
                return client;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        */
        public string FilePath { get; set; }

        public PB(string filePath)
        {
            FilePath = filePath;
        }

        public bool CreateFile(object obj)
        {
            throw new NotImplementedException();
        }

        public object GetObjectFromFile()
        {
            throw new NotImplementedException();
        }

        public string Serialize(object obj)
        {
            throw new NotImplementedException();
        }

        public object Deserialize(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
