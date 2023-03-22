using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProiectPS.Models;

namespace ProiectPS.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-LOB8N2F\\SQLEXPRESS; database=MvcDemoDb; integrated security = SSPI;";
        }
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Employees where username='"+acc.Name+"' and password="+acc.Password+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return View();
            }
            con.Close();
        }
    }
}
