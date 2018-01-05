using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using ConsoleApp1.Entities;
using ConsoleApp1.UnitOfWorks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            

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

            using (var uow = new UnitOfWork("LosGatos"))
            {
                uow.ContactRepository.Add(c);
                uow.Commit();
            }

            //Same way we can write SELECT UPDATE AND DELETE 


               

            }
    }



  
}
