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
        public List<Beer> Beers = new List<Beer>();
        Beer _beer = new Beer();
        public Beer AddNewBeerToList(int beerId, string nameBeer, int Blg, int year, int quantity, string yeast, string typeOfBeer)
        {

            Beer beer = new Beer(2, beerId, nameBeer, Blg, year, quantity, yeast, typeOfBeer);
            AddNewObject(beer);
            return beer;
        }

        public void DeleteBeerFromList(int beerId)
        {
            GetAllBeerObjects();
            var deletedBeer = Objects[beerId-1];
            DeleteObject(deletedBeer);
            GetAllBeerObjects();
            Beers.OrderBy(i => i.Id);
            for (int i = beerId - 1; i < Beers.Count; i++)
            {
                Beers[i].Id = Beers[i].Id - 1;
            }
        }

        public int UpdateBeer(int productId, int updatedBeerId, int updatedBeerBlg, int updatedBeerQuantity)
        {
            GetAllBeerObjects();
            Beer beer = Objects.FirstOrDefault(p => p.Id == productId);
            if (beer != null)
            {
                Objects[productId - 1].Id = updatedBeerId;
                Objects[productId - 1].Blg = updatedBeerBlg;
                Objects[productId - 1].Quantity = updatedBeerQuantity;
            }
            else
            {
                return productId;
            }
            Console.WriteLine($"\nWine updated: {Objects[productId - 1].Id}, {Objects[productId - 1].Name}, {Objects[productId - 1].Blg}, {Objects[productId - 1].Quantity}");
            return productId;
        }
        public Beer GetBeerDetailsById(int productID)
        {
            var beer = ObjectDetail(productID);
            Console.WriteLine("");
            //Console.WriteLine($"\nbeer id: {beer.Id} beer name: {beer.Name} beer Blg: {beer.Blg} beer year: {beer.yearProduction} beer bootle: {beer.Quantity} beer yeast {beer.Yeast} beer {beer.TypeOfBeer}");
            return beer;
        }
        public int GetAllBeerObjects()
        {
            Beers = GetAllObjects();
            foreach (var beer in Beers)
            {
                Console.WriteLine($"\n {Beers.Count} beer id: {beer.Id} beer name: {beer.Name} beer Blg: {beer.Blg} beer year: {beer.yearProduction} beer bootle: {beer.Quantity} beer yeast {beer.Yeast} beer {beer.TypeOfBeer}");
            }
            return Beers.Count();
        }
    }
}
