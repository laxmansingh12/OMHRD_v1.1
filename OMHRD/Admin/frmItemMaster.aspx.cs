using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Object;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace OMHRD.AdminPanel
{
    public partial class frmItemMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillCategory();
                if (Request.QueryString["st"] != null)
                {
                    Form_detail(int.Parse(Request.QueryString["st"].ToString()));
                    btnsubmit.Text = "Save Change";
                }
            }
        }
        public void Form_detail(int ItemId)
        {
            try
            {
                ITEM_MASTER cm = ITEM_MASTER.GetByITEM_ID(ItemId);
                if (cm.ITEM_ID > 0)
                {
                    ViewState["MID"] = ItemId;
                    txtitemName.Text = cm.ITEMNAME;
                    int SubId = cm.SubCategory_ID;

                    dropCategory.SelectedValue = SubCategoryMaster.GetByCategory_ID(SubId).Category_ID.ToString();
                    fillSubCategory();
                    dropSubCate.SelectedValue = cm.SubCategory_ID.ToString();
                    BindUnit();
                    txtitemCode.Text = cm.CODE;
                    txthsnCode.Text = cm.HSNCODE;
                    txtCGST.Text = cm.CGST.ToString();
                    txtSGST.Text = cm.SGST.ToString();
                    txtIGST.Text = cm.IGST.ToString();
                    txtDescription.Text = cm.Description;
                    txtstock.Text = cm.OPEN_STOCK.ToString();
                    if (cm.Image == "" || cm.Image == null)
                    {
                        Image.ImageUrl = "~/images/b1.jpg";
                    }
                    else
                    {
                        Image.ImageUrl = "~/images/ItemImages/" + cm.Image;
                    }
                    if (cm.Image1 == "" || cm.Image1 == null)
                    {
                        Image1.ImageUrl = "~/images/b1.jpg";
                    }
                    else
                    {
                        Image1.ImageUrl = "~/images/ItemImages/" + cm.Image1;
                    }
                    if (cm.Image2 == "" || cm.Image2 == null)
                    {
                        Image2.ImageUrl = "~/images/b1.jpg";
                    }
                    else
                    {
                        Image2.ImageUrl = "~/images/ItemImages/" + cm.Image2;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void fillCategory()
        {
            try
            {
                List<CategoryMaster> _state = CategoryMasterCollection.GetAll();
                CategoryMaster sm = new CategoryMaster();
                sm.CATEGORY_ID = 0;
                sm.CATEGORY_NAME = "-select Category-";
                _state.Insert(0, sm);
                dropCategory.DataSource = _state;
                dropCategory.DataTextField = "CATEGORY_NAME";
                dropCategory.DataValueField = "CATEGORY_ID";
                dropCategory.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void fillSubCategory()
        {
            try
            {
                List<SubCategoryMaster> _state = SubCategoryMasterCollection.GetAll().Where(x => x.Category_ID == int.Parse(dropCategory.SelectedValue.ToString())).OrderBy(x => x.SubCategory_NAME).ToList();
                SubCategoryMaster sm = new SubCategoryMaster();
                sm.SubCategory_ID = 0;
                sm.SubCategory_NAME = "-select Sub Category-";
                _state.Insert(0, sm);
                dropSubCate.DataSource = _state;
                dropSubCate.DataTextField = "SubCategory_NAME";
                dropSubCate.DataValueField = "SubCategory_ID";
                dropSubCate.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void BindUnit()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetUnitByItem";
            cmd.Parameters.Add("@SubCatId", SqlDbType.Int).Value = dropSubCate.SelectedValue;
            if (Request.QueryString["st"] != null && Request.QueryString["st"].ToString() != "")
            {
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = int.Parse(Request.QueryString["st"].ToString());
            }
            cmd.Connection = con;
            try
            {
                con.Open();
                gvUnits.EmptyDataText = "No Records Found";
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                gvUnits.DataSource = dt;
                gvUnits.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        private void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();

                ClearInputs(ctrl.Controls);
                btnsubmit.Text = "Submit";
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ITEM_MASTER cm = new ITEM_MASTER();
                string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection cn = new SqlConnection(constr);

                if (btnsubmit.Text == "Submit")
                {
                    if (!ValidateItemControls())
                        return;
                    SqlCommand cmd = new SqlCommand("usp_SaveItemMaster", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (Request.QueryString["st"] == null)
                    {
                        cmd.Parameters.AddWithValue("@ITEM_ID", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ITEM_ID", Request.QueryString["st"]);
                    }
                    cmd.Parameters.AddWithValue("@ITEMNAME", txtitemName.Text);
                    cmd.Parameters.AddWithValue("@SubCategory_ID", dropSubCate.SelectedValue);
                    cmd.Parameters.AddWithValue("@CODE", txtitemCode.Text);
                    cmd.Parameters.AddWithValue("@HSNCODE", txthsnCode.Text);
                    cmd.Parameters.AddWithValue("@CGST", txtCGST.Text);
                    cmd.Parameters.AddWithValue("@SGST", txtSGST.Text);
                    cmd.Parameters.AddWithValue("@IGST", txtIGST.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@OPEN_STOCK", txtstock.Text);
                    #region Image1
                    string exten = System.IO.Path.GetExtension(fileImage.FileName);
                    if (fileImage.HasFile == true)
                    {
                        fileImage.SaveAs(Server.MapPath("~/images/ItemImages/" + txtitemName.Text + 1 + exten));
                        string Image = txtitemName.Text + 1 + exten;
                        cmd.Parameters.AddWithValue("@Image", Image);
                    }
                    #endregion
                    #region Image2
                    string exten1 = System.IO.Path.GetExtension(fileImage1.FileName);
                    if (fileImage1.HasFile == true)
                    {
                        fileImage1.SaveAs(Server.MapPath("~/images/ItemImages/" + txtitemName.Text + 2 + exten1));
                        string Image1 = txtitemName.Text + 2 + exten1;
                        cmd.Parameters.AddWithValue("@Image1", Image1);
                    }
                    #endregion
                    #region Image3
                    string exten2 = System.IO.Path.GetExtension(fileImage2.FileName);
                    if (fileImage2.HasFile == true)
                    {
                        fileImage2.SaveAs(Server.MapPath("~/images/ItemImages/" + txtitemName.Text + 3 + exten2));
                        string Image3 = txtitemName.Text + 3 + exten2;
                        cmd.Parameters.AddWithValue("@Image2", Image3);
                    }
                    #endregion
                    cmd.Parameters.AddWithValue("@ItemUnits", GetUnitsDT());
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully....');</Script>", false);
                }
                else if (btnsubmit.Text == "Save Change")
                {
                    SqlCommand cmd = new SqlCommand("usp_SaveItemMaster", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (Request.QueryString["st"] == null)
                    {
                        cmd.Parameters.AddWithValue("@ITEM_ID", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ITEM_ID", Request.QueryString["st"]);
                    }
                    cmd.Parameters.AddWithValue("@ITEMNAME", txtitemName.Text);
                    cmd.Parameters.AddWithValue("@SubCategory_ID", dropSubCate.SelectedValue);
                    cmd.Parameters.AddWithValue("@CODE", txtitemCode.Text);
                    cmd.Parameters.AddWithValue("@HSNCODE", txthsnCode.Text);
                    cmd.Parameters.AddWithValue("@CGST", txtCGST.Text);
                    cmd.Parameters.AddWithValue("@SGST", txtSGST.Text);
                    cmd.Parameters.AddWithValue("@IGST", txtIGST.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@OPEN_STOCK", txtstock.Text);
                    #region Image1
                    string exten = System.IO.Path.GetExtension(fileImage.FileName);
                    if (fileImage.HasFile == true)
                    {
                        fileImage.SaveAs(Server.MapPath("~/images/ItemImages/" + txtitemName.Text + 1 + exten));
                        string Image = txtitemName.Text + 1 + exten;
                        cmd.Parameters.AddWithValue("@Image", Image);
                    }
                    #endregion
                    #region Image2
                    string exten1 = System.IO.Path.GetExtension(fileImage1.FileName);
                    if (fileImage1.HasFile == true)
                    {
                        fileImage1.SaveAs(Server.MapPath("~/images/ItemImages/" + txtitemName.Text + 2 + exten1));
                        string Image1 = txtitemName.Text + 2 + exten1;
                        cmd.Parameters.AddWithValue("@Image1", Image1);
                    }
                    #endregion
                    #region Image3
                    string exten2 = System.IO.Path.GetExtension(fileImage2.FileName);
                    if (fileImage2.HasFile == true)
                    {
                        fileImage2.SaveAs(Server.MapPath("~/images/ItemImages/" + txtitemName.Text + 3 + exten2));
                        string Image3 = txtitemName.Text + 3 + exten2;
                        cmd.Parameters.AddWithValue("@Image2", Image3);
                    }
                    #endregion
                    cmd.Parameters.AddWithValue("@ItemUnits", GetUnitsDT());
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully...');</Script>", false);
                }
                Response.Redirect("frmItemList.aspx");
                ClearInputs(Page.Controls);
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
            ITEM_MASTER cm = ITEM_MASTER.GetByITEM_ID(int.Parse(nid));
            txtitemName.Text = cm.ITEMNAME;


            dropCategory.SelectedValue = cm.CATEGORY_ID.ToString(); /*fillCategory(); fillSubCategory();*/
            dropSubCate.SelectedValue = cm.SubCategory_ID.ToString();


            txtitemCode.Text = cm.CODE;
            txthsnCode.Text = cm.HSNCODE;
            //  dropUnit.SelectedIndex = cm.UNIT_ID;
            txtCGST.Text = cm.CGST.ToString();
            txtSGST.Text = cm.SGST.ToString();
            txtIGST.Text = cm.IGST.ToString();
            txtDescription.Text = cm.Description;
            txtstock.Text = cm.OPEN_STOCK.ToString();
            btnsubmit.Text = "Update";
        }

        protected void dropCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSubCategory();
        }

        protected void txtCGST_TextChanged(object sender, EventArgs e)
        {
            if (txtCGST.Text != "")
            {
                txtSGST.Text = txtCGST.Text;
                decimal tax = decimal.Parse(txtCGST.Text.Trim()) + decimal.Parse(txtSGST.Text.Trim());
                txtIGST.Text = tax.ToString();
            }
            else
            {
                txtSGST.Text = "";
                txtIGST.Text = "";
            }
        }

        private DataTable GetUnitsDT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UnitCode", typeof(string));
            dt.Columns.Add("Color_Code", typeof(string));
            dt.Columns.Add("Quantity", typeof(decimal));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("DisscountPrice", typeof(decimal));
            decimal qty = 0;
            decimal price = 0;
            decimal discount = 0;
            foreach (GridViewRow item in gvUnits.Rows)
            {
                decimal.TryParse((item.Cells[5].FindControl("txtQty") as TextBox).Text.Trim(), out qty);
                decimal.TryParse((item.Cells[6].FindControl("txtPrice") as TextBox).Text.Trim(), out price);
                decimal.TryParse((item.Cells[7].FindControl("txtDiscount") as TextBox).Text.Trim(), out discount);
                dt.Rows.Add(item.Cells[1].Text, item.Cells[2].Text, qty, price, discount);
            }

            return dt;
        }

        private bool ValidateItemControls()
        {
            if (string.IsNullOrEmpty(txtitemName.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Enter Item Name...!!');</script>", false);
                txtitemName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txthsnCode.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Enter HSN CODE...!!');</script>", false);
                txthsnCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCGST.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Enter Tax Rate...!!');</script>", false);
                txtCGST.Focus();
                return false;
            }
            if (fileImage.PostedFile.FileName == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Plz select Image.');</Script>", false);
                return false;
            }
            if (fileImage1.PostedFile.FileName == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Plz select Image.');</Script>", false);
                return false;
            }
            if (fileImage2.PostedFile.FileName == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Plz select Image.');</Script>", false);
                return false;
            }
            return true;
        }

        protected void dropSubCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindUnit();
        }
    }
}