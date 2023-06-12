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
using MagazynWina.Domain.Base;
using MagazynWina.App.Manager;
using System.IO;

namespace MagazynWina.App.Concrete
{
    public class FilesService
    {
        public string outputWine;
        public string outputBeer;
        private List<Wine> listWine = new List<Wine>();
        private List<Beer> listBeer = new List<Beer>();
        private string wine = "Wine";
        private string beer = "Beer";
        private string raport = "Raport";
        StreamWriter sw;
        JsonWriter jWriter;
        JsonSerializer serializer = new JsonSerializer();

        public int AddingFirstTestList()
        {
            listWine.Add(new Wine(1, "grape", 1, 15, 2017, 10, "Bayanus"));
            listWine.Add(new Wine(2, "redGrape", 1, 13, 2018, 35, "Bayanus"));
            listWine.Add(new Wine(3, "mixGrape", 2, 5, 2019, 25, "Bayanus"));
            listWine.Add(new Wine(4, "chokeberry", 3, 1, 2020, 30, "Bayanus"));
            listWine.Add(new Wine(5, "Apple", 2, 7, 2019, 20, "Bayanus"));
            listWine.Add(new Wine(8, "AppleRaspberry", 1, 10, 2019, 20, "Bayanus"));
            listWine.Add(new Wine(7, "mixGrape", 3, 2, 2020, 35, "Bayanus"));
            listWine.Add(new Wine(6, "redCurant", 1, 10, 2021, 40, "Bayanus"));
            listBeer.Add(new Beer(1, "FirstBeer", 2, 2020, 30, "yeast", "Pale Ale"));
            listBeer.Add(new Beer(2, "Second Beer", 5, 2020, 20, "yeast", "Special Biter"));
            listBeer.Add(new Beer(3, "The best Beer", 0, 2021, 40, "yeast", "Austarial Pale Ale"));
            listBeer.Add(new Beer(4, "Good Beer", 3, 2021, 50, "yeast", "Ale"));
            SavingToFile(listWine, listBeer);
            return listWine.Count;
        }

        public string SavingToFile(List<Wine> listWine, List<Beer> listBeer)
        {
            var sortListWine = listWine.OrderBy(i => i.Id).ThenBy(i => i.TypeOfWine);
            var sortListBeer = listBeer.OrderBy(i => i.Id).ThenBy(i => i.TypeOfBeer);
            sw = StreamWriterFile(wine);
            jWriter = new JsonTextWriter(sw);
            serializer.Serialize(jWriter, sortListWine);
            sw.Close();
            sw = StreamWriterFile(beer);
            jWriter = new JsonTextWriter(sw);
            serializer.Serialize(jWriter, sortListBeer);
            sw.Close();
            string jsonFromFileWine = ReadFromFile(wine);
            string jsonFromFileBeer = ReadFromFile(beer);
            string wineString = ClosingFile(wine);
            string beerString = ClosingFile(beer);
            return wineString + beerString;
        }

        public List<Wine> ReadFromFileWine()
        {
            string jsonFromFileWine = ReadFromFile(wine);
            var ObjectsWine = JsonConvert.DeserializeObject<List<Wine>>(jsonFromFileWine);
            ClosingFile(wine);
            return ObjectsWine;
        }

        public List<Beer> ReadFromFileBeer()
        {
            string jsonFromFileBeer = ReadFromFile(beer);
            var ObjectsBeers = JsonConvert.DeserializeObject<List<Beer>>(jsonFromFileBeer);
            ClosingFile(beer);
            return ObjectsBeers;
        }

        public void ReportSaveFile()
        {
            Console.WriteLine("\r\nwrite a report on the changes made");
            string report = $"Wydruk raportu: /n";
            sw = StreamWriterFile(raport);
            jWriter = new JsonTextWriter(sw);
            serializer.Serialize(jWriter, report);
            Console.WriteLine("Write what you want");
            report = Console.ReadLine();
            serializer.Serialize(jWriter, report);
            Console.WriteLine("If you want to refill your report wrtine here:");
            report = Console.ReadLine();
            serializer.Serialize(jWriter, report);
            ClosingFile(raport);
        }

        public void ReadReportFile()
        { 
            string jsonFromFile = ReadFromFile(raport);
            var readReport = JsonConvert.DeserializeObject<string>(jsonFromFile);
            ClosingFile(raport);
            Console.WriteLine(readReport);
        }

        private StreamWriter StreamWriterFile(string Object)
        {
            sw = new StreamWriter($@"D:\Programowanie\Szkoła DotNETa\Tydzień5-Praca z danymi\Objects{Object}File.txt");
            return sw;
        }

        private string ReadFromFile(string Object)
        {
            using StreamReader streamReader = new StreamReader($@"D:\Programowanie\Szkoła DotNETa\Tydzień5-Praca z danymi\Objects{Object}File.txt");
            string jsonFromFile;
            jsonFromFile = streamReader.ReadToEnd();
            return jsonFromFile;
        }

        private string ClosingFile(string Object)
        {
            using StreamReader streamReader = new StreamReader($@"D:\Programowanie\Szkoła DotNETa\Tydzień5-Praca z danymi\Objects{Object}File.txt");
            streamReader.Close();
            return streamReader.ToString();
        }
    }
}
