using ChandrashekharTest.Data;
using ChandrashekharTest.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static ChandrashekharTest.Data.AppDbConnection;

namespace ChandrashekharTest.Data
{
    public class UserRepository
    {

        //private readonly AppDbConnection connectionFactory;

        //public UserRepository()
        //{
        //    connectionFactory =
        //        new AppDbConnection ();
        //}

        //public User GetByUsername(string username)
        //{
        //    const string sql = @"
        //    SELECT
        //        UserId,
        //        Username,
        //        PasswordHash,
        //        RoleName,
        //        IsActive,
        //        CreatedDate
        //    FROM Users
        //    WHERE Username = @Username";

        //    using (var connection =
        //           connectionFactory.CreateConnection())
        //    {
        //        connection.Open();

        //        return connection.QueryFirstOrDefault<User>(
        //            sql,
        //            new
        //            {
        //                Username = username
        //            });
        //    }
        //}

        //public int Insert(User user)
        //{
        //    const string sql = @"
        //    INSERT INTO Users
        //    (
        //        Username,
        //        PasswordHash,
        //        RoleName,
        //        IsActive
        //    )
        //    VALUES
        //    (
        //        @Username,
        //        @PasswordHash,
        //        @RoleName,
        //        @IsActive
        //    );

        //    SELECT CAST(SCOPE_IDENTITY() AS INT);";

        //    using (var connection =
        //           connectionFactory.CreateConnection())
        //    {
        //        connection.Open();

        //        return connection.ExecuteScalar<int>(
        //            sql,
        //            user);
        //    }
        //}

        private readonly AppDbConnection _db;

        public UserRepository()
        {
            _db = new AppDbConnection();
        }

        //public User Login(string userName, string password)
        //{
        //    using (var con = _db.CreateConnection())
        //    {
        //        var parameters = new
        //        {
        //            UserName = userName,
        //            Password = password
        //        };

        //        return con.QueryFirstOrDefault<User>(
        //            "sp_User_Login",
        //            parameters,
        //            commandType: CommandType.StoredProcedure);
        //    }
        //}

        public User Login(string userName, string password)
        {
            using (var con = _db.CreateConnection())
                {
                con.Open();

                var parameters = new
                {
                    UserName = userName,
                    Password = password
                };

                return con.QueryFirstOrDefault<User>(
                    "spUser_Login",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}




