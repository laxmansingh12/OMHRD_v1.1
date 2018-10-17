using Business.Object;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.PickUp
{
    public partial class SaleProduct : System.Web.UI.Page
    {
        int billid = 0;
        static decimal maxrate = 0; public static string OTP;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetMaxbillid();
            if (!IsPostBack)
            {
                fillCategory();
                fillUser();
                btndallbill.Visible = false;
                btnOtp.Visible = false;
                txtComfirmotp.Visible = false;
                btnWelletpay.Visible = false;
            }
        }
        public void fillCategory()
        {
            try
            {
                List<ITEM_MASTER> _state = ITEM_MASTERCollection.GetAll();
                ITEM_MASTER sm = new ITEM_MASTER();
                sm.ITEM_ID = 0;
                sm.ITEMNAME = "-select Category-";
                _state.Insert(0, sm);
                ddlItem.DataSource = _state;
                ddlItem.DataTextField = "ITEMNAME";
                ddlItem.DataValueField = "ITEM_ID";
                ddlItem.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void fillUser()
        {
            try
            {
                List<USERPROFILEMASTER> _state = USERPROFILEMASTERCollection.GetAll();
                USERPROFILEMASTER sm = new USERPROFILEMASTER();
                sm.Registration_ID = 0;
                sm.User_Name = "-select User-";
                _state.Insert(0, sm);
                ddlUser.DataSource = _state;
                ddlUser.DataTextField = "User_Name";
                ddlUser.DataValueField = "User_Name";
                ddlUser.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlItem.SelectedIndex > 0)
                {
                    if (ddlUser.SelectedIndex > 0)
                    {
                        int ItemId = int.Parse(ddlItem.SelectedValue);
                        int User = ddlUser.SelectedIndex;
                        txtItemCode.Text = ITEM_MASTER.GetByITEM_ID(ItemId).HSNCODE;
                        txtrate.Text = ITEM_MASTER.GetByITEM_IDRATE(ItemId).Price.ToString();
                        int UserState = USERPROFILEMASTER.GetByRegistration_ID(User).State;
                        int PicUpState = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).State;
                        if (UserState == PicUpState)
                        {
                            txtigst.Text = "0";
                            txtcgst.Text = ITEM_MASTER.GetByITEM_ID(ItemId).CGST.ToString();
                            txtsgst.Text = ITEM_MASTER.GetByITEM_ID(ItemId).SGST.ToString();
                        }
                        else
                        {
                            txtcgst.Text = "0";
                            txtsgst.Text = "0";
                            txtigst.Text = ITEM_MASTER.GetByITEM_ID(ItemId).IGST.ToString();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Plz Select User');</Script>", false);
                        ddlUser.Focus();
                        return;
                    }
                }
                else
                {
                    txtcgst.Text = "0";
                    txtsgst.Text = "0";
                    txtigst.Text = "0";
                }
            }
            catch (Exception ew) { }
        }
        public void grid()
        {
            gdvNotice.DataSource = ProductInvoice_MasterCollection.GetAll().FindAll(x => x.BILL_ID == billid);
            gdvNotice.DataBind();
        }
        public void GetMaxbillid()
        {
            try
            {
                billid = ProductBill_Master.MaxId() + 1;
            }
            catch (Exception ew) { }
        }
        void ClearControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Text = "";
                else if (c is RadioButton)
                    ((RadioButton)c).Checked = false;
                else if (c is Image)
                    ((Image)c).ImageUrl = null;
                ClearControls(c); btnsave.Text = "Submit";
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal maxrateigst = 0;
                decimal total = 0;
                ProductInvoice_Master ln = new ProductInvoice_Master();
                total = decimal.Parse(numqty.Text) * decimal.Parse(txtrate.Text.Trim());
                if (btnsave.Text == "Submit")
                {
                    if (string.IsNullOrEmpty(numqty.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Plz Enter Quantity..');</Script>", false);
                        numqty.Focus();
                        return;
                    }
                    else
                    {
                        decimal qt = decimal.Parse(numqty.Text.Trim());
                        if (qt <= 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Quantity must be greater than zero..');</Script>", false);
                            numqty.Focus();
                            return;
                        }
                    }
                    ln.INVOICE_ID = ProductInvoice_Master.MaxId() + 1;
                    ln.ITEM_ID = int.Parse(ddlItem.SelectedValue);
                    ln.ITEMNAME = ITEM_MASTER.GetByITEM_ID(ln.ITEM_ID).ITEMNAME;
                    ln.HSNCODE = ITEM_MASTER.GetByITEM_ID(ln.ITEM_ID).HSNCODE;
                    ln.QUANTITY = decimal.Parse(numqty.Text);
                    ln.RATE_PER = decimal.Parse(txtrate.Text.Trim());
                    ln.TOTAL = total;
                    decimal cgst = decimal.Parse(txtcgst.Text.Trim());
                    decimal sgst = decimal.Parse(txtsgst.Text.Trim());
                    decimal igst = decimal.Parse(txtigst.Text.Trim());
                    if (cgst > maxrate)
                        maxrate = cgst;
                    if (sgst > maxrate)
                        maxrate = sgst;
                    if (igst > maxrate)
                        maxrate = igst;
                    maxrateigst = maxrate;
                    ln.CGST_AMT = (total * cgst) / 100;
                    ln.SGST_AMT = (total * sgst) / 100;
                    ln.IGST_AMT = (total * igst) / 100;
                    ln.CGST_RATE = cgst;
                    ln.SGST_RATE = sgst;
                    ln.IGST_RATE = igst;
                    ln.BILL_ID = billid;
                    ln.REMARKS = "";
                    ln.INVOICE_DATE = System.DateTime.Today;
                    ln.Bil_Stutas = "Waiting";
                    ln.Save();
                }
                else if (btnsave.Text == "Update")
                {
                    ln = ProductInvoice_Master.GetByINVOICE_ID(int.Parse(ViewState["id"].ToString()));
                    ln.INVOICE_ID = int.Parse(ViewState["id"].ToString());
                    ln.ITEM_ID = int.Parse(ddlItem.SelectedValue);
                    ln.ITEMNAME = ITEM_MASTER.GetByITEM_ID(ln.ITEM_ID).ITEMNAME;
                    ln.HSNCODE = ITEM_MASTER.GetByITEM_ID(ln.ITEM_ID).HSNCODE;
                    ln.QUANTITY = decimal.Parse(numqty.Text);
                    ln.RATE_PER = decimal.Parse(txtrate.Text.Trim());
                    ln.TOTAL = total;
                    decimal cgst = decimal.Parse(txtcgst.Text.Trim());
                    decimal sgst = decimal.Parse(txtsgst.Text.Trim());
                    decimal igst = decimal.Parse(txtigst.Text.Trim());
                    if (cgst > maxrate)
                        maxrate = cgst;
                    if (sgst > maxrate)
                        maxrate = sgst;
                    if (igst > maxrate)
                        maxrate = igst;
                    maxrateigst = maxrate;
                    ln.CGST_AMT = (total * cgst) / 100;
                    ln.SGST_AMT = (total * sgst) / 100;
                    ln.IGST_AMT = (total * igst) / 100;
                    ln.CGST_RATE = cgst;
                    ln.SGST_RATE = sgst;
                    ln.IGST_RATE = igst;
                    ln.BILL_ID = billid;
                    ln.REMARKS = "";
                    ln.INVOICE_DATE = System.DateTime.Today;
                    ln.Bil_Stutas = "Waiting";
                    ln.Save();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully...');</Script>", false);
                }
                grid();
                ddlItem.SelectedIndex = 0;
                ClearControls(this);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert(error);</script>", false);
            }
        }

        protected void linkbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)lb.NamingContainer;
            ViewState["id"] = ((Label)gr.FindControl("labelNOTICE_ID")).Text;
            string nid = ViewState["id"].ToString();
            ProductInvoice_Master dm = ProductInvoice_Master.GetByINVOICE_ID(int.Parse(nid));
            ddlItem.SelectedValue = dm.ITEM_ID.ToString();
            txtItemCode.Text = ITEM_MASTER.GetByITEM_ID(ddlItem.SelectedIndex).CODE;
            txtcgst.Text = dm.CGST_RATE.ToString();
            txtsgst.Text = dm.SGST_RATE.ToString();
            txtigst.Text = dm.IGST_RATE.ToString();
            numqty.Text = dm.QUANTITY.ToString();
            txtrate.Text = dm.RATE_PER.ToString();
            btnsave.Text = "Update";
        }

        protected void linkbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                ViewState["id"] = ((Label)gv.FindControl("labelNOTICE_ID")).Text;
                string did = ViewState["id"].ToString();
                ProductInvoice_Master dm = new ProductInvoice_Master();
                dm.INVOICE_ID = int.Parse(did);
                dm.Delete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("frmSale.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }
        public string Rupees(Int64 rup)
        {
            string result = "";
            Int64 res;
            if ((rup / 10000000) > 0)
            {
                res = rup / 10000000;
                rup = rup % 10000000;
                result = result + ' ' + RupeesToWords(res) + " Crore";
            }
            if ((rup / 100000) > 0)
            {
                res = rup / 100000;
                rup = rup % 100000;
                result = result + ' ' + RupeesToWords(res) + " Lakh";
            }
            if ((rup / 1000) > 0)
            {
                res = rup / 1000;
                rup = rup % 1000;
                result = result + ' ' + RupeesToWords(res) + " Thousand";
            }
            if ((rup / 100) > 0)
            {
                res = rup / 100;
                rup = rup % 100;
                result = result + ' ' + RupeesToWords(res) + " Hundred";
            }
            if ((rup % 10) >= 0)
            {
                res = rup % 100;
                result = result + " " + RupeesToWords(res);
            }
            result = result + ' ';// +" Rupees only";
            return result;
        }
        public string RupeesToWords(Int64 rup)
        {
            string result = "";
            if ((rup >= 1) && (rup <= 10))
            {
                if ((rup % 10) == 1) result = "One";
                if ((rup % 10) == 2) result = "Two";
                if ((rup % 10) == 3) result = "Three";
                if ((rup % 10) == 4) result = "Four";
                if ((rup % 10) == 5) result = "Five";
                if ((rup % 10) == 6) result = "Six";
                if ((rup % 10) == 7) result = "Seven";
                if ((rup % 10) == 8) result = "Eight";
                if ((rup % 10) == 9) result = "Nine";
                if ((rup % 10) == 0) result = "Ten";
            }
            if (rup > 9 && rup < 20)
            {
                if (rup == 11) result = "Eleven";
                if (rup == 12) result = "Twelve";
                if (rup == 13) result = "Thirteen";
                if (rup == 14) result = "Forteen";
                if (rup == 15) result = "Fifteen";
                if (rup == 16) result = "Sixteen";
                if (rup == 17) result = "Seventeen";
                if (rup == 18) result = "Eighteen";
                if (rup == 19) result = "Nineteen";
            }
            if (rup >= 20 && (rup / 10) == 2 && (rup % 10) == 0) result = "Twenty";
            if (rup > 20 && (rup / 10) == 3 && (rup % 10) == 0) result = "Thirty";
            if (rup > 20 && (rup / 10) == 4 && (rup % 10) == 0) result = "Forty";
            if (rup > 20 && (rup / 10) == 5 && (rup % 10) == 0) result = "Fifty";
            if (rup > 20 && (rup / 10) == 6 && (rup % 10) == 0) result = "Sixty";
            if (rup > 20 && (rup / 10) == 7 && (rup % 10) == 0) result = "Seventy";
            if (rup > 20 && (rup / 10) == 8 && (rup % 10) == 0) result = "Eighty";
            if (rup > 20 && (rup / 10) == 9 && (rup % 10) == 0) result = "Ninty";

            if (rup > 20 && (rup / 10) == 2 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Twenty One";
                if ((rup % 10) == 2) result = "Twenty Two";
                if ((rup % 10) == 3) result = "Twenty Three";
                if ((rup % 10) == 4) result = "Twenty Four";
                if ((rup % 10) == 5) result = "Twenty Five";
                if ((rup % 10) == 6) result = "Twenty Six";
                if ((rup % 10) == 7) result = "Twenty Seven";
                if ((rup % 10) == 8) result = "Twenty Eight";
                if ((rup % 10) == 9) result = "Twenty Nine";
            }
            if (rup > 20 && (rup / 10) == 3 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Thirty One";
                if ((rup % 10) == 2) result = "Thirty Two";
                if ((rup % 10) == 3) result = "Thirty Three";
                if ((rup % 10) == 4) result = "Thirty Four";
                if ((rup % 10) == 5) result = "Thirty Five";
                if ((rup % 10) == 6) result = "Thirty Six";
                if ((rup % 10) == 7) result = "Thirty Seven";
                if ((rup % 10) == 8) result = "Thirty Eight";
                if ((rup % 10) == 9) result = "Thirty Nine";
            }
            if (rup > 20 && (rup / 10) == 4 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Forty One";
                if ((rup % 10) == 2) result = "Forty Two";
                if ((rup % 10) == 3) result = "Forty Three";
                if ((rup % 10) == 4) result = "Forty Four";
                if ((rup % 10) == 5) result = "Forty Five";
                if ((rup % 10) == 6) result = "Forty Six";
                if ((rup % 10) == 7) result = "Forty Seven";
                if ((rup % 10) == 8) result = "Forty Eight";
                if ((rup % 10) == 9) result = "Forty Nine";
            }
            if (rup > 20 && (rup / 10) == 5 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Fifty One";
                if ((rup % 10) == 2) result = "Fifty Two";
                if ((rup % 10) == 3) result = "Fifty Three";
                if ((rup % 10) == 4) result = "Fifty Four";
                if ((rup % 10) == 5) result = "Fifty Five";
                if ((rup % 10) == 6) result = "Fifty Six";
                if ((rup % 10) == 7) result = "Fifty Seven";
                if ((rup % 10) == 8) result = "Fifty Eight";
                if ((rup % 10) == 9) result = "Fifty Nine";
            }
            if (rup > 20 && (rup / 10) == 6 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Sixty One";
                if ((rup % 10) == 2) result = "Sixty Two";
                if ((rup % 10) == 3) result = "Sixty Three";
                if ((rup % 10) == 4) result = "Sixty Four";
                if ((rup % 10) == 5) result = "Sixty Five";
                if ((rup % 10) == 6) result = "Sixty Six";
                if ((rup % 10) == 7) result = "Sixty Seven";
                if ((rup % 10) == 8) result = "Sixty Eight";
                if ((rup % 10) == 9) result = "Sixty Nine";
            }
            if (rup > 20 && (rup / 10) == 7 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Seventy One";
                if ((rup % 10) == 2) result = "Seventy Two";
                if ((rup % 10) == 3) result = "Seventy Three";
                if ((rup % 10) == 4) result = "Seventy Four";
                if ((rup % 10) == 5) result = "Seventy Five";
                if ((rup % 10) == 6) result = "Seventy Six";
                if ((rup % 10) == 7) result = "Seventy Seven";
                if ((rup % 10) == 8) result = "Seventy Eight";
                if ((rup % 10) == 9) result = "Seventy Nine";
            }
            if (rup > 20 && (rup / 10) == 8 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Eighty One";
                if ((rup % 10) == 2) result = "Eighty Two";
                if ((rup % 10) == 3) result = "Eighty Three";
                if ((rup % 10) == 4) result = "Eighty Four";
                if ((rup % 10) == 5) result = "Eighty Five";
                if ((rup % 10) == 6) result = "Eighty Six";
                if ((rup % 10) == 7) result = "Eighty Seven";
                if ((rup % 10) == 8) result = "Eighty Eight";
                if ((rup % 10) == 9) result = "Eighty Nine";
            }
            if (rup > 20 && (rup / 10) == 9 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Ninty One";
                if ((rup % 10) == 2) result = "Ninty Two";
                if ((rup % 10) == 3) result = "Ninty Three";
                if ((rup % 10) == 4) result = "Ninty Four";
                if ((rup % 10) == 5) result = "Ninty Five";
                if ((rup % 10) == 6) result = "Ninty Six";
                if ((rup % 10) == 7) result = "Ninty Seven";
                if ((rup % 10) == 8) result = "Ninty Eight";
                if ((rup % 10) == 9) result = "Ninty Nine";
            }
            return result;
        }
        public void PrintBill()
        {
            try
            {
                int UserId = ddlUser.SelectedIndex;
                List<ProductInvoice_Master> _Pro = ProductInvoice_MasterCollection.GetAll().FindAll(x => x.BILL_ID == billid);
                #region Company
                string CompanyName = USERPROFILEMASTER.GetByRegistration_ID(1).First_Name;
                string CompanyAddress = USERPROFILEMASTER.GetByRegistration_ID(1).Address;
                string CompanyState = USERPROFILEMASTER.GetByRegistration_ID(1).StateName;
                string CompanyCity = USERPROFILEMASTER.GetByRegistration_ID(1).CityName;
                string ZipCode = USERPROFILEMASTER.GetByRegistration_ID(1).ZipCode;
                string CompanyGST = USERPROFILEMASTER.GetByRegistration_ID(1).GstinVerified;
                string CompanyContact = USERPROFILEMASTER.GetByRegistration_ID(1).ContactNumber;
                #endregion
                #region Seller
                string ShipName = USERPROFILEMASTER.GetByRegistration_ID(UserId).First_Name + " " + USERPROFILEMASTER.GetByRegistration_ID(UserId).Last_Name;
                string ShipAdd1 = USERPROFILEMASTER.GetByRegistration_ID(UserId).Address;
                string ShipAdd2 = USERPROFILEMASTER.GetByRegistration_ID(UserId).AddressLine2;
                string ShipState = USERPROFILEMASTER.GetByRegistration_ID(UserId).StateName;
                string ShipCity = USERPROFILEMASTER.GetByRegistration_ID(UserId).CityName;
                string ShipZip = USERPROFILEMASTER.GetByRegistration_ID(UserId).ZipCode;
                string Contry = USERPROFILEMASTER.GetByRegistration_ID(UserId).COUNTRY;

                string BillName = USERPROFILEMASTER.GetByRegistration_ID(UserId).First_Name + " " + USERPROFILEMASTER.GetByRegistration_ID(UserId).Last_Name;
                string PermanentAdd1 = USERPROFILEMASTER.GetByRegistration_ID(UserId).ShippingAddress;
                string PermanentAdd2 = USERPROFILEMASTER.GetByRegistration_ID(UserId).ShippingAddressLine2;
                string PermanentState = USERPROFILEMASTER.GetByRegistration_ID(UserId).ShippStateName;
                string PermanentCity = USERPROFILEMASTER.GetByRegistration_ID(UserId).ShipCityName;
                string PermanentZip = USERPROFILEMASTER.GetByRegistration_ID(UserId).ShippingZip;
                string Gstin = USERPROFILEMASTER.GetByRegistration_ID(UserId).GstinVerified;
                #endregion
                #region BillDetail
                System.Guid guid = System.Guid.NewGuid();
                String id = guid.ToString();
                string OrderId = id;
                DateTime dt = System.DateTime.Today;
                string InvoiNo = ProductBill_Master.GetByBILL_ID(billid).BILLNO;
                string InvoiDate = dt.ToString();
                string Phone = USERPROFILEMASTER.GetByRegistration_ID(UserId).ContactNumber;
                string Email = USERPROFILEMASTER.GetByRegistration_ID(UserId).Email;
                #endregion
                decimal totamt = Math.Round(ProductBill_Master.GetByBILL_ID(billid).TOTAL, 0);
                var values = totamt.ToString(CultureInfo.InvariantCulture).Split('.');
                Int64 rup = Convert.ToInt64(values[0]);
                Int64 paise = 0;
                if (values.Length == 2)
                    paise = Convert.ToInt64(values[1]);
                string rupee = string.Empty;
                string pa = string.Empty;
                if (paise != 0)
                {
                    pa = Rupees(paise) + "Paise Only";
                    rupee = Rupees(rup) + "Rupees and " + pa;
                }
                else
                {
                    rupee = Rupees(rup) + "Rupees Only";
                }
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                this.ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("/Report/PickUpSale.rdlc");
                ReportDataSource datasource = new ReportDataSource("BillGenrate", _Pro);
                ReportParameter[] rpt = new ReportParameter[28];
                rpt[0] = new ReportParameter("CompanyName", CompanyName);
                rpt[1] = new ReportParameter("CompanyAddress", CompanyAddress);
                rpt[2] = new ReportParameter("CompanyState", CompanyState);
                rpt[3] = new ReportParameter("CompanyCity", CompanyCity);
                rpt[4] = new ReportParameter("ZipCode", ZipCode);
                rpt[5] = new ReportParameter("CompanyGST", CompanyGST);
                rpt[6] = new ReportParameter("CompanyContact", CompanyContact);
                rpt[7] = new ReportParameter("ShipName", ShipName);
                rpt[8] = new ReportParameter("ShipAdd1", ShipAdd1);
                rpt[9] = new ReportParameter("ShipAdd2", ShipAdd2);
                rpt[10] = new ReportParameter("ShipCity", ShipCity);
                rpt[11] = new ReportParameter("ShipState", ShipState);
                rpt[12] = new ReportParameter("ShipZip", ShipZip);
                rpt[13] = new ReportParameter("Contry", Contry);
                rpt[14] = new ReportParameter("BillName", BillName);
                rpt[15] = new ReportParameter("PermanentAdd1", PermanentAdd1);
                rpt[16] = new ReportParameter("PermanentAdd2", PermanentAdd2);
                rpt[17] = new ReportParameter("PermanentCity", PermanentCity);
                rpt[18] = new ReportParameter("PermanentState", PermanentState);
                rpt[19] = new ReportParameter("PermanentZip", PermanentZip);
                rpt[20] = new ReportParameter("Gstin", Gstin);
                rpt[21] = new ReportParameter("OrderId", OrderId);
                rpt[22] = new ReportParameter("InvoiNo", InvoiNo);
                rpt[23] = new ReportParameter("InvoiDate", InvoiDate);
                rpt[24] = new ReportParameter("Phone", Phone);
                rpt[25] = new ReportParameter("Email", Email);
                rpt[26] = new ReportParameter("TotalAmountWord", rupee);
                rpt[27] = new ReportParameter("PaymentMod", "Wallet");
                this.ReportViewer1.LocalReport.SetParameters(rpt);
                this.ReportViewer1.LocalReport.DataSources.Clear();
                this.ReportViewer1.LocalReport.DataSources.Add(datasource);
                this.ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            { }
        }
        List<Bill> _bill = new List<Bill>();

        public void MakePayment()
        {
            grid();
            decimal totalamt = 0;
            foreach (GridViewRow gv in gdvNotice.Rows)
            {
                totalamt += decimal.Parse(gv.Cells[4].Text.ToString());
            }
            #region
            //string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            //using (SqlConnection conn = new SqlConnection(constr))
            //{
            //    SqlDataAdapter da = new SqlDataAdapter();
            //    da.InsertCommand = new SqlCommand("Insert Into UserOrderPaymenttbl (Orderid, TrackingId, BankRefNo, OrderStatus,FailureMessage,PaymentMod,CardName,StatusCode,StatusMessage,ResponseCode,PaymentDate,Amount,UserId) Values (@Orderid, @TrackingId, @BankRefNo, @OrderStatus,@FailureMessage,@PaymentMod,@CardName,@StatusCode,@StatusMessage,@ResponseCode,@PaymentDate,@Amount,@UserId)", conn);
            //    da.InsertCommand.Parameters.Add("@Orderid", SqlDbType.Int).Value = 0;
            //    da.InsertCommand.Parameters.Add("@TrackingId", SqlDbType.Text).Value = "";
            //    da.InsertCommand.Parameters.Add("@BankRefNo", SqlDbType.Text).Value = "";
            //    da.InsertCommand.Parameters.Add("@OrderStatus", SqlDbType.Text).Value = "PickUp";

            //    da.InsertCommand.Parameters.Add("@FailureMessage", SqlDbType.Text).Value = "";
            //    da.InsertCommand.Parameters.Add("@PaymentMod", SqlDbType.Text).Value = "Wallet";
            //    da.InsertCommand.Parameters.Add("@CardName", SqlDbType.Text).Value = "";
            //    da.InsertCommand.Parameters.Add("@StatusCode", SqlDbType.Int).Value = 0;

            //    da.InsertCommand.Parameters.Add("@StatusMessage", SqlDbType.Text).Value = "";
            //    da.InsertCommand.Parameters.Add("@ResponseCode", SqlDbType.Int).Value = 0;
            //    da.InsertCommand.Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = System.DateTime.Now;
            //    da.InsertCommand.Parameters.Add("@Amount", SqlDbType.Decimal).Value = totalamt;
            //    da.InsertCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = ddlUser.SelectedIndex;
            //    conn.Open();

            //    da.InsertCommand.ExecuteNonQuery();

            //    conn.Close();
            //}
            #endregion
            ProductBill_Master bm = new ProductBill_Master();
            bm.BILL_ID = ProductBill_Master.MaxId() + 1;
            bm.BILLNO = "OMHRD" + Session["PickupID"] + "000" + bm.BILL_ID.ToString();
            bm.TOTAL = Math.Round(totalamt, 0);
            bm.STATUS = "Wallet";
            bm.BILLDATE = DateTime.Today.Date;
            bm.RECEIVER_ID = ddlUser.SelectedIndex;
            bm.REMARKS = null;
            bm.LOGIN_ID = int.Parse(Session["PickupID"].ToString());
            bm.Bil_Stutas = "Paid";
            bm.Extra_Payment = 0;
            bm.NO_OF_BOXES = "";
            bm.Save();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Save Successfully...');</Script>", false);
            PrintBill();
        }
        protected void btndallbill_Click(object sender, EventArgs e)
        {
            MakePayment();
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
        protected void btnOtp_Click(object sender, EventArgs e)
        {
            string numbers = "1234567890";
            string characters = numbers;
            if (numbers == "1")
            {
                characters += numbers;
            }
            int length = int.Parse("5");
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            ViewState["GenerateOTP"] = otp;
            OTP = ViewState["GenerateOTP"].ToString();
            int UserId = ddlUser.SelectedIndex;
            string Contact = USERPROFILEMASTER.GetByRegistration_ID(UserId).ContactNumber;
            Sendmsg("Your OTP is " + " " + OTP, Contact);
            txtComfirmotp.Visible = true;
            btnWelletpay.Visible = true;
        }

        protected void rdCash_CheckedChanged(object sender, EventArgs e)
        {
            btndallbill.Visible = true;
            btnOtp.Visible = false;
            txtComfirmotp.Visible = false;
        }

        protected void rdWalllet_CheckedChanged(object sender, EventArgs e)
        {
            btndallbill.Visible = false;
            btnOtp.Visible = true;
            txtComfirmotp.Visible = false;
        }
        public void Tranfer()
        {
            try
            {
                decimal totalamt = 0;
                int UserId = ddlUser.SelectedIndex;
                USERPROFILEMASTER User = USERPROFILEMASTER.GetByRegistration_ID(UserId);
                if (User.Registration_ID > 0)
                {
                    foreach (GridViewRow gv in gdvNotice.Rows)
                    {
                        totalamt += decimal.Parse(gv.Cells[4].Text.ToString());
                    }
                    decimal UserAmount = User.UserWallet;
                    decimal TransferAmount = totalamt;
                    if (UserAmount <= TransferAmount)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Insufulset amount in User account.!!!')</script>", false);
                        return;
                    }

                    PickupMaster lm = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString()));
                    if (lm.PickupID > 0)
                    {
                        PickupMaster lmm = new PickupMaster();
                        decimal PreviousAmount = lm.PickUpWallet;
                        decimal Amount = totalamt;
                        decimal TotalAmount = PreviousAmount + Amount;
                        lmm.PaymentByWallet(lm.PickupID, TotalAmount);
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Payment successful..!!!')</script>", false);
                        }
                    }
                    decimal MyAmount = User.UserWallet;
                    decimal TranferAmount = totalamt;
                    decimal FinalAmount = MyAmount - TranferAmount;
                    User.WalletRecharge(User.Registration_ID, FinalAmount);
                    MakePayment();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Old Password is not Correct...!!!')</script>", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + ex.Message + "')</script>", false);
            }
        }
        protected void btnWelletpay_Click(object sender, EventArgs e)
        {
            string Comfirmotp = txtComfirmotp.Text.Trim();
            if (OTP == Comfirmotp)
            {
                Tranfer();
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('OTP not matched !!...');</Script>", false);
                return;
            }
        }
    }
}