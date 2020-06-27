using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lunch.Service.Dto
{
    public class QueryDto
    {
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string KeyWord { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Type { get; set; }
    }
}
