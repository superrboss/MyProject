using First.Core.Interfaces;
using System.Linq.Expressions;

namespace first.EF.classes
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        public BaseRepo(AppDbContext context)
        {
            _context = context;
        }
        public T Add(T Item)
        {
            _context.Set<T>().Add(Item);
            _context.SaveChanges();
            return Item;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
           
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Edit( T UpdatedUser)
        {
             _context.Set<T>().Update(UpdatedUser);
            _context.SaveChanges();
            return UpdatedUser;
        }

        public T Delete(T DeletedUser)
        {
             _context.Set<T>().Remove(DeletedUser);
            _context.SaveChanges();
            return DeletedUser;
        }

        public T Find(Expression<Func<T, bool>> Expression)
        {
            //IQueryable<T> query = _context.Set<T>();
            return _context.Set<T>().SingleOrDefault(Expression);
        }
    }
}
