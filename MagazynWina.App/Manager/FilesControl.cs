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
        public FilesHelper _listObjectsService = new FilesHelper();

        public void ChosingReportOperations(int operation, List<Wine> listWines, List<Beer> listBeers)
        {
            switch (operation)
            {
                case 1:
                    SaveToFile(listWines, listBeers);
                    break;
                case 2:
                    ReaderObjectsFromFile();
                    break;
                case 3:
                    _listObjectsService.ReportSaveFile();
                    break;
                case 4:
                    _listObjectsService.ReadReportFile();
                    break;
                case 5:
                    AddingTestList();
                    break;
                default:
                    break;
            }
        }

        public void SaveToFile(List<Wine> listWines, List<Beer> listBeers)
        {
            listWine = listWines;
            listBeer = listBeers;
            _listObjectsService.SavingToFile(listWine, listBeer);
        }

        public void ReaderObjectsFromFile()
        {
            listWine = _listObjectsService.ReadFromFileWine();
            listBeer = _listObjectsService.ReadFromFileBeer();
        }

        public void AddingTestList()
        {
            _listObjectsService.AddingFirstTestList();
        }
    }
}
