using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class ParserNameAttribute : Attribute
    {
        public string Name { get; set; }
        public ParserNameAttribute(string name)
        {
            Name = name;
        }
    }
}
