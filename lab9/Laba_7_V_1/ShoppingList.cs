using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_7_V_1
{
    public class ShoppingList
    {
        private List<Product> _productList;

        /// <summary>
        /// Свойство лист продуктов
        /// </summary>
        public List<Product> ProductList { get => _productList; set => _productList = value; }

        /// <summary>
        /// Инициализация листа с помощью массива продуктов или пустой лист
        /// </summary>
        /// <param name="products">продукты, добавляемые в лист</param>
        public ShoppingList(params Product[] products)
        {
            if (products is not null)
            {
                List<Product> newProductList = new List<Product>();
                foreach (Product product in products)
                {
                    newProductList.Add(product);
                }
                ProductList = newProductList;
            }
            else
            {
                ProductList = new List<Product>();
            }
        }

        /// <summary>
        /// Добавления елемента в лист, возвращает ArgumentNullException, если добавляемый елемент равен нулю
        /// </summary>
        /// <param name="element">добавляемый елемент в лист</param>
        public void AddElement(Product element)
        {
            if (element is not null)
            {
                ProductList.Add(element);
            }
            else
            {
                throw new ArgumentNullException();
            }

        }
        /// <summary>
        /// Удаление елемента по индексу в листе, возвращает ArgumentOutOfRangeException, если индекс выходит за пределы листа
        /// </summary>
        /// <param name="indexRemove">индекс удаляемого улемента</param>
        public void RemoveElementByIndex(int indexRemove)
        {
            if (indexRemove > 0 && indexRemove < ProductList.Count)
            {
                ProductList.RemoveAt(indexRemove);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// Удаление елемента в листе, возвращает ArgumentNullException, если удаляемый елемент равен null
        /// </summary>
        /// <param name="product">удаляемый елемент</param>
        public void RemoveElementByProduct(Product product)
        {
            if (product is not null)
            {
                ProductList.Remove(product);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (Product product in ProductList)
            {
                str.Append(product + "\n");
            }
            return str.ToString();
        }

    }
}
