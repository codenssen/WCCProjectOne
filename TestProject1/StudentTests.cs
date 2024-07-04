
namespace WCCProjectOne.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Student_Initialization_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string lastName = "Doe";
            string firstName = "John";
            DateTime birthDate = new DateTime(2000, 1, 1);
            int id = 123;

            // Act
            var student = new Student(lastName, firstName, birthDate, id);

            // Assert
            Assert.Equal(lastName, student.LastName);
            Assert.Equal(firstName, student.FirstName);
            Assert.Equal(birthDate, student.BirthDate);
            Assert.Equal(id, student.Id);
        }

        [Fact]
        public void ListOne_ShouldOutputCorrectInformation()
        {
            // Arrange
            string lastName = "Doe";
            string firstName = "John";
            DateTime birthDate = new DateTime(2000, 1, 1);
            int id = 123;
            var student = new Student(lastName, firstName, birthDate, id);

            // Redirect Console Output
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            student.ListOne();

            // Assert
            string expectedOutput = $"ID : {id}\r\nNom : {lastName}\r\nPrénom : {firstName}\r\nDate de naissance : {birthDate}\r\n";
            Assert.Equal(expectedOutput, stringWriter.ToString());
        }
    }
}
