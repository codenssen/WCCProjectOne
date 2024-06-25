namespace WCCProjectOne
{
    public class UserMenu
    {

        public int Home()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine("/=/ Bienvenue dans votre application de gestion Eleves/Cours /=/");
            Console.WriteLine("");
            Console.WriteLine("Faites votre choix :");
            Console.WriteLine("1 - Gestion des élèves");
            Console.WriteLine("2 - Gestion des cours");
            Console.WriteLine("9 - Quitter l'application");
            Console.WriteLine("dev : 98 - Effacer fichier JSON");
            Console.WriteLine("dev : 99 - populate mockup");
            userInput = UserInput();
            return userInput;
        }

        public int UserInput()
        {
            int userInput;
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("====================/!\\=====================");
                Console.WriteLine("|  Erreur  ! Merci de rentrer un chiffre !  |");
                Console.WriteLine("============================================");
                Console.ReadKey(true);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur ! {ex.Message}");
                Console.WriteLine("Appuyez sur une touche pour continuer");
                Console.ReadKey(true);
                return 0;
            }

            return userInput;
        }

        public string UserStringInput()
        {
            string userStringInput;
            try
            {
                userStringInput = Console.ReadLine()!;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("=======================/!\\========================");
                Console.WriteLine("|  Erreur  ! Merci de rentrer un texte correct !  |");
                Console.WriteLine("==================================================");
                Console.ReadKey(true);
                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur ! {ex.Message}");
                Console.WriteLine("Appuyez sur une touche pour continuer");
                Console.ReadKey(true);
                return "";
            }
            if (string.IsNullOrWhiteSpace(userStringInput))
            {
                userStringInput = "";
            }
            return userStringInput;
        }

        public int Student()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine(">> Gestion des élèves <<");
            Console.WriteLine("Faites votre choix :");
            Console.WriteLine("1 - Lister les élèves");
            Console.WriteLine("2 - Créer un nouvel élève");
            Console.WriteLine("3 - Consulter un élève existant");
            Console.WriteLine("4 - Ajouter une note à un élève");
            Console.WriteLine("0 - Revenir au menu principal");
            userInput = UserInput();
            return userInput;
        }
        public int Course()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine(">> Gestion des cours <<");
            Console.WriteLine("Faites votre choix :");
            Console.WriteLine("1 - Lister les cours existants");
            Console.WriteLine("2 - Ajouter un nouveau cours au programme");
            Console.WriteLine("3 - Supprimer un cours");
            Console.WriteLine("0 - Revenir au menu principal");
            userInput = UserInput();
            return userInput;
        }
        public void ListStudents(List<Student> students)
        {
            Console.WriteLine(">> Liste des elèves : <<");
            int index = 1;
            foreach (Student student in students)
            {
                Console.WriteLine($"{index} - {student.LastName} - {student.FirstName}");
                index++;
            }
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal");

        }
        public void listCourses(List<Course> courses)
        {
            int index = 1;
            foreach (Course course in courses)
            {
                Console.WriteLine($"{index} - {course.Name}");
                index++;
            }
        }

        public void PrintStudent(List<Student> students)
        {
            int userInput;

            Console.Clear();
            Console.WriteLine("Voici la liste des élèves :");
            Console.WriteLine("Choisir l'élève à afficher en tapant son identifiant");
            foreach (Student student in students)
            {
                Console.WriteLine($"ID : {student.Id} - Nom : {student.LastName}");
            }
            Console.WriteLine("Choix :");
            userInput = UserInput();
            IEnumerable<Student> printedStudent = students.Where(student => student.Id == userInput);
            Console.WriteLine("==========================================");
            foreach (Student student in printedStudent)
            {
                student.ListOne();
                Console.WriteLine("==========================================");
                student.PrintStudentGrades();
            }
            Console.WriteLine("Taper une touche pour revenir au menu principal");
            Console.ReadKey(true);

        }

        public void AddGrade(List<Student> students)
        {
            int studentId;
            int courseId;
            int grade;
            string? appreciation;
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Id} - {student.LastName}");
            }
            Console.WriteLine("Choix de l'élève ?");
            studentId = UserInput();

            Console.WriteLine("Choix du cours ?");
            courseId = UserInput();
            Console.WriteLine("Merci de rentrer votre note (entre 0 et 20)");
            grade = UserInput();
            Console.WriteLine("Merci de rentrer votre appréciation (ou laisser vide)");
            appreciation = UserStringInput();
            if (string.IsNullOrWhiteSpace(appreciation))
            {
                appreciation = "Aucune appréciation fournie.";
            }
            var query = students.Where(student => student.Id == studentId);
            foreach (Student student in query)
            {
                student.AddGrade(grade, appreciation, courseId);
            }

        }
        public void AddStudent(List<Student> students)
        {
            string? lastName;
            string? firstName;
            int year;
            int month;
            int day;
            int id;


            while (true)
            {
                Console.WriteLine(">> Création d'un nouvel élève <<");
                Console.WriteLine("Saisir le nom de l'élève :");
                lastName = UserStringInput();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    lastName = "Aucun nom fourni";
                }
                Console.WriteLine("Saisir le prénom de l'élève :");
                firstName = UserStringInput();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    firstName = "Aucune prénom fourni";
                }
                Console.WriteLine("Saisir la date de naissance de l'élève :");
                Console.WriteLine("Jour de naissance :");
                day = UserInput();
                if (day <= 0 || day > 31)
                {
                    Console.WriteLine("Erreur ! Le jour n'est pas valide. Appuyez sur une touche pour recommencer");
                    Console.ReadKey(true);
                    Console.Clear();
                    continue;
                }
                Console.WriteLine("Mois de naissance (Exemple : 07 pour Juillet) :");
                month = UserInput();
                if (month <= 0 || month > 12)
                {
                    Console.WriteLine("Erreur ! Le mois n'est pas valide. Appuyez sur une touche pour recommencer");
                    Console.ReadKey(true);
                    Console.Clear();
                    continue;
                }
                
                Console.WriteLine("Année de naissance (Exemple : 1994) :");
                year = UserInput();
                if (year <= 1900 || year > DateTime.Now.Year)
                {
                    Console.WriteLine("Erreur ! Le mois n'est pas valide. Appuyez sur une touche pour recommencer");
                    Console.ReadKey(true);
                    Console.Clear();
                    continue;
                }
                break;
            }
            id = students.Count == 0 ? 0 : students.Max(s => s.Id) + 1;
            students.Add(new Student(lastName, firstName, $"{day}/{month}/{year}", id));
        }
        public void AddCourse(List<Course> courses)
        {
            string name;
            int id;
            Console.WriteLine(">> Création d'un nouveau cours <<");
            Console.WriteLine("Saisir le nom du cours :");
            name = UserStringInput();
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Aucun nom de cours fourni.";
            }
            id = courses.Count == 0 ? 0 : courses.Max(c => c.Id) + 1;
            courses.Add(new Course(name, id));
        }

        public void DeleteCourse(List<Course> courses)
        {
            int userInput;
            Console.WriteLine("Veuillez rentrer l'ID du cours à supprimer :");
            int index = 1;
            foreach (Course course in courses)
            {
                Console.WriteLine($"{index} - {course.Name}");
                index++;
            }
            Console.WriteLine("Choix (0 pour retour au menu) :");
            userInput = UserInput();
            if (userInput != 0)
            {
                courses.RemoveAt(userInput - 1);
            }
        }
    }
}
