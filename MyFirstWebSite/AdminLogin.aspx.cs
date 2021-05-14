using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstWebSite
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["loginSubmit"] != null)
            {
                string sql;
                string dbFileName = "MyFirstDB.accdb";
                string userMail = Request.Form["userMail"];
                string userPwd = Request.Form["userPwd"];

                //בדיקה האם קיימת רשומה בטבלת המנהלים עם אותם ערכים בשדות דואל וסיסמה
                sql = "SELECT * FROM tbl_admin WHERE userMail = '" + userMail + "' AND userPwd = '" + userPwd + "'";
                if (MyAdoHelper.IsExist(dbFileName, sql))
                {
                    Session["userName"] = "מנהל";
                    Session["Admin"] = true;
                    Response.Redirect("AdminHome.aspx"); //ניתוב לדף הבית
                }
                else //כשלון
                {
                    Response.Redirect("AdminLogin.aspx?code=1");
                }
            }
        }
    }
}