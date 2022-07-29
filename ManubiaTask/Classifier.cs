using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManubiaTask
{
    public abstract class Classifier
    {
        protected abstract string AttributeName { get; }
        protected ushort ConcurrentOperationsLimit { get; set; } = 1;
        protected virtual Dictionary<string, string> ExtractAttributes(Product product) => null;

        public void Run(string folderName)
        {
            Logger.Log(LogLevel.INFO, AttributeName, $"{AttributeName} classifier started attributes' extraction process for {folderName}");
            var path = $@"{Directory.GetCurrentDirectory()}\{folderName}.json";
            if(Directory.Exists(path))
            {
                var products = new List<Product>();
                foreach(var file in Directory.GetFiles(path))
                {
                    try
                    {
                        var content = File.ReadAllText(file);
                        if(!string.IsNullOrEmpty(content))
                        {
                            var product = JsonConvert.DeserializeObject<Product>(content);
                            products.Add(product);
                        }
                    }
                    catch(Exception e)
                    {
                        Logger.Log(LogLevel.ERROR, AttributeName, "Exception occured while deserializing product", e);
                    }
                }

                if(products.Any())
                {
                    Parallel.ForEach(products, new ParallelOptions { MaxDegreeOfParallelism = ConcurrentOperationsLimit }, (product) =>
                    {
                        var attributes = ExtractAttributes(product);
                        if(attributes != null)
                        {
                            if(product.Attributes == null)
                            {
                                product.Attributes = new Dictionary<string, string>();
                            }

                            foreach(var attribute in attributes)
                            {
                                product.Attributes[attribute.Key] = attribute.Value;
                            }
                        }
                        try
                        {
                            var serializedProduct = JsonConvert.SerializeObject(product);
                            File.WriteAllText($@"{path}\{product.Sku}", serializedProduct);
                        }
                        catch(Exception e)
                        {
                            Logger.Log(LogLevel.ERROR, AttributeName, $"Exception occured while serializing product: {product.Sku}", e);
                        }
                    });
                }
            }

            Logger.Log(LogLevel.INFO, AttributeName, $"{AttributeName} classifier finished attributes' extraction process for {folderName}");
        }

        protected static class Suffixes
        {
            public const string LENGTH = "_LENGTH";
            public const string CAPACITY = "_CAPACITY";
            public const string WEIGHT = "_WEIGHT";
        }

        protected static class Regexes
        {
            public static Dictionary<string, string[]> Units { get; } = new Dictionary<string, string[]>()
            {
                ["CAPACITY"] = new[] { "ML", "L" },
                ["LENGTH"] = new[] { "MM", "CM", "DM", "M"},
                ["WEIGHT"] = new[] { "MCG", "µG", "MG", "G", "DAG", "KG"},
            };

            public static Regex UnitValueRegex { get; } = new Regex(@"WRITE_PATTERN_HERE", RegexOptions.Compiled); //needs pattern to work 
        }
    }
}
