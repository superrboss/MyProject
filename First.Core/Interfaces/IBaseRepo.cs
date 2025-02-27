using System.Linq.Expressions;

namespace First.Core.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
        T Add(T Item);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Edit(T UpdatedItem);
        T Delete(T DeletedItem);
        T Find(Expression<Func<T,bool>> Expression);
    }
}
