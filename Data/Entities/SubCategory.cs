using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            SubCategoryToPackages = new HashSet<SubCategoryToPackage>();
            SubCategoryToProducts = new HashSet<SubCategoryToProduct>();
        }

        public int Id { get; set; }
        public int FeaturedCategoryId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? DisplayOrder { get; set; }

        public virtual FeaturedCategory FeaturedCategory { get; set; }
        public virtual ICollection<SubCategoryToPackage> SubCategoryToPackages { get; set; }
        public virtual ICollection<SubCategoryToProduct> SubCategoryToProducts { get; set; }
    }
}
