using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manage
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
                Label1.Text = "欢迎您" + Session["id"];
            else
            {            
                Server.Transfer("~/enter.aspx");
            }               
            
        }

     
    }
}