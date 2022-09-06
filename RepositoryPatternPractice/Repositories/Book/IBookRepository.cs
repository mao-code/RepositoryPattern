using System;
using RepositoryPatternPractice.Models;

namespace RepositoryPatternPractice.Repositories
{
	//derive from my generic Repository interface
	//C# allow this interface chain
	public interface IBookRepository : IRepository<Book>
	{
		IEnumerable<Book> GetTopSellingBooks(int count);
		IEnumerable<Book> GetBooksByAuthor(Author author);
	}
}

