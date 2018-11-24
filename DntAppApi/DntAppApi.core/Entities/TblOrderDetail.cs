using System;
using System.Collections.Generic;

namespace DntAppApi.core.Entities
{
    public partial class TblOrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Qty { get; set; }
        public double? Price { get; set; }

        public TblOrderMst Order { get; set; }
    }
}
