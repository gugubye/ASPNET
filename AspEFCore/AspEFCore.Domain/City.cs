using System;
using System.Collections.Generic;
using System.Text;

namespace AspEFCore.Domain
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AreaCore { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
