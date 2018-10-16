using Business.Object;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD
{
    /// <summary>
    /// Summary description for Webservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Webservice : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool CheckUserName(string username)
        {
            bool status = false;
            string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CheckUserAvailability", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", username.Trim());
                    conn.Open();
                    status = Convert.ToBoolean(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            return status;
        }
        void ClearControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Text = "";
                else if (c is RadioButton)
                    ((RadioButton)c).Checked = false;
                else if (c is DropDownList)
                    ((DropDownList)c).SelectedIndex = 0;
                else if (c is Image)
                    ((Image)c).ImageUrl = null;
                ClearControls(c);
            }
        }
        public class SaveUserClass
        {
            public string Fname { set; get; }
            public string Lname { set; get; }
            public string Email { set; get; }
            public string UserName { set; get; }
            public string Password { set; get; }
            public string ContactNo { set; get; }
            public string RefId { set; get; }
        }
        [WebMethod]
        public string SaveUser(SaveUserClass user)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    USERPROFILEMASTER rm = new USERPROFILEMASTER();
                    rm.Registration_ID = USERPROFILEMASTER.MaxId() + 1;
                    rm.First_Name = user.Fname;
                    rm.Last_Name = user.Lname;
                    rm.Email = user.Email;
                    rm.User_Name = user.UserName;
                    rm.User_ID = "OM000000" + rm.Registration_ID;
                    rm.Password = user.Password;
                    rm.DOB = DateTime.Today;
                    rm.ContactNumber = user.ContactNo;
                    rm.NomineeName = "";
                    rm.NomineeId = "";
                    rm.NomineeRelation = "";
                    USERPROFILEMASTER um1 = USERPROFILEMASTER.GetByUser_Name(user.RefId);
                    if (string.IsNullOrWhiteSpace(um1.Reference_Id))
                        return "Reference Id is not available";
                    rm.Reference_Id = user.RefId;
                    rm.RegDate = DateTime.Today.Date;
                    rm.COUNTRY = "India";
                    rm.Individual_Company = ""; rm.IdentificationType = ""; rm.TaxExempt = ""; rm.Commission = ""; rm.WFile = "";
                    rm.AnniversaryDate = DateTime.Today; rm.SmartDeliveryDate = DateTime.Today;
                    rm.Website = ""; rm.Address = ""; rm.AddressLine2 = ""; rm.City = 1; rm.State = 1; rm.StateOther = "";
                    rm.ZipCode = ""; rm.ShippingFirstName = ""; rm.ShippingLastName = ""; rm.ShippingAddress = "";
                    rm.ShippingAddressLine2 = ""; rm.ShippingCity = 1; rm.ShippingState = 1; rm.ShippingZip = ""; rm.ShippingStateOther = "";
                    rm.AlternativeNumber = ""; rm.Fax = ""; rm.Co_Applicant = ""; rm.Language = ""; rm.Skype = ""; rm.Twitter = ""; rm.Facebook = ""; rm.AadharVerified = "";
                    rm.AadharImage = ""; rm.PanVerified = ""; rm.PanImage = ""; rm.ChequeVerified = ""; rm.ChequeImage = ""; rm.GstinVerified = "";
                    rm.AddressVerified = ""; rm.AddressImage = ""; rm.Image_Name = ""; rm.Status = "Active"; rm.BankName = ""; rm.AccountNo = "";
                    rm.IFSCCode = ""; rm.Branch = ""; rm.UserParentId = 0;
                    rm.Save();
                    // Sendmsg("Welcome to OMHRD " + " ", user.ContactNo.Trim());
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Username is not available";
            }
        }
        [WebMethod]
        public bool CheckReference(string Reference_Id)
        {
            bool status = false;
            string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CheckReference", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Reference_Id", Reference_Id.Trim());
                    conn.Open();
                    status = Convert.ToBoolean(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            return status;
        }
        [WebMethod]
        public List<object> GetChartData(int userId)
        {
            string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            List<object> chartData = new List<object>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.GetChildren"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@IncludeFullUser", 1);
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    da.Fill(ds);
                    con.Close();
                }
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        chartData.Add(new object[]
                           { dr["Registration_ID"], dr["User_Name"], dr["UserParentId"] });
                    }
                }
                return chartData;
            }
        }
        public class ShopingInvoice
        {
            public int Item { set; get; }
            public decimal Qty { set; get; }
            public decimal Rate { set; get; }
            public decimal Total { set; get; }
            public decimal Discount { set; get; }
            public decimal Taxvalue { set; get; }
            public int BillId { set; get; }
            public int Category { set; get; }
            public int Size { set; get; }
            public int Color { set; get; }
            public string status { set; get; }
            public DateTime Date { set; get; }
        }
        [WebMethod]
        public string SaveShopingInvoic(ShopingInvoice Invoice)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    ShoppingInvoiceMaster rm = new ShoppingInvoiceMaster();
                    rm.INVOICE_ID = ShoppingInvoiceMaster.MaxId() + 1;
                    rm.ITEM_ID = Invoice.Item;
                    rm.QUANTITY = Invoice.Qty;
                    rm.RATE_PER = Invoice.Rate;
                    rm.TOTAL = Invoice.Total;
                    rm.DISCOUNT = Invoice.Discount;
                    rm.TEXABLEVALUE = Invoice.Taxvalue;
                    rm.BILL_ID = Invoice.BillId;
                    rm.CATEGORY_ID = Invoice.Category;
                    rm.Color_ID = Invoice.Color;
                    rm.Size_ID = Invoice.Size;
                    rm.Bil_Stutas = Invoice.status;
                    rm.INVOICE_DATE = DateTime.Today;
                    rm.Save();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Error..!! some technical issue";
            }
        }
        public class SavePicupDetail
        {
            public string FName { set; get; }
            public string LName { set; get; }
            public string UserName { set; get; }
            public int City { set; get; }
            public int State { set; get; }
            public string Address { set; get; }
            public string Pincode { set; get; }
            public string ContactNo { set; get; }
            public string Alternate1 { set; get; }
            public string Alternate2 { set; get; }
            public string GstinNo { set; get; }
            public DateTime RegDate { set; get; }
        }
        [WebMethod]
        public string SavePicup(SavePicupDetail Pick)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    PickupMaster rm = new PickupMaster();
                    rm.PickupID = PickupMaster.GetMaxID() + 1;
                    rm.FirstName = Pick.FName;
                    rm.LastName = Pick.LName;
                    rm.State = Pick.State;
                    rm.City = Pick.City;
                    rm.Address = Pick.Address;
                    rm.Pincode = Pick.Pincode;
                    rm.City = Pick.City;
                    rm.State = Pick.State;
                    rm.ContactNo = Pick.ContactNo;
                    rm.Alternate1 = Pick.Alternate1;
                    rm.Alternate2 = Pick.Alternate2;
                    rm.GstinNo = Pick.GstinNo;
                    rm.Regdate = DateTime.Today;
                    rm.Status = "Waiting";
                    rm.Action = "Active";
                    rm.Save();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Error..!! some technical issue";
            }
        }
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public string addtocart(int productId, int userId, int quantity, string unitcode, string Color)
        {
            bool status = false;
            string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AddtoCart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Qty", quantity);
                    cmd.Parameters.AddWithValue("@Unitcode", unitcode);
                    cmd.Parameters.AddWithValue("@Color_Code", Color);
                    conn.Open();
                    status = Convert.ToBoolean(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            return string.Empty;
        }

        public class SendPasswordEmail
        {
            public string ContactNumber { set; get; }
            public string User_Name { set; get; }
            public string Password { set; get; }
            public string Email { set; get; }

        }
        public string Sendmsg(string msg, string mobno)
        {
            string UserName = "socialhub";
            string Password = "well03come";
            string senderid = "OMHRDA";
            string http = "https://www.auruminfo.com/Rest/AIwebservice/Bulk?";
            string parameters = "user=" + UserName + "&password=" + Password + "&mobilenumber=" + mobno + "&message=" + msg + "&sid=" + senderid + "&mtype=n";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(http + parameters);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(response.GetResponseStream());
            respStreamReader.Close();
            return respStreamReader.ToString();
        }
        [WebMethod]
        public string SendEmail(SendPasswordEmail Email)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    USERPROFILEMASTER um = USERPROFILEMASTERCollection.GetAll().Find(x => x.ContactNumber == Email.ContactNumber && x.User_Name == Email.User_Name.Trim());
                    if (um == null)
                    {

                    }
                    else
                    {
                        Email.Password = um.Password;
                        Sendmsg("Your Password is " + " " + Email.Password, Email.ContactNumber.Trim());
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Error..!! some technical issue";
            }
        }
    }
}
