using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class SubCategoryToProduct
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Product Product { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
