using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Core.Interfaces;

public interface IRepository<T> where T : class
{
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
}
