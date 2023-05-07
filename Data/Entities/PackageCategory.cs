using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class PackageCategory
    {
        public PackageCategory()
        {
            Packages = new HashSet<Package>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Package> Packages { get; set; }
    }
}
