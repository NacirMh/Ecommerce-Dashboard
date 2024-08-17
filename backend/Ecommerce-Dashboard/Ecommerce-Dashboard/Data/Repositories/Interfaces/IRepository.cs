using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Dashboard.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public T GetById(int id);

        public IEnumerable<T> GetAll(params string[] eagers);

        public void Add(T t);
        public void Add(IEnumerable<T> list);


        public void Update(T t);
        public void Update(IEnumerable<T> list);

        public void Delete(T t);
        public void Delete(IEnumerable<T> list);


        public Task<ActionResult<T>> GetByIdAsync(int id);
        public Task<ActionResult<IEnumerable<T>>> GetAllAsync();
        public Task AddAsync(T t);  
        public Task UpdateAsync(T t);
        public Task UpdateAsync(IEnumerable<T> list);
        public Task DeleteAsync(T t);   
        public Task DeleteAsync(IEnumerable<T> list);

    }
}
