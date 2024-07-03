
using Newtonsoft.Json;

namespace WCCProjectOne
{
    public class DataManager
    {
        [JsonProperty("students")]
        private List<Student> _students;

        [JsonProperty("courses")]
        private List<Course> _courses;

        [JsonProperty("notes")]
        private List<Note> _notes;

        public DataManager()
        {
            _students = new List<Student>();
            _courses = new List<Course>();
            _notes = new List<Note>();
        }

        public void Save()
        {
            FileManager.SaveFile(this);
        }

        public DataManager Load()
        {
            return FileManager.LoadFile();
        }

        public List<Student> GetStudents()
        {
            return _students;
        }
        public Student GetStudent(int id)
        {
            return _students.SingleOrDefault(s => s.Id == id);

        }
        public int GetOneStudentId(int index)
        {
            int studentId = _students[index - 1].Id;
            return studentId;
        }

        public void PrintStudents()
        {
            int index = 1;
            Console.WriteLine("========================");
            foreach (Student student in _students)
            {
                Console.WriteLine($"{index} - {student.FirstName} - {student.LastName}");
                index++;
            }
            Console.WriteLine("========================");
        }

        public void AddStudent(string lastName, string firstName, DateTime formattedDate, int id)
        {
            _students.Add(new Student(lastName, firstName, formattedDate, id));
        }
        public List<Course> GetCourses()
        {
            return _courses;
        }
        public void PrintCourses()
        {
            int index = 1;
            Console.WriteLine("========================");
            foreach (Course course in _courses)
            {
                Console.WriteLine($"{index} - {course.Name}");
                index++;
            }
            Console.WriteLine("========================");
        }
        public int GetOneCourseId(int index)
        {
            int courseId = _courses[index - 1].Id;
            return courseId;
        }
        public string GetOneCourseName(int id)
        {
            Course returnedCourse = _courses.SingleOrDefault(s => s.Id == id);
            return returnedCourse != null ? returnedCourse.Name : "Cours non trouvé";

        }
        public bool DeleteCourse(int id)
        {
            _courses.RemoveAll(course => course.Id == id);
            _notes.RemoveAll(note => note.CourseId == id);
            return true;
        }

        public List<Note> GetNotes()
        {
            return _notes;
        }
        public void AddNote(double grade, string appreciation, int studentId, int courseId)
        {
            _notes.Add(new Note(grade, appreciation, studentId, courseId));
        }

    }
}
