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

namespace OMHRD.User
{
    public partial class frmWalletDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                decimal Am = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString())).UserWallet;
                lblWallet.Text = Am.ToString();
                GetTotalSale();
            }
        }
        void GetTotalSale()
        {
            if (Session["loginid"] != null && !string.IsNullOrEmpty(Session["loginid"].ToString()))
            {
                String strConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand com = new SqlCommand("usp_GetOffOnLineShopping", con);
                com.Parameters.AddWithValue("@UserId", int.Parse(Session["loginid"].ToString()));
                com.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    using (SqlDataReader read = com.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            lbltotal.Text = (read["TotalAmount"].ToString());
                        }
                    }
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('User not login');</Script>", false);
                return;
            }
        }
    }
}