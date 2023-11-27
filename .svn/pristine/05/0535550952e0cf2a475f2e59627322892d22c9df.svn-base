
using ADO.NET.Models;
using Nov27Practice.Helpers;
using System.Data;
using System.Linq;

namespace ADO.NET.Services;

public class BlogService : IBaseService<Blog>
{
    public int Create(Blog data)
    {
        string query = $"INSERT INTO Artists VALUES (N'{data.Title}', N'{data.Description}', N'{data.UserId}')";
        return SqlHelper.Exec(query);
    }

    public int Delete(int id)
    {
        string query = $"DELETE Blogs WHERE Id = {id}";
        return SqlHelper.Exec(query);
    }

    public List<Blog> GetAll()
    {
        DataTable dt = SqlHelper.GetDatas("SELECT * FROM Blogs");
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

    public Blog GetById(int id)
    {
        DataTable dt = SqlHelper.GetDatas($"SELECT * FROM Blogs WHERE Id = {id}");
        DataRow dr = dt.Rows[0];
        return new Blog { Id = (int)dr["Id"], Title = (string)dr["Title"], UserId = (int)dr["UserId"] };

    }

    public List<Blog> GetWhere(string query)
    {
        DataTable dt = SqlHelper.GetDatas(query);
        List<Blog> list = new();
        foreach (DataRow row in dt.Rows)
        {
            list.Add(new() {Title = (string)row["Title"], Description = (string)row["Description"], UserId = (int)row["UserId"], });
        }
        return list;
    }

    public int Update(int id, Blog data)
    {
        throw new NotImplementedException();

    }
}
