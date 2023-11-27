
using ADO.NET.Services;
using Nov27Practice.Helpers;
using Nov27Practice.Models;
using System.Data;

using System.Linq;


namespace Nov27Practice.Services
{
    internal class UserService : IBaseService<User>
    {
        public int Create(User data)
        {
            var count = SqlHelper.GetDatas($"SELECT * FROM USERS WHERE Username = '{data.Username}'").Rows.Count;
            if (count > 0)
                throw new Exception("Username already exists!");
            var a = SqlHelper.Exec($"INSERT INTO USERS VALUES (N'{data.Username}',N'{data.Name}',N'{data.Surname}',N'{InputHelper.HashString(data.Password,"salt")}')");
            return a;
        }

        public int Delete(int id)
        {
            return SqlHelper.Exec($"DELETE FROM Users WHERE Id = {id}");
        }

        public List<User> GetAll()
        {
            return SqlHelper.GetDatas("SELECT * FROM Users").AsEnumerable()
                .Select( (DataRow dataRow) => new Models.User() 
                {
                    Id = (int)dataRow["Id"],
                    Username = (string)dataRow["Username"],
                    Name = (string)dataRow["Name"],
                    Surname = (string)dataRow["Surname"],
                    Password = (string)dataRow["Password"]
                }
                ).ToList();
        }

        public User GetById(int id)
        {
            return SqlHelper.GetDatas($"SELECT * FROM Users WHERE Id = {id}")
                .AsEnumerable().Select((DataRow a) => new Models.User()
                {
                    Id = (int)a["Id"],
                    Username = (string)a["Username"],
                    Name = (string)a["Name"],
                    Surname = (string)a["Surname"],
                    Password = (string)a["Password"]
                }).Single();
        }

        public User? CheckCreds(string username,string password)
        {
            string hashedPassword = InputHelper.HashString(password,"salt");
            var user = SqlHelper.GetDatas($"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{hashedPassword}'")
                .AsEnumerable().Select((DataRow a) => new Models.User()
                {
                    Id = (int)a["Id"],
                    Username = (string)a["Username"],
                    Name = (string)a["Name"],
                    Surname = (string)a["Surname"],
                    Password = (string)a["Password"]
                }).SingleOrDefault();

            return user;
        }


        public int Update(int id, User data)
        {
            return SqlHelper
                .Exec($"update Users SET Username = N'{data.Username}, 'Name = N'{data.Name}', Surname = N'{data.Surname}' WHERE Id = {data.Id}");
        }
    }
}
