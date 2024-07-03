using Newtonsoft.Json;

namespace WCCProjectOne
{
    public class FileManager
    {

        static public bool SaveFile(DataManager data)
        {
            try
            {
                File.WriteAllText(@"app.json", JsonConvert.SerializeObject(data, Formatting.Indented));
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

        static public DataManager LoadFile()
        {
            string filePath = @"app.json";
            if (!File.Exists(filePath))
            {
                return new DataManager();
            }
            try
            {
                return JsonConvert.DeserializeObject<DataManager>(File.ReadAllText(filePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur au chargement du fichier");
                Console.WriteLine(ex.ToString());
                Console.ReadKey(true);
                return new DataManager();
            }

        }
    }
}
