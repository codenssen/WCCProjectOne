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
                Console.WriteLine("Erreur au chargement du fichier");
                Console.WriteLine(ex.ToString());
                Console.ReadKey(true);
                return false;
            }
            return true;
        }

        static public SchoolManager LoadFile()
        {
            string filePath = @"app.json";
            if (!File.Exists(filePath))
            {
                return new SchoolManager();
            }
            try
            {
                return JsonConvert.DeserializeObject<SchoolManager>(File.ReadAllText(filePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur au chargement du fichier");
                Console.WriteLine(ex.ToString());
                Console.ReadKey(true);
                return new SchoolManager();
            }

        }
    }
}
