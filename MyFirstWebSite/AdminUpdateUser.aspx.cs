using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstWebSite
{
    public partial class AdminUpdateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null) // הדף זמין רק למנהל האתר
            {
                string dbFileName = "MyFirstDB.accdb";

                if (Request.Form["submit_update"] != null)
                {
                    // שאילת נתונים מהטופס
                    string userMail = Request.Form["userMail"];
                    string userPwd = Request.Form["userPwd"];
                    string userFname = Request.Form["userFname"];
                    string userLname = Request.Form["userLname"];
                    string userPhone = Request.Form["userPhone"];
                    string userGender = Request.Form["userGender"];
                    string userColors = Request.Form["userColors"];
                    string userDistrict = Request.Form["userDistrict"];

                    // עדכון הפרטים
                    string sql = "UPDATE tbl_users SET";
                    sql += "  userFname='"    + userFname       + "'";
                    sql += ", userLname='"      + userLname     + "'";
                    sql += ", userPwd='"        + userPwd       + "'";
                    sql += ", userDistrict='"   + userDistrict  + "'";
                    sql += ", userGender='"     + userGender    + "'";
                    sql += ", userPhone='"      + userPhone     + "'";
                    sql += ", userColors='"     + userColors    + "'";
                    sql += " WHERE userMail='"  + userMail      + "'";

                    MyAdoHelper.DoQuery(dbFileName, sql);

                    Response.Redirect("AdminHome.aspx");// הפנייה לדף
                }
            }
            else // אם המנהל לא מחובר
                Response.Redirect("AdminLogin.aspx"); // הפנייה לדף
        }
    }
}