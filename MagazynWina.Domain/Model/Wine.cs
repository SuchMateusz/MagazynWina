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
        //public int Id { get; set; }
        //public string Name { get; set; }
        public int TypeOfWine { get; set; }
        //public int Blg { get; set; }
        public int yearProduction { get; set; }
        //public int Quantity { get; set; }
        public string Yeast { get; set; }
        protected bool low { get; set; }

    public Wine(int wineId, string nameWine, int typeOfWine, int blg, int year, int quantity, string yeast)
    {
            Id = wineId;
            Name = nameWine;
            TypeOfWine = typeOfWine;
            Blg = blg;
            yearProduction = year;
            Quantity = quantity;
            Yeast = yeast;
    }

        public Wine() : this (0,"nameTest",0,0,0,0, "yeast")
        {
            
        }

        public void CheckValue(int quantityy)
        {
            string check = "";
            if (quantityy <= 10)
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
