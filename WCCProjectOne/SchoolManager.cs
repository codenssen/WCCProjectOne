

namespace WCCProjectOne
{
    public class SchoolManager
    {
        public void Run(List<Student> students, List<Course> courses)
        {

            int userInput;
            UserMenu menu = new UserMenu();

            while (true)
            {
                // Menu Accueil
                userInput = menu.Home();

                if (userInput == 0)
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
                        menu.ListStudents(students);
                        Console.ReadKey(true);
                    }
                    if (userInput == 2)
                    {
                        Console.Clear();
                        menu.AddStudent(students);
                        continue;
                    }
                    if (userInput == 3)
                    {
                        menu.PrintStudent(students);
                        continue;
                    }
                    if (userInput == 4)
                    {
                        menu.AddGrade(students);
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
                        menu.listCourses(courses);
                        Console.ReadKey(true);
                        continue;

                    }
                    if (userInput == 2)
                    {
                        Console.Clear();
                        menu.AddCourse(courses);
                        continue;
                    }
                    if (userInput == 3)
                    {
                        Console.Clear();
                        menu.DeleteCourse(courses);
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
