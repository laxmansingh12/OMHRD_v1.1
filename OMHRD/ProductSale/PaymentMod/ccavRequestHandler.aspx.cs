using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCA.Util;


public partial class SubmitData : System.Web.UI.Page
{
    CCACrypto ccaCrypto = new CCACrypto();
    string workingKey = "7D433FB0149712F58126D2E2CB59CC9C";//put in the 32bit alpha numeric key in the quotes provided here 	
                                                           // string workingKey = "7D433FB0149712F58126D2E2CB59CC9C";//put in the 32bit alpha numeric key in the quotes provided here 	
    string ccaRequest = "";
    public string strEncRequest = "";
    public string strAccessCode = "AVQV79FG04AN86VQNA";
    // public string strAccessCode = "AVQV79FG04AN86VQNA";// put the access key in the quotes provided here.
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //foreach (string name in Request.Form)
            // {
            //     if (name != null)
            //     {
            //         if (!name.StartsWith("_"))
            //         {
            //             ccaRequest = ccaRequest + name + "=" + Request.Form[name] + "&";
            //           /* Response.Write(name + "=" + Request.Form[name]);
            //             Response.Write("</br>");*/
            //         }
            //     }
            // }
            ccaRequest = Session["PaymentDetail"] as string;

            strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);
        }
    }
}

