using Address;
using San_Tsg_Project.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace San_Tsg_Project.DataReaders
{
    internal class XmlReader : IDataReader
    {
        /// <summary>
        /// This method read xml and returns  csv data that filtered by params
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="sortTypeEnum"></param>
        /// <param name="outputFileName"></param>
        /// <returns></returns>
        public int ReadData(string cityName, SortTypeEnum? sortTypeEnum, string outputFileName)
        {
            var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            const string fileName = "sample_data.xml";
            const int count = 0;
            path = Path.Combine(path, @"San_Tsg_Project\Datas\", fileName);
            var myDeserializer = new XmlSerializer(typeof(AddressInfo));
            var xr = new XmlTextReader(path);
            if (!myDeserializer.CanDeserialize(xr)) return count;
            var retDatas = (AddressInfo)myDeserializer.Deserialize(xr);
            var retCities = retDatas.City.Where(x => x.name == cityName).OrderByDescending(x => x.District[0].Zip[0].code).ToArray();

            var addressInfoCities = retCities;
            Tools.ToCsv(",", addressInfoCities, outputFileName);
            return addressInfoCities.Length;
        }
        public int ReadData(string cityName, SortTypeEnum? sortTypeEnum, SortTypeEnum? sortTypeEnum2, string outputFileName)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
