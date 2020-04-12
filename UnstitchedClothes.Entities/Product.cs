using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnstitchedClothes.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }
        public decimal Price { get; set; }
        //public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}
