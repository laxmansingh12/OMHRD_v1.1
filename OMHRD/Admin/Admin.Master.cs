using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblProfileName.Text = " Wellcome," + " " + USERPROFILEMASTER.GetByUser_Name(Session["UserName"] == null ? string.Empty : Session["UserName"].ToString()).First_Name + " " + USERPROFILEMASTER.GetByUser_Name(Session["UserName"] == null ? string.Empty : Session["UserName"].ToString()).Last_Name;
                decimal Am = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).UserWallet;
                lblWallet.Text = Am.ToString();
            }
        }
    }
}