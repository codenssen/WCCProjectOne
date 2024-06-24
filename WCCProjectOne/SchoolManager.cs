

using Newtonsoft.Json;

namespace WCCProjectOne
{
    public class SchoolManager
    {

        private List<Student> _students;
        private List<Course> _courses;

        public SchoolManager()
        {
            _students = LoadData<List<Student>>("students.json") ?? new List<Student>();
            _courses = LoadData<List<Course>>("courses.json") ?? new List<Course>();
        }

        public void Run()
        {

            int userInput;
            UserMenu menu = new UserMenu();

            while (true)
            {
                // Menu Accueil
                userInput = menu.Home();
                if (userInput == 0)
                {
                    continue;
                }
                if (userInput == 9)
                {
                    break;
                }
                else if (userInput == 1)
                {
                    // <<< Sous-menu Elève >>>
                    //    // "1 - Lister les élèves"
                    //    // "2 - Créer un nouvel élève"
                    //    // "3 - Consulter un élève existant"
                    //    // "4 - Ajouter une note à un élève"
                    //    // "0 - Revenir au menu principal"
                    userInput = menu.Student();
                    if (userInput == 0)
                    {
                        continue;
                    }
                    if (userInput == 1)
                    {
                        Console.Clear();
                        menu.ListStudents(_students);
                        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal ");
                        Console.ReadKey(true);
                    }
                    if (userInput == 2)
                    {
                        Console.Clear();
                        menu.AddStudent(_students);
                        SaveData(_students, "students.json");
                        continue;
                    }
                    if (userInput == 3)
                    {
                        menu.PrintStudent(_students);
                        continue;
                    }
                    if (userInput == 4)
                    {
                        menu.AddGrade(_students);
                        Console.ReadKey(true);
                        continue;
                    }
                }
                else if (userInput == 2)
                {
                    // <<< Sous-menu Cours >>>
                    // "1 - Lister les cours existants"
                    // "2 - Ajouter un nouveau cours au programme"
                    // "3 - Supprimer un cours
                    // "0 - Revenir au menu principal"
                    userInput = menu.Course();
                    if (userInput == 0)
                    {
                        continue;
                    }
                    if (userInput == 1)
                    {
                        Console.Clear();
                        menu.listCourses(_courses);
                        Console.ReadKey(true);
                        continue;

                    }
                    if (userInput == 2)
                    {
                        Console.Clear();
                        menu.AddCourse(_courses);
                        continue;
                    }
                    if (userInput == 3)
                    {
                        Console.Clear();
                        menu.DeleteCourse(_courses);
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void SaveData<T>(T data, string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving data: " + ex.Message);
            }
        }

        private T LoadData<T>(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading data: " + ex.Message);
            }
            return default(T);
        }

    }
}
