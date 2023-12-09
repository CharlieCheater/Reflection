using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class ColumnHeader
    {
        public ColumnHeader(int position, string name)
        {
            Name = name;
            Position = position;
        }

        public string Name { get; set; }
        public int Position { get; set; }
    }
}
