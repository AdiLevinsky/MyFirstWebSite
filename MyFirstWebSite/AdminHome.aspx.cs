using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstWebSite
{
    public partial class AdminHome : System.Web.UI.Page
    {
        public string adm = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string dbFileName = "MyFirstDB.accdb"; 
            string userGender = Request.Form["userGender"];
            string userDistrict = Request.Form["userDistrict"];
            
            // בניית שאילתת החיפוש בהתאם לקריטריונם שנבחרו
            string sql = "SELECT * FROM tbl_users";
            bool sqlChanged = false;

            if(userGender != null)
            {
                sql += " WHERE userGender ='" + userGender + "'";
                sqlChanged = true;
            }

            if (userDistrict != null && userDistrict != "choose")
            {
                if(sqlChanged)
                    sql += " AND userDistrict ='" + userDistrict + "'";
                else
                    sql += " WHERE userDistrict ='" + userDistrict + "'";
            }

            // בניית הטבלה עם נתוני המשתמשים
            DataTable table = MyAdoHelper.ExecuteDataTable(dbFileName, sql);
            int length = table.Rows.Count;
            if (length > 0)
            {
                adm += "<table class='styled-table'>";
                adm += "<thead><tr>";
                adm += "<th>דואר אלקטרוני</th>";
                adm += "<th>סיסמה</th>";
                adm += "<th>שם פרטי</th>";
                adm += "<th>שם משפחה</th>";
                adm += "<th>מספר טלפון</th>";
                adm += "<th>מין</th>";
                adm += "<th>צבעים אהובים</th>";
                adm += "<th>אזור מגורים</th>";
                adm += "<th colspan='2'>פעולות</th>";
                adm += "</tr></thead>";
                adm += "<tbody>";
                for (int i = 0; i < length; i++) // הכנסת הנתונים לטבלה - כל איטרציה היא רשומה מבסיס הנתונים של משתמש רשום
                {
                    adm += "<tr>";
                    adm += "<form method='post' action='AdminEditUser.aspx'>";

                    adm += "<td><input type='text' class='inputToLabelLarge' name='userMail'     value='" + table.Rows[i]["userMail"]     + "' readonly/></td>";
                    adm += "<td><input type='text' class='inputToLabel'      name='userPwd'      value='" + table.Rows[i]["userPwd"]      + "' readonly/></td>";
                    adm += "<td><input type='text' class='inputToLabel'      name='userFname'    value='" + table.Rows[i]["userFname"]    + "' readonly/></td>";
                    adm += "<td><input type='text' class='inputToLabel'      name='userLname'    value='" + table.Rows[i]["userLname"]    + "' readonly/></td>";
                    adm += "<td><input type='text' class='inputToLabel'      name='userPhone'    value='" + table.Rows[i]["userPhone"]    + "' readonly/></td>";
                    adm += "<td><input type='text' class='inputToLabel'      name='userGender'   value='" + table.Rows[i]["userGender"]   + "' readonly/></td>";
                    adm += "<td><input type='text' class='inputToLabel'      name='userColors'   value='" + table.Rows[i]["userColors"]   + "' readonly/></td>";
                    adm += "<td><input type='text' class='inputToLabel'      name='userDistrict' value='" + table.Rows[i]["userDistrict"] + "' readonly/></td>";

                    adm += "<td><input type='image' id='submitUpdate' name='submitUpdate' src='/Images/update.png' width='30' height='25' alt='עדכון פרטי משתמש' /></td>";

                    adm += "<td><a href='AdminDeleteUser.aspx?userMail=" + table.Rows[i]["userMail"] + "'><img src='/Images/delete.png' width='30' height='25' alt='מחיקת משתמש מבסיס הנתונים'/></a></td>";

                    adm += "</form>";
                    adm += "</tr>";
                }
                adm += "</tbody></table>";
            }
            else
            {
                adm = "אין ערכים תואמים לחיפוש";
            }
        }
    }
}