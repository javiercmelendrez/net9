using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : BaseEntity
    {
        public string? Description { get; set; }
        public decimal Price {get;set;}

        public ICollection<Store>? Stores {get;set;}

        public ICollection<StoreProduct> StoreProducts {get;set;}
    }
}