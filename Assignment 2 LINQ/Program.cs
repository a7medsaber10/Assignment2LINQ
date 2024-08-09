using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
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

        }
    }
}
