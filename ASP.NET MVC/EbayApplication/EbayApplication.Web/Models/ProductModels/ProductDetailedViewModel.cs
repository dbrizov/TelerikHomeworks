namespace EbayApplication.Web.Models.ProductModels
{
    using EbayApplication.Web.Models.AuctionModels;
    using System.Linq;

    public class ProductDetailedViewModel
    {
        public AuctionDetailedViewModel Auction { get; set; }

        public ProductViewModel Product { get; set; }

        public ProductDetailedViewModel()
        {
        }

        public ProductDetailedViewModel(ProductViewModel product)
        {
            this.Product = product;
        }

        public ProductDetailedViewModel(ProductViewModel product, AuctionDetailedViewModel auction)
            :this(product)
        {
            this.Auction = auction;
        }

        public IQueryable<ProductFlatViewModel> SimilarProducts { get; set; }
    }
}