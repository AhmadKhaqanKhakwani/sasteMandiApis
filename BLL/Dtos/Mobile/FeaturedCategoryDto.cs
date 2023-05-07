using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos.Mobile
{
    public class FeaturedCategoryDto
    {
        
        public int featuredCategoryId { get; set; }
        public string title { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int displayOrder { get; set; }
        public string imageURL { get; set; }
        public string text { get; set; }
        public List<SubCategoryDto> subCategory { get; set; }
    }
    public class SubCategoryDto
    {
        public int subCategoryId { get; set; }
        public int featuredCategoryId { get; set; }
        public string text { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int displayOrder { get; set; }
    }
}
