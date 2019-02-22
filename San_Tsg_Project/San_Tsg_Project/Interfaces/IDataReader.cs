namespace San_Tsg_Project.Interfaces
{
    public interface IDataReader
    {
        int ReadData(string cityName, SortTypeEnum? sortTypeEnum,string outputFileName);
        int ReadData(string cityName, SortTypeEnum? sortTypeEnum,SortTypeEnum? sortTypeEnum2,string outputFileName);
    }
}
