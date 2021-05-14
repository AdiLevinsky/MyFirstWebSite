using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstWebSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["loginSubmit"] != null)
            {
                string sql, fname;
                string dbFileName = "MyFirstDB.accdb";
                string userMail = Request.Form["userMail"];
                string userPwd = Request.Form["userPwd"];

                //בדיקה האם קיימת רשומה בטבלה עם אותם ערכים בשדות דואל וסיסמה
                sql = "SELECT * FROM tbl_users WHERE userMail = '" + userMail + "' AND userPwd = '" + userPwd + "'";

                // שליפת השם הפרטי של המשתמש מתוך הרשומה במידה ונמצאה התאמה בבסיס הנתונים
                fname = MyAdoHelper.GetItemRowData(dbFileName, sql, 2);

                if (fname != "") //הצלחה
                {
                    Session["userName"] = fname;
                    Response.Redirect("HomePage.aspx"); //ניתוב לדף הבית
                }
                else //כשלון
                {
                    Response.Redirect("Login.aspx?code=1");
                }
            }
        }
    }
}