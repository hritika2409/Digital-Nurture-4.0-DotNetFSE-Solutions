using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceSearch
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName.ToLower();
            Category = category.ToLower();
        }

        public override string ToString()
        {
            return $"{ProductId} - {ProductName} ({Category})";
        }
    }

    class Program
    {
        static List<Product> products = new List<Product>();
        static Dictionary<string, List<Product>> nameDict = new Dictionary<string, List<Product>>();
        static Dictionary<string, List<Product>> categoryDict = new Dictionary<string, List<Product>>();

        static void Main()
        {
          
            SeedProducts();
            BuildDictionaries();

            int searchId = 104;
            string searchName = "book";
            string searchCategory = "education";

            Console.WriteLine("📌 Product List:");
            ShowAllProducts();

            // ---------------------------
            // 1. Understand Asymptotic Notation
            //
            // Big O Notation:
            // - Big O notation describes the upper bound of an algorithm’s runtime as input size grows.
            // - It helps evaluate how scalable an algorithm is in worst-case scenarios.
            // - Example: O(n), O(log n), O(1)
            //
            // Best, Average, and Worst Case:
            // - Best Case: Ideal scenario (e.g., element is at the beginning).
            // - Average Case: Expected scenario over many inputs.
            // - Worst Case: Least favorable input (e.g., element not found or at end).
            // ---------------------------

            Console.WriteLine("\n🔍 Linear Search by ID:");
            // Linear Search has:
            // - Best Case: O(1) (if item is at start)
            // - Average Case: O(n/2) ≈ O(n)
            // - Worst Case: O(n)
            var linear = LinearSearch(searchId);
            Console.WriteLine(linear != null ? $"✅ Found: {linear}" : "❌ Not found");

            Console.WriteLine("\n🔍 Binary Search by ID:");
            // Binary Search has:
            // - Best Case: O(1) (if item is at mid)
            // - Average/Worst Case: O(log n)
            // Requires sorted input
            var binary = BinarySearch(searchId);
            Console.WriteLine(binary != null ? $"✅ Found: {binary}" : "❌ Not found");

            Console.WriteLine($"\n🔍 Dictionary Search by Name: \"{searchName}\"");
            // Dictionary lookup is typically O(1) average-case due to hashing
            var nameResults = SearchByName(searchName);
            if (nameResults.Count > 0)
                nameResults.ForEach(p => Console.WriteLine($"✅ {p}"));
            else
                Console.WriteLine("❌ No results");

            Console.WriteLine($"\n🔍 Dictionary Search by Category: \"{searchCategory}\"");
            var categoryResults = SearchByCategory(searchCategory);
            if (categoryResults.Count > 0)
                categoryResults.ForEach(p => Console.WriteLine($"✅ {p}"));
            else
                Console.WriteLine("❌ No results");

            // ---------------------------
            // 4. Analysis:
            //
            // Linear Search vs Binary Search:
            // - Linear Search Time Complexity: O(n)
            // - Binary Search Time Complexity: O(log n), but needs sorted data
            //
            // Dictionary Search:
            // - Average-case Time Complexity: O(1)
            // - Worst-case (due to collisions): O(n)
            //
            // Recommendation:
            // - Use Dictionary for constant-time lookups by Name or Category.
            // - Use Binary Search if data is sorted and memory-efficient solution is preferred.
            // - Linear Search is simple and works without sorting but less efficient.
            // ---------------------------
        }

        static void SeedProducts()
        {
            products = new List<Product>
            {
                new Product(105, "Shoes", "Footwear"),
                new Product(101, "Laptop", "Electronics"),
                new Product(104, "Book", "Education"),
                new Product(102, "Shirt", "Clothing"),
                new Product(103, "Mobile", "Electronics"),
                new Product(106, "Pen", "Education"),
                new Product(107, "Trousers", "Clothing"),
            };
        }

        static void BuildDictionaries()
        {
            nameDict.Clear();
            categoryDict.Clear();

            foreach (var product in products)
            {
                if (!nameDict.ContainsKey(product.ProductName))
                    nameDict[product.ProductName] = new List<Product>();
                nameDict[product.ProductName].Add(product);

                if (!categoryDict.ContainsKey(product.Category))
                    categoryDict[product.Category] = new List<Product>();
                categoryDict[product.Category].Add(product);
            }
        }

        static Product LinearSearch(int id)
        {
            // O(n) Time Complexity
            return products.FirstOrDefault(p => p.ProductId == id);
        }

        static Product BinarySearch(int id)
        {
            // O(log n) Time Complexity
            var sorted = products.OrderBy(p => p.ProductId).ToList();
            int left = 0, right = sorted.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (sorted[mid].ProductId == id)
                    return sorted[mid];
                else if (sorted[mid].ProductId < id)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }

        static List<Product> SearchByName(string name)
        {
            // O(1) Average Case using HashMap 
            name = name.ToLower();
            return nameDict.ContainsKey(name) ? nameDict[name] : new List<Product>();
        }

        static List<Product> SearchByCategory(string category)
        {
            // O(1) Average Case using HashMap 
            category = category.ToLower();
            return categoryDict.ContainsKey(category) ? categoryDict[category] : new List<Product>();
        }

        static void ShowAllProducts()
        {
            foreach (var product in products.OrderBy(p => p.ProductId))
                Console.WriteLine(product);
        }
    }
}
