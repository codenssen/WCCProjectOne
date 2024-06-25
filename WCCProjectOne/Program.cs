namespace WCCProjectOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolManager schoolManager = FileManager.LoadFile();
            schoolManager.Run();
            // Mockup students
            List<Student> students = new List<Student>
            {
                new Student("ABRASSART", "Aurélien", new DateOnly(1982, 07, 27)),
                new Student("ROBERTO", "Paul", new DateOnly(1998, 03, 14)),
                new Student("POUAL", "Alain", new DateOnly(1998, 03, 14)),
                new Student("EPONGE", "Bob", new DateOnly(1998, 03, 14))
            };

            // Mockup courses
            List<Course> courses = new List<Course>
            {
                new Course("Français"),
                new Course("Mathématique"),
                new Course("Javascript"),
                new Course("CSharp")
            };

            SchoolManager schoolManager = new SchoolManager();
            schoolManager.Run(students, courses);
            // Mockup students
            List<Student> students = new List<Student>
            {
                new Student("ABRASSART", "Aurélien", new DateOnly(1982, 07, 27)),
                new Student("ROBERTO", "Paul", new DateOnly(1998, 03, 14)),
                new Student("POUAL", "Alain", new DateOnly(1998, 03, 14)),
                new Student("EPONGE", "Bob", new DateOnly(1998, 03, 14))
            };

            // Mockup courses
            List<Course> courses = new List<Course>
            {
                new Course("Français"),
                new Course("Mathématique"),
                new Course("Javascript"),
                new Course("CSharp")
            };

            SchoolManager schoolManager = new SchoolManager();
            schoolManager.Run(students, courses);
            // Mockup students
            List<Student> students = new List<Student>
            {
                new Student("ABRASSART", "Aurélien", new DateOnly(1982, 07, 27)),
                new Student("ROBERTO", "Paul", new DateOnly(1998, 03, 14)),
                new Student("POUAL", "Alain", new DateOnly(1998, 03, 14)),
                new Student("EPONGE", "Bob", new DateOnly(1998, 03, 14))
            };

            // Mockup courses
            List<Course> courses = new List<Course>
            {
                new Course("Français"),
                new Course("Mathématique"),
                new Course("Javascript"),
                new Course("CSharp")
            };

            SchoolManager schoolManager = new SchoolManager();
            schoolManager.Run(students, courses);
        }
    }
}

