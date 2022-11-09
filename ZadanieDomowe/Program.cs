using MagazynWina.App;
using MagazynWina.App.AbstractInteface;
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
            WineAppControl wineAppControl = new WineAppControl(actionService, wineService);
            ListWineService listWineService = new ListWineService(wineService);

            Console.WriteLine("Welcom in my app");
            
            
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

                       var newId = wineAppControl.AddNewWine();

                        break;

                    case '2':
                        
                        wineAppControl.GetAllWines();
                        wineAppControl.DeleteWine();
                        break;

                    case '3':
                        var allWines = wineAppControl.GetAllWines();
                        break;
                    case '4':
                        wineAppControl.wineDetail();
                        break;

                    case '5':
                        wineAppControl.UpdateWine();
                        break;

                    case '6':
                        wineAppControl.SugarAdd();
                        break;

                    case '7':
                        listWineService.readerFromFile();
                        break;
                    case '8':
                        listWineService.saveToFile();
                        break;
                    case '9':
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