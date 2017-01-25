using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

// Contrary to MVC apps. A Web Api uses DEFAULT routing like this:
// api/{controller}/{id}
// where:
//
// - You use the word api at the beginning to differentiate a WebAPI controller from an MVC controller.
// - Then you set the controller, that it would match the class name + the word Controller. In this case, Products + Controller
// - Finally, to find the action, WebApi would look for the HTTP method (GET, POST, PUT, or DELETE) that matches the beginning of a method.
namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Data Source. In this sample is this fixed array of Products, but we can get it from a Database
        /// </summary>
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        /// <summary>
        /// Returns a list (IEnumerable) of Products.
        /// GET
        /// api/products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        /// <summary>
        /// Returns a single Product.
        /// GET
        /// api/products/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
