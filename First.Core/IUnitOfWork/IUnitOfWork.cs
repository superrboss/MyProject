using First.Core.Interfaces;
using First.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Core.IUnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        IBaseRepo<product> products { get; }
        IBaseRepo<User> Users{ get; }

        int Complate();
    }
}
