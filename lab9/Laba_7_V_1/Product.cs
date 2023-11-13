using System;
using System.Text.Json.Serialization;

namespace Laba_7_V_1
{
    [Serializable]
    public class Product
    {
        private double _price;
        private string _name;
        private string _brand;
        private bool _isPromotional;
        private double _promotionalPrice;

        public Product(double price, string name, string brand, double promotionalPrice=double.NaN)
        {
            Price = price;
            Name = name;
            Brand = brand;
            if (!double.IsNaN(promotionalPrice))
            {
                IsPromotional = true;
                PromotionalPrice = promotionalPrice;
            }
            else
            {
                IsPromotional = false;
            }
        }

        [JsonPropertyName("Price")]
        /// <summary>
        ///СВойство цена продукта , возвращает ArgumentOutOfRangeException, если пытаемся присвоить отрицательное значение 
        /// </summary>
        public double Price
        {
            get => _price;
            init
            {
                if (value > 0 )
                {
                    _price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        [JsonPropertyName("Name")]
        /// <summary>
        /// Свойство название продукта , возвращает ArgumentNullException, если пытаемся присвоить пустую строку
        /// </summary>
        public string Name
        {
            get => _name;
            init
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value.Trim();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        [JsonPropertyName("Brand")]
        /// <summary>
        /// Свойство бренд,фирма продукта , возвращает ArgumentNullException, если пытаемся присвоить пустую строку
        /// </summary>
        public string Brand
        {
            get => _brand;
            init
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _brand = value.Trim();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        [JsonPropertyName("IsPromotional")]
        /// <summary>
        /// Свойство акционный ли товар 
        /// </summary>
        public bool IsPromotional
        {
            get => _isPromotional;
            init => _isPromotional = value;
        }

        [JsonPropertyName("PromotionalPrice")]
        /// <summary>
        ///СВойство акционная цена продукта , возвращает ArgumentOutOfRangeException, если пытаемся присвоить отрицательное значение или значение больше обычной цены
        /// </summary>
        public double PromotionalPrice
        {
            get => _promotionalPrice;
            init
            {
                if (value >= 0 && value<Price)
                {
                    _promotionalPrice = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public override string ToString()
        {
            string finalPrice = "" + (IsPromotional ?  PromotionalPrice : Price);
            return $"Product(name = {Name} ; brand= {Brand} ; final price= {finalPrice} )\n";
        }
        /// <summary>
        /// Сравнивание цены на продукт по убыванию
        /// </summary>
        /// <param name="left">первый продукт</param>
        /// <param name="right">второй продукт</param>
        /// <returns></returns>
        public static bool IsHighestPrice(Product left , Product right)
        {
            double leftPrice = left.IsPromotional ? left.PromotionalPrice : left.Price;
            double rightPrice = right.IsPromotional ? right.PromotionalPrice : right.Price;

            return leftPrice < rightPrice;
        }
        /// <summary>
        /// Сравнивание цены на продукт по возростанию
        /// </summary>
        /// <param name="left">первый продукт</param>
        /// <param name="right">второй продукт</param>
        /// <returns></returns>
        public static bool IsLowerPrice(Product left, Product right)
        {
            double leftPrice = left.IsPromotional ? left.PromotionalPrice : left.Price;
            double rightPrice = right.IsPromotional ? right.PromotionalPrice : right.Price;

            return leftPrice > rightPrice;
        }

    }
}
