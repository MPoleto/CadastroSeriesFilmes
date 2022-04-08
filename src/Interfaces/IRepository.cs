using System.Collections.Generic;

namespace Cadastro_Series.src
{
    public interface IRepository<T>
    {
         List<T> catalog();
         T ReturnById (int id);
         void Insert (T entity);
         void Delete (int id);
         void Update (int id, T entity);
         int NextId();
    }
}