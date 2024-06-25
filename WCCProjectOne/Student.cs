
namespace WCCProjectOne
{
    public class Student
    {
        private DateOnly _birthDate;

        public readonly int Id;
        public readonly string LastName;
        public readonly string FirstName;

        public string BirthDate { get { return _birthDate.ToString(); } }

        private List<Note> _notes;

        public Student(string lastName, string firstName, string birthDate, int id)
        {
            LastName = lastName;
            FirstName = firstName;
            _birthDate = DateOnly.ParseExact(birthDate, "dd/MM/yyyy");
            Id = id;

            _notes = new List<Note>();
        }


        public void AddGrade(double grade, string appreciation, int courseId)
        {
            _notes.Add(new Note(grade, appreciation, courseId));
        }
        public void PrintStudentGrades()
        {
            foreach (Note note in _notes)
            {
                note.PrintNote();
            }
        }

        public void ListOne()
        {
            Console.WriteLine($"ID : {Id}");
            Console.WriteLine($"Nom : {LastName}");
            Console.WriteLine($"Prénom : {FirstName}");
            Console.WriteLine($"Date de naissance : {_birthDate}");
        }
    }
}
