using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookAddGrade()
        {
            //arrange
            var book = new InMemoryBook("C sharp in depth");
            var grade1 = book.AddGrade(1.0);
            var grade2 = book.AddGrade(100.0);
            //act
            var result = book.GetStatistics();

            //assert
            Assert.InRange(grade1, 0, 100);
            Assert.InRange(grade2, 0, 100);
        }

        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new InMemoryBook("C sharp in depth");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            
            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
