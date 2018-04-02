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
using System.Net;
using System.Net.Mail;

namespace manage
{
    public partial class findpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String str = ConfigurationManager.ConnectionStrings["manageConnectionString"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string select = "select *from msg where id='" + TextBox1.Text.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet add = new DataSet();
            da.Fill(add);
            if (add.Tables[0].Rows.Count > 0)
            {
                string strselect = "select * from msg where id='" + TextBox1.Text.Trim() + "' and email='" + TextBox2.Text.Trim() + "'";
                SqlCommand com = new SqlCommand(strselect, con);
                SqlDataReader ad = com.ExecuteReader();
                if (ad.Read())
                {
                    try
                    {
MailMessage mymail = new MailMessage();
                    mymail.From = new MailAddress("x1596638165@163.com");
                    mymail.To.Add(new MailAddress(TextBox2.Text));
                    mymail.Subject = "重置密码";
                    mymail.Body = "重置密码请点击此" + "http://localhost:52243//resetpassword.aspx?id=" + TextBox1.Text + "&time=" + DateTimeToStamp(DateTime.Now);
                    SmtpClient myclient = new SmtpClient();
                    myclient.Host = "smtp.163.com";
                    myclient.Port = 25;
                    myclient.Credentials = new NetworkCredential("x1596638165@163.com","xqqx09487");
                    Response.Write("<script language=javascript>alert('已成功发送至您的邮箱，请注意查收')</script>");
                    myclient.Send(mymail);
                    }
                    
                    catch(Exception ex){
                        Response.Write("<script language=javascript>alert('邮件发送失败')</script>");                    
                    }
                }
                else
                    Response.Write("<script language=javascript>alert('邮箱不正确')</script>");
            }
            else
                Response.Write("该用户不存在");
        }
        private int DateTimeToStamp(DateTime time) 
        { 
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds; 
        }   //时间转时间戳
    }
}