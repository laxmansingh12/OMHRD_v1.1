using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.ProductSale
{
    public partial class SubProductDetailShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int catId = 0;
                int subCatId = 0;

                if (!string.IsNullOrWhiteSpace(Request.QueryString["catid"]))
                {
                    int.TryParse(Request.QueryString["catid"].Trim(), out catId);
                }
                if (!string.IsNullOrWhiteSpace(Request.QueryString["subcatid"]))
                {
                    int.TryParse(Request.QueryString["subcatid"].Trim(), out subCatId);
                }

                FIllSubProduct(catId, subCatId);

                //if (Request.QueryString["catid"].ToString() == null || Request.QueryString["catid"].ToString() == "" || Request.QueryString["subcatid"].ToString() == null || Request.QueryString["subcatid"].ToString() == "")
                //{
                //    Response.Redirect("Default.aspx");
                //}
                //else
                //{
                //    FIllSubProduct(catId, subCatId);
                //}
            }
        }
        public void FIllSubProduct(int catid, int subcatid)
        {
            //List<ITEM_MASTER> fp = ITEM_MASTERCollection.GetAll().Where(x => (catid == 0 || x.CATEGORY_ID == catid) && (subcatid == 0 || x.SubCategory_ID == subcatid)).ToList();
            //if (fp.Count > 0)
            List<ITEM_MASTER> fp = ITEM_MASTERCollection.GetAll().Where(x => (subcatid == 0 || x.SubCategory_ID == subcatid)).ToList();
            if (fp.Count > 0)
            {
                ListView1.DataSource = fp;
                ListView1.DataBind();
            }
        }
    }
}