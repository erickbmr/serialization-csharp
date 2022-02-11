using Serialization.Builders;
using Serialization.FileTypes;
using Serialization.Helper;
using System;
using System.IO;

namespace Serialization
{
    public class Program
    {
        public const string CLIENT_FILE_NAME = "client";

        public static void Main(string[] args)
        {
            DoJson();
            DoYaml();
            DoXml();
            DoPB();
        }

        private static void DoJson()
        {
            try
            {
                var newClient = GetClientObj();
                var filesPath = GetPath();
                var fileName = CLIENT_FILE_NAME + Constants.JSON_EXTENSION;
                var jsonPath = Path.Combine(filesPath, fileName);

                DeleteIfExists(jsonPath);

                var builder = new Builder(new JSON(jsonPath));

                if (builder.CreateFile(newClient))
                {
                    var client = builder.GetObjectFromFile() as Client;

                    PrintResult(jsonPath, client);
                    return;
                }

                PrintNotCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private static void DoYaml()
        {
            try
            {
                var newClient = GetClientObj();
                var filesPath = GetPath();
                var fileName = CLIENT_FILE_NAME + Constants.YAML_EXTENSION;
                var yamlPath = Path.Combine(filesPath, fileName);

                DeleteIfExists(yamlPath);

                var builder = new Builder(new YAML(yamlPath));
                
                if (builder.CreateFile(newClient))
                {
                    var client = builder.GetObjectFromFile() as Client;

                    PrintResult(yamlPath, client);
                    return;
                }

                PrintNotCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private static void DoXml()
        {
            try
            {
                var newClient = GetClientObj();
                var filesPath = GetPath();
                var fileName = CLIENT_FILE_NAME + Constants.XML_EXTENSION;
                var xmlPath = Path.Combine(filesPath, fileName);

                DeleteIfExists(xmlPath);

                var builder = new Builder(new XML(xmlPath, typeof(Client)));
                
                if (builder.CreateFile(newClient))
                {
                    var client = builder.GetObjectFromFile() as Client;

                    PrintResult(xmlPath, client);
                    return;
                }

                PrintNotCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private static void DoPB()
        {
            try
            {
                var newClient = GetClientObj();
                var filesPath = GetPath();
                var fileName = CLIENT_FILE_NAME + Constants.PB_EXTENSION;
                var pbPath = Path.Combine(filesPath, fileName);

                DeleteIfExists(pbPath);

                var builder = new Builder(new PB(pbPath, typeof(Client)));
                
                if (builder.CreateFile(newClient))
                {
                    var client = builder.GetObjectFromFile() as Client;

                    PrintResult(pbPath, client);
                    return;
                }

                PrintNotCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private static Client GetClientObj()
        {
            var newAddress = new Address("940 Memorial Dr NW", "Calgary", "Alberta", "Canada");
            return new Client("Name LastName", "32423", "31988887777", newAddress);
        }

        private static void PrintResult(string path, Client client)
        {
            Console.WriteLine("File's path: " + path);
            Console.WriteLine("\n-------------- Info from file --------------\n");
            Console.WriteLine("Address: " + client.Address.Line);
            Console.WriteLine("City: " + client.Address.City);
            Console.WriteLine("Country: " + client.Address.Country);
            Console.WriteLine("Document: " + client.Document);
            Console.WriteLine("Name: " + client.Name);
            Console.WriteLine("Phone Number: " + client.PhoneNumber);
            Console.WriteLine("State: " + client.Address.State);
            Console.WriteLine("\n\n\n");
        }

        private static void PrintNotCreated()
        {
            Console.WriteLine("The file was not created.");
        }

        private static string GetPath()
        {
            var filesPath = Path.GetDirectoryName(Environment.CurrentDirectory) + "\\files";
            if (!Directory.Exists(filesPath))
                Directory.CreateDirectory(filesPath);
            
            return filesPath;
        }

        private static void DeleteIfExists(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
