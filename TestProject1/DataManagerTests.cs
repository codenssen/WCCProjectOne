
using WCCProjectOne;

namespace TestProject1
{
    public class DataManagerTests
    {
        [Fact]
        public void GetOneStudentId_test()
        {
            // Arrange
            int index = 2;
            var data = new DataManager();
            data.AddStudent("Bob", "Boby", new DateTime(2023, 12, 01), 3);
            data.AddStudent("Bob", "Boby", new DateTime(2023, 12, 01), 4);
            data.AddStudent("Bob", "Boby", new DateTime(2023, 12, 01), 5);

            // Act
            int studentId = data.GetOneStudentId(index);

            // Assert
            Assert.Equal(4, studentId);
        }

        [Fact]
        public void GetOneCourseId_test()
        {
            // Arrange
            int index = 3;
            var data = new DataManager();
            data.AddCourse("Cours1", 5);
            data.AddCourse("Cours2", 8);
            data.AddCourse("Cours3", 12);

            // Act
            int courseId = data.GetOneCourseId(index);

            // Assert
            Assert.Equal(12, courseId);
        }

        [Fact]
        public void GetOneCourseName_test()
        {
            // Arrange
            var data = new DataManager();
            string courseName = "Cours1";
            data.AddCourse(courseName, 10);

            // Act
            string resultName = data.GetOneCourseName(10);

            // Assert
            Assert.Equal(courseName, resultName);
        }

        [Fact]
        public void DeleteCourse_test()
        {
            // Arrange
            var data = new DataManager();
            data.AddCourse("Cours 1", 0);

            // Act
            bool confirmDelete = data.DeleteCourse(0);

            // Assert
            Assert.True(confirmDelete);

        }

    }
}

