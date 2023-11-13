using System.Collections.Generic;


namespace Laba_7_V_1
{
    public class ShopingListExtentions
    {
        public delegate bool CompareDelegate(Product left, Product right);
        public delegate bool SearchDelegate(Product product, string searchValue);

        /// <summary>
        /// Сортировка листа покупок
        /// </summary>
        /// <param name="listProducts">лист продуктов</param>
        /// <param name="compareDelegate">ссылка на функцию , как сравнивать елементы листа </param>
        public static void Sort(List<Product> listProducts, CompareDelegate compareDelegate)
        {
            
            for (int i = 0; i < listProducts.Count - 1; i++)
            {
                for (int j = 0; j < listProducts.Count - 1; j++)
                {
                    if (compareDelegate(listProducts[j], listProducts[j + 1]))
                    {
                        (listProducts[j], listProducts[j + 1]) = (listProducts[j + 1], listProducts[j]);
                    }
                }
            }
        }
        /// <summary>
        /// Поиск в листе продуктов
        /// </summary>
        /// <param name="listProducts">лист продуктов</param>
        /// <param name="searchValue"> по какому значению фильтровать</param>
        /// <param name="searchDelegate"> ссылка на функцию , как фильтровать елементы листа</param>
        /// <returns></returns>
        public static List<Product> Search(List<Product> listProducts, string searchValue, SearchDelegate searchDelegate)
        {
            List<Product> newListProducts = new List<Product>();

            for (int i = 0; i < listProducts.Count; i++)
            {
                if (searchDelegate(listProducts[i], searchValue))
                {
                    newListProducts.Add(listProducts[i]);
                }
            }
            return newListProducts;
        }
    }
}
