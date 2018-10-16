using Business.Object;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.Admin
{
    public partial class frmBannerMaster : System.Web.UI.Page
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
            gdvNotice.DataSource = BannerMasterCollection.GetAll();
            gdvNotice.DataBind();

        }
        void ClearControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Text = "";
                else if (c is RadioButton)
                    ((RadioButton)c).Checked = false;
                else if (c is DropDownList)
                    ((DropDownList)c).SelectedIndex = 0;
                else if (c is Image)
                    ((Image)c).ImageUrl = null;
                ClearControls(c); btnsub.Text = "Submit";
            }
        }

        protected void btnsub_Click(object sender, EventArgs e)
        {
            try
            {
                BannerMaster ln = new BannerMaster();
                if (btnsub.Text == "Submit")
                {
                    if (FileUpload1.PostedFile.FileName == "")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Plz select Image.');</Script>", false);
                        return;
                    }
                    string fn = FileUpload1.PostedFile.FileName;
                    string fl = Server.MapPath("../images/" + fn);
                    if (File.Exists(fl))
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('This  File is allready present in  database.');</Script>", false);
                        return;
                    }
                    ln.FILE_ID = BannerMaster.GetMaxID() + 1;
                    ln.HEADING1 = txtfirst.Text; ln.HEADING2 = txtsecond.Text; ln.HEADING3 = txtthird.Text;
                    #region
                    string exten = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (FileUpload1.PostedFile.FileName != "")
                    {
                        ln.FILE_NAME = "banner" + exten;
                        ln.ATTETMENT = ("../images/" + ln.FILE_NAME);
                        FileUpload1.SaveAs(Server.MapPath("../images/" + ln.FILE_NAME));
                    }
                    else
                    {
                        ln.FILE_NAME = "";
                        ln.ATTETMENT = "";
                    }
                    #endregion
                    #region
                    string exten1 = System.IO.Path.GetExtension(FileUpload2.FileName);
                    if (FileUpload2.PostedFile.FileName != "")
                    {
                        ln.FILE_NAME1 = "Footer" + exten1;
                        ln.ATTETMENT1 = ("../images/" + ln.FILE_NAME1);
                        FileUpload2.SaveAs(Server.MapPath("../images/" + ln.FILE_NAME1));
                    }
                    else
                    {
                        ln.FILE_NAME1 = "";
                        ln.ATTETMENT1 = "";
                    }
                    ln.FooterHeading = txtFooter.Text.Trim();
                    #endregion
                    ln.Save();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully...');</Script>", false);
                }
                else if (btnsub.Text == "Update")
                {
                    ln = BannerMaster.GetByFILE_ID(int.Parse(ViewState["Galid"].ToString()));
                    string fn = FileUpload1.PostedFile.FileName;
                    string fl = Server.MapPath("../images/" + fn);
                    if (File.Exists(fl))
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('This  File is allready present in  database.');</Script>", false);
                        return;
                    }
                    ln.FILE_ID = int.Parse(ViewState["Galid"].ToString());
                    ln.HEADING1 = txtfirst.Text; ln.HEADING2 = txtsecond.Text; ln.HEADING3 = txtthird.Text;
                    #region FooterImage
                    string exten = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (FileUpload1.HasFile == true)
                    {
                        FileUpload1.SaveAs(Server.MapPath("../images/" + "Banner" + exten));
                        ln.FILE_NAME = "Banner" + exten;
                    }
                    else
                    {
                        ln.FILE_NAME = BannerMaster.GetByFILE_ID(ln.FILE_ID).FILE_NAME;
                    }
                    #endregion
                    #region FooterImage
                    string exten1 = System.IO.Path.GetExtension(FileUpload2.FileName);
                    if (FileUpload2.HasFile == true)
                    {
                        FileUpload2.SaveAs(Server.MapPath("../images/" + "Footer" + exten1));
                        ln.FILE_NAME1 = "Footer" + exten1;
                    }
                    else
                    {
                        ln.FILE_NAME1 = BannerMaster.GetByFILE_ID(ln.FILE_ID).FILE_NAME1;
                    }
                    #endregion
                    ln.FooterHeading = txtFooter.Text.Trim();
                    ln.Save();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully...');</Script>", false);
                }
                grid();
                ClearControls(this);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert(error);</script>", false);
            }
        }

        protected void linkbtnEdit_Click(object sender, EventArgs e)
        {

            LinkButton lb = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)lb.NamingContainer;
            ViewState["Galid"] = ((Label)gr.FindControl("labelNOTICE_ID")).Text;
            string nid = ViewState["Galid"].ToString();
            BannerMaster dm = BannerMaster.GetByFILE_ID(int.Parse(nid));
            txtfirst.Text = dm.HEADING1; txtsecond.Text = dm.HEADING2; txtthird.Text = dm.HEADING3; txtFooter.Text = dm.FooterHeading;
            Image1.ImageUrl = "../images/" + dm.FILE_NAME;
            Image2.ImageUrl = "../images/" + dm.FILE_NAME1;
            btnsub.Text = "Update";
            string fupload = FileUpload1.PostedFile.FileName;
        }

        protected void linkbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                ViewState["Galid"] = ((Label)gv.FindControl("labelNOTICE_ID")).Text;
                string did = ViewState["Galid"].ToString();
                BannerMaster dm = new BannerMaster();
                dm.FILE_ID = int.Parse(did);
                if (BannerMaster.GetByFILE_ID(int.Parse(did)).FILE_NAME != "")
                {
                    string pathfile = Server.MapPath("../images/" + BannerMaster.GetByFILE_ID(int.Parse(did)).FILE_NAME);
                    if (File.Exists(pathfile))
                    {
                        File.Delete(pathfile);
                    }
                }
                if (BannerMaster.GetByFILE_ID(int.Parse(did)).FILE_NAME1 != "")
                {
                    string pathfile = Server.MapPath("../images/" + BannerMaster.GetByFILE_ID(int.Parse(did)).FILE_NAME1);
                    if (File.Exists(pathfile))
                    {
                        File.Delete(pathfile);
                    }
                }
                dm.GetByDelete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("frmBannerMaster.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }
    }
}