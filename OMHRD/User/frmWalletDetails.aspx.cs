using Business.Object;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            int userId = int.Parse(Session["loginid"].ToString());
            String strConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            string selectSql = "select sum(Amount) as TotalAmount from UserOrderPaymenttbl where OrderStatus='Success' and UserId=" + userId + "";
            SqlCommand com = new SqlCommand(selectSql, con);
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
    }
}