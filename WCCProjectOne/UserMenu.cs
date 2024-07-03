﻿using Serilog;
using System.Globalization;

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
        public void ListStudents(DataManager data)
        {
            Console.Clear();
            List<Student> students = data.GetStudents();
            Console.WriteLine(">> Liste des elèves : <<");
            int index = 1;
            foreach (Student student in students)
            {
                Console.WriteLine($"{index} - {student.LastName} - {student.FirstName}");
                index++;
            }
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal");
            Console.ReadKey(true);
        }
        public void listCourses(DataManager data)
        {
            Console.Clear();
            int index = 1;
            List<Course> courses = data.GetCourses();
            foreach (Course course in courses)
            {
                Console.WriteLine($"{index} - {course.Name}");
                index++;
            }
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal");
            Console.ReadKey(true);
        }

        public void PrintStudent(DataManager data)
        {
            List<Student> students = data.GetStudents();

            Console.Clear();
            Console.WriteLine("Voici la liste des élèves :");
            Console.WriteLine("Choisir l'élève à afficher en tapant son identifiant");
            data.PrintStudents();
            Console.WriteLine("Choix :");
            int indexStudent = UserInput();
            int studentId = data.GetOneStudentId(indexStudent);
            Student student = data.GetStudent(studentId);

            List<Note> notes = data.GetNotes().Where(note => note.StudentId == studentId).OrderBy(note => note.StudentId).ToList();

            // Calcul de la moyenne des notes
            double average;
            double sum = 0;
            foreach (Note note in notes)
            {
                sum += note.Grade;
            }
            average = sum / notes.Count;

            Console.WriteLine("==========================================");
            Console.WriteLine("Informations sur l'élève : ");
            Console.WriteLine();
            Console.WriteLine($"Nom :{student.LastName}");
            Console.WriteLine($"Prénom : {student.FirstName}");
            Console.WriteLine($"Date de naissance : {student.BirthDate.ToString("dd-MM-yyyy")}");


            if (notes.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Résultats scolaires :");
                Console.WriteLine("");
                foreach (Note note in notes)
                {
                    Console.WriteLine($"Cours : {data.GetOneCourseName(note.CourseId)}");
                    Console.WriteLine($"Note : {note.Grade} / 20");
                    if (note.Appreciation != "")
                    {
                        Console.WriteLine($"Appréciation : {note.Appreciation}");
                    }
                    Console.WriteLine();

                }
                Console.WriteLine();
                Console.WriteLine($"Moyenne : {average} / 20");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Pas de notes enregistrées pour cet éléve");
            }
            Console.WriteLine("==========================================");
            Console.WriteLine("Taper une touche pour revenir au menu principal");
            Console.ReadKey(true);

        }

        public void AddGrade(DataManager data)
        {
            Console.Clear();

            List<Note> notes = data.GetNotes();
            double grade;
            string appreciation;
            int studentId;
            int courseId;

            data.PrintStudents();
            Console.WriteLine("Merci de choisir un élève :");
            int indexStudent = UserInput();
            studentId = data.GetOneStudentId(indexStudent);

            data.PrintCourses();
            Console.WriteLine("Merci de choisir le cours :");
            int indexCourse = UserInput();
            courseId = data.GetOneCourseId(indexCourse);

            Console.WriteLine("Merci de rentrer votre note (entre 0 et 20)");
            grade = UserInput();

            Console.WriteLine("Merci de rentrer votre appréciation (ou laisser vide)");
            appreciation = UserStringInput();

            if (string.IsNullOrWhiteSpace(appreciation))
            {
                appreciation = "Aucune appréciation fournie.";
            }
            data.AddNote(grade, appreciation, studentId, courseId);
            Console.ReadKey(true);

        }
        public void AddStudent(DataManager data)
        {
            List<Student> students = data.GetStudents();
            string lastName;
            string firstName;
            DateTime birthdate;
            int id;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(">> Création d'un nouvel élève <<");

                while (true)
                {
                    Console.WriteLine("Saisir le nom de l'élève :");
                    lastName = UserStringInput();
                    if (!string.IsNullOrWhiteSpace(lastName)) break;
                    else Console.WriteLine("Format de nom inconnect. Veuillez réessayer.");
                }

                // Boucle input prénom
                while (true)
                {
                    Console.WriteLine("Saisir le prénom de l'élève :");
                    firstName = UserStringInput();
                    if (!string.IsNullOrWhiteSpace(firstName)) break;
                    else Console.WriteLine("Format de prénom inconnect. Veuillez réessayer.");
                }

                // Boucle input date de naissance
                while (true)
                {
                    Console.Write("Entrez la date de naissance (JJ-MM-AAAA): ");
                    string birthdateInput = UserStringInput();
                    if (DateTime.TryParseExact(birthdateInput, "dd-MM-yyyy", null, DateTimeStyles.None, out birthdate)) break;
                    else Console.WriteLine("Format de date incorrect. Veuillez réessayer.");
                }

                // Générez un nouvel ID pour l'élève
                id = students.Count == 0 ? 1 : students.Max(s => s.Id) + 1;

                // Créez et ajoutez l'élève à la liste
                data.AddStudent(lastName, firstName, birthdate, id);

                Console.WriteLine("Nouvel élève ajouté avec succès !");
                Log.Information($"Nouvelle étudiant crée : {lastName} - {firstName}");
                break;
            }
        }
        public void AddCourse(DataManager data)
        {
            Console.Clear();
            string name;
            int id;
            List<Course> courses = data.GetCourses();
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

        public void DeleteCourse(DataManager data)
        {
            Console.Clear();
            int userInput;
            List<Course> courses = data.GetCourses();
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
                int courseId = data.GetOneCourseId(userInput);
                bool confirm = data.DeleteCourse(courseId);
                Console.WriteLine(confirm ? "Suppression effectuée" : "Erreur de suppression");
                Console.ReadKey(true);
            }
        }
    }
}
