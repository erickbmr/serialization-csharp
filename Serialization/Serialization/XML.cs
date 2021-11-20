using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization
{
    public class XML
    {
        /*
        public static void Main(string[] args)
        {
            try
            {
                //Criação do objeto Address
                Address newAddress = new Address("940 Memorial Dr NW", "Calgary", "Alberta", "Canada");
                //Criação do objeto Client
                Client newClient = new Client("Name LastName", "32423", "31988887777", newAddress);

                //Definindo o caminho do diretório que irá salvar o arquivo
                string filesPath = Path.GetDirectoryName(Environment.CurrentDirectory) + "\\files";
                //Testa se o diretório já existe, se não cria ele
                if (!Directory.Exists(filesPath))
                    Directory.CreateDirectory(filesPath);
                string fileName = "client.xml";
                //Adiciona o nome do arquivo no caminho do diretório para completar
                string xmlPath = Path.Combine(filesPath, fileName);

                //Se o arquivo já existir, deleta ele
                if (File.Exists(xmlPath))
                    File.Delete(xmlPath);

                //Chama o método para criar o arquivo XML (Serialização)
                bool isCreated = CreateFile(newClient, xmlPath);

                //Se estiver criado, começa a leitura
                if (isCreated)
                {
                    Console.WriteLine("File's path: " + xmlPath);
                    //Chama o método para ler o objeto a partir do arquivo YAML (Desserialização)
                    Client client = GetObjectFromFile(xmlPath);
                    Console.WriteLine("\n-------------- Info from file --------------\n");
                    Console.WriteLine("Address: " + client.Address.Line);
                    Console.WriteLine("City: " + client.Address.City);
                    Console.WriteLine("Country: " + client.Address.Country);
                    Console.WriteLine("Document: " + client.Document);
                    Console.WriteLine("Name: " + client.Name);
                    Console.WriteLine("Phone Number: " + client.PhoneNumber);
                    Console.WriteLine("State: " + client.Address.State);
                }
                else
                    Console.WriteLine("The file was not created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        */

        public static bool CreateFile(Client client, string xmlPath)
        {
            try
            {
                //Instancia um objeto da biblioteca de serialização de XML
                XmlSerializer serializer = new XmlSerializer(typeof(Client));
                //Abre uma stream para criação de um arquivo
                using (FileStream stream = File.Create(xmlPath))
                    //Serializa o objeto em um arquivo
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
                //Instancia um objeto da biblioteca de serialização de XML
                XmlSerializer serializer = new XmlSerializer(typeof(Client));
                //Abre uma stream para leitura de um arquivo
                using(FileStream stream = File.OpenRead(path))
                    //Deserializa o arquivo em um objeto
                    client = (Client)serializer.Deserialize(stream);
                
                return client;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
