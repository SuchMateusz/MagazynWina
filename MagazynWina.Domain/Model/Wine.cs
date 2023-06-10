using MagazynWina.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynWina.Domain.Model

{
    public class Wine : BaseModel
    {
        public int TypeOfWine { get; set; }
        public int YearProduction { get; set; }
        public string Yeast { get; set; }

        public Wine(int wineId, string nameWine, int typeOfWine, byte blg, int year, ushort quantity, string yeast)
        {
            Id = wineId;
            Name = nameWine;
            TypeOfWine = typeOfWine;
            Blg = blg;
            YearProduction = year;
            Quantity = quantity;
            Yeast = yeast;
        }
    }
}
