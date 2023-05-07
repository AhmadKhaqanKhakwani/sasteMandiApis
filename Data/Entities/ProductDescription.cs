using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class ProductDescription
    {
        public ProductDescription()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string DetailEng { get; set; }
        public string DetailUrdu { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
