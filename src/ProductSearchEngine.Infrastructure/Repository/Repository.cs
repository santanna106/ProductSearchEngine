using Microsoft.EntityFrameworkCore;
using ProductSearchEngine.Domain.Interfaces.Repositories;
using ProductSearchEngine.Infrastructure.Context;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace ProductSearchEngine.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public Repository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(int? id)
        {
            return _context.Set<T>().FindAsync(id).Result;
        }

        public async Task Add(T entity)
        {
             _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        
    }
}
