using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

namespace BibliotecaGestor.Models.Database
{
    public interface IBookData
    {
        public dynamic Get(int id);
        public dynamic GetAll();
        public void Insert(Book book);
        public void Delete(int id);
    }

    public class MySqlConector 
    {
        public IDbConnection Conection()
        {
            string connectionString = "Server=localhost;Database=dbbiblioteca;Userid=root;Pwd=123456789;";
            IDbConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
    }

    public class BookData : IBookData
    {
        private IDbConnection _conection;
        public BookData(IDbConnection conection)
        {
            this._conection = conection;
        }
        
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public dynamic Get(int id)
        {
            string procedule = "select_all_books";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.QueryFirst<Book>(
                        procedule,
                        new { select_book = id},
                        commandType: CommandType.StoredProcedure
                        );
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Book();
            }
        }

        public dynamic GetAll()
        {
            string procedule = "select_all_books";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.Query<Book>(
                        procedule,
                        commandType: CommandType.StoredProcedure
                        );
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Book();
            }
        }

        public void Insert(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
