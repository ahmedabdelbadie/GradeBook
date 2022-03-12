using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {
        static void gradeadded(Object c,EventArgs ar,double grade)
        {
          Console.WriteLine($"Grade {grade} Addded Succesfully");  
        }
        static void Main(string[] args)
        {
            IBook book = new InMemeoryBook("ahmed's Grade book");
            book.gradeAdded += gradeadded;
            EnterBookGrade(book);
            var result = book.showstatistics();
            Console.WriteLine($" Avarage : {result.Avarage}");
            Console.WriteLine($" Low : {result.Low}");
            Console.WriteLine($" High : {result.High}");
            Console.WriteLine($" Letter : {result.Letter}");
            Console.ReadLine();



        }
        private static void EnterBookGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("enter agrade to add or 'q' to quite");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    book.AddGrade(double.Parse(input));
                }
                catch (System.Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // ..... 
                }

            }
        }
    }
}
