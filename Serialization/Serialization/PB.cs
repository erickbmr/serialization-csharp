using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Serialization
{
    public class PB
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
                string fileName = "client.dat";
                //Adiciona o nome do arquivo no caminho do diretório para completar
                string pbPath = Path.Combine(filesPath, fileName);
                
                //Se o arquivo já existir, deleta ele
                if (File.Exists(pbPath))
                    File.Delete(pbPath);

                //Chama o método para criar o arquivo PB [dat] (Serialização)
                bool isCreated = CreateFile(newClient, pbPath);

                //Se estiver criado, começa a leitura
                if (isCreated)
                {
                    Console.WriteLine("File's path: " + pbPath);
                    //Chama o método para ler o objeto a partir do arquivo PB (Desserialização)
                    Client client = GetObjectFromFile(pbPath);
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

        public static bool CreateFile(Client client, string pbPath)
        {
            try
            {
                //Abre a stream para criação do arquivo
                using (FileStream stream = File.Create(pbPath))
                    //Serializa o objeto em ProtocolBuffer
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
                //Lê todos os bytes do arquivo
                byte[] array = File.ReadAllBytes(path);
                //Desserializa o arquivo em objeto
                Client client = Serializer.Deserialize<Client>(new MemoryStream(array));
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
