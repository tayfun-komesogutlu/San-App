using System.Reflection;
using San_Tsg_Project.Interfaces;

namespace San_Tsg_Project
{
    internal class Processor
    {
        private readonly ILogger _logger;
        private readonly IDataReader _dataReader;
        public Processor()
        {
            _logger = IoCUtil.Resolve<ILogger>("dbLogger");
            _dataReader = IoCUtil.Resolve<IDataReader>("fileLogger");
        }
        public void Process()
        {
            _logger.Log(MethodBase.GetCurrentMethod(), "Log Text");
            _dataReader.ReadData("",null,"");
        }
    }
}
