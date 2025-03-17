using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public abstract class BaseRepository<T>(DataContext context) : IBaseRepository<T> where T : class
{
    protected readonly DataContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public virtual async Task<T?> AddAsync(T entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }


    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            var entities = await _dbSet.ToListAsync();
            return entities;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
    }

    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
    {
        try
        {
            var result = await _dbSet.AnyAsync(expression);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }


    public virtual async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public virtual async Task<bool> DeleteAsync(T entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }




}