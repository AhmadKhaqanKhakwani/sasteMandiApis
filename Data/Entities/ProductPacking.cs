using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class ProductPacking
    {
        public int Id { get; set; }
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public decimal Weight { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string PackingTitle { get; set; }

        public virtual Pricing Price { get; set; }
        public virtual Product Product { get; set; }
    }
}
