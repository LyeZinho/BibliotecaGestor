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

    //Abstração para todas as classes IBookData
    public class database : IBookData
    {
        IBookData _datacontroller;

        public database(IBookData datacontroller)
        {
            _datacontroller = datacontroller;
        }

        public void Delete(int id)
        {
            _datacontroller.Delete(id);
        }

        public dynamic Get(int id)
        {
            dynamic data = _datacontroller.Get(id);
            return data;
        }

        public dynamic GetAll()
        {
            dynamic data = _datacontroller.GetAll();
            return data;
        }

        public void Insert(Book book)
        {
            _datacontroller.Insert(book);
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
            string procedule = "delete_book";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.QueryFirst<Book>(
                        procedule,
                        new { id },
                        commandType: CommandType.StoredProcedure
                        );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public dynamic Get(int id)
        {
            string procedule = "select_book";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.QueryFirst<Book>(
                        procedule,
                        new { id },
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
            string procedule = "insert_book";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.Query<Book>(
                        procedule, new
                        {
                            title = book.GetIdBook(),
                            author = book.GetAuthor(),
                            isbn = book.GetIsbn(),
                            publisher = book.GetPublisher()
                        },
                        commandType: CommandType.StoredProcedure
                        );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(Book book)
        {
            string procedule = "update_book";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.Query<Book>(
                        procedule, new
                        {
                            id = book.GetIdBook(),
                            title = book.GetTitle(),
                            author = book.GetAuthor(),
                            isbn = book.GetIsbn(),
                            publisher = book.GetPublisher()
                        },
                        commandType: CommandType.StoredProcedure
                        );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class UserData
    {
        private IDbConnection _conection;
        public UserData(IDbConnection conection)
        {
            this._conection = conection;
        }

        public void Delete(int id)
        {
            string procedule = "delete_user";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.QueryFirst<Book>(
                        procedule,
                        new { id },
                        commandType: CommandType.StoredProcedure
                        );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Insert(User user)
        {
            string procedule = "insert_user";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.Query<Book>(
                        procedule, new
                        {
                            name = user.GetName(),
                            email = user.GetEmail(),
                            phone = user.GetPhone(),
                            zipcode = user.GetZipCode()
                        },
                        commandType: CommandType.StoredProcedure
                        );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public dynamic Get(int id)
        {
            string procedule = "select_user";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.QueryFirst<Book>(
                        procedule,
                        new { id },
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
            string procedule = "select_all_users";
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

        public void  Update(User user)
        {
            string procedule = "update_book";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.Query<Book>(
                        procedule, new
                        {
                            id = user.GetId(),
                            name = user.GetName(),
                            email = user.GetEmail(),
                            phone = user.GetPhone(),
                            zipcode = user.GetZipCode()  
                        },
                        commandType: CommandType.StoredProcedure
                        );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
