using Holtz_ProductCatalog.Models;

namespace Holtz_ProductCatalog.ViewModels
{
    public class ListProductViewModel
    {
        public int Id { get; set; } 
        public string Title { get; set; } 
        public decimal Price { get; set; } 
        public int Quantity { get; set; }
        public int CategoryId { get; set; } 
        public string Category { get; set; } 
    }
}
