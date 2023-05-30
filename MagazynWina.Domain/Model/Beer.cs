using MagazynWina.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MagazynWina.Domain.Model
{
    public class Beer : BaseModel
    {
        public int yearProduction { get; set; }
        //public int Quantity { get; set; }
        public string Yeast { get; set; }

        public string TypeOfBeer { get; set; }

        protected bool low { get; set; }

        public Beer(int typeBeerId, int beerId, string nameBeer, int blg, int year, int quantity, string yeast, string typeOfBeer)
        {
            TypeObjectId = typeBeerId;
            Id = beerId;
            Name = nameBeer;
            Blg = blg;
            yearProduction = year;
            Quantity = quantity;
            Yeast = yeast;
            TypeOfBeer = typeOfBeer;
        }
        public Beer() : this(2,0, "nameTest", 0, 0, 0, "yeast", "PaleAle")
        {

        }

        public void CheckValueBeer(int quantityy)
        {
            string check = "";
            if (quantityy <= 15)
            {
                low = true;
            }
            else
                low = false;

            if (low == true)
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
