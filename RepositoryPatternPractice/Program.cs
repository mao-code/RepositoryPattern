using System;
using RepositoryPatternPractice.Models;

namespace RepositoryPatternPractice
{
   class Program
   {
        public static void Main(string[] args)
        {
            //example of using these interfaces and classes
            //using block like try/finally and call Dispose()
            using ( var unitOfWork = new UnitOfWork(new MypostgresContext()) )
            {
                //Example 1
                var books = unitOfWork.Books.GetAll();
                Console.WriteLine("Initial State: ");
                foreach (Book b in books)
                {
                    Console.WriteLine($"book: {b.BookName}, author: {unitOfWork.Authors.Get(b.AuthorId).AuthorName}");
                }
                Console.WriteLine();

                //Example 2
                unitOfWork.Books.AddRange(new List<Book>() {
                    new Book() { BookName="AIGuide", Price=300, Author=unitOfWork.Authors.GetAuthorByName("Xuan")},
                    new Book() { BookName="PSGuide", Price=230, Author=unitOfWork.Authors.GetAuthorByName("Xuan")}
                });


                //Example3
                unitOfWork.Books.Get(2).BookName = "C#dotNETGuide";

                unitOfWork.Complete();

                Console.WriteLine("After changes: ");
                books = unitOfWork.Books.GetAll();
                foreach (Book b in books)
                {
                    Console.WriteLine($"book: {b.BookName}, author: {unitOfWork.Authors.Get(b.AuthorId).AuthorName}");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
   }
}