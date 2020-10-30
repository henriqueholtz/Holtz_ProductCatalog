using Holtz_ProductCatalog.Data;
using Holtz_ProductCatalog.Models;
using Holtz_ProductCatalog.ViewModels;
using Holtz_ProductCatalog.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Holtz_ProductCatalog.Controllers
{
    public class ProductController
    {
        private readonly Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }

        [Route("v1/products")]
        [HttpGet]
        public List<ListProductViewModel> Get()
        {
            return _context.Products
                .Include(x => x.Category)
                .Select(x => new ListProductViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    CategoryId = x.CategoryId,
                    Category = x.Category.Name
                })
                .AsNoTracking()
                .ToList();
        }


        [Route("v1/products/{id}")]
        [HttpGet]
        public Product Get(int id)
        {
            return _context.Products.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }


        [Route("v1/products")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorProductViewModel productVM)
        {
            productVM.Validate();
            if (productVM.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar este Produto.",
                    Data = productVM.Notifications
                };
            }
            Product product = new Product
            {
                Description = productVM.Description,
                CategoryId = productVM.CategoryId,
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Image = productVM.Image,
                Price = productVM.Price,
                Quantity = productVM.Quantity,
                Title = productVM.Title
            };
            _context.Products.Add(product);
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto cadastrado com sucesso!",
                Data = product
            };
        }


        [Route("v1/products")]
        [HttpPut]
        public ResultViewModel Put([FromBody] EditorProductViewModel productVM)
        {
            productVM.Validate();
            if (productVM.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar este Produto.",
                    Data = productVM.Notifications
                };
            }
            var product = _context.Products.Find(productVM.Id);
            {
                product.Description = productVM.Description;
                product.CategoryId = productVM.CategoryId;
                product.UpdateDate = DateTime.Now;
                product.Image = productVM.Image;
                product.Price = productVM.Price;
                product.Quantity = productVM.Quantity;
                product.Title = productVM.Title;
            };
            _context.Products.Update(product);
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto cadastrado com sucesso!",
                Data = product
            };
        }
    }
}
