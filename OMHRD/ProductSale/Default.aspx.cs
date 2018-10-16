using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Object;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

namespace OMHRD.ProductSale
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSliderRepeater(); BindFooterSlider(); FIllNewCollection();
            }
        }
        //public void FIllNewCollection()
        //{
        //    List<ITEM_MASTER> fp = ITEM_MASTERCollection.GetAll();
        //    if (fp.Count > 0)
        //    {
        //        ListView1.DataSource = fp;
        //        ListView1.DataBind();
        //    }
        //}

        void FIllNewCollection()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand myCmd = new SqlCommand("usp_GetAllItem", con);
            myCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("usp_GetAllItem", con);
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                adapter.Fill(ds);
                ListView1.DataSource = ds.Tables[0];
            }
            catch (SqlException se)
            {
                //lblMsg.Text = se.Message;
            }
            finally { }
            ListView1.DataBind();
            con.Close();
        }
        public void BindSliderRepeater()
        {
            List<BannerMaster> bp = BannerMasterCollection.GetAll();
            rptSlider.DataSource = bp;
            rptSlider.DataBind();
        }
        public void BindFooterSlider()
        {
            List<BannerMaster> banners = BannerMasterCollection.GetAll();
            banners.Add(new BannerMaster()
            {
                FILE_ID = 1,
                FILE_NAME1 = "Slider 2",
                //HEADING1 = "A BROAD RANGE OF CONSTRUCTION SERVICES ARE AVAILABLE FROM OUR STAFF",
                //HEADING2 = "A BROAD RANGE OF CONSTRUCTION SERVICES ARE AVAILABLE FROM OUR STAFF",
                //HEADING3 = "A BROAD RANGE OF CONSTRUCTION SERVICES ARE AVAILABLE FROM OUR STAFF",
                //SliderCSSClass1 = "collections"

            });

            Repeater2.DataSource = banners;
            Repeater2.DataBind();
        }
        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //    try
            //    {
            //        if (e.CommandName == "QuickView")
            //        {
            //            int CollectID = Convert.ToInt32(e.CommandArgument);
            //            ITEM_MASTER rg = ITEM_MASTER.GetByITEM_ID(CollectID);
            //            if (rg.ITEM_ID > 0)
            //            {
            //                Response.Redirect("productdetail.aspx?st=" + rg.ITEM_ID);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    { string script = "<script>alert('" + ex.Message + "');</script>"; }
        }
        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (ListView1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.FIllNewCollection();
        }
    }
}