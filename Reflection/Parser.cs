using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Parser
    {
        public static List<T> GetData<T>(string pathToFile) where T : class
        {
            if (!File.Exists(pathToFile))
            {
                throw new FileNotFoundException(nameof(pathToFile));
            }
            var list = new List<T>();
            var type = typeof(T);
            var props = GetProperties(type);

            var lines = File.ReadAllLines(pathToFile).ToList();
            var headers = GetHeaders(lines);
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var instance = Activator.CreateInstance<T>();
                var columns = line.Split(';').Select(x => x.Trim()).ToList();

                for (int i = 0; i < columns.Count(); i++)
                {
                    var header = headers[i];
                    var prop = props
                        .FirstOrDefault(x => x.nameField.ToLower() == header.Name.ToLower());
                    if(prop.prop is null)
                    {
                        continue;
                    }
                    prop.prop.SetValue(instance, Convert.ChangeType(columns[i], prop.prop.PropertyType));
                }
                list.Add(instance);
            }
            return list;
        }
        private static List<ColumnHeader> GetHeaders(List<string> lines)
        {
            return lines[0].Split(';')
                .Select((x, index) => new ColumnHeader(index, x))
                .ToList(); ;
        }
        private static List<(string nameField, PropertyInfo prop)> GetProperties(Type type)
        {
            List<(string nameField, PropertyInfo prop)> normalizeProperties = new();

            var properties = type.GetProperties().Where(x => x.CustomAttributes
                .Any(y => y.AttributeType == typeof(ParserNameAttribute)))
                .ToList();

            foreach (var prop in properties)
            {
                var attribute = prop.GetCustomAttribute<ParserNameAttribute>();
                normalizeProperties.Add((attribute.Name, prop));
            }
            return normalizeProperties;
        }
    }
}
