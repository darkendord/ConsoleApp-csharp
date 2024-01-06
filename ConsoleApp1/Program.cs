
using ConsoleApp1.Data;
using ConsoleApp1.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;



public class Program
{
    static void Main(string[] args)
    {


        //To connect to DB
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        DataContextEF entityFramework = new DataContextEF(configuration);


        /*
        Computer myComputer = new Computer()
        {
            Motherboard = "Z690",
            HasWifi = true, 
            HasLTE = false,
            ReleaseDate = DateTime.Now,
            Price = 943.87m,
            VideoCard = "RTX 2060"
        };

        
         //To Connect to DB
        entityFramework.Add(myComputer);
        entityFramework.SaveChanges();

        
      //  IEnumerable<Computer> computersEf = entityFramework.Computer.ToList();

        if (computersEf != null)
        {
            Console.WriteLine("'CompiterId','MotherBoard','HasWifi','HasLTE','ReleaseDate','Price','VideoCard'");

            foreach (var singleComputer in computersEf)
            {
                Console.WriteLine(
                    $"'{singleComputer?.ComputerId}'," +
                    $"'{singleComputer?.Motherboard}'," +
                    $"'{singleComputer?.HasWifi}'," +
                    $"'{singleComputer?.HasLTE}'," +
                    $"'{singleComputer?.ReleaseDate}'," +
                    $"'{singleComputer?.Price}'," +
                    $"'{singleComputer?.VideoCard}'"
                );
            }
        

        }
        

        string sql = @"INSERT INTO TutorialAppSchema.Computer(
            Motherboard,
            HasWifi
            HasLTE
            ReleaseDate
            Price
            VideoCard
          ) VALUES ('" + myComputer.Motherboard
                  + "','" + myComputer.HasWifi
                  + "','" + myComputer.HasLTE
                  + "','" + myComputer.ReleaseDate
                  + "','" + myComputer.Price
                  + "','" + myComputer.VideoCard
            + "')";

        /// File management
        string filePath = "C:\\Users\\apaniagua\\Desktop\\Prueba\\ConsoleApp1\\ConsoleApp1\\log.txt";

        File.WriteAllText(filePath, "\n" + sql + "\n");

        using StreamWriter openFile = new (filePath, append: true);

        openFile.WriteLine("\n" + sql + "\n");

        openFile.Close();
        */

        //string fileText = File.ReadAllText("");

        string filePath = "C:\\Users\\apaniagua\\Desktop\\Prueba\\ConsoleApp1\\ConsoleApp1\\Computers.json";

        string computersJson = File.ReadAllText(filePath);

        // Console.WriteLine(computersJson);

       
        
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        
        IEnumerable<Computer> computersNewtojSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

        IEnumerable<Computer> computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);


        if (computersNewtojSoft != null)
        {
            foreach (var computer in computersNewtojSoft)
            {
                // Console.WriteLine(computer.Motherboard);
        

                Computer myComputer = new Computer()
                {
                    Motherboard = computer.Motherboard,
                    HasWifi = computer.HasWifi,
                    HasLTE = computer.HasLTE,
                    ReleaseDate = computer.ReleaseDate,
                    Price = computer.Price,
                    VideoCard = computer.VideoCard
                };


                //To Connect to DB
                entityFramework.Add(myComputer);
                entityFramework.SaveChanges();
            }


            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtojSoft, settings);
            string computersCopyNewtonsoftFilePath = "C:\\Users\\apaniagua\\Desktop\\Prueba\\ConsoleApp1\\ConsoleApp1\\computersCopyNewtonsoft.txt";
            File.WriteAllText(computersCopyNewtonsoftFilePath, computersCopyNewtonsoft);



            string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);
            string computersCopySystemFilePath = "C:\\Users\\apaniagua\\Desktop\\Prueba\\ConsoleApp1\\ConsoleApp1\\computersCopySystem.txt";
            File.WriteAllText(computersCopySystemFilePath, computersCopySystem);

        }
        else
        {
            Console.WriteLine("The json content comes NULL");
        }
    }
}