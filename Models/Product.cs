using System;

namespace Holtz_ProductCatalog.Models
{
    public class Product {
        public int ProCod { get; set; } //Code
        public string ProTit { get; set; } //Title
        public string ProDes { get; set; } //Description
        public decimal ProPri { get; set; } //Price
        public DateTime ProDatIns { get; set; } //Insert Date
        public DateTime ProDatUpd { get; set; } //Update Date
        public int CatCod { get; set; } //Category Code
        public Category Category { get; set; } //Category
    }
}