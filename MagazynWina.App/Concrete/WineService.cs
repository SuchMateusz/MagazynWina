using MagazynWina.App.Common;
using MagazynWina.Domain.Model;
using MagazynWina.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynWina.App.Concrete

{
    public class WineService : BaseService<Wine>
    {
        //public List<Wine> Wines { get; set; }

        //public int AddNewWine(char wineType)
        //{
        //    int typeOfWine;
        //    Int32.TryParse(wineType.ToString(), out typeOfWine);
        //    Wine wine = new Wine();
        //    wine.TypeOfWine = typeOfWine;
        //    Console.WriteLine("\nEnter id for new wine: ");
        //    var id = Console.ReadLine();
        //    int wineId;
        //    Int32.TryParse(id, out wineId);
        //    Console.WriteLine("Write name for this wine: ");
        //    string nameWine = Console.ReadLine();
        //    Console.WriteLine("Write me value of BLG: ");
        //    int Blg;
        //    Int32.TryParse(Console.ReadLine(), out Blg);
        //    Console.WriteLine("Write me when this wine was producted: ");
        //    int year;
        //    Int32.TryParse(Console.ReadLine(), out year);

        //    wine.Id = wineId;
        //    wine.Name = nameWine;
        //    wine.Blg = Blg;
        //    wine.yearProduction = year;

        //    Wines.Add(wine);
        //    return wineId;
        //}

        //public int RemoveWineView()
        //{
        //    Console.WriteLine("\nEnter Id wine you want to remove: ");
        //    var wineId = Console.ReadLine();
        //    int id;
        //    Int32.TryParse(wineId, out id);
        //    return id;
        //}

        //public void RemoveWine(int removeId)
        //{
        //    Wine wineToRemove = new Wine();
        //    foreach(var wine in Wines)
        //    {
        //        if(wine.Id == removeId)
        //        {
        //            wineToRemove = wine;
        //            break;
        //        }
        //    }
        //    Wines.Remove(wineToRemove);
        //}

        //public int selectionWineDetail()
        //{
        //    Console.WriteLine("\nPlease enter id for item you want to show:");
        //    var wineId = Console.ReadKey();
        //    int idWine;
        //    Int32.TryParse(wineId.KeyChar.ToString(), out idWine);

        //    return idWine;
        //}

        //public void wineDetail(int detailId)
        //{
        //    Wine wineToShow = new Wine();
        //    foreach (var Wine in Wines)
        //    {
        //        if (Wine.Id == detailId)
        //        {
        //            wineToShow = Wine;
        //            break;
        //        }
        //    }

        //    Console.WriteLine($"Wine id: {wineToShow.Id}");
        //    Console.WriteLine($"Wine name: {wineToShow.Name}");
        //    Console.WriteLine($"Wine type id: {wineToShow.TypeOfWine}");
        //    Console.WriteLine($"Wine Blg: {wineToShow.Blg}");
        //    Console.WriteLine($"Wine year production: {wineToShow.yearProduction}");
        //}

        //public int selectionTypeWineDetail()
        //{
        //    Console.WriteLine("\nTell what list of type wine you want:");
        //    Console.WriteLine("1 - Sweet, 2 - half sweet, 3 - dry");
        //    var wineIdType = Console.ReadKey();
        //    int typeIdWine;
        //    Int32.TryParse(wineIdType.KeyChar.ToString(), out typeIdWine);
        //    return typeIdWine;
        //}

        //public void selectedTypeWinesDetail(int selectedTypeWine)
        //{
        //    List<Wine> winesToShow = new List<Wine>();

        //    foreach (var Wine in Wines)
        //    { 
        //        if(Wine.TypeOfWine == selectedTypeWine)
        //        {
        //            winesToShow.Add(Wine);
        //        }
        //    }

        //    for(int i = 0; i < winesToShow.Count; i++) { 
        //        Console.WriteLine($" \nSelected category wine:{selectedTypeWine} \n Wine ID:{winesToShow[i].Id} Name: {winesToShow[i].Name} Blg: {winesToShow[i].Blg} Year: {winesToShow[i].yearProduction}");
        //    }
        //}

        //public void SugarAdd()
        //{
        //    int neededSugar;
        //    int addedSugar;
        //    int litersOfWine;
        //    int power;
        //    Console.WriteLine("\nTell me how much sugar (in grams) is there:");
        //    Int32.TryParse(Console.ReadLine(), out addedSugar);
        //    Console.WriteLine("Tell me how many liters of wine you want to prepare:");
        //    Int32.TryParse(Console.ReadLine(), out litersOfWine);
        //    Console.WriteLine("Tell me what kind of power you want to have:");
        //    Int32.TryParse(Console.ReadLine(), out power);
        //    neededSugar = (17 * power * litersOfWine) - addedSugar;

        //    Console.WriteLine($"You need: {neededSugar} [grams] to get {litersOfWine} liters wine with {power}%");
        //    Console.WriteLine("Remember to sprinkle sugar int tree portions: ");
        //}
    }

}
