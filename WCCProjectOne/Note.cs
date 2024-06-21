namespace WCCProjectOne
{
    public class Note
    {
        private double _grade;
        private string _appreciation;
        private int _courseId;

        public Note(double grade, string appreciation, int courseId)
        {
            _grade = grade;
            _appreciation = appreciation;
            _courseId = courseId;
        }

        public void PrintNote()
        {
            Console.WriteLine($"Note : {_grade} - Appreciation : {_appreciation} - Cours : {_courseId}");
        }

    }
}
