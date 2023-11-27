
using ADO.NET.Models;
using Nov27Practice.Helpers;
using System.Data;
using System.Linq;

namespace ADO.NET.Services;

public class BlogService 
{ 
    public int Create(Blog data)
    {
        string query = $"INSERT INTO Blogs VALUES (N'{data.Title}', N'{data.Description}', N'{data.UserId}')";
        return SqlHelper.Exec(query);
    }

    public int Delete(int id,int userId)
    {
        GetById(id, userId);
        string query = $"DELETE Blogs WHERE Id = {id} AND UserId = {userId}";
        return SqlHelper.Exec(query);
    }

    public List<Blog> GetAll(int userId)
    {
        DataTable dt = SqlHelper.GetDatas($"SELECT * FROM Blogs WHERE UserId = {userId}");
        List<Blog> list = new List<Blog>();
        foreach (DataRow row in dt.Rows)
        {
            list.Add(new Blog
            {
                Id = (int)row["Id"],
                Title = (string)row["Title"],
                Description = (string)row["Description"],
                UserId = (int) row["UserId"]
            });
        }
        return list;
    }

    public Blog GetById(int id,int userId)
    {
        DataTable dt = SqlHelper.GetDatas($"SELECT * FROM Blogs WHERE Id = {id} AND UserId = {userId}");
        if(dt.Rows.Count>0)
        {
        DataRow dr = dt.Rows[0];
        var blog =  new Blog { Id = (int)dr["Id"], Title = (string)dr["Title"], UserId = (int)dr["UserId"] };
        return blog;
        }
        throw new Exception($"Logged in user has no blog with id = {id}!");
    }


    public int Update(int id, Blog data)
    {
        GetById(id, (int)data.UserId);
        return SqlHelper
                .Exec($"update Blogs SET Title = N'{data.Title}', Description = N'{data.Description}' WHERE UserId = {data.UserId} AND Id = {id}");
    }
}
