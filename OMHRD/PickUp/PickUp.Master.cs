using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.PickUp
{
    public partial class PickUp : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblProfileName.Text = " Wellcome," + " " + PickupMaster.GetByPickupName(Session["Pickuser"] == null ? string.Empty : Session["Pickuser"].ToString()).FirstName + " " + PickupMaster.GetByPickupName(Session["Pickuser"] == null ? string.Empty : Session["Pickuser"].ToString()).LastName;
                decimal Am = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).PickUpWallet;
                lblWallet.Text = Am.ToString();
            }
        }
    }
}