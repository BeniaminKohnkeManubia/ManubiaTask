using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace ManubiaTask
{
    public abstract class Sitemap
    {
        private readonly string _algorithmName;
        private readonly string _resultPath;
        private readonly string _mainPageUrl;

        protected ushort ConcurrentRequestsLimit { get; set; } = 1;
        protected ConcurrentBag<string> CategoriesPages { get; } = new ConcurrentBag<string>();
        protected ConcurrentBag<string> ProductsPages { get; } = new ConcurrentBag<string>();

        protected Sitemap(string shopName, string mainPageUrl)
        {
            _algorithmName = shopName;
            _mainPageUrl = mainPageUrl;
            _resultPath = $@"{Directory.GetCurrentDirectory()}\{_algorithmName}";
            if(Directory.Exists(_resultPath))
            {
                foreach(var file in Directory.GetFiles(_resultPath))
                {
                    File.Delete(file);
                }
            }
            else
            {
                Directory.CreateDirectory(_resultPath);
            }
        }

        protected abstract void GetCategoriesPages(string mainPageUrl);
        protected abstract void GetProductsPages(string categoryPageUrl);
        protected abstract void ExtractProductData(string productPageUrl);

        protected virtual void SaveProduct(Product product)
        {
            if(string.IsNullOrEmpty(product.Sku))
            {
                Logger.Log(LogLevel.WARNING, _algorithmName, "Product sku is empty");
            }
            else if(Directory.Exists($@"{_resultPath}\{product.Sku}.json"))
            {
                Logger.Log(LogLevel.WARNING, _algorithmName, $"Product has been duplicated - sku:{product.Sku}");
            }
            else
            {
                try
                {
                    var serializedProduct = JsonConvert.SerializeObject(product, Formatting.Indented);
                    File.WriteAllText($@"{_resultPath}\{product.Sku}.json", serializedProduct);
                    
                    Logger.Log(LogLevel.INFO, _algorithmName, $"Product has been saved - sku:{product.Sku}");
                }
                catch(Exception e)
                {
                    Logger.Log(LogLevel.ERROR, _algorithmName, "Exception while saving the product", e);
                }
            }
        }

        public void Run()
        {
            Logger.Log(LogLevel.INFO, _algorithmName, $"Started data extraction process");
            GetCategoriesPages(_mainPageUrl);

            Parallel.ForEach(CategoriesPages, new ParallelOptions { MaxDegreeOfParallelism = ConcurrentRequestsLimit }, (category) =>
            {
                GetProductsPages(category);
            });

            Parallel.ForEach(ProductsPages, new ParallelOptions { MaxDegreeOfParallelism = ConcurrentRequestsLimit }, (product) =>
            {
                ExtractProductData(product);
            });

            Logger.Log(LogLevel.INFO, _algorithmName, $"Finished data extraction process");
        }
    }
}
