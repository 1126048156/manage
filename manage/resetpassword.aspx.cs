using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace manage
{
    public partial class resetpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime s = StampToDateTime(Request.Params["time"]);
            if (DateTime.Compare(DateTime.Now.AddMinutes(-3), s )> 0)
                Response.Write("<script language='javascript'>alert('会话已失效');window.location='enter.aspx'</script>");
            else
                Label1.Text = Request.Params["id"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             String str = ConfigurationManager.ConnectionStrings["manageConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string select = "select *from msg where id='" +Request.Params["id"] +"'";

            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet add = new DataSet();
            da.Fill(add);
            if (add.Tables[0].Rows.Count > 0)
            {
                if (TextBox2.Text.ToString().Length > 16)
                    Response.Write("密码不能超出16位");
                else
                {
                    String update = "update msg set psd='" + TextBox1.Text.Trim() + "' where id=" +Request.Params["id"];
                    SqlCommand cmd = new SqlCommand(update, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script language='javascript'>alert('重置密码成功');window.location='enter.aspx'</script>");
                }
            }
        }
        private DateTime StampToDateTime(string timeStamp) 
        { 
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); 
            long lTime = long.Parse(timeStamp + "0000000"); 
            TimeSpan toNow = new TimeSpan(lTime); 
            return dateTimeStart.Add(toNow); 
        }
    }

}