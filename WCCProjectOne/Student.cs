
using Newtonsoft.Json;

namespace WCCProjectOne
{
    public class Student
    {
        private DateOnly _birthDate;

        public readonly int Id;
        public readonly string LastName;
        public readonly string FirstName;

        public string BirthDate { get { return _birthDate.ToString(); } }

        public Student(string lastName, string firstName, string birthDate, int id)
        {
            LastName = lastName;
            FirstName = firstName;
            _birthDate = DateOnly.ParseExact(birthDate, "dd/MM/yyyy");
            Id = id;
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
