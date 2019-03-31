
namespace ProductShop.Dtos.Export
{
    using Newtonsoft.Json;

    public class CategoryDto
    {
        [JsonProperty("category")]
        public string Name { get; set; }

        [JsonProperty("productsCount")]
        public int ProductsCount { get; set; }

        [JsonIgnore]
        public decimal TotalPrices { get; set; }

        [JsonProperty("averagePrice")]
        public string AvaragePrice => $"{(this.TotalPrices / this.ProductsCount):F2}";

        [JsonProperty("totalRevenue")]
        public string TotalRevenue => $"{this.TotalPrices:F2}";
    }
}
