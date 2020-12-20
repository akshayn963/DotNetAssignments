using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCAssignment.Models;

namespace MVCAssignment.Controllers
{
    public class UserController : Controller
    {


        // GET: User/Create
        public ActionResult Create()
        {
            User objUser = new User();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = UserDB; Integrated Security = True; Pooling = False";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select cityId,cityName from Cities";
            SqlDataReader dr = cmd.ExecuteReader();
          
            List<SelectListItem> objCities = new List<SelectListItem>();

            while (dr.Read())
            {
                objCities.Add(
                    new SelectListItem
                    {
                        Text = dr.GetString(1),
                        Value = dr.GetInt32(0).ToString()

                    });
                objUser.cities = objCities;
            }
            return View(objUser);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User objUser)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = UserDB; Integrated Security = True; Pooling = False";
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Users values(@loginName,@password,@fullName,@EmailId,@cityId,@phone)";

                cmd.Parameters.AddWithValue("@loginName",objUser.loginName);
                cmd.Parameters.AddWithValue("@password", objUser.password);
                cmd.Parameters.AddWithValue("@fullName", objUser.fullName);
                cmd.Parameters.AddWithValue("@EmailId", objUser.emailId);
               
              
                cmd.Parameters.AddWithValue("@cityId",objUser.cityId);
                cmd.Parameters.AddWithValue("@phone", objUser.phone);
               
               
                cmd.ExecuteNonQuery();


                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit()
        {
            SqlConnection cn = new SqlConnection();
            string loginName = Session["loginName"].ToString();

            User user = new User();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = UserDB; Integrated Security = True; Pooling = False";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Users where loginName =@loginName";
            cmd.Parameters.AddWithValue("@loginName",loginName);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            
                user.loginName = dr["loginName"].ToString();
                user.password = dr["password"].ToString();
                user.fullName= dr["fullName"].ToString();
                user.emailId= dr["emailId"].ToString();
                user.cityId = Convert.ToInt32(dr["cityId"]);
                user.phone = dr["phone"].ToString();
            
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = UserDB; Integrated Security = True; Pooling = False";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Users set password=@password," +
                    "fullName=@fullName,emailid=@emailid,cityid=@cityid,phone=@phone where loginName=@loginName ";

                cmd.Parameters.AddWithValue("@loginName", user.loginName);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@fullName", user.fullName);
                cmd.Parameters.AddWithValue("@emailid", user.emailId);
                cmd.Parameters.AddWithValue("@cityid", user.cityId);
                cmd.Parameters.AddWithValue("@phone", user.phone);

                cmd.ExecuteNonQuery();
                cn.Close();

                return RedirectToAction("Home");

            }
            catch
            {
                return View();
            }
        }

       public ActionResult Login()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        
        public ActionResult Login(User user)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = UserDB; Integrated Security = True; Pooling = False";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            cmd.CommandText = "SELECT * FROM Users where loginName=@loginName and password = @password";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@loginName", user.loginName);
            cmd.Parameters.AddWithValue("@password", user.password);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //FormsAuthentication.SetAuthCookie(user.loginName, true);
                Session["loginName"] = user.loginName;
                return RedirectToAction("Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
            cn.Close();
            return View();
        }

        public ActionResult Home()
        {
            if (Session["loginName"] == null)
            {
                return RedirectToAction("login");
            }

            User user = new User();
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=UserDB;Integrated Security=True;Pooling=False";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Users where loginName = @loginName";
                string loginName = (string)Session["loginName"];
                cmd.Parameters.AddWithValue("@loginName", loginName);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    user.cityId = (int)dr["cityid"];
                    user.loginName = (string)dr["loginName"];
                    user.fullName = (string)dr["fullName"];
                    user.phone = (string)dr["phone"];
                    user.emailId = (string)dr["emailid"];
                    return View(user);
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["loginName"] = null;
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
