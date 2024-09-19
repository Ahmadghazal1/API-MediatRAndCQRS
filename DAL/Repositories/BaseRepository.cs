using Core.IRepositories;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            var model =  await _context.Set<T>().FindAsync(id);
            if (model == null)
                return null; 
            return model;
        }

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> Update(T entity,int id)
        {
            _context.Update(entity);
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
           _context.Remove(entity);
            return entity;
        }
    }
}
