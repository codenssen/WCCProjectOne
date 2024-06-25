using Newtonsoft.Json;

namespace WCCProjectOne
{
    public class FileManager
    {

        static public bool SaveFile(SchoolManager app)
        {
            try
            {
                File.WriteAllText(@"app.json", JsonConvert.SerializeObject(app, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreure au chargement du fichier");
                Console.WriteLine(ex.ToString());
                Console.ReadKey(true);
                return false;
            }
            return true;
        }

        static public SchoolManager LoadFile(SchoolManager app)
        {
            app = JsonConvert.DeserializeObject<SchoolManager>(File.ReadAllText(@"app.json"));
            return app;
        }
    }
}
