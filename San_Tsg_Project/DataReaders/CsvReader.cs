using Address;
using San_Tsg_Project.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace San_Tsg_Project.DataReaders
{
    internal class CsvReader : IDataReader
    {
        /// <summary>
        /// This method read csv and returns xml data that filtered with params
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="sortTypeEnum"></param>
        /// <param name="outputFileName"></param>
        /// <returns></returns>
        public int ReadData(string cityName, SortTypeEnum? sortTypeEnum, string outputFileName)
        {
            var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            var outputPath = path;
            const string fileName = "sample_data.csv";
            path = Path.Combine(path, @"San_Tsg_Project\Datas\", fileName);

            outputPath = Path.Combine(outputPath, @"San_Tsg_Project\Output\", outputFileName);
            var returnCsv = File.ReadAllLines(path)
                .Skip(1)
                .Select(x => x.Split(','))
                .Select(x => new AddressInfo()
                {
                    City = new[]
                    {
                        new AddressInfoCity()
                        {
                            name = x[0],
                            code = x[1],
                            District = new[]
                            {
                                new AddressInfoCityDistrict()
                                    {name = x[2], Zip = new[] {new AddressInfoCityDistrictZip() {code = x[3]}}}
                            }
                        }
                    }
                }).Where(x => x.City.Any(s => s.name == cityName)).ToArray(); 

            var xsSubmit = new XmlSerializer(typeof(AddressInfo[]));
            var xml = "";
            using (var sww = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, returnCsv);
                    xml = sww.ToString();
                }
            }
            if (File.Exists(outputPath))
                File.Delete(outputPath);
            File.WriteAllText(outputPath, xml, Encoding.UTF8);
            return returnCsv.Length;
        }
        /// <summary>
        /// This method read csv and return csv data that filtered by params 
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="sortTypeEnum"></param>
        /// <param name="sortTypeEnum2"></param>
        /// <param name="outputFileName"></param>
        /// <returns></returns>
        public int ReadData(string cityName, SortTypeEnum? sortTypeEnum, SortTypeEnum? sortTypeEnum2, string outputFileName)
        {
            var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            const string fileName = "sample_data.csv";
            path = Path.Combine(path, @"San_Tsg_Project\Datas\", fileName);
            var returnedCsv = File.ReadAllLines(path)
                .Skip(1)
                .Select(x => x.Split(','))
                .Select(x => new AddressInfo()
                {
                    City = new[]{ new AddressInfoCity(){name = x[0],code = x[1],District = new[]
                    { new AddressInfoCityDistrict()
                        { name = x[2], Zip = new[]{new AddressInfoCityDistrictZip(){code = x[3] }}}
                    }}}
                }).OrderBy(x => x.City[0].name).ThenBy(x=>x.City[0].District[0].Zip[0].code).ToArray();
            var addressInfoCities = returnedCsv;
            Tools.ToCsv(",", addressInfoCities.SelectMany(x => x.City), outputFileName);
            return returnedCsv.Length;
        }
    }
}
