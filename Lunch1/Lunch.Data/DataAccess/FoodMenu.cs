using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunch.DataAccess
{
    public class FoodMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
