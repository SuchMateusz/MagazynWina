using MagazynWina.App.Common;
using MagazynWina.Domain.Model;
using MagazynWina.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagazynWina.App.AbstractInteface;

namespace MagazynWina.App.Concrete

{
    public class WineService : BaseService<Wine>
    {
        public List<Wine> Wines { get; set; }

        public int AddNewWineToList(int wineId, string nameWine, int typeOfWine, byte Blg, int year, ushort quantity, string yeast)
        {
            Wine wine = new Wine(wineId, nameWine, typeOfWine, Blg, year, quantity, yeast);
            AddNewObject(wine);
            return wineId;
        }
        public void DeleteWineFromList(int wineID)
        {
            GetAllWineObjects();
            var deletedWine = Wines[wineID-1];
            DeleteObject(deletedWine);
            Console.WriteLine("List of wine after deleted selected wine: \n");
            GetAllWineObjects();
            Wines.OrderBy(i => i.Id);
            for (int i = wineID - 1; i < Wines.Count; i++)
            {
                Wines.Find(x => x.Id == wineID).Id = Wines.Find(x => x.Id == wineID).Id - 1;
            }
        }
        public int UpdateWine(int productId, int updatedWineId, int updatedWineBlg, int updatedWineQuantity)
        {
            GetAllWineObjects();
            Wine wine = Wines.FirstOrDefault(p => p.Id == productId);
            if (wine != null)
            {
                Wines.Find(x => x.Id == productId).Blg = updatedWineBlg;
                Wines.Find(x => x.Id == productId).Quantity = updatedWineQuantity;
            }
            
            else
            {
                return productId;
            }

            wine = Wines.FirstOrDefault(p => p.Id == productId);
            Console.WriteLine($"\nWine updated: {wine.Id}, {wine.Name}, {wine.Blg}, {wine.Quantity}");
            return productId;
        }
        public Wine GetWineDetailsById(int productID)
        {
            var wine = ObjectDetail(productID);
            return wine;
        }
        public int GetAllWineObjects()
        {
            Wines = GetAllObjects();
            Wines = Wines.OrderBy(wine => wine.Id).ToList();
            foreach (var wine in Wines)
            {
                Console.WriteLine($"\n wine id: {wine.Id} wine name: {wine.Name} wine type: {wine.TypeOfWine} wine Blg: {wine.Blg} wine year: {wine.YearProduction} wine bootle: {wine.Quantity} wine yeast: {wine.Yeast}");
            }

            return Wines.Count;
        }
        public int SuggarForNewWine(int addedSugar, int litersOfWine, int power)
        {
            int neededSugar;
            neededSugar = (17 * power * litersOfWine) - addedSugar;
            return neededSugar;
        }
    }
}