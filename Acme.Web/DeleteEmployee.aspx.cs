using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acme.Web
{
    public partial class DeleteEmployee : System.Web.UI.Page
    {
        AcmeServiceReference.AcmeServiceClient client = new AcmeServiceReference.AcmeServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridData();
            }
        }

        //Bind Grid  
        public void BindGridData()
        {
            DataSet ds = new DataSet();
            ds = client.GetEmployees();
            grdEmployees.DataSource = ds;
            grdEmployees.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            AcmeServiceReference.Employee employee = new AcmeServiceReference.Employee
            {
                EmployeeId = int.Parse(txtSearch.Text.Trim())
            };

            string result = client.DeleteEmployee(employee);

            if (result == "Record Deleted Successfully!")
            {
                BindGridData();
                lblSearchResult.Text = "Employee ID: " + txtSearch.Text.Trim() + "Deleted Successfully!";
            }
            else
            {
                lblSearchResult.Text = "Employee ID: " + txtSearch.Text.Trim() + "Not Found!";
            }
        }
    }
}