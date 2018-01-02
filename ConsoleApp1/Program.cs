using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;



namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DapperHelper objDapperHelper = new DapperHelper();

            #region Insert Dynamic Object To Database  

            dynamic c = new Contacts();
            Program p = new Program();
            Console.WriteLine("Enter First Name : ");
            c.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name : ");
            c.LastName = Console.ReadLine();
            Console.WriteLine("Enter Email Address : ");
            c.Email = Console.ReadLine();
            Console.WriteLine("Enter Company Name: ");
            c.Company = Console.ReadLine();
            Console.WriteLine("Enter Title : ");
            c.Title = Console.ReadLine();
            Console.WriteLine("New Contact Created With ID {0} ", objDapperHelper.CreateContact(c));

            #endregion

            #region GetContacts
            var contacts = objDapperHelper.GetAllContact(1);
            #endregion


            //We can write same SP for Delete and update 
            
        }
    }



    public class DapperHelper
    {
        static IDbConnection db;
        static DapperHelper()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString);
        }

        public List<Contacts> GetAllContact(int id)
        {
            List<Contacts> lstContact = null;

            try
            {

                using (var result = db.QueryMultiple("usp_GetAllContacts", new { ID = id }, commandType: CommandType.StoredProcedure))
                {
                    lstContact = result.Read<Contacts>().ToList();

                }

                return lstContact;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CreateContact(Contacts con)
        {
            try
            {

                var parameter = new DynamicParameters();
                parameter.Add("@Id", con.Id, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                parameter.Add("@FirstName", con.FirstName);
                parameter.Add("@LastName", con.LastName);
                parameter.Add("@Company", con.Company);
                parameter.Add("@Title", con.Title);
                parameter.Add("@Email", con.Email);

                db.Execute("usp_InsetContact", parameter, commandType: CommandType.StoredProcedure);

                //To get newly created ID back  
                con.Id = parameter.Get<int>("@Id");

                return con.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
