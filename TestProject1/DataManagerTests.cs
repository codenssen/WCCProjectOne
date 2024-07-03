using WCCProjectOne;

namespace WCCProjectOneTests
{

    public class DataManagerTests
    {
        [Fact]
        public void Constructor_InitializesLists()
        {
            // Arrange & Act
            var dataManager = new DataManager();

            // Assert
            Assert.NotNull(dataManager.GetStudents());
            Assert.NotNull(dataManager.GetCourses());
            Assert.NotNull(dataManager.GetNotes());
            Assert.Empty(dataManager.GetStudents());
            Assert.Empty(dataManager.GetCourses());
            Assert.Empty(dataManager.GetNotes());
        }

        [Fact]
        public void AddStudent_AddsStudentToList()
        {
            // Arrange
            var dataManager = new DataManager();
            var lastName = "Doe";
            var firstName = "John";
            var birthDate = "01/01/2000";
            var id = 1;

            // Act
            dataManager.AddStudent(lastName, firstName, birthDate, id);
            var students = dataManager.GetStudents();

            // Assert
            Assert.Single(students);
            Assert.Equal(lastName, students[0].LastName);
            Assert.Equal(firstName, students[0].FirstName);
            Assert.Equal(birthDate, students[0].BirthDate);
            Assert.Equal(id, students[0].Id);
        }

        // Mock FileManager to test Save and Load methods


    }
}
