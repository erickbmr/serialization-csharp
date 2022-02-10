using Serialization.FileTypes;
using System;
using System.IO;

namespace Serialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //improve
            DoJson();
            DoYaml();
        }

        private static void DoJson()
        {
            try
            {
                var newClient = GetClientObj();

                var filesPath = Path.GetDirectoryName(Environment.CurrentDirectory) + "\\files";

                if (!Directory.Exists(filesPath))
                    Directory.CreateDirectory(filesPath);

                var fileName = "client.json";
                var jsonPath = Path.Combine(filesPath, fileName);

                if (File.Exists(jsonPath))
                    File.Delete(jsonPath);

                var builder = new Helper.Builder(new JSON(jsonPath));

                var isCreated = builder.CreateFile(newClient);

                if (isCreated)
                {
                    var client = builder.GetObjectFromFile() as Client;

                    Console.WriteLine("File's path: " + jsonPath);
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

        private static void DoYaml()
        {
            try
            {
                var newClient = GetClientObj();

                var filesPath = Path.GetDirectoryName(Environment.CurrentDirectory) + "\\files";
                if (!Directory.Exists(filesPath))
                    Directory.CreateDirectory(filesPath);

                var fileName = "client.yaml";
                var yamlPath = Path.Combine(filesPath, fileName);

                if (File.Exists(yamlPath))
                    File.Delete(yamlPath);

                var builder = new Helper.Builder(new YAML(yamlPath));
                var isCreated = builder.CreateFile(newClient);

                if (isCreated)
                {
                    var client = builder.GetObjectFromFile() as Client;

                    Console.WriteLine("File's path: " + yamlPath);
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

        private static Client GetClientObj()
        {
            var newAddress = new Address("940 Memorial Dr NW", "Calgary", "Alberta", "Canada");
            return new Client("Name LastName", "32423", "31988887777", newAddress);
        }

        /*
         * TODO
         * 
        public static void xml()
        {
            try
            {
                Address newAddress = new Address("940 Memorial Dr NW", "Calgary", "Alberta", "Canada");
                Client newClient = new Client("Name LastName", "32423", "31988887777", newAddress);

                string filesPath = Path.GetDirectoryName(Environment.CurrentDirectory) + "\\files";
                if (!Directory.Exists(filesPath))
                    Directory.CreateDirectory(filesPath);
                string fileName = "client.xml";
                string xmlPath = Path.Combine(filesPath, fileName);

                if (File.Exists(xmlPath))
                    File.Delete(xmlPath);

                bool isCreated = CreateFile(newClient, xmlPath);

                if (isCreated)
                {
                    Console.WriteLine("File's path: " + xmlPath);
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

        public static void pb()
        {
            try
            {
                Address newAddress = new Address("940 Memorial Dr NW", "Calgary", "Alberta", "Canada");
                Client newClient = new Client("Name LastName", "32423", "31988887777", newAddress);

                string filesPath = Path.GetDirectoryName(Environment.CurrentDirectory) + "\\files";
                if (!Directory.Exists(filesPath))
                    Directory.CreateDirectory(filesPath);
                string fileName = "client.dat";
                string pbPath = Path.Combine(filesPath, fileName);

                if (File.Exists(pbPath))
                    File.Delete(pbPath);

                bool isCreated = CreateFile(newClient, pbPath);

                if (isCreated)
                {
                    Console.WriteLine("File's path: " + pbPath);
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
    }
}
