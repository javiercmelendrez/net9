using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Store : BaseEntity
    {

        public string? Name { get; set; }
        public string? Address { get; set; }

        public ICollection<Product>? Products {get;set;}

        public ICollection<StoreProduct> StoreProducts {get;set;}
       
    }
}