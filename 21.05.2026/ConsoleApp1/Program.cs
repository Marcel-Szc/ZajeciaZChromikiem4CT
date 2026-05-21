namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            IDataBaseUser user = new DataBase();
            IDatabaseAdmin admin = new DataBase();

            
        }
    }
    public class DataBase : IDatabaseAdmin, IDataBaseUser
    {
        public string DataBaseName { get; set; }
        public string UserName { get; set; }
        public void SaveToDataBase(string Data)
        {
            Console.WriteLine($"Savin {Data} to database");
        }

        public void ReadFromDataBase(string Key)
        {
            Console.WriteLine($"Reading from Database where key: {Key}");
        }
    }
    public interface IDatabaseAdmin
    {
        string DataBaseName { get; set; }
        void SaveToDataBase(string Data);
        void ReadFromDataBase(string Key);

    }
    public interface IDataBaseUser
    {
        string UserName { get; set; }
        void ReadFromDataBase(string Key);
    }
}