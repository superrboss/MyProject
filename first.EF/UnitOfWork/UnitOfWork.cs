using first.EF.classes;
using First.Core.Interfaces;
using First.Core.IUnitOfWork;
using First.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBaseRepo<product> products { get; private set; }

        public IBaseRepo<User> Users { get; private set; }

        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            products = new BaseRepo<product>(_context);
            Users = new BaseRepo<User>(_context);
        }
        public int Complate()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
         _context.Dispose();
        }
    }
}
