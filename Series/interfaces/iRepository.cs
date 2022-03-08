using System.Collections.Generic;

namespace dioSeries.interfaces
{
    public interface IRepository<T>
    {
        List<T> ListSeries();
        T ReturnForId(int id);
        void Insert(T entidade);
        void Delet(int id);
        void Update(int id, T entidade);
        int NextId();
    }

}