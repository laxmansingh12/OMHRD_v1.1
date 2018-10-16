using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.AdminPanel
{
    public partial class frmNewCollection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid(); fillCategory();
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
        public void fillSubCategory()
        {
            try
            {
                List<SubCategoryMaster> _state = SubCategoryMasterCollection.GetAll().Where(x => x.Category_ID == int.Parse(dropCategory.SelectedValue.ToString())).OrderBy(x => x.SubCategory_NAME).ToList();
                SubCategoryMaster sm = new SubCategoryMaster();
                sm.SubCategory_ID = 0;
                sm.SubCategory_NAME = "-select Sub Category-";
                _state.Insert(0, sm);
                dropSubCate.DataSource = _state;
                dropSubCate.DataTextField = "SubCategory_NAME";
                dropSubCate.DataValueField = "SubCategory_ID";
                dropSubCate.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void grid()
        {
            gdvNotice.DataSource = NewCollectionMasterCollection.GetAll();
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
                NewCollectionMaster cm = new NewCollectionMaster();
                if (btnsubmit.Text == "Submit")
                {
                    cm.NewCollection_ID = NewCollectionMaster.MaxId() + 1;
                    cm.ITEM_ID = 1;
                    cm.ITEMNAME = txtitemName.Text;
                    cm.CATEGORY_ID = int.Parse(dropCategory.SelectedValue.ToString());
                    cm.SubCategory_ID = int.Parse(dropSubCate.SelectedValue.ToString());
                    cm.Description = txtDescription.Text.Trim();
                    cm.DiscountPrice = decimal.Parse(txtdiscountPrice.Text);
                    cm.Price = decimal.Parse(txtprice.Text);
                    #region Image1
                    string exten = System.IO.Path.GetExtension(fileImage.FileName);
                    if (fileImage.HasFile == true)
                    {
                        fileImage.SaveAs(Server.MapPath("~/images/ItemImages/" + cm.ITEMNAME + 1 + exten));
                        cm.Image = cm.ITEMNAME + 1 + exten;
                    }
                    else
                    {
                        cm.Image = ITEM_MASTER.GetByITEM_ID(cm.ITEM_ID).Image;
                    }
                    #endregion
                    cm.Save();
                    grid();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully....');</Script>", false);
                }
                else if (btnsubmit.Text == "Update")
                {
                    cm = NewCollectionMaster.GetByNewCollection_ID(int.Parse(ViewState["id"].ToString()));
                    cm.NewCollection_ID = int.Parse(ViewState["id"].ToString());
                    cm.ITEM_ID = 1;
                    cm.ITEMNAME = txtitemName.Text;
                    cm.CATEGORY_ID = int.Parse(dropCategory.SelectedValue.ToString());
                    cm.SubCategory_ID = int.Parse(dropSubCate.SelectedValue.ToString());
                    cm.Description = txtDescription.Text.Trim();
                    cm.DiscountPrice = decimal.Parse(txtdiscountPrice.Text);
                    cm.Price = decimal.Parse(txtprice.Text);
                    #region Image1
                    string exten = System.IO.Path.GetExtension(fileImage.FileName);
                    if (fileImage.HasFile == true)
                    {
                        fileImage.SaveAs(Server.MapPath("~/images/ItemImages/" + cm.ITEMNAME + 1 + exten));
                        cm.Image = cm.ITEMNAME + 1 + exten;
                    }
                    else
                    {
                        cm.Image = ITEM_MASTER.GetByITEM_ID(cm.ITEM_ID).Image;
                    }
                    #endregion
                    grid();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully...');</Script>", false);
                }
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
            ITEM_MASTER dm = ITEM_MASTER.GetByITEM_ID(int.Parse(nid));
            //txtcolor.Text = dm.Color_NAME;
            //txtremark.Text = dm.REMARK;
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
                ITEM_MASTER dm = new ITEM_MASTER();
                dm.Color_ID = int.Parse(did);
                dm.Delete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("frmItemMaster.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }

        protected void dropCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSubCategory();
        }
    }
}