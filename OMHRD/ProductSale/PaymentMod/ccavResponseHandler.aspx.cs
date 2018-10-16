using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;
using CCA.Util;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class ResponseHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string workingKey = "7D433FB0149712F58126D2E2CB59CC9C";//put in the 32bit alpha numeric key in the quotes provided here
        CCACrypto ccaCrypto = new CCACrypto();
        string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
        NameValueCollection Params = new NameValueCollection();
        string[] segments = encResponse.Split('&');
        foreach (string seg in segments)
        {
            string[] parts = seg.Split('=');
            if (parts.Length > 0)
            {
                string Key = parts[0].Trim();
                string Value = parts[1].Trim();
                Params.Add(Key, Value);
            }
        }


        string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        SqlConnection cn = new SqlConnection(constr);
        cn.Open();
        var ordID = Params["order_id"].ToString();
        var trkID = Params["tracking_id"].ToString();
        var bakRefno = Params["bank_ref_no"].ToString();
        var ordstus = Params["order_status"].ToString();
        var failmsg = Params["failure_message"].ToString();
        var Pmod = Params["payment_mode"].ToString();
        var Cname = Params["card_name"].ToString();
        var stusCode = Params["status_code"].ToString();
        var stsMsg = Params["status_message"].ToString();
        var ResCode = Params["response_code"].ToString();
        var Amount = Params["amount"].ToString();
        var UserID = Params["merchant_param1"].ToString();


        SqlCommand cmd = new SqlCommand("insert into UserOrderPaymenttbl(Orderid,TrackingId ,BankRefNo,OrderStatus,FailureMessage,PaymentMod,CardName,StatusCode,StatusMessage,ResponseCode,PaymentDate,Amount,UserId) values (@Orderid,@TrackingId ,@BankRefNo,@OrderStatus,@FailureMessage,@PaymentMod,@CardName,@StatusCode,@StatusMessage,@ResponseCode,@PaymentDate,@Amount,@UserId)", cn);
        cmd.Parameters.AddWithValue("@Orderid", ordID);
        cmd.Parameters.AddWithValue("@TrackingId", trkID);
        cmd.Parameters.AddWithValue("@BankRefNo", bakRefno);
        cmd.Parameters.AddWithValue("@OrderStatus", ordstus);
        cmd.Parameters.AddWithValue("@FailureMessage", failmsg);
        cmd.Parameters.AddWithValue("@PaymentMod", Pmod);
        cmd.Parameters.AddWithValue("@CardName", Cname);
        cmd.Parameters.AddWithValue("@StatusCode", stusCode);
        cmd.Parameters.AddWithValue("@StatusMessage", stsMsg);
        cmd.Parameters.AddWithValue("@ResponseCode", ResCode);
        cmd.Parameters.AddWithValue("@PaymentDate", System.DateTime.Now);
        cmd.Parameters.AddWithValue("@Amount", Amount);
        cmd.Parameters.AddWithValue("@UserId", UserID);
        cn.Open();
        cn.Close();
    }
}

