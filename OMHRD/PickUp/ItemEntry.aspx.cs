using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.PickUp
{
    public partial class ItemEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillCategory();
                grid(); 
            }
        }
        public void grid()
        {
            gdvNotice.DataSource = PickUpItemMasterCollection.GetAll().FindAll(x => x.PickupID == int.Parse(Session["PickupID"].ToString()));
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


        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlItem.SelectedIndex > 0)
                {
                    int ItemId = int.Parse(ddlItem.SelectedValue);
                    txtItemCode.Text = ITEM_MASTER.GetByITEM_ID(ItemId).HSNCODE;
                    txtrate.Text = ITEM_MASTER.GetByITEM_IDRATE(ItemId).Price.ToString();
                    txtcgst.Text = ITEM_MASTER.GetByITEM_ID(ItemId).CGST.ToString();
                    txtsgst.Text = ITEM_MASTER.GetByITEM_ID(ItemId).SGST.ToString();
                    txtigst.Text = ITEM_MASTER.GetByITEM_ID(ItemId).IGST.ToString();
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                decimal total = 0;
                PickUpItemMaster ln = new PickUpItemMaster();
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
                    ln.Id = PickUpItemMaster.GetMaxID() + 1;
                    ln.ITEM_ID = int.Parse(ddlItem.SelectedValue);
                    ln.ITEMNAME = ITEM_MASTER.GetByITEM_ID(int.Parse(ddlItem.SelectedValue)).ITEMNAME;
                    ln.HSNCODE = txtItemCode.Text;
                    ln.CGST = int.Parse(txtcgst.Text);
                    ln.SGST = int.Parse(txtsgst.Text);
                    ln.IGST = int.Parse(txtigst.Text);
                    ln.QUANTITY = decimal.Parse(numqty.Text);
                    ln.RATE_PER = decimal.Parse(txtrate.Text.Trim());
                    ln.TOTAL = total;
                    ln.EntryDate = System.DateTime.Today;
                    ln.PickupID = int.Parse(Session["PickupID"].ToString());
                    ln.Save();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully...');</Script>", false);
                }
                else if (btnsubmit.Text == "Update")
                {
                    ln = PickUpItemMaster.GetByOrderId(int.Parse(ViewState["id"].ToString()));
                    ln.Id = int.Parse(ViewState["id"].ToString());
                    ln.ITEM_ID = ddlItem.SelectedIndex;
                    ln.QUANTITY = decimal.Parse(numqty.Text);
                    ln.RATE_PER = decimal.Parse(txtrate.Text.Trim());
                    ln.TOTAL = total;
                    ln.EntryDate = System.DateTime.Today;
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

        protected void linkbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)lb.NamingContainer;
            ViewState["id"] = ((Label)gr.FindControl("labelNOTICE_ID")).Text;
            string nid = ViewState["id"].ToString();
            PickUpItemMaster dm = PickUpItemMaster.GetByOrderId(int.Parse(nid));
            ddlItem.SelectedValue = dm.ITEM_ID.ToString();
            txtItemCode.Text = dm.HSNCODE;
            numqty.Text = dm.QUANTITY.ToString();
            txtcgst.Text = dm.CGST.ToString();
            txtsgst.Text = dm.SGST.ToString();
            txtigst.Text = dm.IGST.ToString();
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
                PickUpItemMaster dm = new PickUpItemMaster();
                dm.Id = int.Parse(did);
                dm.GetByDelete();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Data Delete....');</Script>", false);
                Response.Redirect("ItemEntry.aspx");
                grid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('" + ex.Message + "');</Script>", false);
            }
        }
    }
}