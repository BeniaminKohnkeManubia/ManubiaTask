using System.Collections.Generic;

namespace ManubiaTask
{
    public sealed class Product
    {
        #region PART_1
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Sku { get; set; } //product id from the page
        public string Name { get; set; }
        public string Description { get; set; }
        public string Availability { get; set; } //current status of the product (for example: "out of stock")
        public string Brand { get; set; }
        public decimal Price { get; set; } //current price of the product
        public decimal OldPrice { get; set; } //only displayed when the product is discounted
        public List<string> Categories { get; set; } = new List<string>();
        public Dictionary<string, string> Specification { get; set; } = new Dictionary<string, string>(); //product's attributes which are not part of the description (for example: ilość:20szt.)
        #endregion

        #region PART_2
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
        #endregion
    }
}
