using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.PickUp
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                PickupMaster lm = PickupMaster.GetByPASSWORD(txtOld.Text);
                if (lm.PickupID > 0)
                {
                    if (txtnewpassword.Text != txtcomformpassword.Text)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Confirm Password is not Matching...!!!')</script>", false);
                        return;
                    }
                    PickupMaster lmm = new PickupMaster();
                    lmm.Update_PASSWORD(lm.PickupID, txtnewpassword.Text);
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Your Password Has been Changed...!!!')</script>", false);
                    }
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
    }
}
