using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public interface IRepositoryBase<T>
    {
        //CRUD
        // Nesleri izleyip izlememek icin bool tipinde bir parametre eklendi.
        IQueryable<T> FindAll(bool trackChanges);
        // Nesleri izleyip izlememek icin bool tipinde bir parametre eklendi.
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
