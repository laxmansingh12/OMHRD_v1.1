using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Object;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace OMHRD.ProductSale
{
    public partial class frmAddToCartList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddtoCardDetail.Visible = false;
                GetAddtoCartDetail();
            }
        }

        void GetAddtoCartDetail()
        {
            if (Session["loginid"] != null && !string.IsNullOrEmpty(Session["loginid"].ToString()))
            {
                String strConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnString);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("usp_AddToCartList", con);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", int.Parse(Session["loginid"].ToString()));
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    adapter.Fill(ds);
                    ListView1.DataSource = ds.Tables[0];
                    ListView1.DataBind();
                    if (ListView1.Items.Count > 0)
                    {
                        AddtoCardDetail.Visible = true;
                    }
                    else
                    {
                        lblStatus.Text = "Your Shopping Cart is empty.";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Your Shopping Cart is empty.');</Script>", false);
                    }
                }
                catch (SqlException ex)
                {
                    //lblMsg.Text = se.Message;
                }
                finally { }


                con.Close();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('User not login');</Script>", false);
                return;
            }
        }
        protected void linkbtnView_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                ViewState["id"] = ((Label)gv.FindControl("labelNOTICE_ID")).Text;
                string did = ViewState["id"].ToString();
                ProductAddtoCartMaster dm = new ProductAddtoCartMaster();
                dm.Cart_id = int.Parse(did);
                dm.Delete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Product Remove....');</Script>", false);
                Response.Redirect("frmAddToCartList.aspx");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int ProId = Convert.ToInt32(e.CommandArgument);
                int UserId = int.Parse(Session["loginid"].ToString());
                ProductAddtoCartMaster dm = new ProductAddtoCartMaster();
                var product = ProductAddtoCartMaster.GetByUser_idProductID(UserId, ProId);
                int Cartid = product.Cart_id;
                dm.Cart_id = Cartid;
                dm.Delete();
                //var product = db.AddtoCarts.FirstOrDefault(x => x.Product_id == ProId || x.User_id == UserId);
                //db.AddtoCarts.Remove(product);
                //db.SaveChanges();
                GetAddtoCartDetail();
            }
        }
    }
}