using System.Reflection;

namespace San_Tsg_Project.Interfaces
{
    public interface ILogger
    {
        void Log(MethodBase methodBase, string message);
    }
}
