using System;
using RepositoryPatternPractice.Repositories;

namespace RepositoryPatternPractice
{
	//Unit of work
	//interfce chain with IDisposable, so the class implement this interface
	//need to implement the Dispose() method
	public interface IUnitOfWork : IDisposable
	{
		//Repository act the collection of objects in memory
		IBookRepository Books { get; }
		IAuthorRepository Authors { get;  }
		int Complete();
	}
}

