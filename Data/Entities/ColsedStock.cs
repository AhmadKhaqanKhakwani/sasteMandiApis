using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class ColsedStock
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public int? ProductId { get; set; }
        public int? TypeId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Product Product { get; set; }
    }
}
