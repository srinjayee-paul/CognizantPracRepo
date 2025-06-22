using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Ex2
{
    public class Product
    {
        public int productId;
        public String productName;
        public String category;
        public Product(int id, string name, string cate)
        {
            productId = id;
            productName = name;
            category = cate;
        }
        public void Display()
        {
            Console.WriteLine($"ID: {productId}, Name: {productName}, Category: {category}");
        }
    }
    internal class Program
    {
        static Product LinearSearch(Product[] ar, int target)
        {
            foreach (Product p in ar)
            {
                if (p.productId == target)
                    return p;
            }
            return null;
        }

        static Product BinarySearch(Product[] ar, int target)
        {
            int low = 0, high = ar.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (ar[mid].productId == target)
                    return ar[mid];
                else if (ar[mid].productId < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return null;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number of products: ");
            int n = int.Parse(Console.ReadLine());
            Product[] linear_array = new Product[n];
            Product[] binary_array = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter details for product {i + 1}:");
                Console.Write("Product ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Product Name: ");
                string name = Console.ReadLine();
                Console.Write("Category: ");
                string cate = Console.ReadLine();
                Product p = new Product(id, name, cate);
                linear_array[i] = p;
                binary_array[i] = p;
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (binary_array[j].productId > binary_array[j + 1].productId)
                    {
                        var temp = binary_array[j];
                        binary_array[j] = binary_array[j + 1];
                        binary_array[j + 1] = temp;
                    }
                }
            }
            Console.Write("\nEnter Product ID to search: ");
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine("\nLinear Search Result:");
            Product result = LinearSearch(linear_array, target);
            if (result != null)
                result.Display();
            else
                Console.WriteLine("Product not found.");

            Console.WriteLine("\nBinary Search Result:");
            Product result2 = BinarySearch(binary_array, target);
            if (result2 != null)
                result2.Display();
            else
                Console.WriteLine("Product not found.");
        }
    }
}
