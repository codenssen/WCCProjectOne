using Newtonsoft.Json;
using Serilog;

namespace WCCProjectOne
{
    public class SchoolManager
    {
        public void Run(DataManager data)
        {
            int userInput;
            UserMenu menu = new UserMenu();

            while (true)
            {
                // Menu Accueil
                userInput = menu.Home();
                if (userInput == 0)
                {
                    Log.Information("Retour au menu principal");
                    continue;
                }
                if (userInput == 9)
                {
                    Log.Information("Sortie normale du programme");
                    break;
                }
                else if (userInput == 1)
                {
                    //<<< menu Elèves >>>
                    userInput = menu.Student();
                    if (userInput == 0)
                    {
                        //"0 - Revenir au menu principal"
                        continue;
                    }
                    if (userInput == 1)
                    {
                        // "1 - Lister les élèves"
                        menu.ListStudents(data);
                    }
                    if (userInput == 2)
                    {
                        // "2 - Créer un nouvel élève"
                        menu.AddStudent(data);
                        data.Save();
                        continue;
                    }
                    if (userInput == 3)
                    {
                        // "3 - Consulter un élève existant"
                        menu.PrintStudent(data);
                        continue;
                    }
                    if (userInput == 4)
                    {
                        // "4 - Ajouter une note à un élève"
                        menu.AddGrade(data);
                        data.Save();
                        continue;
                    }
                }
                else if (userInput == 2)
                {
                    //<<< menu Cours >>>
                    userInput = menu.Course();
                    if (userInput == 0)
                    {
                        //"0 - Revenir au menu principal"
                        continue;
                    }
                    if (userInput == 1)
                    {
                        //"1 - Lister les cours existants"
                        menu.listCourses(data);
                        data.Save();
                        continue;

                    }
                    if (userInput == 2)
                    {
                        //"2 - Ajouter un nouveau cours au programme"
                        menu.AddCourse(data);
                        data.Save();
                        continue;
                    }
                    if (userInput == 3)
                    {
                        //"3 - Supprimer un cours
                        menu.DeleteCourse(data);
                        data.Save();
                        continue;
                    }

                }
            }
        }
    }
}
