using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Reflection;

namespace Serialization
{
    public class JSON
    {
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
                string fileName = "client.json";
                //Adiciona o nome do arquivo no caminho do diretório para completar
                string jsonPath = Path.Combine(filesPath, fileName);

                //Se o arquivo já existir, deleta ele
                if (File.Exists(jsonPath))
                    File.Delete(jsonPath);

                //Chama o método para criar o arquivo JSON (Serialização)
                bool isCreated = CreateFile(newClient, jsonPath);

                //Se estiver criado, começa a leitura
                if (isCreated)
                {
                    Console.WriteLine("File's path: " + jsonPath);
                    //Chama o método para ler o objeto a partir do arquivo JSON (Desserialização)
                    Client client = GetObjectFromFile(jsonPath);
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public static bool CreateFile(Client newClient, string jsonPath)
        {
            try
            {
                //Chama o método para serialização do objeto
                string clientSerialized = Serialization(newClient);
                //Cria uma stream para criar um arquivo
                using (FileStream stream = File.Create(jsonPath))
                {
                    //Transforma o objeto serializado em um array de bytes para escrita
                    byte[] jsonBytes = Encoding.ASCII.GetBytes(clientSerialized);
                    //Escreve no novo arquivo
                    stream.Write(jsonBytes);
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static Client GetObjectFromFile(string jsonPath)
        {
            try
            {
                //Lê todos os bytes do arquivo salvo
                byte[] readBuffer = File.ReadAllBytes(jsonPath);
                //Transforma os bytes do arquivo em uma string
                string jsonObject = Encoding.ASCII.GetString(readBuffer);
                //Chama o método para desserializar o arquivo em objeto
                return Deserialization(jsonObject);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static string Serialization(Client client)
        {
            try
            {
                if (client == null)
                    return null;
                string response = "";
                //Serialização do objeto em JSON
                response = JsonSerializer.Serialize(client);

                string fileName = "client.json";
                //Escreve no novo arquivo
                File.WriteAllText(fileName, response);
                return response;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static Client Deserialization(string client)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(client))
                    return null;
                Client response = new Client();
                //Desserialização do JSON em objeto
                response = JsonSerializer.Deserialize<Client>(client);

                return response;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
