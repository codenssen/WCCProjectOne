using Newtonsoft.Json;

namespace WCCProjectOne
{
    public class SchoolManager
    {
        [JsonProperty("students")]
        private List<Student> _students;

        [JsonProperty("courses")]
        private List<Course> _courses;

        public SchoolManager()
        {

            _students = new List<Student>();
            _courses = new List<Course>();
        }

        public void Run()
        {

            int userInput;
            UserMenu menu = new UserMenu();
            //FileManager.LoadFile(this);

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
                if (userInput == 99)
                {
                    _students.Add(new Student("ABRASSART", "Aurélien", "27/07/1982"));
                    _students.Add(new Student("ROBERTO", "Paul", "15/07/1978"));
                    _students.Add(new Student("POUAL", "Alain", "01/01/2014"));
                    _students.Add(new Student("EPONGE", "Bob", "19/04/1996"));
                    _courses.Add(new Course("Mathématiques"));
                    _courses.Add(new Course("Français"));
                    _courses.Add(new Course("Anglais"));
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
                        FileManager.SaveFile(this);
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
                        FileManager.SaveFile(this);
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
                        FileManager.SaveFile(this);
                        continue;
                    }
                    if (userInput == 3)
                    {
                        Console.Clear();
                        menu.DeleteCourse(_courses);
                        FileManager.SaveFile(this);
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }



    }
}
