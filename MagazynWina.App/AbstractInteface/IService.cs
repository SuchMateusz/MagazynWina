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
        List<T> Wines { get; set; }

        List<T> GetAllWines();
        int AddWine(T wine);
        int UpdateWine(T wine);

        void DeleteWine(T wine);

        void SuggarAddWine();

        T wineDetail(int Id);
        T UpdateWineTestID(T wine);

    }
}
