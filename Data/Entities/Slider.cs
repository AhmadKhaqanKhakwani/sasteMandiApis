using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Slider
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Task { get; set; }
        public int PackageId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
