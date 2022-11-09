using MagazynWina.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynWina.Domain
{
    public class MenuAction : BaseModel

    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MenuName { get; set; }

        public MenuAction(int id, string name, string menuName)
        {
            ID = id;
            Name = name;
            MenuName = menuName;
        }
    }




}
