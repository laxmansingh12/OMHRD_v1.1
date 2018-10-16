using Business.Object;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.PickUp
{
    public partial class OrderFrm : System.Web.UI.Page
    {
        int billid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetMaxbillid();
            if (!IsPostBack)
            {
                fillCategory();
            }
        }
        public void grid()
        {
            gdvNotice.DataSource = OrderMasterCollection.GetAll().FindAll(x => x.OrderBILL_ID == billid);
            gdvNotice.DataBind();

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
                ClearControls(c); btnsubmit.Text = "Submit";
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
        public void GetMaxbillid()
        {
            try
            {
                billid = OrderBillMaster.MaxId() + 1;
            }
            catch (Exception ew) { }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                decimal total = 0;
                OrderMaster ln = new OrderMaster();
                total = decimal.Parse(numqty.Text) * decimal.Parse(txtrate.Text.Trim());
                if (btnsubmit.Text == "Submit")
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
                    ln.OrderId = OrderMaster.GetMaxID() + 1;
                    ln.ITEM_ID = ddlItem.SelectedIndex;
                    ln.QUANTITY = decimal.Parse(numqty.Text);
                    ln.RATE_PER = decimal.Parse(txtrate.Text.Trim());
                    ln.TOTAL = total;
                    ln.OrderBILL_ID = billid;
                    ln.OrderDate = System.DateTime.Today;
                    ln.PickupID = int.Parse(Session["PickupID"].ToString());
                    ln.Save();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully...');</Script>", false);
                }
                else if (btnsubmit.Text == "Update")
                {
                    ln = OrderMaster.GetByOrderId(int.Parse(ViewState["id"].ToString()));
                    ln.OrderId = int.Parse(ViewState["id"].ToString());
                    ln.ITEM_ID = ddlItem.SelectedIndex;
                    ln.QUANTITY = decimal.Parse(numqty.Text);
                    ln.RATE_PER = decimal.Parse(txtrate.Text.Trim());
                    ln.TOTAL = total;
                    ln.OrderBILL_ID = billid;
                    ln.OrderDate = System.DateTime.Today;
                    ln.PickupID = int.Parse(Session["PickupID"].ToString());
                    ln.Save();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully...');</Script>", false);
                }
                grid();
                ClearControls(this);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert(error);</script>", false);
            }
        }
        public void PrintBill()
        {
            try
            {
                List<OrderMaster> _bill = OrderMasterCollection.GetAll().FindAll(x => x.OrderBILL_ID == billid);
                string BillNo = OrderBillMaster.GetByOrderBILL_ID(billid).BILLNO;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                this.ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("/Report/PickUpOrder.rdlc");
                ReportDataSource datasource = new ReportDataSource("ProductOrder", _bill);
                this.ReportViewer1.LocalReport.DataSources.Clear();
                this.ReportViewer1.LocalReport.DataSources.Add(datasource);
                this.ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            { }
        }

        protected void linkbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)lb.NamingContainer;
            ViewState["id"] = ((Label)gr.FindControl("labelNOTICE_ID")).Text;
            string nid = ViewState["id"].ToString();
            OrderMaster dm = OrderMaster.GetByOrderId(int.Parse(nid));
            ddlItem.SelectedIndex = dm.ITEM_ID;
            txtItemCode.Text = ITEM_MASTER.GetByITEM_ID(ddlItem.SelectedIndex).CODE;
            numqty.Text = dm.QUANTITY.ToString();
            txtrate.Text = dm.RATE_PER.ToString();
            btnsubmit.Text = "Update";

        }

        protected void linkbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gv = (GridViewRow)lb.NamingContainer;
                ViewState["id"] = ((Label)gv.FindControl("labelNOTICE_ID")).Text;
                string did = ViewState["id"].ToString();
                OrderMaster dm = new OrderMaster();
                dm.OrderId = int.Parse(did);
                dm.GetByDelete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("OrderFrm.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ItemId = int.Parse(ddlItem.SelectedValue);
            txtItemCode.Text = ITEM_MASTER.GetByITEM_ID(ItemId).CODE;
            txtrate.Text = ITEM_MASTER.GetByITEM_IDRATE(ItemId).Price.ToString();
        }

        protected void txtOrderbill_Click(object sender, EventArgs e)
        {
            grid();
            decimal totalamt = 0;
            foreach (GridViewRow gv in gdvNotice.Rows)
            {
                totalamt += decimal.Parse(gv.Cells[4].Text.ToString());
            }
            OrderBillMaster bm = new OrderBillMaster();
            bm.OrderBILL_ID = OrderBillMaster.MaxId() + 1;
            bm.BILLNO = bm.OrderBILL_ID.ToString();
            bm.TOTAL = Math.Round(totalamt, 0);
            bm.STATUS = "Send";
            bm.BILLDATE = DateTime.Today.Date;
            bm.REMARKS = null;
            bm.LOGIN_ID = int.Parse(Session["PickupID"].ToString());
            bm.Bil_Stutas = "Used";
            bm.Extra_Payment = decimal.Parse(txtextra.Text);
            bm.NO_OF_Items = txtNOPro.Text;
            bm.Save();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Order Send Successfully...');</Script>", false);
            PrintBill();
        }
    }
}