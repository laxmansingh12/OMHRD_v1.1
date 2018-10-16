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
    public partial class frontEndBanner : System.Web.UI.Page
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
            gdvNotice.DataSource = FrontBannerMasterCollection.GetAll();
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
                FrontBannerMaster ln = new FrontBannerMaster();
                if (btnsub.Text == "Submit")
                {
                    if (FileUpload1.PostedFile.FileName == "")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Plz select Image.');</Script>", false);
                        return;
                    }
                    ln.FILE_ID = BannerMaster.GetMaxID() + 1;
                    ln.HEADING1 = txtfirst.Text;
                    ln.HEADING2 = txtsecond.Text;
                    ln.HEADING3 = txtthird.Text;
                    ln.HEADING4 = txtfour.Text;
                    ln.HEADING5 = txtfive.Text;
                    #region
                    string exten = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (FileUpload1.PostedFile.FileName != "")
                    {
                        ln.FILE_NAME1 = "banner1" + exten;
                        FileUpload1.SaveAs(Server.MapPath("../images/nw/" + ln.FILE_NAME1));
                    }
                    else
                    {
                        ln.FILE_NAME1 = "";
                    }
                    #endregion
                    #region
                    string exten1 = System.IO.Path.GetExtension(FileUpload2.FileName);
                    if (FileUpload2.PostedFile.FileName != "")
                    {
                        ln.FILE_NAME2 = "banner2" + exten1;
                        FileUpload2.SaveAs(Server.MapPath("../images/" + ln.FILE_NAME2));
                    }
                    else
                    {
                        ln.FILE_NAME2 = "";
                    }

                    #endregion
                    #region
                    string exten3 = System.IO.Path.GetExtension(FileUpload3.FileName);
                    if (FileUpload3.PostedFile.FileName != "")
                    {
                        ln.FILE_NAME3 = "banner3" + exten3;
                        FileUpload3.SaveAs(Server.MapPath("../images/" + ln.FILE_NAME3));
                    }
                    else
                    {
                        ln.FILE_NAME3 = "";
                    }
                    #endregion
                    #region
                    string exten4 = System.IO.Path.GetExtension(FileUpload4.FileName);
                    if (FileUpload4.PostedFile.FileName != "")
                    {
                        ln.FILE_NAME4 = "banner4" + exten4;
                        FileUpload4.SaveAs(Server.MapPath("../images/" + ln.FILE_NAME4));
                    }
                    else
                    {
                        ln.FILE_NAME4 = "";
                    }

                    #endregion
                    #region
                    string exten5 = System.IO.Path.GetExtension(FileUpload5.FileName);
                    if (FileUpload5.PostedFile.FileName != "")
                    {
                        ln.FILE_NAME5 = "banner5" + exten5;
                        FileUpload5.SaveAs(Server.MapPath("../images/" + ln.FILE_NAME5));
                    }
                    else
                    {
                        ln.FILE_NAME5 = "";
                    }

                    #endregion
                    ln.Save();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully...');</Script>", false);
                }
                grid();
                ClearControls(this);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert(error);</script>", false);
            }
        }
    }
}