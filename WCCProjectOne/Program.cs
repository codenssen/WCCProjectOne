namespace WCCProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataManager data = new DataManager().Load();
            
            SchoolManager schoolManager = new SchoolManager();
            schoolManager.Run(data);  
        }
    }
}

