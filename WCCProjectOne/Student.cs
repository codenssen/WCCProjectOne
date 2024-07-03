
using Newtonsoft.Json;

namespace WCCProjectOne
{
    public class Student
    {
        public readonly DateTime BirthDate;

        public readonly int Id;
        public readonly string LastName;
        public readonly string FirstName;

        //public string BirthDate { get { return _birthDate.ToString("dd/MM/yyyy"); } }

        public Student(string lastName, string firstName, DateTime birthDate, int id)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
            Id = id;
        }

        public void ListOne()
        {
            Console.WriteLine($"ID : {Id}");
            Console.WriteLine($"Nom : {LastName}");
            Console.WriteLine($"Prénom : {FirstName}");
            Console.WriteLine($"Date de naissance : {BirthDate}");
        }
    }
}
