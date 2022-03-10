using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> Get(int id);
        public Task<IReadOnlyCollection<T>> GetAll();
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(T entity);
    }
}
