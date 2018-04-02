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
    public partial class enter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox3.Text.ToLower() == Session["code"].ToString())
                {
                    String str = ConfigurationManager.ConnectionStrings["manageConnectionString"].ConnectionString.ToString();
                    SqlConnection con = new SqlConnection(str);
                    con.Open();
                    string select = "select *from msg where id='"+TextBox1.Text.ToString()+"'";
                
                    SqlDataAdapter da = new SqlDataAdapter(select, con);
                    DataSet add = new DataSet();
                    da.Fill(add);
                    if (add.Tables[0].Rows.Count > 0)
                    {
                        string strselect = "select * from msg where id='" + TextBox1.Text.Trim() + "' and psd='" + TextBox2.Text.Trim() + "'";
                        SqlCommand com=new SqlCommand(strselect,con);
                        SqlDataReader ad = com.ExecuteReader();
                        Session["id"] = TextBox1.Text;
                        if (ad.Read())
                        {
                            Response.Redirect("~/home.aspx");
                        }
                        else
                            Response.Write("<script language=javascript>alert('密码不正确')</script>");
                    }
                    else
                        Response.Write("用户名不存在");
                }
                else
                    Response.Write("<script language=javascript>alert('验证码不正确')</script>");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}