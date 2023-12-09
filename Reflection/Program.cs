using Reflection;

using System.Text;
using System.Text.Encodings;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var data = Parser.GetData<Client>("C:\\Users\\admin\\Documents\\Clients.csv");
var services = Parser.GetData<Service>("C:\\Users\\admin\\Documents\\services.csv");
if (true)
{
    
}