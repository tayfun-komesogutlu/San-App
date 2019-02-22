using Microsoft.VisualStudio.TestTools.UnitTesting;
using San_Tsg_Project.Interfaces;

namespace San_Tsg_Project.Test
{
    [TestClass]
    public class TestCase3
    {
        [TestMethod]
        public void TestMethod3()
        {
            //TestCase 3 - Generate CSV output from XML input, filtered by City name =’Ankara’ and sorted by Zip code descending
            var reader = IoCUtil.Resolve<IDataReader>("XmlService");
            var actual = reader.ReadData("Ankara", SortTypeEnum.Desc, GetType().Name + ".csv");
            Assert.IsTrue(actual > 0, $"{actual} objectes fetched");
        }
    }
}
