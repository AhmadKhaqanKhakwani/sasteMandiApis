using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class EmailTemplate
    {
        public int EmailTemplateId { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
