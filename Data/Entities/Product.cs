using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Product
    {
        public Product()
        {
            ColsedStocks = new HashSet<ColsedStock>();
            PackageDetails = new HashSet<PackageDetail>();
            ProductImages = new HashSet<ProductImage>();
            ProductPackings = new HashSet<ProductPacking>();
            SubCategoryToProducts = new HashSet<SubCategoryToProduct>();
        }

        public int Id { get; set; }
        public string Sku { get; set; }
        public string TitleEng { get; set; }
        public string TitleUrdu { get; set; }
        public int DescriptionId { get; set; }
        public int PerKgPrice { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ProductDescription Description { get; set; }
        public virtual ICollection<ColsedStock> ColsedStocks { get; set; }
        public virtual ICollection<PackageDetail> PackageDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductPacking> ProductPackings { get; set; }
        public virtual ICollection<SubCategoryToProduct> SubCategoryToProducts { get; set; }
    }
}
