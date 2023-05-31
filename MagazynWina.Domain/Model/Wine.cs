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
        protected bool Low { get; set; }
        public Wine(int typeWineId, int wineId, string nameWine, int typeOfWine, byte blg, int year, ushort quantity, string yeast)
        {
            TypeObjectId = typeWineId;
            Id = wineId;
            Name = nameWine;
            TypeOfWine = typeOfWine;
            Blg = blg;
            YearProduction = year;
            Quantity = quantity;
            Yeast = yeast;
        }
        public void CheckWineAmount (int quantity)
        {
            string check;
            if (quantity <= 10)
            {
                Low = true;
            }

            else
                Low = false;

            if (Low == true)
            {
            check = "Posiadasz już zbyt małą ilość do handlu";
            }   

            else
            {
                check = "Posiadana ilość jest wystarczająca";
            }

            Console.WriteLine(check);
        }
    }
}
