using System.Text.RegularExpressions;

namespace ManubiaTask
{
    public static class Constant
    {
        /// <summary>
        /// get href attribute
        /// </summary>
        public const string FARMASIRO_CATEGORIES_PAGES_XPATH = "//div[@id='productDiv']//div[@class='productMenuHeader']/a";
        public const string FARMASIRO_PRODUCTS_PAGES_POST_URL = "https://farmasi.ro/Product/GetProductsByCategoryId";
        /// <summary>
        /// replace CATEGORY_ID_STRING with category id from url and PAGE_NUMBER_STRING with page number from API response for first page
        /// </summary>
        public const string FARMASIRO_PRODUCTS_PAGES_POST_DATA = "{" + "\"CategoryId\":\"CATEGORY_ID_STRING\",\"PageNumber\":PAGE_NUMBER_STRING" + "}";
        /// <summary>
        /// replace PRODUCT_ID with product id from API response
        /// </summary>
        public const string FARMASIRO_PRODUCT_PAGE_URL = "https://farmasi.ro/product/detail?pid=PRODUCT_ID";

        public const string FARMASIRO_PRODUCT_ID_JSONPATH = "$.Products..Code";
        public const string FARMASIRO_CATEGORY_PAGES_COUNT_JSONPATH = "$.Paging..TotalPages";

        /// <summary>
        /// get src attribute
        /// </summary>
        public const string FARMASIRO_IMAGE_URL_XPATH = "//img[@id='imgProduct']";
        public const string FARMASIRO_SKU_XPATH = "//div[@class='desktopCenterDiv']//div[@class='ProductCode']";
        public const string FARMASIRO_NAME_XPATH = "//div[@class='desktopCenterDiv']//h1[@class='LongName ProductNameDesktop']";
        public const string FARMASIRO_DESCRIPTION_XPATH = "//span[@id='ProductDescription' and @class='Description']";
        public const string FARMASIRO_PRICE_XPATH = "//div[@class='ProductPriceDesktop']//span[@id='MinPrice' and @class='MinPrice']";
        public const string FARMASIRO_OLD_PRICE_XPATH = "//div[@class='ProductPriceDesktop']//span[@id='MaxPrice' and @class='MaxPrice']";
        public const string FARMASIRO_CATEGORIES_XPATH = "//nav[@class='shop-breadcrumb']/ul/li[not(contains(@class,'LongName'))]";
        /// <summary>
        /// set key as "Instrucţiuni de utilizare"
        /// </summary>
        public const string FARMASIRO_SPECIFICATION_1_XPATH = "//span[@id='HowToUse' and @class='Description']";
        /// <summary>
        /// set key as "Detaliile tehnice ale produsului"
        /// </summary>
        public const string FARMASIRO_SPECIFICATION_2_XPATH = "//span[@id='TechnicalDescription' and @class='Description']";

        /// <summary>
        /// use regexes to fix product json content
        /// </summary>
        public const string FARMASIRO_PRODUCT_JSON_XPATH = "//script[contains(text(), '\"type\":\"Product\"')]";
        public const string FARMASIRO_IMAGE_URL_JSONPATH = "$.image";
        public const string FARMASIRO_SKU_JSONPATH = "$.productID";
        public const string FARMASIRO_NAME_JSONPATH = "$.name";
        public const string FARMASIRO_DESCRIPTION_JSONPATH = "$.description";
        public const string FARMASIRO_AVAILABILITY_JSONPATH = "$.offers..availability";
        public const string FARMASIRO_BRAND_JSONPATH = "$.brand";
        public const string FARMASIRO_PRICE_JSONPATH = "$.offers..price";

        /// <summary>
        /// use it on product's json - change group 1 to "group 1"
        /// </summary>
        public static readonly Regex PRODUCT_JSON_DESCRIPTION_FIX_REGEX = new Regex("\"description\":([\\s\\S]+),\\s*\"url\"", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// use it on product's json - change group 1 to "group 1"
        /// </summary>
        public static readonly Regex PRODUCT_JSON_URL_FIX_REGEX = new Regex("\"url\":([\\S]+),", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// use it on product's json - change group 1 to "group 1"
        /// </summary>
        public static readonly Regex PRODUCT_JSON_IMAGE_URL_FIX_REGEX = new Regex("\"image\":([\\S]+),", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// use it in category url - group 1 contains category id
        /// </summary>
        public static readonly Regex CATEGORY_ID_REGEX = new Regex(@"\?cid=([a-z\d-]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// group 1 is unit, group 2 is content
        /// </summary>
        public const string UNIT_VALUE_REGEX_PATTERN = @"(MCG|DAG|µG|MG|KG|ML|MM|CM|DM|G|L|M)(\d+(?:\.\d+)?)";
    }
}
