using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public decimal Total { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public int CustomerId { get; set; }
        public int AdressId { get; set; }
        public int StatusId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual OrderStatus Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
