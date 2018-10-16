using Business.Object;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.ProductSale
{
    public partial class frmAllProductShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FIllNewCollection(); FIllAllCollection();
            }
        }
        public void FIllNewCollection()
        {
            List<ITEM_MASTER> fp = ITEM_MASTERCollection.GetAll().OrderByDescending(x => x.ITEM_ID).Take(12).ToList();
            if (fp.Count > 0)
            {
                ListView1.DataSource = fp;
                ListView1.DataBind();
            }
        }
        public void FIllAllCollection()
        {
            List<ITEM_MASTER> fp = ITEM_MASTERCollection.GetAll();
            if (fp.Count > 0)
            {
                ListView2.DataSource = fp;
                ListView2.DataBind();
            }
        }

        protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "QuickView")
                {
                    int CollectID = Convert.ToInt32(e.CommandArgument);
                    ITEM_MASTER rg = ITEM_MASTER.GetByITEM_ID(CollectID);
                    if (rg.ITEM_ID > 0)
                    {
                        Response.Redirect("productdetail.aspx?st=" + rg.ITEM_ID);
                    }
                }
            }
            catch (Exception ex)
            { string script = "<script>alert('" + ex.Message + "');</script>"; }
        }

       

        protected void linkfilter_Click(object sender, EventArgs e)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                string query = "SELECT * FROM ITEM_MASTER WHERE (DiscountPrice BETWEEN @Start AND @End) OR (@Start = 0 AND @End = 0)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Start", txtmin.Text);
                    cmd.Parameters.AddWithValue("@End", txtmax.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds, "ITEM_MASTER");
                    }
                }
            }
            DataTable dt = new DataTable();
            dt.TableName = "Range";
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                string query = "SELECT MIN(DiscountPrice) [Min], MAX(DiscountPrice) [Max] FROM ITEM_MASTER";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            ds.Tables.Add(dt);
            //  return ds.GetXml();
        }
    }
}