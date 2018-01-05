using System.Collections.Generic;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Repositories
{
    public interface IContactRepository
    {
        void Add(Contacts entity);
        IEnumerable<Contacts> All();
        void Delete(int id);
        void Delete(Contacts entity);
        Contacts Find(int id);
        Contacts FindByName(string name);
        void Update(Contacts entity);
    }
}