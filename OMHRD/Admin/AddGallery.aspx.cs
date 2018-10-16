using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.Admin
{
    public partial class AddGallery : System.Web.UI.Page
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
            gdvNotice.DataSource = GallarymasterCollection.GetAll();
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
                else if (ctrl is Image)
                    ((Image)ctrl).ImageUrl = "";
                ClearInputs(ctrl.Controls);
                btnsubmit.Text = "Submit";
            }
        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                GallaryMaster cm = new GallaryMaster();
                if (btnsubmit.Text == "Submit")
                {
                    cm.Id = GallaryMaster.GetMaxID() + 1;
                    string exten1 = System.IO.Path.GetExtension(fileImage.FileName);
                    if (fileImage.HasFile == true)
                    {
                        cm.FileName = "Gal" + cm.Id + exten1;
                        fileImage.SaveAs(Server.MapPath("~/images/Gallery/" + "Gal" + cm.Id + exten1));
                    }
                    else
                    {
                        cm.FileName = GallaryMaster.GetById(cm.Id).FileName;
                    }
                    cm.Heading = txthesd.Text;
                    cm.Save();
                    grid();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully....');</Script>", false);
                }
                else if (btnsubmit.Text == "Update")
                {
                    cm = GallaryMaster.GetById(int.Parse(ViewState["id"].ToString()));
                    cm.Id = int.Parse(ViewState["id"].ToString());
                    string exten1 = System.IO.Path.GetExtension(fileImage.FileName);
                    if (fileImage.HasFile == true)
                    {
                        cm.FileName = "Gal" + cm.Id + exten1;
                        fileImage.SaveAs(Server.MapPath("~/images/Gallery/" + "Gal" + cm.Id + exten1));
                    }
                    else
                    {
                        cm.FileName = GallaryMaster.GetById(cm.Id).FileName;
                    }
                    cm.Heading = txthesd.Text;
                    cm.Heading = txthesd.Text;
                    cm.Save();
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
            GallaryMaster cm = GallaryMaster.GetById(int.Parse(nid));
            if (cm.FileName == "" || cm.FileName == null)
            {
                ImagePhoto.ImageUrl = "~/images/b1.jpg";
            }
            else
            {
                ImagePhoto.ImageUrl = "~/images/Gallery/" + cm.FileName;
            }
            txthesd.Text = cm.Heading;
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
                GallaryMaster dm = new GallaryMaster();
                dm.Id = int.Parse(did);
                dm.GetByDelete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("AddGallery.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }
    }
}