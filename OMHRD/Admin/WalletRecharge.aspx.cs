using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.Admin
{
    public partial class WalletRecharge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid();
                fillUser();
            }
        }

        public void grid()
        {
            gdvNotice.DataSource = WalletRechargeMasterCollection.GetAll().FindAll(x => x.ByUser_id == int.Parse(Session["loginid"].ToString()));
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
        public void fillUser()
        {
            try
            {
                List<USERPROFILEMASTER> _state = USERPROFILEMASTERCollection.GetAll();
                USERPROFILEMASTER sm = new USERPROFILEMASTER();
                sm.Registration_ID = 0;
                sm.User_Name = "-select User-";
                _state.Insert(0, sm);
                ddlUser.DataSource = _state;
                ddlUser.DataTextField = "User_Name";
                ddlUser.DataValueField = "Registration_ID";
                ddlUser.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void Tranfer()
        {
            try
            {
                USERPROFILEMASTER User = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString()));
                if (User.Registration_ID > 0)
                {
                    decimal UserAmount = User.UserWallet;
                    decimal TransferAmount = decimal.Parse(txtamount.Text.Trim());
                    if (UserAmount <= TransferAmount)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Insufulset amount in your accoun.!!!')</script>", false);
                        return;
                    }

                    USERPROFILEMASTER lm = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(ddlUser.SelectedValue));
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
                    decimal MyAmount = User.UserWallet;
                    decimal TranferAmount = decimal.Parse(txtamount.Text.Trim());
                    decimal FinalAmount = MyAmount - TranferAmount;
                    User.WalletRecharge(User.Registration_ID, FinalAmount);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Old Password is not Correct...!!!')</script>", false);
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
                    cm.User_id = int.Parse(ddlUser.SelectedValue);
                    cm.Amount = decimal.Parse(txtamount.Text.Trim());
                    cm.Date = System.DateTime.Now;
                    cm.Save();
                    Tranfer();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Transfer Successfully....');</Script>", false);
                }
                else if (btnsubmit.Text == "Update")
                {
                    cm = WalletRechargeMaster.GetById(int.Parse(ViewState["id"].ToString()));
                    cm.Id = int.Parse(ViewState["id"].ToString());
                    cm.ByUser_id = int.Parse(Session["loginid"].ToString());
                    cm.User_id = int.Parse(ddlUser.SelectedValue);
                    cm.Amount = decimal.Parse(txtamount.Text.Trim());
                    cm.Date = System.DateTime.Now;
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

        }
    }
}