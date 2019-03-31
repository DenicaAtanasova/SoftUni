namespace ProductShop.Dtos.Export
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class SellerDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public ICollection<SoldProductDto> ProductsSold { get; set; }
    }
}