using System;
using System.Collections.Generic;
using System.Text;

namespace Product.DataAccessLayer.Entities
{
    public class ProductEntity
    {
        public long? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductQty { get; set; }
        public decimal ProductPrice { get; set; }
    }
    public class ProductDetailEntity : ProductEntity
    {

    }
    public class ProductFilterEntity
    {
        public string ProductName { get; set; }
    }

}
