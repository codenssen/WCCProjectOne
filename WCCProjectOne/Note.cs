using System.Diagnostics;

namespace WCCProjectOne
{
    public class Note
    {
        public readonly double Grade;
        public readonly string Appreciation;
        public readonly int StudentId;
        public readonly int CourseId;


        public Note(double grade, string appreciation, int studentId, int courseId)
        {
            Grade = grade;
            Appreciation = appreciation;
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
