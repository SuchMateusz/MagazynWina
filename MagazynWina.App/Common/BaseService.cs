using MagazynWina.App.AbstractInteface;
using MagazynWina.Domain.Base;
using MagazynWina.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynWina.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseModel
    {
        public List<T> Wines { get ; set ; }
        
        Wine _wine = new Wine();
        public BaseService()
        {
            Wines = new List<T>();
        }

        public int AddWine(T wine)
        {
            Wines.Add(wine);
            return wine.Id;
        }

        public void DeleteWine(T wine)
        {
            Wines.Remove(wine);
        }

        public List<T> GetAllWines()
        {
            return Wines;
        }

        public void SuggarAddWine()
        {
            int neededSugar;
            int addedSugar;
            int litersOfWine;
            int power;
            
            Console.WriteLine("\nTell me how much sugar (in grams) is there:");
            Int32.TryParse(Console.ReadLine(), out addedSugar);
            Console.WriteLine("Tell me how many liters of wine you want to prepare:");
            Int32.TryParse(Console.ReadLine(), out litersOfWine);
            Console.WriteLine("Tell me what kind of power you want to have:");
            Int32.TryParse(Console.ReadLine(), out power);
            neededSugar = (17 * power * litersOfWine) - addedSugar;
            Console.WriteLine($"You need: {neededSugar} [grams] to get {litersOfWine} liters wine with {power}%");
            Console.WriteLine("Remember to sprinkle sugar int tree portions: ");
        }

        public int UpdateWine(T wine)
        {
            GetAllWines();
            Console.WriteLine("\nWrite me witch wine you want to update: ");
            int productId;
            Int32.TryParse(Console.ReadLine(), out productId);
            
            wine = Wines.FirstOrDefault(p => p.Id == productId);
            if (wine != null)
            {
                
                Console.WriteLine("\nWrite me updated wine ID: ");
                int updatedWineId;
                Int32.TryParse(Console.ReadLine(), out updatedWineId);
                Console.WriteLine("Write updated name for this wine: ");
                string updatedWameWine = Console.ReadLine();
                Console.WriteLine("Write me new value of BLG: ");
                int updatedWineBlg;
                Int32.TryParse(Console.ReadLine(), out updatedWineBlg);
                Console.WriteLine("Write me how much wine are in your storage: ");
                int updatedWineQuantity;
                Int32.TryParse(Console.ReadLine(), out updatedWineQuantity);
                
                Wines[productId - 1].Id = updatedWineId;
                Wines[productId - 1].Blg = updatedWineBlg;
                Wines[productId - 1].Quantity = updatedWineQuantity;
                //wine.Id = updatedWineId;
                //wine.Blg = updatedWineBlg;
                //wine.Quantity = updatedWineQuantity;
                //Wines[productId - 1] = wine;
            }
            else
            {
                return productId;
            }
            
            Console.WriteLine($"\nWine updated: {Wines[productId - 1].Id}, {Wines[productId - 1].Name}, {Wines[productId - 1].Blg}, {Wines[productId - 1].Quantity} ");
            _wine.CheckValue(Wines[productId - 1].Quantity);
            //Wines.Sort();
            return productId;
        }

        public T wineDetail(int id)
        {
            var wineDetails = Wines.FirstOrDefault(p => p.Id == id);
            return (T)wineDetails;
        }
        public T UpdateWineTestID(T wine)
        {
            wine = Wines.FirstOrDefault(p => p.Id == wine.Id);
            wine.Id = 10;
            wine.Blg = 10;
            wine.Quantity = 15;
            //Wines[wine.Id].Id = wine.Id;
            //Wines[wine.Id].Blg = wine.Blg;
            //Wines[wine.Id].Quantity = wine.Quantity;
            return wine;
        }
    }
}