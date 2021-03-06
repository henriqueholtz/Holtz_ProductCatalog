using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Holtz_ProductCatalog.Data;
using Holtz_ProductCatalog.Models;

namespace Holtz_ProductCatalog.Controllers {
    public class CategoryController : Controller {
        private readonly Context _context;
        public CategoryController(Context context)
        {
            _context = context;
        }

        [Route("v1/categories")]
        [HttpGet]
        public List<Category> Get() {
            return _context.Categories.AsNoTracking().ToList();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id) {
            return _context.Categories.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }
        
        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public IEnumerable<Product> GetProducts(int id) {
            return _context.Products.AsNoTracking().Where(x => x.CategoryId == id).ToList();
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody]Category category) {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        [Route("v1/categories")]
        [HttpPut]
        public Category Put([FromBody]Category category) {
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();
            return category;
        }

        
        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody]Category category) {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }
    }
}