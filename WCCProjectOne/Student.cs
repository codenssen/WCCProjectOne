
namespace WCCProjectOne
{
    public class Student
    {
        private int _id;
        private string _lastName;
        private string _firstName;
        private DateOnly _birthDate;

        private string[] _appreciations;
        private double[] _grades;
        private int[] _courseId;

        private static int _indexId = 1;

        // Must be start 0
        private static int _indexGrade = 0;

        public Student(string lastName, string firstName, DateOnly birthDate)
        {
            _id = _indexId++;
            _lastName = lastName;
            _firstName = firstName;
            _birthDate = birthDate;

            _grades = new double[50];
            _courseId = new int[50];
            _appreciations = new string[50];
        }

        public int Id { get { return _id; } }

        public string LastName { get { return _lastName; } }

        public string FirstName { get { return _firstName; } }

        public DateOnly BirthDate { get { return _birthDate; } }

        public void AddGrade(int courseId, string appreciation, double grade)
        {
            _grades[_indexGrade] = grade;
            _appreciations[_indexGrade] = appreciation;
            _courseId[_indexGrade] = courseId;
            _indexGrade++;
        }
        public void PrintStudentGrades()
        {
            for (int i = 0; i < _grades.Length && _courseId[i] != 0; i++)
            {
                Console.WriteLine($"Note : {_grades[i]}");
                Console.WriteLine($"Appréciation : {_appreciations[i]}");
                Console.WriteLine($"Matière : {_courseId[i]}");

            }
        }

        public void ListOne()
        {
            Console.WriteLine($"ID : {_id}");
            Console.WriteLine($"Nom : {_lastName}");
            Console.WriteLine($"Prénom : {_firstName}");
            Console.WriteLine($"Date de naissance : {_birthDate}");
        }



    }

}
