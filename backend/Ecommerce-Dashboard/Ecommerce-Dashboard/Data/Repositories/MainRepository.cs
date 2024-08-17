using Ecommerce_Dashboard.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ecommerce_Dashboard.Data.Repositories
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public T GetById(int id)
        {

            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll(params string[] eagers)
        {
            IQueryable<T> query = _context.Set<T>();
            return query.ToList();
        }
        

        public async Task<ActionResult<T>> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Add(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();

        }

        public void Update(T t)
        {
         
             _context.Set<T>().Update(t);
             _context.SaveChanges();
            
        }

        public void Delete(T t)
        {

                _context.Set<T>().Remove(t);
                _context.SaveChanges();
        }

        public void Add(IEnumerable<T> list)
        {
            if(list != null)
            {
                _context.Set<T>().AddRange(list);
                _context.SaveChanges();
            }
        }

        public void Update(IEnumerable<T> list)
        {
            _context.Set<T>().UpdateRange(list);
            _context.SaveChanges();
        }

        public void Delete(IEnumerable<T> list)
        {
            _context.Set<T>().UpdateRange(list);
            _context.SaveChanges();
        }

        public async Task AddAsync(T t)
        {
            _context.Set<T>().Add(t);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T t)
        {

            _context.Set<T>().Update(t);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IEnumerable<T> list)
        {
            _context.Set<T>().UpdateRange(list);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T t)
        {
            _context.Set<T>().Remove(t);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<T> list)
        {
            _context.Set<T>().UpdateRange(list);
           await _context.SaveChangesAsync();
        }
    }
}
