using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Product.DataAccessLayer.Entities;
using ProductAPI.Utils;

namespace ProductAPI.Models
{
    public class ProductModel
    {
        public long? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductQty { get; set; }
        public decimal ProductPrice { get; set; }

    }
    public class ProductDetailModel : ProductModel
    {
    }


    public class ProductFilterModel
    {
        public string ProductName { get; set; }
    }
}
