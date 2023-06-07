using MagazynWina.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynWina.App.AbstractInteface
{
    public interface IService<T>
    {
        List<T> Objects { get; set; }
        List<T> GetAllObjects();
        int AddNewObject(T obj);
        int UpdateObject(T obj);
        void DeleteObject(T obj);
        T ObjectDetail(int Id);
    }
}
