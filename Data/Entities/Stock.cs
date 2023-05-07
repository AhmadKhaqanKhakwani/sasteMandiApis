using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Stock
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public int ProductId { get; set; }
        public int EntityTypeId { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Pricing PriceNavigation { get; set; }
    }
}
