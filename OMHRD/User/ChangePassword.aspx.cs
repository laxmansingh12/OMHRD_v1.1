using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.User
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        int logid;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                USERPROFILEMASTER lm = USERPROFILEMASTER.GetByPASSWORD(txtOld.Text);
                if (lm.Registration_ID > 0)
                {
                    logid = lm.Registration_ID;
                    if (txtnewpassword.Text != txtcomformpassword.Text)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Confirm Password is not Matching...!!!')</script>", false);
                        return;
                    }
                    USERPROFILEMASTER lmm = new USERPROFILEMASTER();
                    lmm.Update_PASSWORD(logid, txtnewpassword.Text);
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