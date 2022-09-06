using System;
using RepositoryPatternPractice.Models;
using RepositoryPatternPractice.Repositories;

namespace RepositoryPatternPractice
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MypostgresContext _context;

		public IBookRepository Books { get; private set; }
		public IAuthorRepository Authors { get; private set; }

		//we will use this context across all repositories
		public UnitOfWork(MypostgresContext context)
		{
			this._context = context;
			//use the same context to initialize our repository
			Books = new BookRepository(_context);
			Authors = new AuthorRepository(_context);
		}

		public int Complete()
        {
			return this._context.SaveChanges();
        }

		public void Dispose()
		{
			_context.Dispose(); //dispose the context
		}
	}
}

