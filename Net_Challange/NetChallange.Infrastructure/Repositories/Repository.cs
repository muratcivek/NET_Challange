using Microsoft.EntityFrameworkCore;
using NetChallange.Core.Interfaces;
using NetChallange.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallange.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _applicationDbContext;

    public Repository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _applicationDbContext.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _applicationDbContext.Set<T>().Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await _applicationDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var values = await _applicationDbContext.Set<T>().FindAsync(id);
        return values;
    }

    public async Task InsertAsync(T entity)
    {
        await _applicationDbContext.Set<T>().AddAsync(entity);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _applicationDbContext.Set<T>().Update(entity);
        await _applicationDbContext.SaveChangesAsync();
    }
}
