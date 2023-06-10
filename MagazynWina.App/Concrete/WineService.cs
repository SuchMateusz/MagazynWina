﻿using MagazynWina.App.Common;
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
        public int AddNewWineToList(int wineId, string nameWine, int typeOfWine, byte Blg, int year, ushort quantity, string yeast)
        {
            Wine wine = new Wine(wineId, nameWine, typeOfWine, Blg, year, quantity, yeast);
            AddNewObject(wine);
            return wineId;
        }

        public void DeleteWineFromList(int wineID)
        {
            GetAllWineObjects();
            var deletedWine = Objects[wineID];
            DeleteObject(deletedWine);
            Console.WriteLine("List of wine after deleted selected wine: \n");
            GetAllWineObjects();
            Objects.OrderBy(i => i.Id);
            if (wineID > 0)
            {
                for (int i = wineID - 1; i < Objects.Count; i++)
                {
                    Objects.Find(x => x.Id == wineID).Id = Objects.Find(x => x.Id == wineID).Id - 1;
                }
            }
        }

        public int UpdateWine(int productId,string updatedNameWine, int updatedWineBlg, int updatedWineQuantity)
        {
            bool checkAmount;
            string check;
            GetAllWineObjects();
            Wine wine = Objects.FirstOrDefault(p => p.Id == productId);
            if (wine != null)
            {
                wine.Name = updatedNameWine;
                wine.Blg = updatedWineBlg;
                wine.Quantity = updatedWineQuantity;
                UpdateObject(wine);
            }
            else
            {
                return productId;
            }

            wine = Objects.FirstOrDefault(p => p.Id == productId);
            Console.WriteLine($"\nWine updated: \nId:{wine.Id}, Name:{wine.Name}, Blg: {wine.Blg}, Quantity: {wine.Quantity}");
            
            checkAmount = CheckObjectAmount(wine.Quantity);
            if (checkAmount == true)
                check = "Posiadasz już zbyt małą ilość do handlu";
            else
                check = "Posiadana ilość jest wystarczająca";
            Console.WriteLine(check);
            return productId;
        }

        public Wine GetWineDetailsById(int productID)
        {
            var wine = ObjectDetail(productID);
            return wine;
        }

        public int GetAllWineObjects()
        {
            Objects = GetAllObjects();
            Objects = Objects.OrderBy(wine => wine.Id).ToList();
            foreach (var wine in Objects)
            {
                Console.WriteLine($"\n wine id: {wine.Id} wine name: {wine.Name} wine type: {wine.TypeOfWine} wine Blg: {wine.Blg} wine year: {wine.YearProduction} wine bootle: {wine.Quantity} wine yeast: {wine.Yeast}");
            }

            return Objects.Count;
        }

        public int SuggarForNewWine(int addedSugar, int litersOfWine, int power)
        {
            int neededSugar;
            neededSugar = (17 * power * litersOfWine) - addedSugar;
            return neededSugar;
        }
    }
}