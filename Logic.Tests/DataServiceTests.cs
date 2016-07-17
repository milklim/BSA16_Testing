using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestFixture]
    public class DataServiceTests
    {
        IDataService dataService;
        int capacity = 5;

        [OneTimeSetUp]
        public void DataServiceInit()
        {
            dataService = new DataService(capacity);
        }
        
        [TearDown]
        public void Reset()
        {
            dataService = null;
            dataService = new DataService(capacity);
        }

        [Test]
        public void DataServiceCtor_When_init_with_negative_number_Then_throw_exception()
        {
            // Arrange
            int initCapasity = -1;

            // Act
            // Asserts
            Assert.Throws<ArgumentOutOfRangeException>(() => new DataService(initCapasity));
        }

        [Test]
        public void AddItem_When_add_items_Then_ItemsCount_increase()
        {
            // Arrange
            int countAdded = capacity--;
            int countExpected = dataService.ItemsCount + countAdded;

            // Act
            for (int i = 0; i < countAdded; i++)
            {
                dataService.AddItem(i);
            }

            // Assert
            Assert.That(dataService.ItemsCount, Is.EqualTo(countExpected));
        }

        [Test]
        public void AddItem_When_add_more_items_than_capasity_Then_ItemsCount_return_correct_result()
        {
            // Arrange
            int countAdded = capacity++;
            int countExpected = dataService.ItemsCount + countAdded;

            // Act
            for (int i = 0; i < countAdded; i++)
            {
                dataService.AddItem(i);
            }

            // Assert
            Assert.That(dataService.ItemsCount, Is.EqualTo(countExpected));
        }

        [Test]
        public void GetElementAt_When_pass_index_Then_get_correct_value()
        {
            // Arrange
            int expectValue = 3;
            for (int i = 0; i < 5; i++)
            {
                dataService.AddItem(i); // value = index
            }
            
            // Act
            int value = dataService.GetElementAt(expectValue);

            // Assert
            Assert.That(value, Is.EqualTo(expectValue));
        }

        [Test]
        public void GetAllData_When_method_executed_Then_get_all_elements()
        {
            // Arrange
            List<int> testData = new List<int>() { 11, 22, 33, 44, 55 };
            for (int i = 0; i < testData.Count; i++)
            {
                dataService.AddItem(testData[i]);
            }

            // Act
            // Assert
            Assert.AreEqual(dataService.GetAllData(), testData);
        }

        [Test]
        public void RemoveAt_When_pass_index_Then_delete_correct_element()
        {
            // Arrange
            dataService.AddItem(11); // index = 0
            dataService.AddItem(22); // index = 1

            // Act
            dataService.RemoveAt(0);

            // Assert
            Assert.That(dataService.GetElementAt(0), Is.EqualTo(22));
        }

        [Test]
        public void RemoveAt_When_pass_negative_index_Then_expected_exception()
        {
            // Arrange
            dataService.AddItem(11); // index = 0
            dataService.AddItem(22); // index = 1

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => dataService.RemoveAt(3));
        }

        [Test]
        public void ClearAll_Whet_method_execute_Then_all_elements_deleled()
        {
            // Arrange
            for (int i = 0; i < 5; i++)
            {
                dataService.AddItem(i);
            }

            // Act
            dataService.ClearAll();

            // Assert
            Assert.That(dataService.ItemsCount, Is.EqualTo(0));
        }
    
        [Test]
        public void GetMax_When_method_execute_Then_max_value_return()
        {
            // Arrange
            int expectValue = 99;
            dataService.AddItem(11); // index = 0
            dataService.AddItem(22); // index = 1
            dataService.AddItem(33); // index = 1
            dataService.AddItem(99); // index = 1
            dataService.AddItem(44); // index = 0

            // Act
            // Assert
            Assert.That(dataService.GetMax(), Is.EqualTo(expectValue));
        }
    }
}
