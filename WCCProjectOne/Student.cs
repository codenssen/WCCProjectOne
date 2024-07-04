
using Newtonsoft.Json;

namespace WCCProjectOne
{
    public class Student
    {
        public readonly DateTime BirthDate;
        public readonly int Id;
        public readonly string Promotion;

        private string _lastname;
        private string _firstname;


        public string LastName { get { return _lastname.ToUpper(); } }
        public string FirstName { get { return _firstname.ToUpper(); } }



        public Student(string lastName, string firstName, DateTime birthDate, int id, string promotion)
        {
            _lastname = lastName.ToLower();
            _firstname = firstName.ToLower();
            BirthDate = birthDate;
            Id = id;
            Promotion = promotion;
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
