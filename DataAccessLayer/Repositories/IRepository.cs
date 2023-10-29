using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
	public interface IRepository<T>
	{
		Task<int> CreateAsync(T item);
		Task UpdateAsync(T item);
		Task DeleteAsync(T item);
		Task<IEnumerable<T>> LoadAllAsync();
		Task InitializeDbAsync();
	}
}
