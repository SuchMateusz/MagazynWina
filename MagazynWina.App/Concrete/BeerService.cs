using MagazynWina.App.Common;
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
            Objects.OrderBy(i => i.Id);
            if(beerId>0)
            {
                for (int i = beerId - 1; i < Objects.Count; i++)
                {
                    Objects.Find(x => x.Id == beerId).Id = Objects.Find(x => x.Id == beerId).Id - 1;
                }
            }
        }

        public int UpdateBeer(int productId,string updatedBeerName, int updatedBeerBlg, int updatedBeerQuantity)
        {
            bool checkAmount;
            string check;
            GetAllBeerObjects();
            Beer beer = Objects.FirstOrDefault(p => p.Id == productId);
            if (beer != null)
            {
                beer.Name = updatedBeerName;
                beer.Blg = updatedBeerBlg;
                beer.Quantity = updatedBeerQuantity;
                UpdateObject(beer);
            }

            else
            {
                return productId;
            }

            beer = Objects.FirstOrDefault(p => p.Id == productId);
            Console.WriteLine($"\nBeer updated: \nId = {beer.Id}, Name = {beer.Name}, Blg = {beer.Blg}, Quantity = {beer.Quantity}");
            checkAmount = CheckObjectAmount(beer.Quantity);
            if (checkAmount == true)
                check = "You already have too little to sale";
            else
                check = "The amount available is sufficient";
            Console.WriteLine(check);
            return productId;
        }

        public Beer GetBeerDetailsById(int productID)
        {
            var beer = ObjectDetail(productID);
            return beer;
        }

        public int GetAllBeerObjects()
        {
            Objects = GetAllObjects();
            foreach (var beer in Objects)
            {
                Console.WriteLine($"\nBeer id: {beer.Id} beer name: {beer.Name} beer Blg: {beer.Blg} beer year: {beer.YearProduction} beer bootle: {beer.Quantity} beer yeast {beer.Yeast} beer {beer.TypeOfBeer}");
            }
            return Objects.Count();
        }
    }
}
