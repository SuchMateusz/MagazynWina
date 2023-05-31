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
        public List<T> Objects { get ; set ; }
        public BaseService()
        {
            Objects = new List<T>();
        }
        public int AddNewObject(T obj)
        {
            Objects.Add(obj);
            return obj.Id;
        }
        public void DeleteObject(T obj)
        {
            Objects.Remove(obj);
        }
        public List<T> GetAllObjects()
        {
            return Objects;
        }
        public int UpdateObject(T obj)
        {
            GetAllObjects();
            Objects[obj.Id].Id = obj.Id;
            Objects[obj.Id].Blg = obj.Blg;
            Objects[obj.Id].Quantity = obj.Quantity;
            Console.WriteLine($"\nObject updated: {Objects[obj.Id]}");
            return obj.Id;
        }
        public T ObjectDetail(int id)
        {
            var objectDetails = Objects.FirstOrDefault(p => p.Id == id);
            return (T)objectDetails;
        }
    }
}