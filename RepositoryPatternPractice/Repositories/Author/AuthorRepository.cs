using System;
using RepositoryPatternPractice.Models;

namespace RepositoryPatternPractice.Repositories
{
	public class AuthorRepository : Repository<Author>, IAuthorRepository
	{
		public MypostgresContext MypostgresContext
        {
			get { return Context as MypostgresContext; }
        }

		public AuthorRepository(MypostgresContext context) : base(context) 
		{
		}

		public Author GetAuthorByName(string name)
		{
			return MypostgresContext.Authors.Where(x=>x.AuthorName.Equals(name)).ToList().FirstOrDefault();
		}
	}
}

