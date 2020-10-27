using System.Collections.Generic;

namespace Holtz_ProductCatalog.Models {
    public class Category {
        public int CatCod { get; set; }
        public string CatNam { get; set; }
        public IEnumerable<Product> Products  { get; set; }
    }
}