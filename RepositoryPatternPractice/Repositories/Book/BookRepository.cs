using System;
using RepositoryPatternPractice.Models;

namespace RepositoryPatternPractice.Repositories
{
	//inheritance, implementation
	public class BookRepository : Repository<Book>, IBookRepository
	{
        //Property
        public MypostgresContext MypostgresContext
        {
            get { return Context as MypostgresContext; }   
        }

		public BookRepository(MypostgresContext context) : base(context)
		{
		}

        IEnumerable<Book> IBookRepository.GetBooksByAuthor(Author author)
        {
           return MypostgresContext.Books.Where(x=>x.AuthorId==author.AuthorId).ToList();
        }

        IEnumerable<Book> IBookRepository.GetTopSellingBooks(int count)
        {
            return MypostgresContext.Books.OrderByDescending(b => b.Price).Take(count).ToList();
        }
    }
}

