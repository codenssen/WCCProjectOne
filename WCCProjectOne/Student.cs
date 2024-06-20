
namespace WCCProjectOne
{
    public class Student
    {
        private int _id;
        private string _lastName;
        private string _firstName;
        private DateOnly _birthDate;

        private static int _indexId = 1;

        public Student(string lastName, string firstName, DateOnly birthDate)
        {
            _id = _indexId++;
            _lastName = lastName;
            _firstName = firstName;
            _birthDate = birthDate;
  
        }

        public int Id { get { return _id; } }

        public string LastName { get { return _lastName; } }

        public string FirstName { get { return _firstName; } }

        public DateOnly BirthDate { get { return _birthDate; } }

        public void ListOne()
        {
            Console.WriteLine($"ID : {_id}");
            Console.WriteLine($"Nom : {_lastName}");
            Console.WriteLine($"Prénom : {_firstName}");
            Console.WriteLine($"Date de naissance : {_birthDate}");
        }



    }

}
