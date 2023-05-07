using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int EntityId { get; set; }
        public int EntityTypeId { get; set; }
        public int PriceId { get; set; }
        public decimal TotalQty { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual OrderEntityType EntityType { get; set; }
        public virtual Order Order { get; set; }
        public virtual Pricing Price { get; set; }
    }
}
