using ADO.NET.Services;
using GhostPizza.UI.Helpers;
using Nov27Practice.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nov27Practice.Services
{
    internal class UserService : IBaseService<Nov27Practice.Models.User>
    {
        public int Create(Nov27Practice.Models.User data)
        {   
            var a = SqlHelper.Exec($"INSERT INTO USERS (N'{data.Name}',N'{data.Surname}',N'{InputHelper.HashString(data.Password,"salt")}')");
            return a;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Models.User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Models.User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Models.User> GetWhere(string query)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, Models.User data)
        {
            throw new NotImplementedException();
        }
    }
}
