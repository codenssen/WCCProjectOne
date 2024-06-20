

namespace WCCProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userInput;

            // Mockup students
            List<Student> students = new List<Student>
            {
                new Student("ABRASSART", "Aurélien", new DateOnly(1982, 07, 27)),
                new Student("ROBERTO", "Paul", new DateOnly(1998, 03, 14))
            };
            List<Course> courses = new List<Course>
            {
                new Course("Français"),
                new Course("Mathématique")
            };


            while (true)
            {
                // Menu Accueil
                userInput = Home();

                if (userInput == 0)
                {
                    break;
                }
                else if (userInput == 1)
                {
                    // <<< Sous-menu Elève >>>
                    // "1 - Lister les élèves"
                    // "2 - Créer un nouvel élève"
                    // "3 - Consulter un élève existant"
                    // "0 - Revenir au menu principal"
                    userInput = StudentMenu();

                    if (userInput == 0)
                    {
                        continue;
                    }
                    if (userInput == 1)
                    {
                        Console.Clear();
                        Console.WriteLine(">> Liste des elèves : <<");
                        foreach (Student student in students)
                        {
                            student.ListOne();

                        }
                        Console.ReadKey(true);
                    }
                    if (userInput == 2)
                    {
                        Console.Clear();
                        AddStudent(students);
                        continue;
                    }
                    if (userInput == 3)
                    {
                        PrintStudent(students);
                        continue;
                    }


                }
                else if (userInput == 2)
                {
                    Console.WriteLine("Choix 2");
                    continue;
                }
                else
                {
                    break;
                }



            }

        }
        static int Home()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine("Bienvenue dans votre application de gestion Eleve/Cours");
            Console.WriteLine("Faite votre choix :");
            Console.WriteLine("1 - Gestion des élèves");
            Console.WriteLine("2 - Gestion des cours");
            Console.WriteLine("0 - Quitter l'application");
            userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }

        static int StudentMenu()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine(">> Gestion des élèves <<");
            Console.WriteLine("Faite votre choix :");
            Console.WriteLine("1 - Lister les élèves");
            Console.WriteLine("2 - Créer un nouvel élève");
            Console.WriteLine("3 - Consulter un élève existant");
            Console.WriteLine("0 - Revenir au menu principal");
            userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }
        static void AddStudent(List<Student> students)
        {
            string lastName;
            string firstName;
            int year;
            int month;
            int day;

            Console.WriteLine(">> Création d'un nouvel élève <<");
            Console.WriteLine("Saisir le nom de l'élève :");
            lastName = Console.ReadLine().ToString();
            Console.WriteLine("Saisir le prénom de l'élève :");
            firstName = Console.ReadLine().ToString();
            Console.WriteLine("Saisir la date de naissance de l'élève :");
            Console.WriteLine("Jour de naissance :");
            day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Mois de naissance (Exemple : 07 pour Juillet) :");
            month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Année de naissance (Exemple : 1994) :");
            year = Convert.ToInt32(Console.ReadLine());
            students.Add(new Student(lastName, firstName, new DateOnly(year, month, day)));
        }
        static void PrintStudent(List<Student> students)
        {
            int userInput;

            Console.Clear();
            Console.WriteLine("Voici la liste des élèves :");
            Console.WriteLine("Choisir l'élève a afficher en tapant son ID");
            foreach (Student student in students)
            {
                Console.WriteLine($"ID : {student.Id} - Nom : {student.LastName}");
            }
            Console.WriteLine("Choix :");
            userInput = Convert.ToInt32(Console.ReadLine());
            IEnumerable<Student> printedStudent = students.Where(student => student.Id == userInput);
            Console.WriteLine("==========================================");
            foreach (Student student in printedStudent)
            {
                student.ListOne();
                Console.WriteLine("==========================================");
            }
            Console.WriteLine("Taper une touche pour revenir au menu principal");
            Console.ReadKey(true);

        }


    }
}
