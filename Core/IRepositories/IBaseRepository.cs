using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
       Task <IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task<T> Create(T entity);   
        Task<T> Update(T entity,int id);
        Task<T> Delete(T entity);
    }
}
