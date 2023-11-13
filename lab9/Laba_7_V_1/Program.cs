using System;
using System.Collections.Generic;

namespace Laba_7_V_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product(price: 10.33, name: "bread", brand: "OMXA",promotionalPrice:9.3);
            Product product2 = new Product(price: 120000000.33, name: "dress", brand: "VS", promotionalPrice: 3.3);
            Product product3 = new Product(price: 100000000000000, name: "car", brand: "OPEL");
            Product product4 = new Product(price: 700.450, name: "iphone", brand: "Apple", promotionalPrice: 600);
            Product product5 = new Product(price: 9.99, name: "cup", brand: "My Home", promotionalPrice: 9.3);
            Product product6 = new Product(price: 6501.33, name: "t-short", brand: "lives");

            ShoppingList shoppingList = new ShoppingList(product3);
            //Добавление елементов product6,product2,product1,product5
            shoppingList.AddElement(product6);
            shoppingList.AddElement(product2);
            shoppingList.AddElement(product1);
            shoppingList.AddElement(product5);
            shoppingList.AddElement(product4);

            Console.WriteLine("ShoppingList:\n");
            Console.WriteLine(shoppingList);
            //Сортировка
            ShopingListExtentions.Sort(shoppingList.ProductList, Product.IsHighestPrice);
            Console.WriteLine("ShoppingList sort by price by descending  :\n");
            Console.WriteLine(shoppingList);

            ShopingListExtentions.Sort(shoppingList.ProductList, Product.IsLowerPrice);
            Console.WriteLine("ShoppingList sort by price by ascending :\n");
            Console.WriteLine(shoppingList);

            //Фильтрация с помощью лямбды-выражения
            List<Product> listProducts1 = ShopingListExtentions.Search(shoppingList.ProductList, "E", (Product product, string searchValue) => product.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("ShoppingList filter by Name query=E :\n");
            foreach (Product product in listProducts1)
            {
                Console.WriteLine(product);
                Console.WriteLine("------------------------");
            }

            //Фильтрация с помощью анонимного метода
            ShopingListExtentions.SearchDelegate searchDelegateByBrand= delegate(Product product, string searchValue)
            {
                return product.Brand.Contains(searchValue, StringComparison.OrdinalIgnoreCase);
            };

            List<Product> listProducts2 = ShopingListExtentions.Search(shoppingList.ProductList, "E", searchDelegateByBrand);

            Console.WriteLine("ShoppingList filter by Brand query=E :\n");
            foreach (Product product in listProducts2)
            {
                Console.WriteLine(product);
                Console.WriteLine("------------------------");
            }

        }
    }
}
