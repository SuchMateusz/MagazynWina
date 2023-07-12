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
        public List<T> Objects { get; set; }

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
            Objects[obj.Id-1].Id = obj.Id;
            Objects[obj.Id-1].Name = obj.Name;
            Objects[obj.Id-1].Blg = obj.Blg;
            Objects[obj.Id-1].Quantity = obj.Quantity;
            return obj.Id;
        }

        public T ObjectDetail(int id)
        {
            var objectDetails = Objects.FirstOrDefault(p => p.Id == id);
            return (T)objectDetails;
        }

        public bool CheckObjectAmount(int quantity)
        {
            bool lowAmount;
            if (quantity <= 10)
                lowAmount = true;
            else
                lowAmount = false;

            return lowAmount;
        }
    }
}