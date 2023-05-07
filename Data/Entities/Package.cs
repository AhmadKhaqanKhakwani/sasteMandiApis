using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Package
    {
        public Package()
        {
            PackageDetails = new HashSet<PackageDetail>();
        }

        public int Id { get; set; }
        public string PackageTitle { get; set; }
        public int PackageTotalPrice { get; set; }
        public int PackageCategoryId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual PackageCategory PackageCategory { get; set; }
        public virtual ICollection<PackageDetail> PackageDetails { get; set; }
    }
}
