using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("C sharp in depth");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(70.0);
            // var is typed and can know what type it is based on what the value is
            //var grades = new List<double>() {3.1, 2.2, 4.4};
            var stats = book.GetStatistics();
            
            Console.WriteLine($"Maximum is {stats.High}");
            Console.WriteLine($"Minimum is {stats.Low}");
            Console.WriteLine($"Grade averages {stats.Average:N2}");
        }
    }
}
