using WCCProjectOne;

namespace WCCProjectOneTests
{
    public class StudentTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var lastName = "Doe";
            var firstName = "John";
            var birthDate = "01/01/2000";
            var id = 1;

            // Act
            var student = new Student(lastName, firstName, birthDate, id);

            // Assert
            Assert.Equal(lastName, student.LastName);
            Assert.Equal(firstName, student.FirstName);
            Assert.Equal(birthDate, student.BirthDate);
            Assert.Equal(id, student.Id);
        }

        [Fact]
        public void ListOne_PrintsCorrectly()
        {
            // Arrange
            var lastName = "Doe";
            var firstName = "John";
            var birthDate = "01/01/2000";
            var id = 1;
            var student = new Student(lastName, firstName, birthDate, id);
            var expectedOutput = $"ID : {id}{Environment.NewLine}Nom : {lastName}{Environment.NewLine}Prénom : {firstName}{Environment.NewLine}Date de naissance : 01/01/2000{Environment.NewLine}";

            using var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            student.ListOne();
            var output = writer.ToString();

            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}