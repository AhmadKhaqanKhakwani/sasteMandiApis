using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Address
    {
        public int Id { get; set; }
        public string AddressText { get; set; }
        public string GeoLocaton { get; set; }
        public int LocationId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Location Location { get; set; }
    }
}
