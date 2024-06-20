
namespace WCCProjectOne
{
    public class Course
    {
        private int _id;
        private string _name;

        private static int _indexId = 1;

        public Course(string name)
        {
            _id = _indexId++;
            _name = name;
        }

        public int Id { get { return _id; } }

        public string Name { get { return _name; } }

    }
}
