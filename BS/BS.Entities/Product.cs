using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set;}
        public int? ProducerId { get; set; }
    }
}
