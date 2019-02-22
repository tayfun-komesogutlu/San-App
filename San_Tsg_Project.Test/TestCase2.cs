using Microsoft.VisualStudio.TestTools.UnitTesting;
using San_Tsg_Project.Interfaces;

namespace San_Tsg_Project.Test
{
    [TestClass]
    public class TestCase2
    {
        [TestMethod]
        public void TestMethod2()
        {
            //TestCase2 - Generate CSV output from CSV input, sorted by City name ascending, then District name ascending
            var reader = IoCUtil.Resolve<IDataReader>("CsvService");
            var actual = reader.ReadData("Ankara", SortTypeEnum.Asc, SortTypeEnum.Desc, GetType().Name + ".csv");
            Assert.IsTrue(actual > 0, $"{actual} objectes fetched");
        }
    }
}
