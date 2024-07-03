using Serilog;
using Serilog.Events;

namespace WCCProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Initialize();

            //Log.Logger = new LoggerConfiguration()
            // .MinimumLevel.Debug()
            //.WriteTo.File(@"..\..\..\journal.log", LogEventLevel.Information)
            //.WriteTo.Console()
            //.CreateLogger();

            Log.Information("Programme démarré !!!!");

            DataManager data = new DataManager().Load();
            SchoolManager schoolManager = new SchoolManager();
            Log.Information("Lancement de l'application");
            schoolManager.Run(data);
        }
    }
}

