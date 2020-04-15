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
            var book = new Book("C sharp in depth");
            var grade1 = book.AddGrade(-0.1);
            var grade2 = book.AddGrade(101.0);
            //act
            var result = book.GetStatistics();

            //assert
            Assert.NotInRange(grade1, 0, 100);
            Assert.NotInRange(grade2, 0, 100);
        }

        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new Book("C sharp in depth");
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
