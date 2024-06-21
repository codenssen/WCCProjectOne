namespace WCCProjectOne
{
    public class UserMenu
    {

        public int Home()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine("/+==+/ Bienvenue dans votre application de gestion Eleve/Cours /+==+/");
            Console.WriteLine("");
            Console.WriteLine("Faite votre choix :");
            Console.WriteLine("1 - Gestion des élèves");
            Console.WriteLine("2 - Gestion des cours");
            Console.WriteLine("0 - Quitter l'application");
            userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }

        public int Student()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine(">> Gestion des élèves <<");
            Console.WriteLine("Faite votre choix :");
            Console.WriteLine("1 - Lister les élèves");
            Console.WriteLine("2 - Créer un nouvel élève");
            Console.WriteLine("3 - Consulter un élève existant");
            Console.WriteLine("4 - Ajouter une note à un élève");
            Console.WriteLine("0 - Revenir au menu principal");
            userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }
        public int Course()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine(">> Gestion des cours <<");
            Console.WriteLine("Faite votre choix :");
            Console.WriteLine("1 - Lister les cours existants");
            Console.WriteLine("2 - Ajouter un nouveau cours au programme");
            Console.WriteLine("3 - Supprimer un cours");
            Console.WriteLine("0 - Revenir au menu principal");
            userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }
        public void ListStudents(List<Student> students)
        {
            Console.WriteLine(">> Liste des elèves : <<");
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Id} - {student.LastName}");

            }

        }
        public void listCourses(List<Course> courses)
        {
            foreach (Course course in courses)
            {
                Console.WriteLine($"ID : {course.Id} - {course.Name}");

            }
        }

        public void PrintStudent(List<Student> students)
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
            string appreciation;
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Id} - {student.LastName}");
            }
            Console.WriteLine("Choix de l'élève ?");
            studentId = Convert.ToInt32(Console.ReadLine());
            //foreach (Course course in courses)
            //{
            //    Console.WriteLine($"{course.Id} - {course.Name}");
            //}
            Console.WriteLine("Choix du cours ?");
            courseId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Merci de rentrer votre note (entre 0 et 20)");
            grade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Merci de rentrer votre appréciation (ou laisser vide)");
            appreciation = Console.ReadLine();
            var query = students.Where(student => student.Id == studentId);
            foreach (Student student in query)
            {
                student.AddGrade(grade, appreciation, courseId);
            }

        }
        public void AddStudent(List<Student> students)
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
        public void AddCourse(List<Course> courses)
        {
            string name;
            Console.WriteLine(">> Création d'un nouveau cours <<");
            Console.WriteLine("Saisir le nom du cours :");
            name = Console.ReadLine().ToString();
            courses.Add(new Course(name));
        }

        public void DeleteCourse(List<Course> courses)
        {
            int userInput;
            Console.WriteLine("Veuillez rentrer l'ID du cours à supprimer :");
            foreach (Course course in courses)
            {
                Console.WriteLine($"{course.Id} - {course.Name}");
            }
            Console.WriteLine("Choix (0 pour retour au menu) :");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput != 0)
            {
                var courseToRemove = courses.Single(r => r.Id == userInput);
                courses.Remove(courseToRemove);
            }
        }
    }
}
