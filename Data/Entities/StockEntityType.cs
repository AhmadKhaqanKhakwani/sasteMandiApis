using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class StockEntityType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
}
