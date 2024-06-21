
namespace WCCProjectOne
{
    public class Course
    {
        public readonly int Id;
        public readonly string Name;

        private static int _indexId = 1;

        public Course(string name)
        {
            Id = _indexId++;
            Name = name;
        }
    }
}
