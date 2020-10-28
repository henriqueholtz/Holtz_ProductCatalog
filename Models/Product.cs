using System;

namespace Holtz_ProductCatalog.Models
{
    public class Product {
        public int Id { get; set; } //Code
        public string Title { get; set; } //Title
        public string Description { get; set; } //Description
        public decimal Price { get; set; } //Price
        public int Quantity { get; set; }
        public string Image { get; set; }
        public DateTime InsertDate { get; set; } //Insert Date
        public DateTime UpdateDate { get; set; } //Update Date
        public int CategoryId { get; set; } //Category Code
        public Category Category { get; set; } //Category
    }
}