using Castle.MicroKernel.Registration;
using Castle.Windsor;
using San_Tsg_Project.DataReaders;
using San_Tsg_Project.Interfaces;
using San_Tsg_Project.Loggers;

namespace San_Tsg_Project
{
    public static class IoCUtil
    {
        private static IWindsorContainer _container;
        private static IWindsorContainer Container => _container ?? (_container = BootstrapContainer());
        //Singleton Pattern
        private static IWindsorContainer BootstrapContainer()
        {
            return new WindsorContainer().Register(
                Component.For<IDataReader>().ImplementedBy<CsvReader>().Named("CsvService"),
                Component.For<IDataReader>().ImplementedBy<XmlReader>().Named("XmlService"),
                Component.For<ILogger>().ImplementedBy<DbLogger>().Named("dbLogger"),
                Component.For<ILogger>().ImplementedBy<FileLogger>().Named("fileLogger"));
        }
        public static T Resolve<T>(string param)
        {
            return Container.Resolve<T>(param);
        }
    }
}
