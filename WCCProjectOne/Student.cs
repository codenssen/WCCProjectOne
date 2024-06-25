
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

        private static int _indexId = 1;

        // Must start at 0
        // Issue : Need to be read on JSON file (Take maximum id +1)
        private static int _indexGrade = 0;

        public Student(string lastName, string firstName, string birthDate)
        {
            Id = _indexId++;
            LastName = lastName;
            FirstName = firstName;
            //_birthDate = birthDate;
            _birthDate = DateOnly.ParseExact(birthDate, "dd/MM/yyyy");

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
