using System;
using System.Collections.Generic;

namespace DntAppApi.core.Entities
{
    public partial class TblProduct
    {
        public int Productid { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
    }
}
