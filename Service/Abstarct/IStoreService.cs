using StoreApi.Models;
using System.Collections.Generic;
namespace StoreApi.Services
{
    interface IStoreService
    {
        public List<Product> getProductsOfCategoryAndDescendants(int categoryID);
        public OrderStatistics getOrderStatistics(List<Order> orders);
    }
}