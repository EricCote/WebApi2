using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        static Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        //GET    /api/Products/{id}
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT    /api/Products/{id}
        public IHttpActionResult PutProduct(int id, [FromBody]Product product)
        {
            var prod = products.FirstOrDefault((p) => p.Id == id);
            if (prod == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            prod.Category = product.Category;
            prod.Name = product.Name;
            prod.Price = product.Price;

            return Ok(prod);

        }
    }
}