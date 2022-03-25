using StoreApi.Models;
using StoreApi.DB;
using MongoDB.Driver;
using MongoDB.Bson;

namespace StoreApi.Services.Concreate
{
    public class StoreService : IStoreService
    {
        private readonly IMongoCollection<Categories> _categories;
        private readonly IMongoCollection<Products> _products;
        private readonly IMongoCollection<Orders> _orders;
        private readonly IMongoCollection<OrderProducts> _orderProducts;

        public StoreService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _categories = database.GetCollection<Categories>(settings.Categories);
            _products = database.GetCollection<Products>(settings.Products);
            _orders = database.GetCollection<Orders>(settings.Orders);
            _orderProducts = database.GetCollection<OrderProducts>(settings.OrderProducts);
        }

        public List<Product> getProductsOfCategoryAndDescendants(int categoryID)
        {
            // Burayı doldurun:
            // Verilen ID'ye sahip kategori ve onun alt kategorilerindeki
            // tüm ürünleri veritabanından alıp List<Product>
            // tipinde döndüren kodu yazınız.
            List<Products> products = _products.Find<Products>(product => product.CategoryID == categoryID).ToList();
            List<Categories> subCategories = _categories.Find<Categories>(category => category.ParentID == categoryID).ToList();
            List<Product> productList = new List<Product>();

            foreach (var category in subCategories)
            {
                products.AddRange(_products.Find<Products>(product => product.CategoryID == category.CategoryID).ToList());
            }

            foreach (var product in products)
            {
                Product newProduct = new Product()
                {
                    ID = product.ProductID,
                    CategoryID = product.CategoryID
                };
                productList.Add(newProduct);
            }

            return productList;
        }

        public OrderStatistics getOrderStatistics(List<Order> orders)
        {
            // Burayı doldurun:
            // Verilen siparişlerin içinde, her bir kategoride toplam
            // kaç ürün satıldığını ve toplam ne kadarlık ürün
            // satıldığını hesaplayan kodu yazınız.
            OrderStatistics orderStatistics = new OrderStatistics();
            List<OrderStatisticCategory> orderStatisticCategories = new List<OrderStatisticCategory>();
            List<Product> products = orders.SelectMany(order => order.products).ToList();
            List<int> categories = products.GroupBy(b => b.CategoryID).Select(p => p.Key).ToList();
            List<OrderProducts> orderProducts = new List<OrderProducts>();
            foreach (var category in categories)
            {
                List<int> categoryProducts = products.Where(c => c.CategoryID == category).Select(product => product.ID).ToList();
                int sumOfProducts = categoryProducts.Count();
                decimal TotalPriceOfProductsSold = orderProducts.Where(product => categoryProducts.Contains(product.ProductID)).Select(c => c.Price).Sum();
                OrderStatisticCategory orderStatisticCategory = new OrderStatisticCategory(){
                    NumberOfProductsSold = sumOfProducts,
                    TotalPriceOfProductsSold = TotalPriceOfProductsSold
                };
                orderStatisticCategories.Add(orderStatisticCategory);
            }
            orderStatistics.categories = orderStatisticCategories;
            return orderStatistics;
        }
        public void addNewOrder(Orders order)
        {
            _orders.InsertOne(order);
        }
        public void addNewCategories(Categories categories)
        {
            _categories.InsertOne(categories);
        }
        public void addNewProducts(Products products)
        {
            _products.InsertOne(products);
        }
        public void addNewOrderProducts(OrderProducts orderProducts)
        {
            _orderProducts.InsertOne(orderProducts);
        }

    }
}