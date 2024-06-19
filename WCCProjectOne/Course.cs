
namespace WCCProjectOne
{
    public class Course
    {
        private int _id;
        private string _name;
        private int[] _grades;
        private string[] _appreciations;


        private static int _indexId = 1;

        public Course(string name)
        {
            _id = _indexId++;
            _name = name;
            _grades = new int[100];
            _appreciations = new string[100];
        }

    }
}
