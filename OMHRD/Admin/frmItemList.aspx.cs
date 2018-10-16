using Business.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.Admin
{
    public partial class frmItemList : System.Web.UI.Page
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
            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
            //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //sda.Fill(ds);
            //gdvNotice.DataSource = ds;
            //gdvNotice.DataBind();
            gdvNotice.DataSource = ITEM_MASTERCollection.GetAll();
            gdvNotice.DataBind();

        }
        protected void gdvNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid();
            gdvNotice.PageIndex = e.NewPageIndex;
            gdvNotice.DataBind();
        }

        protected void linkbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                ViewState["id"] = ((Label)gv.FindControl("labelNOTICE_ID")).Text;
                string did = ViewState["id"].ToString();
                ITEM_MASTER dm = new ITEM_MASTER();
                dm.ITEM_ID = int.Parse(did);
                dm.Delete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("frmItemList.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }

        protected void linkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                int FileId = int.Parse(((Label)gv.FindControl("labelNOTICE_ID")).Text);
                ITEM_MASTER rg = ITEM_MASTER.GetByITEM_ID(FileId);
                if (rg.ITEM_ID > 0)
                {
                    Response.Redirect("frmItemMaster.aspx?st=" + rg.ITEM_ID);
                }
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
    }
}