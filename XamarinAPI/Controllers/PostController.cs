using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace XamarinAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {

        private List<PostModel> list = new List<PostModel>();
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public List<PostModel> Get()
        {
            //Ado.net Data Access 
            //List<PostModel> list = new List<PostModel>();
            //SqlConnection con = new SqlConnection(@"Data Source=RANA\SQLEXPRESS;Initial Catalog=XamarinDB;Integrated Security=True");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("Select * from Post", con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    int id = Convert.ToInt32(dr["Id"]);
            //    int userId = Convert.ToInt32(dr["UserId"]);
            //    list.Add(new PostModel { Id = id, UserId = userId, Title = dr["Title"].ToString(), Description = dr["Description"].ToString() });

            //    //list.Add(new PostModel { Id = 1, UserId = 1, Title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit", Description = "My desc1" }
            //    //    );
            //    //list.Add(new PostModel { Id = 2, UserId = 1, Title = "qui est esse", Description = "My desc2" }
            //    //        );

            //}
            list.Add(new PostModel { Id = 1, UserId = 1, Title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit", Description = "My desc1" }
                    );
            list.Add(new PostModel { Id = 2, UserId = 1, Title = "qui est esse", Description = "My desc2" }
                    );

            return list;
        }
        [HttpPost]
        public int Post([FromBody] PostModel model)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RANA\SQLEXPRESS;Initial Catalog=XamarinDB;Integrated Security=True");
            con.Open();
            string inserSQL = "insert into Post(UserId,Title,Description)values(@UserID,@Title,@Desc)";
            SqlCommand cmd= new SqlCommand(inserSQL, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UserID", model.UserId);
            cmd.Parameters.AddWithValue("@Title", model.Title);
            cmd.Parameters.AddWithValue("@Desc", model.Description);
            int result = cmd.ExecuteNonQuery();
            return result;

        }
    }
}
