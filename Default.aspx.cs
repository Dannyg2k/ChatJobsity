using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ChatJobsity
{
    public partial class _Default : Page
    {
        db_chatjobsityEntities _contextDB = new db_chatjobsityEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("/Account/Login");

                }

                //HtmlGenericControl li = new HtmlGenericControl("li");
                //li.InnerText = "Hola";
                //disconnectList.Controls.Add(li);


            }
        }
    }
}