using System;
using System.Linq.Expressions;

namespace RepositoryPatternPractice.Repositories
{
	//Interface here act like a protocol or a license
	//Generic Interface -> Interface<T>
	//where can set some restriction on the generic
	public interface IRepository<TEntity> where TEntity: class
	{
		//Three main group of functions

		//Finding object
		TEntity Get(int id);
		IEnumerable<TEntity> GetAll();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

		/*
			Func<input, output> -> 委派物件(將函數當作物件的容器)
				eg. Func<int, int> fn = n=>n*n;
			Expression (eg. LINQ)
				turn an lambda to an expression tree
				and the LINQ can input a lambda expression (put in a generic delegate)
		 */

		//Adding object
		void Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);

		//Removing object
		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);
	}
}

