using Serialization.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization.FileTypes
{
    public class XML : IBuilder
    {
        /*
         * TODO
         * 
         * 
        public static bool CreateFile(Client client, string xmlPath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Client));
                using (FileStream stream = File.Create(xmlPath))
                    serializer.Serialize(stream, client);

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
                Client client = new Client();
                XmlSerializer serializer = new XmlSerializer(typeof(Client));
                using(FileStream stream = File.OpenRead(path))
                    client = (Client)serializer.Deserialize(stream);
                
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

        public XML(string filePath)
        {
            FilePath = filePath;
        }

        public bool CreateFile(object obj)
        {
            throw new NotImplementedException();
        }

        public object Deserialize(string obj)
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
    }
}
