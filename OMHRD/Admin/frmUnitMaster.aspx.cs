using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Object;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace OMHRD.AdminPanel
{
    public partial class frmUnitMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid();
            }
        }

        public void grid()
        {
            gdvNotice.DataSource = Unit_MasterCollection.GetAll();
            gdvNotice.DataBind();

        }
        private void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();
                ClearInputs(ctrl.Controls);
                btnsubmit.Text = "Submit";
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                if (btnsubmit.Text == "Submit")
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO UNITMASTER VALUES (@Code, @Name, @Description)", connection);
                    cmd.Parameters.AddWithValue("@Code", txtcode.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtname.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDes.Text.Trim());
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully....');</Script>", false);
                    ClearInputs(Page.Controls);
                }
                else if (btnsubmit.Text == "Update")
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("update UNITMASTER Set Code=@Code, Name=@Name, Description=@Description where UNIT_ID=@UNIT_ID", connection);
                    cmd.Parameters.AddWithValue("@Code", txtcode.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtname.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDes.Text.Trim());
                    cmd.Parameters.AddWithValue("@UNIT_ID", ViewState["id"]);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully....');</Script>", false);
                }
                grid(); ClearInputs(Page.Controls);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert(error);</script>", false);
            }
        }

        protected void gdvNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid();
            gdvNotice.PageIndex = e.NewPageIndex;
            gdvNotice.DataBind();
        }

        protected void linkbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)lb.NamingContainer;
            ViewState["id"] = ((Label)gr.FindControl("labelNOTICE_ID")).Text;
            string nid = ViewState["id"].ToString();
            Unit_Master dm = Unit_Master.GetByUNIT_ID(int.Parse(nid));
            txtcode.Text = dm.Code;
            txtname.Text = dm.Name;
            txtDes.Text = dm.Description;
            btnsubmit.Text = "Update";
        }

        protected void linkbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                ViewState["id"] = ((Label)gv.FindControl("labelNOTICE_ID")).Text;
                string did = ViewState["id"].ToString();
                Unit_Master dm = new Unit_Master();
                dm.UNIT_ID = int.Parse(did);
                dm.Delete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("frmUnitMaster.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }
    }
}