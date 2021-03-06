﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("C sharp in depth");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);
            /*
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(70.0);
            book.AddGrade(-1.0);
            // var is typed and can know what type it is based on what the value is
            //var grades = new List<double>() {3.1, 2.2, 4.4};
            */
            var stats = book.GetStatistics();
            
            Console.WriteLine($"Book name is {book.Name}");
            Console.WriteLine($"Maximum is {stats.High}");
            Console.WriteLine($"Minimum is {stats.Low}");
            Console.WriteLine($"Grade averages {stats.Average:N2}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter grade, q to quit: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                // exception handling in C#, put in the catches you know you can deal with
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    // ... event will go here 
                }
                catch (ArgumentException ex) //this catches everything, which isn't what you want
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally // always executes to clean up close file, etc.
                {
                    System.Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added");
        }
    }
}
