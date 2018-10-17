using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.Admin
{
    public partial class AdminWalletRecharge : System.Web.UI.Page
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
            int AdminId = int.Parse(Session["loginid"].ToString());
            gdvNotice.DataSource = WalletRechargeMasterCollection.GetAll().FindAll(x => x.Status == "Self").OrderByDescending(x => x.Id).ToList();
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
        public void Tranfer()
        {
            try
            {
                USERPROFILEMASTER lm = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString()));
                if (lm.Registration_ID > 0)
                {
                    USERPROFILEMASTER lmm = new USERPROFILEMASTER();
                    decimal PreviousAmount = lm.UserWallet;
                    decimal Amount = decimal.Parse(txtamount.Text.Trim());
                    decimal TotalAmount = PreviousAmount + Amount;
                    lmm.WalletRecharge(lm.Registration_ID, TotalAmount);
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Wallet recharge successful..!!!')</script>", false);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Some technical issues. Please contact our support team...!!!')</script>", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + ex.Message + "')</script>", false);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                WalletRechargeMaster cm = new WalletRechargeMaster();
                if (btnsubmit.Text == "Submit")
                {
                    cm.Id = WalletRechargeMaster.MaxId() + 1;
                    cm.ByUser_id = int.Parse(Session["loginid"].ToString());
                    cm.User_id = int.Parse(Session["loginid"].ToString());
                    cm.Amount = decimal.Parse(txtamount.Text.Trim());
                    cm.Date = System.DateTime.Now;
                    cm.Status = "Self";
                    cm.Save();
                    Tranfer();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Transfer Successfully....');</Script>", false);
                }
                else if (btnsubmit.Text == "Update")
                {
                    cm = WalletRechargeMaster.GetById(int.Parse(ViewState["id"].ToString()));
                    cm.Id = int.Parse(ViewState["id"].ToString());
                    cm.ByUser_id = int.Parse(Session["loginid"].ToString());
                    cm.User_id = int.Parse(Session["loginid"].ToString());
                    cm.Amount = decimal.Parse(txtamount.Text.Trim());
                    cm.Date = System.DateTime.Now;
                    cm.Save();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully...');</Script>", false);
                }
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
    }
}