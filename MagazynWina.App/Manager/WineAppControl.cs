using MagazynWina.App.AbstractInteface;
using MagazynWina.App.Concrete;
using MagazynWina.Domain;
using MagazynWina.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynWina.App.Manager
{
    public class WineAppControl
    {
        private readonly MenuActionService _actionService;
        private IService<Wine> _wineService;
        private List<Wine> Wines { get; set; }



        public WineAppControl(MenuActionService actionService, IService<Wine> wineService)
        {
            _actionService = actionService;
            _wineService = wineService;
        }

        public int AddNewWine()
        {
            var addNewWineMenu = _actionService.GetMenuActionsByMenuName("AddNewWineMenu");
            Console.WriteLine("\nTell me witch wine you prefer too add: ");

            for (int i = 0; i < addNewWineMenu.Count; i++)
            {
                Console.WriteLine($"{addNewWineMenu[i].ID}. {addNewWineMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            int typeOfWine;
            Int32.TryParse(operation.KeyChar.ToString(), out typeOfWine);
            Console.WriteLine("\nEnter id for new wine: ");
            var id = Console.ReadLine();
            int wineId;
            Int32.TryParse(id, out wineId);
            Console.WriteLine("Write name for this wine: ");
            string nameWine = Console.ReadLine();
            Console.WriteLine("Write me value of BLG: ");
            int Blg;
            Int32.TryParse(Console.ReadLine(), out Blg);
            Console.WriteLine("Write me when this wine was producted: ");
            int year;
            Int32.TryParse(Console.ReadLine(), out year);
            Console.WriteLine("Write how much wine you producted: ");
            int quantity;
            Int32.TryParse(Console.ReadLine(), out quantity);
            Console.WriteLine("Write which yeast you used: ");
            string yeast = Console.ReadLine();

            Wine wine = new Wine(wineId, nameWine, typeOfWine, Blg, year, quantity, yeast);

            _wineService.AddWine(wine);
            Console.WriteLine("Remember to save changes to file");
            return wineId;
        }

        public void UpdateWine()
        { 
            Wine wine = new Wine();
            _wineService.UpdateWine(wine);
            Console.WriteLine("Remember to save changes to file");
        }

        public void DeleteWine()
        {
            Console.WriteLine("\nEnter Id wine you want to remove: ");
            var wineId = Console.ReadLine();
            int productID;
            Int32.TryParse(wineId, out productID);
            var productWine = _wineService.wineDetail(productID);
            _wineService.DeleteWine(productWine);
            Console.WriteLine("Remember to save changes to file");
        }
        public Wine wineDetail()
        {
            Console.WriteLine("\nEnter Id wine you want to show: ");
            var wineId = Console.ReadLine();
            int productID;
            Int32.TryParse(wineId, out productID);
            var wine = _wineService.wineDetail(productID);
            Console.WriteLine("");
            Console.WriteLine($"\nWine you selected: {wine.Id}, {wine.Name}, {wine.TypeOfWine}, {wine.Blg}, {wine.yearProduction}, {wine.Quantity}");
            return wine;
        }

        public List<Wine> GetAllWines()
        {
            _wineService.GetAllWines();
            foreach(var wine in _wineService.Wines)
            {
                Console.WriteLine($"\nWine id: {wine.Id} wine name: {wine.Name} Type wine: {wine.TypeOfWine} Wine Blg: {wine.Blg} wine year: {wine.yearProduction} wine bootle: {wine.Quantity}");
            }
            return Wines;
        }

        public void SugarAdd()
        {
            _wineService.SuggarAddWine();
        }

        //Testing metod
        public Wine WineDetailId(int Id)
        {
            var wine = _wineService.wineDetail(Id);
            return wine;
        }


    }
}
