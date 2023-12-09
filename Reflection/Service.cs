using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Service
    {
        [ParserName(nameof(Id))]
        public int Id { get; set; }
        [ParserName(nameof(Name))]
        public string Name { get; set; }
        [ParserName(nameof(Description))]
        public string Description { get; set; }
        [ParserName(nameof(Cost))]
        public decimal Cost { get; set; }
    }
}
