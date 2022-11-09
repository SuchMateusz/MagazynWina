using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagazynWina.Domain.Model;


namespace MagazynWina.Domain.Base
{
    public class BaseModel : AuditableModel
    {
        public object Wines;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Blg { get; set; }
        public int Quantity { get; set; }
    }
}
