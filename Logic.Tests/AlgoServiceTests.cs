using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests
{
    [TestFixture]
    public class AlgoServiceTests
    {
        IAlgoService algService;

        [OneTimeSetUp]
        public void AlgoServiceInit()
        {
            algService = new AlgoService();
        }

        [Test]
        public void DoubleSum_When_pass_collection_Then_get_twice_summ_of_elements()
        {
            // Arrange
            List<int> testCollection = new List<int>() { 1, 2, 3, 4, 5 };
            int expectedRes = testCollection.Sum<int>(i => i) * 2;

            // Act
            int givenRes = algService.DoubleSum(testCollection);

            // Assert
            Assert.That(givenRes, Is.EqualTo(expectedRes));

        }

        [Test]
        public void MinValue_When_pass_collection_Then_method_returns_min_value()
        {
            // Arrange
            List<int> testCollection = new List<int>() { 10, 20, 0, -50, 100 };
            int expectedRes = -50;

            // Act
            int givenRes = algService.MinValue(testCollection);

            // Assert
            Assert.That(givenRes, Is.EqualTo(expectedRes));
        }

        [Test]
        public void GetAverage_When_pass_collection_Then_get_average_of_elements()
        {
            // Arrange
            List<int> testCollection = new List<int>() { 10, 20, 30, 0, -10, 50 };
            double expectedRes = (testCollection.Aggregate<int, double>(0, (sum, i) => sum + i) / testCollection.Count);

            // Act
            double givenRes = algService.GetAverage(testCollection);

            // Assert
            Assert.That(givenRes, Is.EqualTo(expectedRes));
        }

        [Test]
        public void GetAverage_When_pass_collection_without_elements_Then_get_average_equal_zero()
        {
            // Arrange
            List<int> testCollection = new List<int>();
            double expectedRes = 0;

            // Act
            double givenRes = algService.GetAverage(testCollection);

            // Assert
            Assert.That(givenRes, Is.EqualTo(expectedRes));
        }

        [Test]
        public void GetAverage_When_pass_argument_equal_null_Then_get_exception()
        {
            // Arrange
            List<int> testCollection = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => algService.GetAverage(testCollection));
        }

        [Test]
        [TestCase(-4)]
        [TestCase(0)]
        [TestCase(4)]
        public void Sqr_When_pass_parameter_Then_get_square_of_this(int param)
        {
            // Arrange
            int expectRes = param * param;

            // Act
            double givenRes = algService.Sqr(param);

            // Assert
            Assert.That(givenRes, Is.EqualTo(expectRes));
        }

        [Test]
        [TestCase(0, 0, 0, 0)]
        [TestCase(10, 5, 10, 5)]
        [TestCase(-5, 5.5, -5, 5.5)]
        public void Function_When_run_method_with_different_parameters_Then_get_correct_result(int a, double b, int c, double d)
        // function: f(a,b,c,d) = d^3 + a * c - Pi * b^(1/2)
        {
            // Arrange
            double expectRes = d * d * d + a * c - Math.PI * Math.Sqrt(b);

            // Act
            double givenRes = algService.Function(a, b, c, d);

            // Assert
            Assert.That(givenRes, Is.EqualTo(expectRes));
        }

        [Test]
        [TestCase(1, -1, 1, 1)]
        [TestCase(0, -1, 0, 0)]
        [TestCase(-1, -1, -1, -1)]
        public void Function_When_parameter_b_is_negative_Then_get_exception(int a, double b, int c, double d)
        {
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => algService.Function(a, b, c, d));
        }

        [Test]
        public void MethodsCalledCount_When_running_some_method_Then_count_is_incremented()
        {
            // Arrange
            algService = null;
            algService = new AlgoService();
            IEnumerable<int> arg = new List<int>() { 1, 2, 3 };
            
            // Act
            algService.DoubleSum(arg);          // 1
            algService.Function(1, 1, 1, 1);    // 2
            algService.Function(1, 1, 1, 1);    // 3
            algService.GetAverage(arg);         // 4
            algService.MinValue(arg);           // 5
            algService.MinValue(arg);           // 6
            algService.Sqr(3);                  // 7

            // Assert
            Assert.That(algService.MethodsCalledCount, Is.EqualTo(7));
        }
    }
}
