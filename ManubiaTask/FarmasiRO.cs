using System.Collections.Generic;

namespace ManubiaTask
{
    public sealed class FarmasiRO : Sitemap
    {
        private readonly Dictionary<string, string> _getRequestHeaders = new Dictionary<string, string>
        {
            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.62",
        };

        private readonly Dictionary<string, string> _postRequestHeaders = new Dictionary<string, string>
        {
            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.62",
            ["Content-Type"] = "application/json",
        };

        public FarmasiRO() : base(nameof(FarmasiRO), "https://farmasi.ro/")
        {
        }

        protected override void GetCategoriesPages(string mainPageUrl)
        {
            //TODO: from main page extract categories' url addresses and add them to CategoriesPages
        }

        protected override void GetProductsPages(string categoryPageUrl)
        {
            //TODO: from categories' pages extract products' url addresses and add them to ProductsPages
            //set limit to 100 products
        }

        protected override void ExtractProductData(string productPageUrl)
        {
            //TODO: from product's page extract product's data and use SaveProduct method to save it (use product class to store data)
        }

        //Hint: use WebRequestsMethods class to download and parse HTML or JSON
        //Hint: check xpath (XML Path Language) to get data from HTML document or JSONPath to get data from JSON
        //what is more, you can check https://jsonpath.com/ to verify if your path works
        //to verify if xpath works just use "Inspect" in the Web browser and then use ctr+f (sometimes you also need to check page source)
        //Hint: use html.DocumentNode.SelectSingleNode/.SelectNodes to extract data from HTML
        //Hint: use json.SelectToken/.SelectTokens to extract data from JSON
        //Hint: you may notice dynamic loading of products (check page's API by inspecting Web traffic - "network" section in the Web browser)
        //Hint: you can handle responses for significant http status codes - for example code 404 (use HttpStatusCode enum)
    }
}
