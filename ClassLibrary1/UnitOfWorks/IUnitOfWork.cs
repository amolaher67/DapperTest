using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ConsoleApp1.Repositories;

namespace ConsoleApp1.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository ContactRepository { get; }
        void Commit();
    }
}
