using System;
using System.Collections.Generic;

namespace DntAppApi.core.Entities
{
    public partial class TblOrderMst
    {
        public TblOrderMst()
        {
            TblOrderDetail = new HashSet<TblOrderDetail>();
        }

        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public double? TotalAmount { get; set; }
        public double? GstAmount { get; set; }
        public double? Discount { get; set; }
        public string PayableAmount { get; set; }

        public TblOrderMst Order { get; set; }
        public TblOrderMst InverseOrder { get; set; }
        public ICollection<TblOrderDetail> TblOrderDetail { get; set; }
    }
}
