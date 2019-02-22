using Microsoft.VisualStudio.TestTools.UnitTesting;
using San_Tsg_Project.Interfaces;

namespace San_Tsg_Project.Test
{
    [TestClass]
    public class TestCase1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //TestCase 1 - Generate XML output from CSV input, filtered by City name =’Antalya’
            const int expected = 83; //total count of cities which names are 'Antalya'
            var reader = IoCUtil.Resolve<IDataReader>("CsvService");
            var actual = reader.ReadData("Antalya", null, GetType().Name + ".xml");
            Assert.AreEqual(expected, actual);
        }
    }
}
