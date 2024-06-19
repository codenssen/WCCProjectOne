using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    public class Student
    {
        private int _id { get; }
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

        public void ListOne()
        {
            Console.WriteLine($"ID : {_id}");
            Console.WriteLine($"Nom : {_lastName}");
            Console.WriteLine($"Prénomn : {_firstName}");
            Console.WriteLine($"Date de naissence {_birthDate}");
        }


    }

}
