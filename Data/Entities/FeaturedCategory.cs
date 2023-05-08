using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class FeaturedCategory
    {
        public FeaturedCategory()
        {
            Products = new HashSet<Product>();
            SubCategories = new HashSet<SubCategory>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsPackage { get; set; }
        public string ImageUrl { get; set; }
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
