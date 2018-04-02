using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace manage
{
    public partial class alterpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
                Label1.Text = Session["id"].ToString();
            else
                Response.Redirect("~/enter.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String str = ConfigurationManager.ConnectionStrings["manageConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string select = "select *from msg where id='" +Session["id"].ToString() + "' and psd='" + TextBox3.Text.Trim() + "'";

            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet add = new DataSet();
            da.Fill(add);
            if (add.Tables[0].Rows.Count > 0)
            {
                if (TextBox2.Text.ToString().Length > 16)
                    Response.Write("密码不能超出16位");
                else if(TextBox1.Text.Trim()==TextBox3.Text.Trim())
                {
                    Response.Write("原始密码与新密码不能一样");                   
                }
                else
                {
                    String update = "update msg set psd='" + TextBox1.Text.Trim() + "' where id=" + Session["id"];
                    SqlCommand cmd = new SqlCommand(update, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session.Remove("id");
                    Response.Write("<script language='javascript'>alert('修改密码成功');window.location='enter.aspx'</script>");
                }
            }
            else
                Response.Write("当前密码错误");
        }
    }
}