using System;
using RepositoryPatternPractice.Models;

namespace RepositoryPatternPractice.Repositories
{
	public interface IAuthorRepository : IRepository<Author>
	{
		Author GetAuthorByName(string name);
	}
}

