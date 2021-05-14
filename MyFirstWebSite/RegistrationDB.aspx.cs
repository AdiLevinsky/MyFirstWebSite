using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class RegistrationDB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["regSubmit"] != null)
        {
            string sql;
            string dbFileName = "MyFirstDB.accdb";

            //--- שליפת ערכי השדות מתוך טופס ההרשמה המלא
            string userMail = Request.Form["userMail"];
            string userPwd = Request.Form["userPwd"];
            string userFname = Request.Form["userFname"];
            string userLname = Request.Form["userLname"];
            string userPhone = Request.Form["userPhone"];
            string userBDay = Request.Form["userBDay"];
            string userGender = Request.Form["userGender"];
            string userColors = Request.Form["userColors"];
            string userDistrict = Request.Form["userDistrict"];
            string userComments = Request.Form["userComments"];

            //TODO - add all the fields from the form

            //בדיקה האם קיימת רשומה בטבלה עם אותם שדות מפתח
            sql = "SELECT * FROM tbl_users WHERE userMail = '" + userMail + "'";

            if (MyAdoHelper.IsExist(dbFileName, sql))
            {
                Response.Redirect("RegistrationDB.aspx?code=1"); //GET
            }
            else
            {
                //ניתן לשמור את פרטי המשתמש בבסים הנתונים
                sql = "INSERT INTO tbl_users ";
                sql += "(userMail, userPwd, userFname, userLname, userGender, userDistrict, userBDay, userColors, userPhone, userComments) ";
                sql += "VALUES (";
                sql += "'" + userMail + "'";
                sql += ",'" + userPwd + "'";
                sql += ",'" + userFname + "'";
                sql += ",'" + userLname + "'";
                sql += ",'" + userGender + "'";
                sql += ",'" + userDistrict + "'";
                sql += ",'" + userBDay + "'";
                sql += ",'" + userColors + "'";
                sql += ",'" + userPhone + "'";
                sql += ",'" + userComments + "'";
                sql += ")";

                Session["userName"] = userFname;
                MyAdoHelper.DoQuery(dbFileName, sql);
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}