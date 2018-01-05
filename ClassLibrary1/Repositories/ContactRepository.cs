using ConsoleApp1.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace ConsoleApp1.Repositories
{
    internal class ContactsRepository : RepositoryBase, IContactRepository
    {
        public ContactsRepository(IDbTransaction transaction)
            : base(transaction)
        {
        }

        public IEnumerable<Contacts> All()
        {

            var result = Connection.QueryMultiple("usp_GetAllContacts", transaction: Transaction, commandType: CommandType.StoredProcedure);
            return result.Read<Contacts>().ToList();
            
            //return Connection.Query<Contacts>(
            //    "SELECT * FROM Contacts",
            //    transaction: Transaction
            //).ToList();
        }

        public Contacts Find(int id)
        {
            var result = Connection.QueryMultiple("usp_GetAllContacts", param: new { Id = id }, transaction: Transaction, commandType: CommandType.StoredProcedure);
            return result.Read<Contacts>().FirstOrDefault();

            //return Connection.Query<Contacts>(
            //    "SELECT * FROM Contacts WHERE ContactsId = @ContactsId",
            //    param: new { ContactsId = id },
            //    transaction: Transaction
            //).FirstOrDefault();
        }

        public void Add(Contacts entity)
        {

            var parameter = new DynamicParameters();
            parameter.Add("@Id", entity.Id, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
            parameter.Add("@FirstName", entity.FirstName);
            parameter.Add("@LastName", entity.LastName);
            parameter.Add("@Company", entity.Company);
            parameter.Add("@Title", entity.Title);
            parameter.Add("@Email", entity.Email);

            Connection.Execute("usp_InsetContact", parameter, transaction: Transaction, commandType: CommandType.StoredProcedure);

            //To get newly created ID back  
            entity.Id = parameter.Get<int>("@Id");
            
            //entity.Id = Connection.ExecuteScalar<int>(
            //    "INSERT INTO Contacts(Name) VALUES(@Name); SELECT SCOPE_IDENTITY()",
            //    param: new { Name = entity.Name },
            //    transaction: Transaction
            //);
        }

        public void Update(Contacts entity)
        {
            //Connection.Execute(
            //    "UPDATE Contacts SET Name = @Name WHERE ContactsId = @ContactsId",
            //    param: new { FirstName = entity.FirstName, Id = entity.Id },
            //    transaction: Transaction
            //);
        }

        public void Delete(int id)
        {
            //Connection.Execute(
            //    "DELETE FROM Contacts WHERE Id = @Id",
            //    param: new { Id = id },
            //    transaction: Transaction
            //);
        }

        public void Delete(Contacts entity)
        {
            Delete(entity.Id);
        }

        public Contacts FindByName(string name)
        {
            //return Connection.Query<Contacts>(
            //    "SELECT * FROM Contacts WHERE FirstName = @Name",
            //    param: new { Name = name },
            //    transaction: Transaction
            //).FirstOrDefault();

            return null;
        }
    }
}
