using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acme.Web
{
    public partial class DisplayEmployeeRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                AcmeServiceReference.AcmeServiceClient client = new AcmeServiceReference.AcmeServiceClient();
                ds = client.GetEmployees();
                grdEmployees.DataSource = ds;
                grdEmployees.DataBind();
            }
        }
    }
}