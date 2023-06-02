﻿using MagazynWina.App.Common;
using MagazynWina.Domain.Base;
using MagazynWina.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MagazynWina.App.Concrete
{
    public class BeerService : BaseService<Beer>
    {
        public List<Beer> Beers = new List<Beer>();
        public Beer AddNewBeerToList(int beerId, string nameBeer, int Blg, int year, int quantity, string yeast, string typeOfBeer)
        {
            Beer beer = new Beer(beerId, nameBeer, Blg, year, quantity, yeast, typeOfBeer);
            AddNewObject(beer);
            return beer;
        }
        public void DeleteBeerFromList(int beerId)
        {
            GetAllBeerObjects();
            var deletedBeer = Objects[beerId];
            DeleteObject(deletedBeer);
            GetAllBeerObjects();
            Beers.OrderBy(i => i.Id);
            if(beerId>0)
            {
                for (int i = beerId - 1; i < Beers.Count; i++)
                {
                    Beers[i].Id = Beers[i].Id - 1;
                }
            }
            else
            {
            }
        }
        public int UpdateBeer(int productId,int updatedBeerBlg, int updatedBeerQuantity)
        {
            GetAllBeerObjects();
            Beer beer = Objects.FirstOrDefault(p => p.Id == productId);
            if (beer != null)
            {
                Beers.Find(x => x.Id == productId).Blg = updatedBeerBlg;
                Beers.Find(x => x.Id == productId).Quantity = updatedBeerQuantity;
                //Beers[productId - 1].Id = updatedBeerId;
            }

            else
            {
                return productId;
            }

            Beer beerUpdated = Beers.Find(x => x.Id == productId);
            Console.WriteLine($"\nBeer updated: {beerUpdated.Id}, {beerUpdated.Name}, {beerUpdated.Blg}, {beerUpdated.Quantity}");
            return productId;
        }
        public Beer GetBeerDetailsById(int productID)
        {
            var beer = ObjectDetail(productID);
            Console.WriteLine("");
            //Console.WriteLine($"\nbeer id: {beer.Id} beer name: {beer.Name} beer Blg: {beer.Blg} beer year: {beer.YearProduction} beer bootle: {beer.Quantity} beer yeast {beer.Yeast} beer {beer.TypeOfBeer}");
            return beer;
        }
        public int GetAllBeerObjects()
        {
            Beers = GetAllObjects();
            foreach (var beer in Beers)
            {
                Console.WriteLine($"\nBeer id: {beer.Id} beer name: {beer.Name} beer Blg: {beer.Blg} beer year: {beer.YearProduction} beer bootle: {beer.Quantity} beer yeast {beer.Yeast} beer {beer.TypeOfBeer}");
            }
            return Beers.Count();
        }
    }
}
