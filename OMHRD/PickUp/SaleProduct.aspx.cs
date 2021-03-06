﻿using Business.Object;
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
        static decimal maxrate = 0;
        public static string OTP;
        static string PaymentMod;

        DataView dvUnitPrice { get { return Session["dvUnitPrice"] as DataView; } }
        string _selectedColorCode { get { return Session["_selectedColorCode"] as string; } }
        string _selectedSizeCode { get { return Session["_selectedSizeCode"] as string; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetMaxbillid();
            if (!IsPostBack)
            {

                //PrintBill();

                List<ProductInvoice_Master> _Pro = new List<ProductInvoice_Master>();

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/PickUpSale.rdlc");
                ReportDataSource datasource = new ReportDataSource("BillGenrate", _Pro);

                this.ReportViewer1.LocalReport.DataSources.Clear();
                this.ReportViewer1.LocalReport.DataSources.Add(datasource);
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
                List<PickUpItemMaster> _state = PickUpItemMasterCollection.GetAll();
                PickUpItemMaster sm = new PickUpItemMaster();
                sm.Id = 0;
                sm.ITEMNAME = "-select Item-";
                _state.Insert(0, sm);
                ddlItem.DataSource = _state;
                ddlItem.DataTextField = "ITEMNAME";
                ddlItem.DataValueField = "ITEM_Id";
                ddlItem.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }

        public void BindSizeColorDropdown(string productId)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string query = "SELECT Id, (UnitCode + ' - ' + ISNULL(Color_Code,'')) AS Text, UnitCode,ISNULL(Color_Code,'') as Color_Code,Price from dbo.ItemUnitRel where itemId = " + productId;
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    DataSet units = new DataSet();
                    da.Fill(units, "UnitColor");
                    Session["dvUnitPrice"] = units.Tables[0].AsDataView();
                    ddlSizeColor.DataSource = dvUnitPrice;
                    ddlSizeColor.DataTextField = "Text";
                    ddlSizeColor.DataValueField = "Id";
                    ddlSizeColor.DataBind();
                    ddlSizeColor.SelectedIndex = 0;
                    SetSelectedPrice(ddlSizeColor.SelectedValue);

                    conn.Close();
                }

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
                ddlUser.DataValueField = "Registration_ID";
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

                        txtItemCode.Text = PickUpItemMaster.GetByOrderId(ItemId).HSNCODE;
                        txtrate.Text = PickUpItemMaster.GetByOrderId(ItemId).RATE_PER.ToString();
                        int UserState = USERPROFILEMASTER.GetByRegistration_ID(User).State;
                        int PicUpState = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).State;
                        if (UserState == PicUpState)
                        {
                            txtigst.Text = "0";
                            txtcgst.Text = PickUpItemMaster.GetByOrderId(ItemId).CGST.ToString();
                            txtsgst.Text = PickUpItemMaster.GetByOrderId(ItemId).SGST.ToString();
                        }
                        else
                        {
                            txtcgst.Text = "0";
                            txtsgst.Text = "0";
                            txtigst.Text = PickUpItemMaster.GetByOrderId(ItemId).IGST.ToString();
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
                BindSizeColorDropdown(ddlItem.SelectedValue);
            }
            catch (Exception ew) { }
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
                ClearControls(c);
                //btnsave.Text = "Submit";
            }
        }
        //protected void btnsave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        decimal maxrateigst = 0;
        //        decimal total = 0;
        //        ProductInvoice_Master ln = new ProductInvoice_Master();
        //        total = decimal.Parse(numqty.Text) * decimal.Parse(txtrate.Text.Trim());
        //        if (btnsave.Text == "Submit")
        //        {
        //            if (string.IsNullOrEmpty(numqty.Text))
        //            {
        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Plz Enter Quantity..');</Script>", false);
        //                numqty.Focus();
        //                return;
        //            }
        //            else
        //            {
        //                decimal qt = decimal.Parse(numqty.Text.Trim());
        //                if (qt <= 0)
        //                {
        //                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Quantity must be greater than zero..');</Script>", false);
        //                    numqty.Focus();
        //                    return;
        //                }
        //            }
        //            ln.INVOICE_ID = ProductInvoice_Master.MaxId() + 1;
        //            ln.ITEM_ID = int.Parse(ddlItem.SelectedValue);
        //            ln.ITEMNAME = PickUpItemMaster.GetByOrderId(ln.ITEM_ID).ITEMNAME;
        //            ln.HSNCODE = PickUpItemMaster.GetByOrderId(ln.ITEM_ID).HSNCODE;
        //            ln.QUANTITY = decimal.Parse(numqty.Text);
        //            ln.RATE_PER = decimal.Parse(txtrate.Text.Trim());
        //            ln.TOTAL = total;
        //            decimal cgst = decimal.Parse(txtcgst.Text.Trim());
        //            decimal sgst = decimal.Parse(txtsgst.Text.Trim());
        //            decimal igst = decimal.Parse(txtigst.Text.Trim());
        //            if (cgst > maxrate)
        //                maxrate = cgst;
        //            if (sgst > maxrate)
        //                maxrate = sgst;
        //            if (igst > maxrate)
        //                maxrate = igst;
        //            maxrateigst = maxrate;
        //            ln.CGST_AMT = (total * cgst) / 100;
        //            ln.SGST_AMT = (total * sgst) / 100;
        //            ln.IGST_AMT = (total * igst) / 100;
        //            ln.CGST_RATE = cgst;
        //            ln.SGST_RATE = sgst;
        //            ln.IGST_RATE = igst;
        //            ln.BILL_ID = billid;
        //            ln.REMARKS = "";
        //            ln.INVOICE_DATE = System.DateTime.Today;
        //            ln.Bil_Stutas = "Waiting";
        //            ln.Save();
        //        }
        //        else if (btnsave.Text == "Update")
        //        {
        //            ln = ProductInvoice_Master.GetByINVOICE_ID(int.Parse(ViewState["id"].ToString()));
        //            ln.INVOICE_ID = int.Parse(ViewState["id"].ToString());
        //            ln.ITEM_ID = int.Parse(ddlItem.SelectedValue);
        //            ln.ITEMNAME = PickUpItemMaster.GetByOrderId(ln.ITEM_ID).ITEMNAME;
        //            ln.HSNCODE = PickUpItemMaster.GetByOrderId(ln.ITEM_ID).HSNCODE;
        //            ln.QUANTITY = decimal.Parse(numqty.Text);
        //            ln.RATE_PER = decimal.Parse(txtrate.Text.Trim());
        //            ln.TOTAL = total;
        //            decimal cgst = decimal.Parse(txtcgst.Text.Trim());
        //            decimal sgst = decimal.Parse(txtsgst.Text.Trim());
        //            decimal igst = decimal.Parse(txtigst.Text.Trim());
        //            if (cgst > maxrate)
        //                maxrate = cgst;
        //            if (sgst > maxrate)
        //                maxrate = sgst;
        //            if (igst > maxrate)
        //                maxrate = igst;
        //            maxrateigst = maxrate;
        //            ln.CGST_AMT = (total * cgst) / 100;
        //            ln.SGST_AMT = (total * sgst) / 100;
        //            ln.IGST_AMT = (total * igst) / 100;
        //            ln.CGST_RATE = cgst;
        //            ln.SGST_RATE = sgst;
        //            ln.IGST_RATE = igst;
        //            ln.BILL_ID = billid;
        //            ln.REMARKS = "";
        //            ln.INVOICE_DATE = System.DateTime.Today;
        //            ln.Bil_Stutas = "Waiting";
        //            ln.Save();
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully...');</Script>", false);
        //        }
        //        grid();
        //        ddlItem.SelectedIndex = 0;
        //        ClearControls(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert(error);</script>", false);
        //    }
        //}

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
                int UserId = 0;
                Int32.TryParse(ddlUser.SelectedValue, out UserId);
                List<ProductInvoice_Master> _Pro = ProductInvoice_MasterCollection.GetAll().FindAll(x => x.BILL_ID == billid);
                #region Company
                string CompanyName = USERPROFILEMASTER.GetByUser_Name("OMHRD").First_Name;
                string CompanyAddress = USERPROFILEMASTER.GetByUser_Name("OMHRD").Address;
                string CompanyState = USERPROFILEMASTER.GetByUser_Name("OMHRD").StateName;
                string CompanyCity = USERPROFILEMASTER.GetByUser_Name("OMHRD").CityName;
                string ZipCode = USERPROFILEMASTER.GetByUser_Name("OMHRD").ZipCode;
                string CompanyGST = USERPROFILEMASTER.GetByUser_Name("OMHRD").GstinVerified;
                string CompanyContact = USERPROFILEMASTER.GetByUser_Name("OMHRD").ContactNumber;
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
                #region PickUp
                int PicupId = int.Parse(Session["PickupID"].ToString());
                string PickUpName = PickupMaster.GetByPickupID(PicupId).FirstName + " " + PickupMaster.GetByPickupID(PicupId).LastName;
                string PickUpAddress = PickupMaster.GetByPickupID(PicupId).Address;
                string PickUpContact = PickupMaster.GetByPickupID(PicupId).ContactNo;
                string CenterName = PickupMaster.GetByPickupID(PicupId).CenterName;
                string CenterCode = PickupMaster.GetByPickupID(PicupId).CenterCode;
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
                ReportParameter[] rpt = new ReportParameter[33];
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

                rpt[27] = new ReportParameter("PaymentMod", PaymentMod);
                rpt[28] = new ReportParameter("PickUpName", PickUpName);
                rpt[29] = new ReportParameter("PickUpAddress", PickUpAddress);
                rpt[30] = new ReportParameter("PickUpContact", PickUpContact);
                rpt[31] = new ReportParameter("CenterName", CenterName);
                rpt[32] = new ReportParameter("CenterCode", CenterCode);
                this.ReportViewer1.LocalReport.SetParameters(rpt);
                this.ReportViewer1.LocalReport.DataSources.Clear();
                this.ReportViewer1.LocalReport.DataSources.Add(datasource);
                this.ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            { }
        }
        List<Bill> _bill = new List<Bill>();


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
            //  OTP = ViewState["GenerateOTP"].ToString();
            OTP = "00000";
            int UserId = ddlUser.SelectedIndex;
            string Contact = USERPROFILEMASTER.GetByRegistration_ID(UserId).ContactNumber;
            // Sendmsg("Your OTP is " + " " + OTP, Contact);
            txtComfirmotp.Visible = true;
            btnWelletpay.Visible = true;
        }

        protected void rdCash_CheckedChanged(object sender, EventArgs e)
        {
            if (ddlUser.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please select user.!!!')</script>", false);
                return;
            }
            else
            {
                PaymentMod = "Cash";
                btndallbill.Visible = true;
                btnOtp.Visible = false;
                txtComfirmotp.Visible = false;
            }
        }

        protected void rdWalllet_CheckedChanged(object sender, EventArgs e)
        {
            if (ddlUser.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please select user.!!!')</script>", false);
                return;
            }
            else
            {
                PaymentMod = "Wallet";
                btndallbill.Visible = false;
                btnOtp.Visible = true;
                txtComfirmotp.Visible = false;
            }
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
        public void MakePayment()
        {
            decimal totalamt = 0;
            int UserId = int.Parse(ddlUser.SelectedValue);
            var products = ProductAddtoCartMasterCollection.GetAll().FindAll(x => x.User_id == UserId);
            var paymentBill = new ProductBill_Master();
            paymentBill.BILL_ID = ProductBill_Master.MaxId() + 1;
            paymentBill.BILLNO = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            foreach (GridViewRow gv in gdvNotice.Rows)
            {
                totalamt += decimal.Parse(gv.Cells[4].Text.ToString());
            }
            paymentBill.TOTAL = totalamt;
            paymentBill.STATUS = "Wallet";
            paymentBill.BILLDATE = DateTime.Today.Date;
            paymentBill.RECEIVER_ID = UserId;
            paymentBill.REMARKS = null;
            paymentBill.LOGIN_ID = int.Parse(Session["PickupID"].ToString());
            paymentBill.Bil_Stutas = "Paid";
            paymentBill.Extra_Payment = 0;
            paymentBill.NO_OF_BOXES = "";
            paymentBill.Save();
            #region 
            foreach (var x in products)
            {
                ProductInvoice_Master invoiceItem = new ProductInvoice_Master();
                {
                    invoiceItem.INVOICE_ID = ProductInvoice_Master.MaxId() + 1;
                    invoiceItem.ITEM_ID = x.Product_id;
                    invoiceItem.ITEMNAME = PickUpItemMaster.GetByOrderId(x.Product_id).ITEMNAME;
                    invoiceItem.HSNCODE = PickUpItemMaster.GetByOrderId(x.Product_id).HSNCODE;
                    invoiceItem.QUANTITY = x.Quantity;
                    invoiceItem.RATE_PER = PickUpItemMaster.GetByOrderId(x.Product_id).RATE_PER;
                    invoiceItem.TOTAL = x.Total;
                    if (paymentBill.RECEIVER_ID == paymentBill.LOGIN_ID)
                    {
                        invoiceItem.CGST_RATE = decimal.Parse(PickUpItemMaster.GetByOrderId(x.Product_id).CGST.ToString());
                        invoiceItem.SGST_RATE = decimal.Parse(PickUpItemMaster.GetByOrderId(x.Product_id).SGST.ToString());
                        invoiceItem.IGST_RATE = 0;
                        invoiceItem.CGST_AMT = (invoiceItem.TOTAL * invoiceItem.CGST_RATE) / 100;
                        invoiceItem.SGST_AMT = (invoiceItem.TOTAL * invoiceItem.SGST_RATE) / 100;
                        invoiceItem.IGST_AMT = (invoiceItem.TOTAL * invoiceItem.IGST_RATE) / 100;
                    }
                    else
                    {
                        invoiceItem.CGST_RATE = 0;
                        invoiceItem.SGST_RATE = 0;
                        invoiceItem.IGST_RATE = decimal.Parse(PickUpItemMaster.GetByOrderId(x.Product_id).IGST.ToString());
                        invoiceItem.CGST_AMT = (invoiceItem.TOTAL * invoiceItem.CGST_RATE) / 100;
                        invoiceItem.SGST_AMT = (invoiceItem.TOTAL * invoiceItem.SGST_RATE) / 100;
                        invoiceItem.IGST_AMT = (invoiceItem.TOTAL * invoiceItem.IGST_RATE) / 100;
                    }
                    invoiceItem.BILL_ID = paymentBill.BILL_ID;
                    invoiceItem.REMARKS = "";
                    invoiceItem.INVOICE_DATE = System.DateTime.Today;
                    invoiceItem.Bil_Stutas = "Waiting";
                    invoiceItem.RECEIVER_ID = paymentBill.RECEIVER_ID;
                    invoiceItem.UnitCode = x.UnitCode;
                    invoiceItem.Color_Code = x.Color_Code;
                }
                invoiceItem.Save();
                #endregion
                ProductAddtoCartMaster dm = new ProductAddtoCartMaster();
                dm.UserDelete(UserId);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Save Successfully...');</Script>", false);
                PrintBill();
            }
        }
        protected void btnWelletpay_Click(object sender, EventArgs e)
        {
            string Comfirmotp = txtComfirmotp.Text.Trim();
            if (OTP == Comfirmotp)
            {
                Tranfer();
                btndallbill.Visible = false;
                btnOtp.Visible = false;
                txtComfirmotp.Visible = false;
                btnWelletpay.Visible = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('OTP not matched !!...');</Script>", false);
                return;
            }
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void ddlSizeColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedPrice(ddlSizeColor.SelectedValue);
        }
        private void SetSelectedPrice(string sizeColorId)
        {

            if (!string.IsNullOrWhiteSpace(sizeColorId) && dvUnitPrice != null)
            {
                var dv = dvUnitPrice;
                dv.RowFilter = null;
                // dv.RowStateFilter = DataViewRowState.ModifiedCurrent;
                dv.RowFilter = "Id = " + sizeColorId;
                // dv.RowStateFilter = DataViewRowState.ModifiedCurrent;
                var row = dv.ToTable().Rows[0];
                Session["_selectedSizeCode"] = row["UnitCode"].ToString();
                Session["_selectedColorCode"] = row["Color_Code"].ToString();
                txtrate.Text = row["Price"].ToString();
            }
            else
            {
                Session["_selectedSizeCode"] = "";
                Session["_selectedColorCode"] = "";
                txtrate.Text = "";
            }
        }
        public void BindProductAddToCart()
        {
            int userId = int.Parse(ddlUser.SelectedValue);
            gdvNotice.DataSource = ProductAddtoCartMasterCollection.GetAll().FindAll(x => x.User_id == userId);
            gdvNotice.DataBind();
        }
        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProductAddToCart();
            ClearControls(this);
        }
        protected void btnPickAddtocart_Click(object sender, EventArgs e)
        {
            try
            {
                ProductAddtoCartMaster ln = new ProductAddtoCartMaster();
                if (btnPickAddtocart.Text == "Add To Cart")
                {
                    ln.Cart_id = ProductAddtoCartMaster.GetMaxID() + 1;
                    ln.User_id = int.Parse(ddlUser.SelectedValue);
                    ln.Product_id = int.Parse(ddlItem.SelectedValue);
                    ln.Quantity = decimal.Parse(numqty.Text);
                    ln.Color_Code = _selectedColorCode;
                    ln.UnitCode = _selectedSizeCode;
                    ln.Save();
                }
                else if (btnPickAddtocart.Text == "Update")
                {
                    ln = ProductAddtoCartMaster.GetByCart_id(int.Parse(ViewState["ProductAddToCartID"].ToString()));
                    ln.Cart_id = int.Parse(ViewState["ProductAddToCartID"].ToString());
                    ln.User_id = int.Parse(ddlUser.SelectedValue);
                    ln.Product_id = int.Parse(ddlItem.SelectedValue);
                    ln.Quantity = decimal.Parse(numqty.Text);
                    ln.Color_Code = _selectedColorCode;
                    ln.UnitCode = _selectedSizeCode;
                    ln.Save();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully...');</Script>", false);
                }
                BindProductAddToCart();
                ddlItem.SelectedIndex = 0;
                btnPickAddtocart.Text = "Add To Cart";
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
            ViewState["ProductAddToCartID"] = ((Label)gr.FindControl("lblProductAddtocart")).Text;
            string nid = ViewState["ProductAddToCartID"].ToString();
            ProductAddtoCartMaster dm = ProductAddtoCartMaster.GetByCart_id(int.Parse(nid));
            ddlItem.SelectedValue = dm.Product_id.ToString();
            txtItemCode.Text = PickUpItemMaster.GetByOrderId(int.Parse(ddlItem.SelectedValue)).HSNCODE;
            txtcgst.Text = PickUpItemMaster.GetByOrderId(int.Parse(ddlItem.SelectedValue)).CGST.ToString();//dm.CGST_RATE.ToString();
            txtsgst.Text = PickUpItemMaster.GetByOrderId(int.Parse(ddlItem.SelectedValue)).SGST.ToString(); //dm.SGST_RATE.ToString();
            txtigst.Text = PickUpItemMaster.GetByOrderId(int.Parse(ddlItem.SelectedValue)).IGST.ToString(); //dm.IGST_RATE.ToString();
            numqty.Text = dm.Quantity.ToString();
            txtrate.Text = PickUpItemMaster.GetByOrderId(int.Parse(ddlItem.SelectedValue)).RATE_PER.ToString(); //dm.RATE_PER.ToString();
            btnPickAddtocart.Text = "Update";

        }
        protected void linkbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                ViewState["ProductAddToCartID"] = ((Label)gv.FindControl("lblProductAddtocart")).Text;
                string did = ViewState["ProductAddToCartID"].ToString();
                ProductAddtoCartMaster dm = new ProductAddtoCartMaster();
                dm.Cart_id = int.Parse(did);
                dm.Delete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                // Response.Redirect("SaleProduct.aspx");
                BindProductAddToCart();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }

    }
}