using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Serialization
{
    public class YAML
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
                string fileName = "client.yaml";
                //Adiciona o nome do arquivo no caminho do diretório para completar
                string yamlPath = Path.Combine(filesPath, fileName);

                //Se o arquivo já existir, deleta ele
                if (File.Exists(yamlPath))
                    File.Delete(yamlPath);

                //Chama o método para criar o arquivo YAML (Serialização)
                bool isCreated = CreateFile(newClient, yamlPath);
                
                //Se estiver criado, começa a leitura
                if (isCreated)
                {
                    Console.WriteLine("File's path: " + yamlPath);
                    //Chama o método para ler o objeto a partir do arquivo YAML (Desserialização)
                    Client client = GetObjectFromFile(yamlPath);
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
        
        public static bool CreateFile(Client client, string yamlPath)
        {
            try
            {
                //Instancia uma interface do pacote YamlDotNet para criação de Serializer
                ISerializer yamlSerializer = new SerializerBuilder().Build();
                //String serializada do objeto
                string clientSerialized = yamlSerializer.Serialize(client);
                using (FileStream stream = File.Create(yamlPath))
                {
                    //Transforma a string em um array de bytes
                    byte[] yamlBt = Encoding.ASCII.GetBytes(clientSerialized);
                    //Escrita no arquivo
                    stream.Write(yamlBt);
                }
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
                //Instancia uma interface do pacote YamlDotNet para criação de Deserializer
                IDeserializer yamlDeserializer = new DeserializerBuilder().Build();
                string clientYaml = "";
                //Abre uma stream para leitura do arquivo
                using (StreamReader reader = new StreamReader(path))
                    //Lê o arquivo e passa para uma string
                    clientYaml = reader.ReadToEnd();
                //Deserializa o arquivo em um objeto do tipo cliente.
                client = yamlDeserializer.Deserialize<Client>(clientYaml);
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
