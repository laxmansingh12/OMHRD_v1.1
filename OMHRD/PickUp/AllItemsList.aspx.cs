using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.PickUp
{
    public partial class AllItemsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { grid(); }
        }
        public void grid()
        {
            gdvNotice.DataSource = ITEM_MASTERCollection.GetAll();
            gdvNotice.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            grid();
        }




        protected void gdvNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid();
            gdvNotice.PageIndex = e.NewPageIndex;
            gdvNotice.DataBind();
        }

        protected void txtPname_TextChanged(object sender, EventArgs e)
        {
            string username = txtPname.Text.Trim();
            List<ITEM_MASTER> _rg = ITEM_MASTERCollection.GetAll().FindAll(x => x.ITEMNAME == username);
            if (_rg.Count > 0)
            {
                gdvNotice.DataSource = _rg;
                gdvNotice.DataBind();
                txtPname.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Not Record Found....');</Script>", false);
                txtPname.Text = "";
                grid();
            }
        }

        protected void txtPcode_TextChanged(object sender, EventArgs e)
        {
            string username = txtPcode.Text.Trim();
            List<ITEM_MASTER> _rg = ITEM_MASTERCollection.GetAll().FindAll(x => x.CODE == username);
            if (_rg.Count > 0)
            {
                gdvNotice.DataSource = _rg;
                gdvNotice.DataBind();
                txtPcode.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Not Record Found....');</Script>", false);
                txtPcode.Text = "";
                grid();
            }
        }
    }
}