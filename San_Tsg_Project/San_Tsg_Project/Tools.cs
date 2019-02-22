using Address;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace San_Tsg_Project
{
    public class Tools
    {
        /// <summary>
        /// This method converts object list to csv data and save data to csv file
        /// </summary>
        /// <param name="separator"></param>
        /// <param name="objectlist"></param>
        /// <param name="outputName"></param>
        /// <returns></returns>
        public static string ToCsv(string separator, IEnumerable<AddressInfoCity> objectlist, string outputName)
        {
            var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            var outputPath = path;
            const string fileName = "schema.csv";
            path = Path.Combine(path, @"San_Tsg_Project\Datas\", fileName);
            outputPath = Path.Combine(outputPath, @"San_Tsg_Project\Output\", outputName);
            var line = "";
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                }
            }
            var csvdata = new StringBuilder();
            csvdata.AppendLine(line);
            foreach (var city in objectlist)
            {
                foreach (var district in city.District)
                {
                    foreach (var zip in district.Zip)
                    {
                        csvdata.AppendLine(city.name + "," + city.code + "," + district.name + "," + zip.code);
                    }
                }
            }
            if (File.Exists(outputPath))
                File.Delete(outputPath);
            File.WriteAllText(outputPath, csvdata.ToString(), Encoding.UTF8);
            return csvdata.ToString();
        }
    }
}
