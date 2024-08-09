using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_2_LINQ
{
    public class SameCharactersTogetherComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            return string.Concat(x.Order()) == string.Concat(y.Order());
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return string.Concat(obj.Order()).GetHashCode();
        }
    }
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

            #region LINQ - Partitioning Operators

            //1.Get the first 3 orders from customers in Washington
            #region Part4 - Q1
            //var firstThreeOrdersInWashington = ListGenerator.CustomersList.Where(c => c.City == "Washington").SelectMany(c => c.Orders).Take(3);

            //if (firstThreeOrdersInWashington.Any())
            //{
            //    Console.WriteLine("First 3 Orders from Customers in Washington:");
            //    foreach (var order in firstThreeOrdersInWashington)
            //    {
            //        Console.WriteLine(order);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No orders found for customers in Washington.");
            //}
            #endregion


            //2.Get all but the first 2 orders from customers in Washington.
            #region Part4 - Q2
            //var ordersAfterFirstTwoInWashington = ListGenerator.CustomersList.Where(c => c.City == "Washington").SelectMany(c => c.Orders).Skip(2);

            //if (ordersAfterFirstTwoInWashington.Any())
            //{
            //    Console.WriteLine("All but the first 2 Orders from Customers in Washington:");
            //    foreach (var order in ordersAfterFirstTwoInWashington)
            //    {
            //        Console.WriteLine(order);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No orders found for customers in Washington after skipping the first 2.");
            //}
            #endregion

            //3.Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            #region Part4 - Q3
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var result = numbers.Select((value, index) => new { value, index }).TakeWhile(x => x.value >= x.index).Select(x => x.value);

            //Console.WriteLine("Elements until a number less than its position is hit:");
            //Console.WriteLine(string.Join(", ", result));
            #endregion

            //4.Get the elements of the array starting from the first element divisible by 3.
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            #region Part4 - Q4
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //int index = numbers.Select((value, index) => new { value, index }).FirstOrDefault(x => x.value % 3 == 0)?.index ?? -1;

            //var result = index >= 0 ? numbers.Skip(index).ToArray() : new int[0]; // Return an empty array if no element divisible by 3 is found

            //Console.WriteLine("Elements starting from the first element divisible by 3:");
            //Console.WriteLine(string.Join(", ", result));

            #endregion

            //5.Get the elements of the array starting from the first element less than its position.
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            #region Part4 - Q5
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 

            //var result = numbers.Select((value, index) =>  new { value, index }).SkipWhile(x => x.value >= x.index).Select(x => x.value);

            //Console.WriteLine("Elements starting from the first element less than its position:");
            //Console.WriteLine(string.Join(", ", result));

            #endregion

            #endregion

            #region LINQ - Quantifiers

            //1.Determine if any of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            #region Part5 - Q1
            //string[] words = File.ReadAllLines("dictionary_english.txt");

            //bool containsEi = words.Any(word => word.ToLower().Contains("ei"));

            //if (containsEi)
            //{
            //    Console.WriteLine("There are words containing the substring 'ei'.");
            //}
            //else
            //{
            //    Console.WriteLine("No words contain the substring 'ei'.");
            //} 
            #endregion

            //2.Return a grouped a list of products only for categories that have at least one product that is out of stock.
            #region Part5 - Q2
            //var groupedProducts = ListGenerator.ProductsList.GroupBy(p => p.Category).Where(p => p.Any(P => P.UnitsInStock == 0));

            //foreach (var group in groupedProducts)
            //{
            //    Console.WriteLine($"Category: {group.Key}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine($"  Product: {product.ProductName}, Units in Stock: {product.UnitsInStock}");
            //    }
            //}
            #endregion

            //3.Return a grouped a list of products only for categories that have all of their products in stock.
            #region Part5 - Q3
            //var groupedProducts = ListGenerator.ProductsList.GroupBy(p => p.Category).Where(p => p.All(P => P.UnitsInStock > 0));

            //foreach (var group in groupedProducts)
            //{
            //    Console.WriteLine($"Category: {group.Key}");
            //    foreach (var product in group)
            //    {
            //        Console.WriteLine($"  Product: {product.ProductName}, Units in Stock: {product.UnitsInStock}");
            //    }
            //} 
            #endregion
            #endregion

            #region LINQ – Grouping Operators
            //1.Use group by to partition a list of numbers by their remainder when divided by 5
            //List<int> numbers = new list<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            #region Part6 - Q1
            //List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            //var groupedNumbers = numbers.GroupBy(n => n % 5);

            //foreach (var group in groupedNumbers)
            //{
            //    Console.WriteLine($"Remainder {group.Key}:");
            //    foreach (var number in group)
            //    {
            //        Console.Write($"{number} ");
            //    }
            //    Console.WriteLine();
            //} 
            #endregion

            //2.Uses group by to partition a list of words by their first letter.
            //Use dictionary_english.txt for Input
            #region Part6 - Q2
            //List<string> words = File.ReadAllLines("dictionary_english.txt").ToList();

            //var groupedWords = words.GroupBy(w => w[0]);

            //foreach (var group in groupedWords)
            //{
            //    Console.WriteLine($"First Letter '{group.Key}':");
            //    foreach (var word in group)
            //    {
            //        Console.WriteLine(word);
            //    }
            //    Console.WriteLine();
            //} 
            #endregion

            //3.Consider this Array as an Input
            //String[] Arr = { "from", "salt", "earn", " last", "near", "form"};
            //Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            #region Part6 - Q3
            //string[] Arr = { "from", "salt", "earn", "last", "near", "form" };

            //var groupedWords = Arr.GroupBy(word => word, new SameCharactersTogetherComparer());

            //foreach (var group in groupedWords)
            //{
            //    foreach (var word in group)
            //    {
            //        Console.WriteLine(word);
            //    }
            //    Console.WriteLine("......");
            //} 
            #endregion

            #endregion
        }
    }
}
