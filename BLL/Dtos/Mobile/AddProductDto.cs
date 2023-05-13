using System.Collections.Generic;

namespace BLL.Dtos.Mobile
{
    public class AddProductDto
    {
        public string engTitle { get; set; }
        public string urduTitle { get; set; }
        public int productCategoryId { get; set; }
        public List<int> productSubCategoryId { get; set; }
        public string imgUrl { get; set; }
        public long defaultPrice { get; set; }

        public List<AddProductPackingDto> productPacking { get; set; }

    }

    public class AddProductPackingDto
    {
        public int id { get; set; }
        public decimal weight { get; set; }
        public string weightText { get; set; }
        public int price { get; set; }

    }
}
