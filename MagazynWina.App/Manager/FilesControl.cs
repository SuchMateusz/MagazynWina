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
using MagazynWina.App.Concrete;
using MagazynWina.Domain.Base;

namespace MagazynWina.App.Manager
{
    public class FilesControl
    {
        public string output;
        public List<Wine> listWine = new List<Wine>();
        public List<Beer> listBeer = new List<Beer>();
        public WineService wineService = new WineService();
        public BeerService beerService = new BeerService();
        public FilesService _listWineService = new FilesService();

        public void ChosingReportOperations(int operation)
        {
            switch (operation)
            {
                case 1:
                    SaveToFile();
                    break;
                case 2:
                    ReaderFromFile();
                    break;
                case 3:
                    _listWineService.ReportSaveFile();
                    break;
                case 4:
                    _listWineService.ReadReportFile();
                    break;
                case 5:
                    AddingTestList();
                    break;
                default:
                    break;
            }
        }

        public void SaveToFile()
        {
            listWine = wineService.Objects;
            listBeer = beerService.Objects;
            _listWineService.SavingToFile(listWine, listBeer);
        }

        public void ReaderFromFile()
        {
            listWine = _listWineService.ReadFromFileWine();
            listBeer = _listWineService.ReadFromFileBeer();
        }

        public void AddingTestList()
        {
            _listWineService.AddingFirstTestList();
        }
    }
}
