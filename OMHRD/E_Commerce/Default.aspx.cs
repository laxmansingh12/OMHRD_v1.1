using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.E_Commerce
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProduct();
            }
        }
        public void BindProduct()
        {
            List<ITEM_MASTER> fp = ITEM_MASTERCollection.GetAll().OrderByDescending(x => x.ITEM_ID).Take(8).ToList();
            if (fp.Count > 0)
            {
                ListView1.DataSource = fp;
                ListView1.DataBind();
            }
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {

        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {

        }
    }
}