using StoreApi.Models;
using StoreApi.Services.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
namespace StoreApi.Controllers
{
    [Route("/store")]
    [ApiController]
    [Produces("application/json")]
    public class SpiralController : ControllerBase
    {
        private readonly StoreService _storeService;
        public SpiralController(StoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpGet]
        public string test()
        {
            return "test";
        }

        [HttpGet("getProductsOfCategoryAndDescendants")]
        public List<Product> getProductsOfCategoryAndDescendants(int categoryID) {
            return _storeService.getProductsOfCategoryAndDescendants(categoryID);
        }

        [HttpPost("getOrderStatistics")]
        public OrderStatistics getOrderStatistics(List<Order> orders) {
            return _storeService.getOrderStatistics(orders);
        }
        
        [HttpPost]
        public string addNewData(Orders order)
        {
            try
            {
                _storeService.addNewOrder(order);
                return "Success";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }
        [HttpPost("addNewProduct")]
        public string addNewProduct(Products product)
        {
            try
            {
                _storeService.addNewProducts(product);
                return "Success";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }

        [HttpPost("addNewCategory")]
        public string addNewCategory(Categories category)
        {
            try
            {
                _storeService.addNewCategories(category);
                return "Success";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }

        [HttpPost("addNewOrderProduct")]
        public string addNewOrderProduct(OrderProducts orderProduct)
        {
            try
            {
                _storeService.addNewOrderProducts(orderProduct);
                return "Success";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }

    }
}