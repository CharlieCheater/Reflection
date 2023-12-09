using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Reflection
{
    public class Client
    {
        [ParserName(nameof(Id))]
        public int Id { get; set; }
        [ParserName(nameof(Name))]
        public string Name { get; set; }
        [ParserName("PasswordHash")]
        public string HashPassword { get; set; }
        [ParserName(nameof(Email))]
        public string Email { get; set; }
        public string Gender { get; set; }
        
        public string ToCsv()
        {
            return "";
        }
    }
}
