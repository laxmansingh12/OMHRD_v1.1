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

namespace OMHRD.ProductSale
{
    public partial class productdetail : System.Web.UI.Page
    {
        public string ImageOneUrl { get; set; }
        public string ImageTwoUrl { get; set; }
        public string ImageThreeUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUnit(); BindColor();
                if (Request.QueryString["st"].ToString() == null || Request.QueryString["st"].ToString() == "")
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Member_detail(int.Parse(Request.QueryString["st"].ToString()));
                }
                hdnProductId.Value = Request.QueryString["st"].ToString();
            }

        }
        public void BindUnit()
        {
            try
            {
                String strConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnString);
                string com = "Select * from ItemUnitRel where ItemId = '" + Request.QueryString["st"] + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dropSize.DataSource = dt;
                dropSize.DataBind();
                dropSize.DataTextField = "UnitCode";
                dropSize.DataValueField = "UnitCode";
                dropSize.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void BindColor()
        {
            try
            {
                String strConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnString);
                string com = "Select * from ItemUnitRel where ItemId = '" + Request.QueryString["st"] + "'";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dropcolor.DataSource = dt;
                dropcolor.DataBind();
                dropcolor.DataTextField = "Color_Code";
                dropcolor.DataValueField = "Color_Code";
                dropcolor.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void Member_detail(int MID)
        {
            try
            {
                string Color = dropcolor.SelectedValue;
                string Unit = dropSize.SelectedValue;
                ITEM_MASTER drms = ITEM_MASTER.GetByITEM_ID(MID);
                if (drms.ITEM_ID > 0)
                {
                    #region
                    ViewState["MID"] = MID;
                    lblItemName.Text = drms.ITEMNAME;
                    lblprice.Text = ITEM_MASTER.GetByITEM_IDRATE(MID).Price.ToString();// txtrate.Text = ITEM_MASTER.GetByITEM_IDRATE(ItemId).Price.ToString();
                    lblDescription.Text = drms.Description;
                    if (string.IsNullOrWhiteSpace(drms.Image))
                    {
                        ImageOneUrl = "../images/NoImage";
                    }
                    else
                    {
                        ImageOneUrl = "../images/ItemImages/" + drms.Image;
                    }
                    if (string.IsNullOrWhiteSpace(drms.Image1))
                    {
                        ImageTwoUrl = "../images/NoImage";
                    }
                    else
                    {
                        ImageTwoUrl = "../images/ItemImages/" + drms.Image1;
                    }
                    if (string.IsNullOrWhiteSpace(drms.Image2))
                    {
                        ImageThreeUrl = "../images/NoImage";
                    }
                    else
                    {
                        ImageThreeUrl = "../images/ItemImages/" + drms.Image2;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }

        protected void dropSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select Price ,DisscountPrice from  ItemUnitRel where ItemId= " + int.Parse(ViewState["MID"].ToString()) + " and UnitCode=" + dropSize.SelectedValue + " ", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblprice.Text = reader["Price"].ToString();
                lblDescription.Text = reader["DisscountPrice"].ToString();
                reader.Close();
                connection.Close();
            }
        }

        protected void dropcolor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}