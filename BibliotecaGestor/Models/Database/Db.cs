﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

namespace BibliotecaGestor.Models.Database
{
    public interface IData
    {
        public dynamic Get(int id);
        public dynamic GetAll();
        public void Insert(dynamic param);
        public void Delete(int id);
        public void Update(dynamic param);
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
    public class database : IData
    {
        IData _datacontroller;

        public database(IData datacontroller)
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

        public void Insert(dynamic param)
        {
            _datacontroller.Insert(param);
        }

        public void Update(dynamic param)
        {
            _datacontroller.Update(param);
        }
    }



    public class BookData : IData
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

        public void Insert(dynamic param)
        {
            string procedule = "insert_book";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.Query<Book>(
                        procedule, new
                        {
                            title = param.GetIdBook(),
                            author = param.GetAuthor(),
                            isbn = param.GetIsbn(),
                            publisher = param.GetPublisher()
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

        public void Update(dynamic param)
        {
            string procedule = "update_book";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.Query<Book>(
                        procedule, new
                        {
                            id = param.GetIdBook(),
                            title = param.GetTitle(),
                            author = param.GetAuthor(),
                            isbn = param.GetIsbn(),
                            publisher = param.GetPublisher()
                        },
                        commandType: CommandType.StoredProcedure
                        );
                    Console.WriteLine(result.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class UserData : IData
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

        public void Insert(dynamic param)
        {
            string procedule = "insert_user";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.Query<Book>(
                        procedule, new
                        {
                            name = param.GetName(),
                            email = param.GetEmail(),
                            phone = param.GetPhone(),
                            zipcode = param.GetZipCode()
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

        public void  Update(dynamic param)
        {
            string procedule = "update_book";
            try
            {
                using (_conection)
                {
                    dynamic result = _conection.Query<Book>(
                        procedule, new
                        {
                            id = param.GetId(),
                            name = param.GetName(),
                            email = param.GetEmail(),
                            phone = param.GetPhone(),
                            zipcode = param.GetZipCode()  
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
