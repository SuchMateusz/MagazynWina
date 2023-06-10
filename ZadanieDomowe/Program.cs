using MagazynWina.App;
using MagazynWina.App.AbstractInteface;
using MagazynWina.App.Common;
using MagazynWina.App.Concrete;
using MagazynWina.App.Manager;
using MagazynWina.Domain;
using MagazynWina.Domain.Model;
using System;
using System.Windows;

namespace MagazynWina
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            WineService wineService = new WineService();
            BeerService beerService = new BeerService();
            FilesControl filesControl = new FilesControl();
            WineAppControl wineAppControl = new WineAppControl(actionService, wineService, beerService);
            Console.WriteLine("Welcome in my application");
            while (true)
            {
                Console.WriteLine("Tell me what you to do");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].ID}. {mainMenu[i].Name}");
                }
                
                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        wineAppControl.AddNewObject();
                        break;
                    case '2':
                        wineAppControl.DeleteObject();
                        break;
                    case '3':
                        wineAppControl.GetAllObjects();
                        break;
                    case '4':
                        wineAppControl.ObjectDetail();
                        break;
                    case '5':
                        wineAppControl.UpdateObject();
                        break;
                    case '6':
                        wineAppControl.SugarAdd();
                        break;
                    case '7':
                        wineAppControl.OperationsOnFile();
                        break;
                    case '8':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nWrong action you entered");
                        break;
                }
            }
        }
    }
}