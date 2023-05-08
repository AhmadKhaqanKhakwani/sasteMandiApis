using Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Dtos.Mobile
{
    public class PublicProductDto
    {
        public string textEng { get; set; }
        public string textUrdu { get; set; }
        public int categoryId { get; set; }
        public List<int> subCategory { get; set; }
        public string imageUrl { get; set; }
        public List<Packaging> packaging { get; set; }
        public int packagePrice { get; set; }
        public int packagePriceId { get; set; }
        public int packageDispalyOrder { get; set; }
        public int displayOrder { get; set; }
        public PublicProductDto toProductDTO(Product product)
        {
            var obj = new PublicProductDto()
            {
                textEng = product.TitleEng,
                textUrdu = product.TitleUrdu,
                imageUrl = product.ProductImages.FirstOrDefault()?.ImageUrl ?? "",
                displayOrder = 1,
                packaging = product.ProductPackings.Select(u => new Packaging() { text = u.Weight.ToString(), price = 100, oldPrice = 50, isDeafult = u.IsDefault }).ToList(),
                categoryId = product.FeaturedCategoryId,
                subCategory = product.SubCategoryToProducts.Select(u => u.Id).ToList()
            };

            return obj;
        }
        public PublicProductDto toPackageProductDTO(Product product)
        {
            var obj = new PublicProductDto()
            {
                textEng = product.TitleEng,
                textUrdu = product.TitleUrdu,
                imageUrl = product.ProductImages.FirstOrDefault()?.ImageUrl ?? "",
                displayOrder = 1,
                categoryId = product.FeaturedCategoryId,
            };

            return obj;
        }
    }
    public class PublicPackageDto
    {
        public string title { get; set; }
        public int totalPrice { get; set; }
        public List<PublicProductDto> products { get; set; }

    }
    public class LocationDto
    {
        public int id { get; set; }
        public string title { get; set; }

    }
    public class ProductAndPackage
    {
        public int productId { get; set; }
        public int packingId { get; set; }
        public int qty { get; set; }

    }
    public class PackageOrderDto
    {
        public int packageId { get; set; }
        public int qty { get; set; }

    }
    public class CreateOrderDto
    {
        public List<ProductAndPackage> products { get; set; }
        public List<PackageOrderDto> packages { get; set; }
        public AddressDto address { get; set; }
        public string freetext { get; set; }
        public int discountId { get; set; }

    }

    public class AddressDto
    {
        public int addressId { get; set; }
        public int locationId { get; set; }
        public string addressText { get; set; }
        public string locationText { get; set; }
        public string googleLocation { get; set; }
    }


    public class Packaging
    {
        public string text { get; set; }
        public int price { get; set; }
        public int priceId { get; set; }
        public int oldPrice { get; set; }
        public bool isDeafult { get; set; }
    }
}
