using Serilog;
using Serilog.Events;

namespace WCCProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Initialize();

            DataManager data = new DataManager().Load();
            SchoolManager schoolManager = new SchoolManager();

            Log.Information("Lancement de l'application");
            schoolManager.Run(data);
        }
    }
}

