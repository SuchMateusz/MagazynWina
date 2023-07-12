using MagazynWina.App.AbstractInteface;
using MagazynWina.App.Concrete;
using MagazynWina.Domain;
using MagazynWina.Domain.Model;
using MagazynWina.App.Manager;
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
        WineService _wineService = new WineService();
        BeerService _beerService = new BeerService();
        FilesControl _filesControl = new FilesControl();

        public WineAppControl(MenuActionService actionService, WineService wineService, BeerService beerService)
        {
            _actionService = actionService;
            _wineService = wineService;
            _beerService = beerService;
        }

        public void AddNewObject()
        {
            var addNewObjectMenu = _actionService.GetMenuActionsByMenuName("AddNewObjectMenu");
            Console.WriteLine("\nTell me which object you prefer too add: ");
            for (int i = 0; i < addNewObjectMenu.Count; i++)
            {
                Console.WriteLine($"{addNewObjectMenu[i].ID}. {addNewObjectMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            int typeOfObject;
            Int32.TryParse(operation.KeyChar.ToString(), out typeOfObject);
            if (typeOfObject == 1)
            {
                var addNewWineMenu = _actionService.GetMenuActionsByMenuName("AddNewWineMenu");
                Console.WriteLine("\nTell me which wine you prefer too add: ");
                for (int i = 0; i < addNewWineMenu.Count; i++)
                {
                    Console.WriteLine($"{addNewWineMenu[i].ID}. {addNewWineMenu[i].Name}");
                }

                var WineType = Console.ReadKey();
                int chosenWineType;
                Int32.TryParse(WineType.KeyChar.ToString(), out chosenWineType);
                Console.WriteLine("\nEnter id for new wine: ");
                var id = Console.ReadLine();
                int wineId;
                Int32.TryParse(id, out wineId);
                Console.WriteLine("Write name for this wine: ");
                string nameWine = Console.ReadLine();
                Console.WriteLine("Write me value of BLG: ");
                byte Blg;
                byte.TryParse(Console.ReadLine(), out Blg);
                Console.WriteLine("Write me when this wine was producted: ");
                int year;
                Int32.TryParse(Console.ReadLine(), out year);
                Console.WriteLine("Write how much wine you producted: ");
                ushort quantity;
                ushort.TryParse(Console.ReadLine(), out quantity);
                Console.WriteLine("Write which yeast you used: ");
                string yeast = Console.ReadLine();
                _wineService.AddNewWineToList(wineId, nameWine, chosenWineType, Blg, year, quantity, yeast);
                _filesControl.SaveToFile(_wineService.Objects, _beerService.Objects);
                Console.Clear();
            }

            else if (typeOfObject == 2)
            {
                Console.WriteLine("\nEnter id for new beer: ");
                var id = Console.ReadLine();
                int beerId;
                Int32.TryParse(id, out beerId);
                Console.WriteLine("Write name for this beer: ");
                string nameBeer = Console.ReadLine();
                Console.WriteLine("Write me value of BLG: ");
                int Blg;
                Int32.TryParse(Console.ReadLine(), out Blg);
                Console.WriteLine("Write me when this beer was producted: ");
                int year;
                Int32.TryParse(Console.ReadLine(), out year);
                Console.WriteLine("Write how much beer you producted: ");
                int quantity;
                Int32.TryParse(Console.ReadLine(), out quantity);
                Console.WriteLine("Write which yeast you used: ");
                string yeast = Console.ReadLine();
                Console.WriteLine("Write what type of beer you producted (Pale Ale, Bitter, IPA etc.): ");
                string typeOfBeer = Console.ReadLine();
                _beerService.AddNewBeerToList(beerId, nameBeer, Blg, year, quantity, yeast, typeOfBeer);
                _filesControl.SaveToFile(_wineService.Objects, _beerService.Objects);
                Console.Clear();
            }

            else
            {
                Console.WriteLine("You wrote wrong type object ID");
            }
        }

        public void DeleteObject()
        {
            int productTypeID = ChoiseObjectTypeId();
            if (productTypeID == 1)
            {
                _wineService.GetAllObjects();
                Console.WriteLine("\nEnter id wine to remove from list: ");
                var id = Console.ReadLine();
                int wineID;
                Int32.TryParse(id, out wineID);
                _wineService.DeleteWineFromList(wineID);
                Console.WriteLine("Deleted wine completed: ");
                _filesControl.SaveToFile(_wineService.Objects, _beerService.Objects);
            }
            else if (productTypeID == 2)
            {
                Console.WriteLine("\nEnter id beer to remove from list: ");
                var id = Console.ReadLine();
                int beerId;
                Int32.TryParse(id, out beerId);
                _beerService.DeleteBeerFromList(beerId);
                _filesControl.SaveToFile(_wineService.Objects, _beerService.Objects);
            }
            else
            {
                Console.WriteLine("You wrote wrong type object ID");
            }
        }

        public void GetAllObjects()
        {
            _wineService.GetAllWineObjects();
            _beerService.GetAllBeerObjects();
        }

        public void ObjectDetail()
        {
            int productTypeID = ChoiseObjectTypeId();
            if (productTypeID == 1)
            {
                Console.WriteLine("\nEnter Id wine you want to show: ");
                var wineId = Console.ReadLine();
                int productID;
                Int32.TryParse(wineId, out productID);
                var wine = _wineService.GetWineDetailsById(productID);
                Console.WriteLine($"\nWine id: {wine.Id} wine name: {wine.Name} wine type: {wine.TypeOfWine} wine Blg: {wine.Blg} wine year: {wine.YearProduction} wine bootle: {wine.Quantity} wine yeast: {wine.Yeast}");
            }
            else if (productTypeID == 2)
            {
                Console.WriteLine("\nEnter Id beer you want to show: ");
                var beerId = Console.ReadLine();
                int productID;
                Int32.TryParse(beerId, out productID);
                var beer = _beerService.GetBeerDetailsById(productID);
                Console.WriteLine($"\nbeer id: {beer.Id} beer name: {beer.Name} beer Blg: {beer.Blg} beer year: {beer.YearProduction} beer bootle: {beer.Quantity} beer yeast {beer.Yeast} beer {beer.TypeOfBeer}");
            }
            else
            {
                Console.WriteLine("You wrote wrong type object ID");
            }
        }

        public void UpdateObject()
        {
            int productTypeID = ChoiseObjectTypeId();
            if (productTypeID == 1)
            {
                Console.WriteLine("\nWrite me which Object you want to update: ");
                int productId;
                Int32.TryParse(Console.ReadLine(), out productId);
                Console.WriteLine("Write updated name for this wine: ");
                string updatedNameWine = Console.ReadLine();
                Console.WriteLine("Write me new value of BLG: ");
                int updatedWineBlg;
                Int32.TryParse(Console.ReadLine(), out updatedWineBlg);
                Console.WriteLine("Write me how much wine are in your storage: ");
                int updatedWineQuantity;
                Int32.TryParse(Console.ReadLine(), out updatedWineQuantity);
                _wineService.UpdateWine(productId, updatedNameWine, updatedWineBlg, updatedWineQuantity);
            }

            else if (productTypeID == 2)
            {
                _beerService.GetAllBeerObjects();
                Console.WriteLine("\nWrite me which Object you want to update: ");
                int productId;
                Int32.TryParse(Console.ReadLine(), out productId);
                Console.WriteLine("\nWrite me updated wine ID: ");
                int updatedBeerId;
                Int32.TryParse(Console.ReadLine(), out updatedBeerId);
                Console.WriteLine("Write updated name for this wine: ");
                string updatedBeerName = Console.ReadLine();
                Console.WriteLine("Write me new value of BLG: ");
                int updatedBeerBlg;
                Int32.TryParse(Console.ReadLine(), out updatedBeerBlg);
                Console.WriteLine("Write me how much wine are in your storage: ");
                int updatedBeerQuantity;
                Int32.TryParse(Console.ReadLine(), out updatedBeerQuantity);
                _beerService.UpdateBeer(productId, updatedBeerName, updatedBeerBlg, updatedBeerQuantity);
            }

            else
            {
                Console.WriteLine("You wrote wrong type object ID");
            }
            _filesControl.SaveToFile(_wineService.Objects, _beerService.Objects);
        }

        public void SugarAdd()
        {
            int addedSugar;
            int litersOfWine;
            int power;
            int neededSugar;
            Console.WriteLine("\nTell me how much sugar (in grams) is there:");
            Int32.TryParse(Console.ReadLine(), out addedSugar);
            Console.WriteLine("Tell me how many liters of wine you want to prepare:");
            Int32.TryParse(Console.ReadLine(), out litersOfWine);
            Console.WriteLine("Tell me how much power percentage you want to get:");
            Int32.TryParse(Console.ReadLine(), out power);
            neededSugar = _wineService.SuggarForNewWine( addedSugar, litersOfWine, power);
            Console.WriteLine($"You need: {neededSugar} [grams] to get {litersOfWine} liters wine with {power}%");
        }

        public int ChoiseObjectTypeId()
        {
            Console.WriteLine("\nEnter type object Id you want to chose: ");
            Console.WriteLine("1 - wine, 2 - beer");
            var objectId = Console.ReadLine();
            int productTypeID;
            Int32.TryParse(objectId, out productTypeID);
            if (productTypeID<1 && productTypeID > 2)
            {
                Console.WriteLine("\nWrite again type object Id you want to chose 1-2: ");
                objectId = Console.ReadLine();
                Int32.TryParse(objectId, out productTypeID);
            }
            else
            {
                Console.WriteLine($"\nYou choose Id type: {productTypeID}");
            }

            Console.Clear();
            return productTypeID;
        }

        public Wine GetWineDetailsById(int id)
        {
            var wine = _wineService.GetWineDetailsById(id);
            return wine;
        }

        public Beer GetBeerDetailsById(int id)
        {
            var beer = _beerService.GetBeerDetailsById(id);
            return beer;
        }

        public int AddNewWine(Wine wine)
        {
            var wineId = _wineService.AddNewObject(wine);
            return wineId;
        }

        public int AddNewBeer(Beer beer1)
        {
            var beerId = _beerService.AddNewObject(beer1);
            return beerId;
        }

        public void OperationsOnFile()
        {
            var addNewObjectMenu = _actionService.GetMenuActionsByMenuName("AddFileMenu");
            Console.WriteLine("\nTell me witch operation you choose: ");
            for (int i = 0; i < addNewObjectMenu.Count; i++)
            {
                Console.WriteLine($"{addNewObjectMenu[i].ID}. {addNewObjectMenu[i].Name}");
            }

            var keyOption = Console.ReadLine();
            int operation;
            Int32.TryParse(keyOption, out operation);
            _filesControl.ChosingReportOperations(operation, _wineService.Objects, _beerService.Objects);
            if(operation == 2)
            {
                _wineService.Objects = _filesControl.listWine;
                _beerService.Objects = _filesControl.listBeer;
            }
        }
    }
}