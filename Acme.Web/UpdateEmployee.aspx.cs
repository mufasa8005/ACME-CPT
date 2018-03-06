using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acme.Web
{
    public partial class UpdateEmployee : System.Web.UI.Page
    {
        AcmeServiceReference.Employee employee = new AcmeServiceReference.Employee();
        AcmeServiceReference.AcmeServiceClient client = new AcmeServiceReference.AcmeServiceClient();
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetPanel(true, false);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                employee.EmployeeId = int.Parse(txtSearch.Text.Trim());
                ds = new DataSet();
                ds = client.SearchEmployee(employee);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblEmpID.Text = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                    txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    // cldTerminatedDate.SelectedDate = DateTime.Now;
                    SetPanel(false, true);

                }
                else
                {
                    lblSearchResult.Text = "Please Enter Employee ID !";
                    lblSearchResult.ForeColor = System.Drawing.Color.White;
                }

            }
            else
            {
                lblSearchResult.Text = "Please Enter Employee ID !";
            }
        }

        private void SetPanel(bool pSearch, bool pUpdate)
        {
            panSearch.Visible = pSearch;
            panUpdate.Visible = pUpdate;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SetPanel(true, false);
            lblMsg.Text = "";
        }

        protected void bntUpdated_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            employee.PersonId = int.Parse(lblEmpID.Text.Trim());
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.TerminatedDate = cldTerminatedDate.SelectedDate;

            string result = client.UpdateEmployee(employee);
            lblSearchResult.Text = result;
            SetPanel(true, false);

            ClearControls();
        }

        private void ClearControls()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            cldTerminatedDate.SelectedDate = DateTime.Now;
            lblEmpID.Text = "";
        }
    }
}