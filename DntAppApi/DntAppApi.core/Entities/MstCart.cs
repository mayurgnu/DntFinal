using System;
using System.Collections.Generic;

namespace DntAppApi.core.Entities
{
    public partial class MstCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int? Qty { get; set; }
        public double? Price { get; set; }
        public double? Total { get; set; }
    }
}
