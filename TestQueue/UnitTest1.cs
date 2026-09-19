using StarostinKD_ZIVT_251_OOP4;

namespace TestQueue
{
    [TestFixture]
    public class StudentTests
    {
        // Тест 1: Проверка, что студент с двойкой отчисляется
        [Test]
        public void StudentWith2()
        {
            // Arrange
            var student = new Student();
            student.Marks = new Dictionary<string, int>
            {
                { "Программирование", 2 },
                { "Философия", 4 },
                { "Сети", 4 },
                { "Методы оптимизации", 4 }
            };

            // Act
            bool result = student.GetDecision();

            // Assert
            Assert.IsTrue(result, "Студент с двойкой должен быть отчислен");
        }

        // Тест 2: Проверка, что студент с низким средним баллом (< 3.5) отчисляется
        [Test]
        public void StudentWithLowAVG()
        {
            // Arrange
            var student = new Student();
            student.Marks = new Dictionary<string, int>
            {
                { "Программирование", 3 },
                { "Философия", 3 },
                { "Сети", 3 },
                { "Методы оптимизации", 4 }
            };

            // Act
            bool result = student.GetDecision();

            // Assert
            Assert.IsTrue(result, "Студент со средним баллом ниже 3.5 должен быть отчислен");
        }

        // Тест 3: Проверка, что студент с высоким средним баллом и без двоек НЕ отчисляется
        [Test]
        public void StudentWithHighAVGAndNo2()
        {
            // Arrange
            var student = new Student();
            student.Marks = new Dictionary<string, int>
            {
                { "Программирование", 4 },
                { "Философия", 4 },
                { "Сети", 5 },
                { "Методы оптимизации", 4 }
            };

            // Act
            bool result = student.GetDecision();

            // Assert
            Assert.IsFalse(result, "Студент с высоким средним баллом и без двоек не должен быть отчислен");
        }

        // Тест 4: Проверка, что студент со средним баллом ровно 3.5 и без двоек не отчисляется
        [Test]
        public void StudentWithAVG3point5()
        {
            // Arrange
            var student = new Student();
            student.Marks = new Dictionary<string, int>
            {
                { "Программирование", 3 },
                { "Философия", 4 },
                { "Сети", 3 },
                { "Методы оптимизации", 4 }
            };

            // Act
            bool result = student.GetDecision();

            // Assert
            Assert.IsFalse(result, "Студент со средним баллом 3.5 и без двоек не должен быть отчислен");
        }

        // Тест 5: Проверка, что студент с двойкой отчисляется, даже если средний балл высокий
        [Test]
        public void StudentWith2AndHighAVG()
        {
            // Arrange
            var student = new Student();
            student.Marks = new Dictionary<string, int>
            {
                { "Программирование", 2 },
                { "Философия", 5 },
                { "Сети", 5 },
                { "Методы оптимизации", 5 }
            };

            // Act
            bool result = student.GetDecision();

            // Assert
            Assert.IsTrue(result, "Студент с двойкой должен быть отчислен, даже если средний балл высокий");
        }
    }
}
