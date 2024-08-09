using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Threading;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_2_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Elements operators

            //1.Get first Product out of Stock
            #region Part1 - Q1
            //var product = ListGenerator.ProductsList.First(p => p.UnitsInStock == 0);
            //Console.WriteLine($"first Product out of Stock: {product}"); 
            #endregion

            //2.Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            #region Part1 - Q2
            //var product = ListGenerator.ProductsList.FirstOrDefault(p => p.UnitPrice > 1_000);
            //Console.WriteLine(product); 
            #endregion

            //3.Retrieve the second number greater than 5
            //Int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            #region Part1 - Q3
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var secondNumberGreaterThan5 = Arr.Order().Where(x => x > 5).Skip(1).FirstOrDefault();

            //Console.WriteLine($"The second number greater than 5 is : {secondNumberGreaterThan5}");
            #endregion

            #endregion

            #region LINQ - Aggregate operators

            //1.Uses Count to get the number of odd numbers in the array
            //Int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            #region Part2 - Q1
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var oddNumbers = Arr.Where(n => n % 2 == 0).Count();

            //Console.WriteLine($"Number of Odd Numbers is : {oddNumbers}");
            #endregion

            //2.Return a list of customers and how many orders each has.
            #region Part2 - Q2
            //var customerssOrderCount = ListGenerator.CustomersList.Select(c => new { c.CustomerName, orderCount = c.Orders.Count() });

            //int customerId = 1;
            //foreach (var customer in customerssOrderCount)
            //{ 
            //    Console.WriteLine($"{customerId} - Customer Name: {customer.CustomerName}, Number of orders: {customer.orderCount}");
            //    customerId++;
            //}
            #endregion

            //3.Return a list of categories and how many products each has
            #region Part2 - Q3
            //var categoryProductsCount = ListGenerator.ProductsList.GroupBy(P => P.Category)
            //                                                      .Select(p => new { ProductCategory = p.Key, ProductCount = p.Count() });
            //foreach (var categoryProduct in categoryProductsCount)
            //{
            //    Console.WriteLine($"Category: {categoryProduct.ProductCategory}, Number of products: {categoryProduct.ProductCount}");
            //}
            #endregion

            //4.Get the total of the numbers in an array.
            //Int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            #region Part2 - Q4
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var sum = Arr.Sum();

            //Console.WriteLine($"Total of the Numbers in the array: {sum}");
            #endregion

            //5.Get the total number of characters of all words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            #region Part2 - Q5
            //string[] words = File.ReadAllLines("dictionary_english.txt");

            //int totalCharacters = words.Sum(w => w.Length);

            //Console.WriteLine($"Total number of characters in all words: {totalCharacters}");
            #endregion

            //6.Get the length of the shortest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            #region Part - Q6
            //string[] words = File.ReadAllLines("dictionary_english.txt");

            //int shortestWordLength = words.Min(word => word.Length);

            //Console.WriteLine($"The length of shortest word: {shortestWordLength}");
            #endregion

            //7.Get the length of the longest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            #region Part2 - Q7
            //string[] words = File.ReadAllLines("dictionary_english.txt");

            //int longestWordLength = words.Max(word => word.Length);

            //Console.WriteLine($"The length of shortest word: {longestWordLength}"); 
            #endregion

            //8.Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            #region Part2 - Q8
            //string[] words = File.ReadAllLines("dictionary_english.txt");

            //var AvgWordLength = words.Average(word => word.Length);

            //Console.WriteLine($"The length of shortest word: {AvgWordLength}");
            #endregion

            //9.Get the total units in stock for each product category.
            #region Part2 - Q9
            //var totalUnitsInStockPerCategory = ListGenerator.ProductsList.GroupBy(P => P.Category)
            //                                                .Select(p => new { category = p.Key, TotalUnitsInStock = p.Sum(p => p.UnitsInStock) });

            //foreach(var category in totalUnitsInStockPerCategory)
            //{
            //    Console.WriteLine($"Category: {category.category}, Total Units: {category.TotalUnitsInStock}");
            //}
            #endregion

            //10.Get the cheapest price among each category's products
            #region Part2 - Q10
            //var cheapestPerCategory = ListGenerator.ProductsList.GroupBy(P => P.Category)
            //                                                .Select(p => new { category = p.Key, cheapest = p.Min(p => p.UnitPrice) });

            //foreach (var category in cheapestPerCategory)
            //{
            //    Console.WriteLine($"Category: {category.category}, cheapest price: {category.cheapest}");
            //}
            #endregion

            //11.Get the products with the cheapest price in each category(Use Let)
            #region Part2 - Q11
            //var cheapestPerCategory = from p in ListGenerator.ProductsList
            //                          group p by p.Category into cat
            //                          let minPrice = cat.Min(p => p.UnitPrice)
            //                          select new
            //                          {
            //                              Category = cat.Key,
            //                              Products = cat.Where(p => p.UnitPrice == minPrice)
            //                          };

            //foreach (var categoryGroup in cheapestPerCategory)
            //{
            //    Console.WriteLine($"Category: {categoryGroup.Category}");
            //    foreach (var product in categoryGroup.Products)
            //    {
            //        Console.WriteLine($"    Product: {product.ProductName}, Price: {product.UnitPrice}");
            //    }
            //}
            #endregion

            //12.Get the most expensive price among each category's products.
            #region Part2 - Q12
            //var MostExpensivePerCategory = ListGenerator.ProductsList.GroupBy(P => P.Category)
            //                                                .Select(p => new { category = p.Key, mostExpensive = p.Max(p => p.UnitPrice) });

            //foreach (var category in MostExpensivePerCategory)
            //{
            //    Console.WriteLine($"Category: {category.category}, most Expensive price: {category.mostExpensive}");
            //}
            #endregion

            //13. Get the products with the most expensive price in each category.
            #region Part2 - Q13
            //var theMostExpensivePerCategory = from p in ListGenerator.ProductsList
            //                          group p by p.Category into cat
            //                          let maxPrice = cat.Max(p => p.UnitPrice)
            //                          select new
            //                          {
            //                              Category = cat.Key,
            //                              Products = cat.Where(p => p.UnitPrice == maxPrice)
            //                          };

            //foreach (var categoryGroup in theMostExpensivePerCategory)
            //{
            //    Console.WriteLine($"Category: {categoryGroup.Category}");
            //    foreach (var product in categoryGroup.Products)
            //    {
            //        Console.WriteLine($"    Product: {product.ProductName}, Price: {product.UnitPrice}");
            //    }
            //}
            #endregion

            //14.Get the average price of each category's products.
            #region Part2 - Q14
            //var AvgPerCategory = ListGenerator.ProductsList.GroupBy(P => P.Category)
            //                                        .Select(p => new { category = p.Key, avg = p.Average(p => p.UnitPrice) });

            //foreach (var category in AvgPerCategory)
            //{
            //    Console.WriteLine($"Category: {category.category}, Average price: {category.avg}");
            //} 
            #endregion

            #endregion

            #region LINQ - Set operators

            //1.Find the unique Category names from Product List
            #region Part3 - Q1
            //var uniqueCategories = ListGenerator.ProductsList.Select(p => p.Category).Distinct();

            //Console.WriteLine("Unique Category Names:");
            //foreach (var category in uniqueCategories)
            //{
            //    Console.WriteLine(category);
            //}
            #endregion

            //2.Produce a Sequence containing the unique first letter from both product and customer names.
            #region Part3 - Q2
            //var productFirstLetters = ListGenerator.ProductsList.Select(p => p.ProductName[0]).Distinct();

            //var customerFirstLetters = ListGenerator.CustomersList.Select(c => c.CustomerName[0]).Distinct();

            //var uniqueFirstLetters = productFirstLetters.Union(customerFirstLetters).Distinct();

            //Console.WriteLine("Unique First Letters:");
            //foreach (var letter in uniqueFirstLetters)
            //{
            //    Console.WriteLine(letter);
            //}
            #endregion

            //3.Create one sequence that contains the common first letter from both product and customer names.
            #region Part3 - Q3
            //var productFirstLetters = ListGenerator.ProductsList.Select(p => p.ProductName[0]).Distinct();

            //var customerFirstLetters = ListGenerator.CustomersList.Select(c => c.CustomerName[0]).Distinct();

            //var commonFirstLetters = productFirstLetters.Intersect(customerFirstLetters).Distinct();

            //Console.WriteLine("Common First Letters:");
            //foreach (var letter in commonFirstLetters)
            //{
            //    Console.WriteLine(letter);
            //}
            #endregion

            //4.Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            #region Part3 - Q4
            //var productFirstLetters = ListGenerator.ProductsList.Select(p => p.ProductName[0]).Distinct();

            //var customerFirstLetters = ListGenerator.CustomersList.Select(c => c.CustomerName[0]).Distinct();

            //var uniqueProductFirstLetters = productFirstLetters.Except(customerFirstLetters).Distinct();

            //Console.WriteLine("First Letters of Products Not in Customer Names:");
            //foreach (var letter in uniqueProductFirstLetters)
            //{
            //    Console.WriteLine(letter);
            //}
            #endregion

            //5.Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
            #region Part3 - Q5
            //var productLastThreeChars = ListGenerator.ProductsList
            //                                         .Select(p => p.ProductName.Length >= 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName);

            //var customerLastThreeChars = ListGenerator.CustomersList
            //                                          .Select(c => c.CustomerName.Length >= 3 ? c.CustomerName.Substring(c.CustomerName.Length - 3) : c.CustomerName);

            //var combinedLastThreeChars = productLastThreeChars.Concat(customerLastThreeChars);

            //Console.WriteLine("Last Three Characters of All Names:");
            //foreach (var chars in combinedLastThreeChars)
            //{
            //    Console.WriteLine(chars);
            //} 
            #endregion

            #endregion

        }
    }
}
