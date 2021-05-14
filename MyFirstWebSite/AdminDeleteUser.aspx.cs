using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstWebSite
{
    public partial class AdminDeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null) // הדף זמין רק למנהל האתר
            {
                string email = Request.QueryString["userMail"];
                if (email != null) // הפרמטר של האימייל לא עבר מסיבה כלשהי
                {
                    string dbFileName = "MyFirstDB.accdb";
                    string sql = "DELETE * FROM tbl_users WHERE userMail='" + email + "'"; // מחיקת המשתמש
                   
                    MyAdoHelper.DoQuery(dbFileName, sql);
                }
                Response.Redirect("AdminHome.aspx"); // הפנייה לדף
            }
            else // אם המנהל לא מחובר
                Response.Redirect("AdminLogin.aspx"); // הפנייה לדף
        }
    }
}