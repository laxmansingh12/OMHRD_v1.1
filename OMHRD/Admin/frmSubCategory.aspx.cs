using Business.Object;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.AdminPanel
{
    public partial class frmSubCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid(); fillCategory(); fillUnitList(); fillColorList();
            }
        }

        public void grid()
        {
            gdvNotice.DataSource = SubCategoryMasterCollection.GetAll();
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
                else if (ctrl is CheckBoxList)
                    ((CheckBoxList)ctrl).ClearSelection();
                ClearInputs(ctrl.Controls);
                btnsubmit.Text = "Submit";
            }
        }
        public void fillCategory()
        {
            try
            {
                List<CategoryMaster> _state = CategoryMasterCollection.GetAll();
                CategoryMaster sm = new CategoryMaster();
                sm.CATEGORY_ID = 0;
                sm.CATEGORY_NAME = "-select Category-";
                _state.Insert(0, sm);
                dropCategory.DataSource = _state;
                dropCategory.DataTextField = "CATEGORY_NAME";
                dropCategory.DataValueField = "CATEGORY_ID";
                dropCategory.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void fillUnitList()
        {
            try
            {
                List<Unit_Master> _state = Unit_MasterCollection.GetAll();
                chkUnitList.DataSource = _state;
                chkUnitList.DataTextField = "Name";
                chkUnitList.DataValueField = "Code";
                chkUnitList.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void fillColorList()
        {
            try
            {
                List<ColorDataMaster> _state = ColorDataMasterCollection.GetAll();
                chkUnitColor.DataSource = _state;
                chkUnitColor.DataTextField = "Color_NAME";
                chkUnitColor.DataValueField = "Color_Code";
                chkUnitColor.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                List<ListItem> selected = chkUnitList.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
                string Unitlist = string.Join(",", selected.Select(x => x.Value));
                List<ListItem> color = chkUnitColor.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
                string ColorList = string.Join(",", color.Select(x => x.Value));
                string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection cn = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("usp_SaveSubCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (ViewState["id"] == null)
                {
                    cmd.Parameters.AddWithValue("@SubCategoryId", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SubCategoryId", ViewState["id"]);
                }
                cmd.Parameters.AddWithValue("@CategoryId", dropCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@SubCategoryName", txtcategory.Text);
                cmd.Parameters.AddWithValue("@UnitList", Unitlist);
                cmd.Parameters.AddWithValue("@ColorList", ColorList);
                cmd.Parameters.AddWithValue("@Remark", txtremark.Text);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully....');</Script>", false);
                grid();
                ClearInputs(Page.Controls);

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
            SubCategoryMaster dm = SubCategoryMaster.GetBySubCategory_ID(int.Parse(nid));
            dropCategory.SelectedIndex = dm.Category_ID;
            txtcategory.Text = dm.SubCategory_NAME;
            txtremark.Text = dm.REMARK;
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
                SubCategoryMaster dm = new SubCategoryMaster();
                dm.SubCategory_ID = int.Parse(did);
                dm.Delete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("frmSubCategory.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }
    }
}