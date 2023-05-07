using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class PackageDetail
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int ProductId { get; set; }
        public int PriceId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Package Package { get; set; }
        public virtual Pricing Price { get; set; }
        public virtual Product Product { get; set; }
    }
}
