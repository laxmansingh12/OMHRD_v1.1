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
    public partial class ShoppingAddress : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        static decimal totalAmount;
        static string orderNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //lnkWallet.Visible = false;
                //btndeliver.Visible = false;
                //btndeliver2.Visible = false;
                //lnkWallet2.Visible = false;
                FIllAddress();
                FIllShippingAddress();
                Member_detail(int.Parse(Session["loginid"].ToString()));
            }
        }

        public void FIllShippingAddress()
        {
            List<USERPROFILEMASTER> fp = USERPROFILEMASTERCollection.GetAll().FindAll(x => x.Registration_ID == int.Parse(Session["loginid"].ToString()));
            if (fp.Count > 0)
            {
                gvdShippingAdd.DataSource = fp;
                gvdShippingAdd.DataBind();
            }
        }
        public void FIllAddress()
        {
            List<USERPROFILEMASTER> fp = USERPROFILEMASTERCollection.GetAll().FindAll(x => x.Registration_ID == int.Parse(Session["loginid"].ToString()));
            if (fp.Count > 0)
            {
                ListView1.DataSource = fp;
                ListView1.DataBind();
            }
        }
        public void Member_detail(int MID)
        {
            try
            {
                USERPROFILEMASTER drms = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(Session["loginid"].ToString()));
                if (drms.Registration_ID > 0)
                {
                    #region Billing Address
                    ViewState["Name"] = drms.First_Name + " " + drms.Last_Name;
                    ViewState["Address"] = drms.Address + " " + drms.AddressLine2;
                    ViewState["City"] = drms.CityName;
                    ViewState["State"] = drms.StateName;
                    ViewState["Zip"] = drms.ZipCode;
                    ViewState["Country"] = drms.COUNTRY;
                    ViewState["Contact"] = drms.ContactNumber;
                    ViewState["Email"] = drms.Email;
                    #endregion

                    #region Shipping address
                    ViewState["ShipName"] = drms.ShippingFirstName + " " + drms.ShippingLastName;
                    ViewState["ShipAddress"] = drms.ShippingAddress + " " + drms.ShippingAddressLine2;
                    ViewState["ShipCity"] = drms.ShipCityName;
                    ViewState["ShipState"] = drms.ShippStateName;
                    ViewState["ShipZip"] = drms.ShippingZip;
                    ViewState["ShipCountry"] = drms.COUNTRY;
                    ViewState["Contact"] = drms.ContactNumber;
                    ViewState["Email"] = drms.Email;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }


        protected void btndeliver_Click(object sender, EventArgs e)
        {
            try
            {
                int UserID = int.Parse(Session["loginid"].ToString());
                SqlConnection cn = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("usp_SaveUserOrder", cn);
                SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_id", UserID);
                cn.Open();
                adptr.Fill(ds);
                cn.Close();

                orderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                totalAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalAmount"]);
                #region 
                string websiteUrl = Request.Url.Host;
                string reqParams = string.Empty;
                reqParams += "uid=" + UserID.ToString() + "&";
                reqParams += "merchant_id=182809" + "&";
                reqParams += "order_id=" + orderNo + "&";
                reqParams += "amount=" + totalAmount + "&";
                reqParams += "currency=INR" + "&";
                reqParams += "redirect_url=" + websiteUrl + "/productsale/paymentmod/ccavResponseHandler.aspx" + "&";
                reqParams += "cancel_url=" + websiteUrl + "/productsale/paymentmod/ccavResponseHandler.aspx" + "&";
                reqParams += "billing_name=" + ViewState["Name"] + "&";
                reqParams += "billing_address=" + ViewState["Address"] + "&";
                reqParams += "billing_city=" + ViewState["City"] + "&";
                reqParams += "billing_state=" + ViewState["State"] + "&";
                reqParams += "billing_zip=" + ViewState["Zip"] + "&";
                reqParams += "billing_country=" + ViewState["Country"] + "&";
                reqParams += "billing_tel=" + ViewState["Contact"] + "&";
                reqParams += "billing_email=" + ViewState["Email"] + "&";
                reqParams += "delivery_name=" + ViewState["Name"] + "&";
                reqParams += "delivery_address=" + ViewState["Address"] + "&";
                reqParams += "delivery_city=" + ViewState["City"] + "&";
                reqParams += "delivery_state=" + ViewState["State"] + "&";
                reqParams += "delivery_zip=" + ViewState["Zip"] + "&";
                reqParams += "delivery_country=" + ViewState["Country"] + "&";
                reqParams += "delivery_tel=" + ViewState["Contact"] + "&";
                reqParams += "merchant_param1=" + "1" + "&";
                reqParams += "merchant_param2=" + "2" + "&";
                reqParams += "merchant_param3=" + "3" + "&";
                reqParams += "merchant_param4=" + "4" + "&";
                reqParams += "merchant_param5=" + "" + "&";
                reqParams += "promo_code=" + "" + "&";
                reqParams += "customer_identifier=" + "cust123";
                Session["PaymentDetail"] = reqParams;
                Response.Redirect("~/productsale/paymentmod/ccavRequestHandler.aspx");
                #endregion
            }
            catch (Exception ex)
            { }
        }
        protected void lnkWallet_Click(object sender, EventArgs e)
        {
            int UserID = int.Parse(Session["loginid"].ToString());
            USERPROFILEMASTER User = USERPROFILEMASTER.GetByRegistration_ID(UserID);
            if (User.Registration_ID > 0)
            {
                decimal UserAmount = User.UserWallet;
                decimal TransferAmount = totalAmount;
                if (UserAmount <= TransferAmount)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Insufulset amount in User account.!!!')</script>", false);
                    return;
                }
                #region
                SqlConnection cn = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("usp_SaveUserOrder", cn);
                SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_id", UserID);
                cn.Open();
                adptr.Fill(ds);
                cn.Close();
                orderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                totalAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalAmount"]);
                #endregion
                USERPROFILEMASTER lm = USERPROFILEMASTER.GetByUser_Name("OMHRD");
                if (lm.Registration_ID > 0)
                {
                    USERPROFILEMASTER lmm = new USERPROFILEMASTER();
                    decimal PreviousAmount = lm.UserWallet;
                    decimal Amount = totalAmount;
                    decimal TotalAmount = PreviousAmount + Amount;
                    lmm.WalletRecharge(lm.Registration_ID, TotalAmount);
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Payment successful..!!!')</script>", false);
                    }
                }
                decimal MyAmount = User.UserWallet;
                decimal TranferAmount = totalAmount;
                decimal FinalAmount = MyAmount - TranferAmount;
                User.WalletRecharge(User.Registration_ID, FinalAmount);
                #region SaveUserOrderPayment
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.InsertCommand = new SqlCommand("Insert Into UserOrderPaymenttbl (Orderid, TrackingId, BankRefNo, OrderStatus,FailureMessage,PaymentMod,CardName,StatusCode,StatusMessage,ResponseCode,PaymentDate,Amount,UserId) Values (@Orderid, @TrackingId, @BankRefNo, @OrderStatus,@FailureMessage,@PaymentMod,@CardName,@StatusCode,@StatusMessage,@ResponseCode,@PaymentDate,@Amount,@UserId)", conn);
                    da.InsertCommand.Parameters.Add("@Orderid", SqlDbType.Int).Value = 0;
                    da.InsertCommand.Parameters.Add("@TrackingId", SqlDbType.Text).Value = "";
                    da.InsertCommand.Parameters.Add("@BankRefNo", SqlDbType.Text).Value = "";
                    da.InsertCommand.Parameters.Add("@OrderStatus", SqlDbType.Text).Value = "Success";

                    da.InsertCommand.Parameters.Add("@FailureMessage", SqlDbType.Text).Value = "";
                    da.InsertCommand.Parameters.Add("@PaymentMod", SqlDbType.Text).Value = "Wallet";
                    da.InsertCommand.Parameters.Add("@CardName", SqlDbType.Text).Value = "";
                    da.InsertCommand.Parameters.Add("@StatusCode", SqlDbType.Int).Value = 0;

                    da.InsertCommand.Parameters.Add("@StatusMessage", SqlDbType.Text).Value = "";
                    da.InsertCommand.Parameters.Add("@ResponseCode", SqlDbType.Int).Value = 0;
                    da.InsertCommand.Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                    da.InsertCommand.Parameters.Add("@Amount", SqlDbType.Decimal).Value = totalAmount;
                    da.InsertCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = UserID;
                    conn.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    conn.Close();
                }
                #endregion
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Some technical error...!!!')</script>", false);
            }
        }
        protected void btndeliver2_Click(object sender, EventArgs e)
        {
            try
            {
                int UserID = int.Parse(Session["loginid"].ToString());

                SqlConnection cn = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("usp_SaveUserOrder", cn);
                SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_id", UserID);
                cn.Open();
                adptr.Fill(ds);
                cn.Close();

                orderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                decimal totalAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalAmount"]);

                #region 
                string websiteUrl = "www.omhrd.com";//Request.Url.Host;
                string reqParams = string.Empty;
                reqParams += "uid=" + UserID.ToString() + "&";
                reqParams += "merchant_id=182809" + "&";
                reqParams += "order_id=" + orderNo + "&";
                reqParams += "amount=" + totalAmount + "&";
                reqParams += "currency=INR" + "&";
                reqParams += "redirect_url=" + websiteUrl + "/productsale/paymentmod/ccavResponseHandler.aspx" + "&";
                reqParams += "cancel_url=" + websiteUrl + "/productsale/paymentmod/ccavResponseHandler.aspx" + "&";
                reqParams += "billing_name=" + ViewState["ShipName"] + "&";
                reqParams += "billing_address=" + ViewState["ShipAddress"] + "&";
                reqParams += "billing_city=" + ViewState["ShipCity"] + "&";
                reqParams += "billing_state=" + ViewState["ShipState"] + "&";
                reqParams += "billing_zip=" + ViewState["ShipZip"] + "&";
                reqParams += "billing_country=" + ViewState["ShipCountry"] + "&";
                reqParams += "billing_tel=" + ViewState["Contact"] + "&";
                reqParams += "billing_email=" + ViewState["Email"] + "&";
                reqParams += "delivery_name=" + ViewState["ShipName"] + "&";
                reqParams += "delivery_address=" + ViewState["ShipAddress"] + "&";
                reqParams += "delivery_city=" + ViewState["ShipCity"] + "&";
                reqParams += "delivery_state=" + ViewState["ShipState"] + "&";
                reqParams += "delivery_zip=" + ViewState["ShipZip"] + "&";
                reqParams += "delivery_country=" + ViewState["ShipCountry"] + "&";
                reqParams += "delivery_tel=" + ViewState["Contact"] + "&";
                reqParams += "merchant_param1=" + UserID.ToString() + "&";
                reqParams += "merchant_param2=" + "2" + "&";
                reqParams += "merchant_param3=" + "3" + "&";
                reqParams += "merchant_param4=" + "4" + "&";
                reqParams += "merchant_param5=" + "" + "&";
                reqParams += "promo_code=" + "" + "&";
                reqParams += "customer_identifier=" + "cust123";
                Session["PaymentDetail"] = reqParams;
                Response.Redirect("~/productsale/paymentmod/ccavRequestHandler.aspx");
                #endregion
            }
            catch (Exception ex)
            { }
        }

        protected void lnkedit_Click(object sender, EventArgs e)
        {
            USERPROFILEMASTER um = USERPROFILEMASTERCollection.GetAll().Find(x => x.Registration_ID == int.Parse(Session["loginid"].ToString()));
            if (um.Registration_ID > 0 && um.Status == "Admin")
            {
                Response.Redirect("../Admin/AdminProfileShow.aspx");
            }
            else
            { Response.Redirect("../User/frmMyProfile.aspx"); }
        }
        protected void lnkedit2_Click(object sender, EventArgs e)
        {
            USERPROFILEMASTER um = USERPROFILEMASTERCollection.GetAll().Find(x => x.Registration_ID == int.Parse(Session["loginid"].ToString()));
            if (um.Registration_ID > 0 && um.Status == "Admin")
            {
                Response.Redirect("../Admin/AdminProfileShow.aspx");
            }
            else
            { Response.Redirect("../User/frmMyProfile.aspx"); }
        }

        protected void rdWallet_CheckedChanged(object sender, EventArgs e)
        {
            btndeliver.Visible = false;
            btndeliver2.Visible = false;
            lnkWallet2.Visible = true;
            lnkWallet.Visible = true;
        }

        protected void rdOnline_CheckedChanged(object sender, EventArgs e)
        {
            btndeliver.Visible = true;
            btndeliver2.Visible = true;
            lnkWallet2.Visible = false;
            lnkWallet.Visible = false;
        }



        protected void lnkWallet2_Click(object sender, EventArgs e)
        {
            int UserID = int.Parse(Session["loginid"].ToString());
            USERPROFILEMASTER User = USERPROFILEMASTER.GetByRegistration_ID(UserID);
            if (User.Registration_ID > 0)
            {
                decimal UserAmount = User.UserWallet;
                decimal TransferAmount = 5000;// totalAmount;
                if (UserAmount <= TransferAmount)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Insufulset amount in User account.!!!')</script>", false);
                    return;
                }
                #region
                SqlConnection cn = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("usp_SaveUserOrder", cn);
                SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_id", UserID);
                cn.Open();
                adptr.Fill(ds);
                cn.Close();
                orderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                totalAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalAmount"]);
                #endregion
                USERPROFILEMASTER lm = USERPROFILEMASTER.GetByUser_Name("OMHRD");
                if (lm.Registration_ID > 0)
                {
                    USERPROFILEMASTER lmm = new USERPROFILEMASTER();
                    decimal PreviousAmount = lm.UserWallet;
                    decimal Amount = totalAmount;
                    decimal TotalAmount = PreviousAmount + Amount;
                    lmm.WalletRecharge(lm.Registration_ID, TotalAmount);
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Payment successful..!!!')</script>", false);
                    }
                }
                decimal MyAmount = User.UserWallet;
                decimal TranferAmount = totalAmount;
                decimal FinalAmount = MyAmount - TranferAmount;
                User.WalletRecharge(User.Registration_ID, FinalAmount);
                #region SaveUserOrderPayment
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.InsertCommand = new SqlCommand("Insert Into UserOrderPaymenttbl (Orderid, TrackingId, BankRefNo, OrderStatus,FailureMessage,PaymentMod,CardName,StatusCode,StatusMessage,ResponseCode,PaymentDate,Amount,UserId) Values (@Orderid, @TrackingId, @BankRefNo, @OrderStatus,@FailureMessage,@PaymentMod,@CardName,@StatusCode,@StatusMessage,@ResponseCode,@PaymentDate,@Amount,@UserId)", conn);
                    da.InsertCommand.Parameters.Add("@Orderid", SqlDbType.Int).Value = 0;
                    da.InsertCommand.Parameters.Add("@TrackingId", SqlDbType.Text).Value = "";
                    da.InsertCommand.Parameters.Add("@BankRefNo", SqlDbType.Text).Value = "";
                    da.InsertCommand.Parameters.Add("@OrderStatus", SqlDbType.Text).Value = "Success";

                    da.InsertCommand.Parameters.Add("@FailureMessage", SqlDbType.Text).Value = "";
                    da.InsertCommand.Parameters.Add("@PaymentMod", SqlDbType.Text).Value = "Wallet";
                    da.InsertCommand.Parameters.Add("@CardName", SqlDbType.Text).Value = "";
                    da.InsertCommand.Parameters.Add("@StatusCode", SqlDbType.Int).Value = 0;

                    da.InsertCommand.Parameters.Add("@StatusMessage", SqlDbType.Text).Value = "";
                    da.InsertCommand.Parameters.Add("@ResponseCode", SqlDbType.Int).Value = 0;
                    da.InsertCommand.Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                    da.InsertCommand.Parameters.Add("@Amount", SqlDbType.Decimal).Value = totalAmount;
                    da.InsertCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = UserID;
                    conn.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    conn.Close();
                }
                #endregion
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Some technical error...!!!')</script>", false);
            }
        }
    }
}