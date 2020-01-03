using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCourseWork
{
    class Utility
    {
        public static void Export() { }
        public static void Import() { }
        public static void WriteToTextFile(string route, string input, bool append = true, int sum = 1 )
        {
            if (!File.Exists(route))
            {
                var file = File.Create(route);
                file.Close();
            }
            using (StreamWriter write = new StreamWriter(route, append : append))
            {
                if (!append)
                {
                    //code that removes the "[" opening bracket from input passes
                    input = input.Trim().Substring(1, input.Trim().Length - 1);
                    //code that removes "]" from input that are passes
                    input = input.Trim().Substring(0, input.Trim().Length - 1);
                }
                if (sum != 0)
                {
                    input = input + ",";
                }
                write.WriteLine(input);

            }
        }
        public static string ReadFromTextFile(string route)
        {
            if (File.Exists(route))
            {
                string input;
                using (StreamReader read = new StreamReader(route))
                {
                    input = read.ReadToEnd();
                }
                if (input != "")
                {
                    input = "[" + input + "]";
                }
                return input;
            }
            return null;
        }
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            if (data != null)
            {
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
            }
            
            return table;

        }

    }
}
