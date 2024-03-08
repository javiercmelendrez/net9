using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class StoreProduct
    {

        public Guid StoreId { get; set; }
        public Store Store {get;set;}

        public Guid ProductId {get;set;}
        public Product Product {get;set;}

        

        public ICollection<Product> Products {get;set;}

    }
}