using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acme.Web
{
    public partial class AddNewEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClearControls();
            }
        }

        private void ClearControls()
        {
            txtEmployeeNumber.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            lblMsg.Text = "";
            cldBirthDate.SelectedDate = DateTime.Now;
            cldEmployedDate.SelectedDate = DateTime.Now;
            cldTerminatedDate.SelectedDate = DateTime.Now;
            txtFirstName.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Adding New Employee Records  

            if ((txtEmployeeNumber.Text != "") || (txtFirstName.Text != "") || (txtLastName.Text != "") || (cldBirthDate.SelectedDate != null) || (cldEmployedDate.SelectedDate != null))
            {
                InsertEmployee();
            }
            else
            {

                lblMsg.Text = "All fields are mandatory! ";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void InsertEmployee()
        {
            try
            {
                AcmeServiceReference.Employee employee = new AcmeServiceReference.Employee
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    BirthDate = cldBirthDate.SelectedDate,
                    EmployedDate = cldBirthDate.SelectedDate,
                    EmployeeNumber = txtEmployeeNumber.Text,
                    TerminatedDate = cldTerminatedDate.SelectedDate
                };

                AcmeServiceReference.AcmeServiceClient client = new AcmeServiceReference.AcmeServiceClient();
                lblMsg.Text = "Employee: " + employee.EmployeeNumber + ", " + client.AddEmployee(employee);
            }
            catch (Exception)
            {
                lblMsg.Text = "Employee ID must be unique! ";
            }
        }

        protected void bntReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
    }
}