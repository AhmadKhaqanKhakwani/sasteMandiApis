using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Pricing
    {
        public Pricing()
        {
            OrderDetails = new HashSet<OrderDetail>();
            PackageDetails = new HashSet<PackageDetail>();
            ProductPackings = new HashSet<ProductPacking>();
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int? DiscountedAmount { get; set; }
        public bool IsDiscounted { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<PackageDetail> PackageDetails { get; set; }
        public virtual ICollection<ProductPacking> ProductPackings { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
