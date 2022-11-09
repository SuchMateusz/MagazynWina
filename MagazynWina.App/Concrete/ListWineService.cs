using MagazynWina.Domain.Model;
using MagazynWina.App.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MagazynWina.App.AbstractInteface;

namespace MagazynWina.App.Concrete
{
    public class ListWineService
    {
        private IService<Wine> _wineService;
        public string output;
        public List<Wine> list = new List<Wine>();

        public ListWineService(IService<Wine> wineService)
        {
            _wineService = wineService;
        }
        public void method()
        {
            list.Add(new Wine(1, "grape", 1, 15, 2017, 10, "Bayanus"));
            list.Add(new Wine(3, "redGrape", 1, 13, 2018, 35, "Bayanus"));
            list.Add(new Wine(2, "mixGrape", 2, 5, 2019, 25, "Bayanus"));
            list.Add(new Wine(4, "chokeberry", 3, 1, 2020, 30, "Bayanus"));
            list.Add(new Wine(5, "Apple", 2, 7, 2019, 20, "Bayanus"));
            list.Add(new Wine(8, "AppleRaspberry", 1, 10, 2019, 20, "Bayanus"));
            list.Add(new Wine(7, "mixGrape", 3, 2, 2020, 35, "Bayanus"));
            list.Add(new Wine(6, "redCurant", 1, 10, 2021, 40, "Bayanus"));

            output = JsonConvert.SerializeObject(list);

            using StreamWriter sw = new StreamWriter(@"D:\Programowanie\Szkoła DotNETa\Tydzień5-Praca z danymi\WinesTest.txt");
            using JsonWriter jWriter = new JsonTextWriter(sw);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jWriter, list);
            var sortList = list.OrderBy(i => i.Id).ThenBy(i=>i.TypeOfWine);
        }

        public void saveToFile()
        {
            DateOnly date;
            list = _wineService.Wines;
            var sortList = list.OrderBy(i => i.Id).ThenBy(i => i.TypeOfWine);
            using StreamWriter sw1 = new StreamWriter(@"D:\Programowanie\Szkoła DotNETa\Tydzień5-Praca z danymi\Wines.txt");
            using StreamWriter sw2 = new StreamWriter($@"D:\Programowanie\Szkoła DotNETa\Tydzień5-Praca z danymi\Archiwum\Wines{date}.json");
            using JsonWriter writer1 = new JsonTextWriter(sw1);
            using JsonWriter writer2 = new JsonTextWriter(sw2);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer1, list);
            serializer.Serialize(writer2, list);
            reportSaveFile();
        }

        public List<Wine> readerFromFile()
        {
            //Console.WriteLine("Chose what file you want to read from file 1 - Main file if 2 - file from archive: ");
            using StreamReader streamReader = new StreamReader(@"D:\Programowanie\Szkoła DotNETa\Tydzień5-Praca z danymi\Wines.txt");
            string jsonFromFile;
            jsonFromFile = streamReader.ReadToEnd();
            var Wines = JsonConvert.DeserializeObject<List<Wine>>(jsonFromFile);
            //Przypisanie danych do serwisu w celu manipulacją danymi
            Wines.OrderBy(i=>i.TypeOfWine).ThenBy(i=>i.Id);
            _wineService.Wines = Wines;
            streamReader.Close();

            return Wines;
        }

        public void readerReportFile()
        {
            DateOnly date;
            Console.WriteLine("Write date of raport you want to see:");
            using StreamReader streamReader = new StreamReader(($@"D:\Programowanie\Szkoła DotNETa\Tydzień5 - Praca z danymi\Raport{date}.json"));
            string jsonFromFile = streamReader.ReadToEnd();
            var readReport = JsonConvert.DeserializeObject<List<Wine>>(jsonFromFile);
            streamReader.Close();
            Console.WriteLine(readReport);
        }

        public void reportSaveFile()
        {
            DateOnly date;
            Console.WriteLine("\r\nwrite a report on the changes made");
            string report = $"Wydruk raportu: /n" ;
            using StreamWriter sW = new StreamWriter(($@"D:\Programowanie\Szkoła DotNETa\Tydzień5 - Praca z danymi\Raport{date}.json"), true);
            using JsonWriter jsonWriter = new JsonTextWriter(sW);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jsonWriter, report);

            Console.WriteLine("Write what you want");
            report = Console.ReadLine();
            serializer.Serialize(jsonWriter, report);
            Console.WriteLine("If you want to refill your report wrtine here:");
            report = Console.ReadLine();
            serializer.Serialize(jsonWriter, report);
            sW.Close();
        }
    }
}
