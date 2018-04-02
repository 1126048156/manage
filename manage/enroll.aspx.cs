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
    public partial class enroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String str = ConfigurationManager.ConnectionStrings["manageConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand comselect = new SqlCommand("select id from msg where id="+TextBox1.Text.ToString(),con);
            SqlDataReader rd = comselect.ExecuteReader();
            if(rd.Read())
            {
                Response.Write("已存在该账号，请重新输入");
                return;
            }
            rd.Close();
            if(TextBox1.Text.ToString().Length>16)
                Response.Write("账号不能超出16位");
            else if(TextBox2.Text.ToString().Length>16)
                Response.Write("密码不能超出16位");
            else
            {
                String insert = "insert into msg values('" + TextBox1.Text.ToString() + "','" + TextBox2.Text.ToString() + "','" + TextBox3.Text.ToString() + "')";
                SqlCommand cominsert = new SqlCommand(insert, con);
                cominsert.ExecuteReader();
                con.Close();
                Response.Write("<script language=javascript>alert('注册成功')</script>");
                Server.Transfer("~/enter.aspx");//——打开新的页面;
            }          
        }
    }
}