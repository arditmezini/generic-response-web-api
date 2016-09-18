using System.Collections.Generic;
using System.Web.Http;
using GenericResponseAPI.Models;

namespace GenericResponseAPI.Controllers
{
    /// <summary>
    /// Manages Products
    /// </summary>
    public class ProductController : ApiController
    {
        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetProducts()
        {
            var products = new List<Product>{
                new Product
                {
                    ProductId = 1,
                    Name = "Product Name 1",
                    Description = "Product Description 1",
                    Price = 1
                },new Product
                {
                    ProductId = 2,
                    Name = "Product Name 2",
                    Description = "Product Description 2",
                    Price = 2
                },new Product
                {
                    ProductId = 3,
                    Name = "Product Name 3",
                    Description = "Product Description 3",
                    Price = 2
                }
            };
            return Ok(products);
        }
    }
}