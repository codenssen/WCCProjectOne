namespace WCCProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolManager schoolManager = FileManager.LoadFile();
            schoolManager.Run();
        }
    }
}

