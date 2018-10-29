using Business.Object;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.AdminPanel
{
    public partial class frmpayout : System.Web.UI.Page
    {
        string disInPer = string.Empty;
        static decimal DisTDS;
        static decimal DisWel;
        static decimal DisChar;
        static decimal DisMiscell;
        static decimal taxableTDS = 0;
        static decimal taxableWel = 0;
        static decimal taxableChar = 0;
        static decimal taxableMiscell = 0;
        static decimal disCountTDS = 0;
        static decimal disCountWel = 0;
        static decimal disCountChar = 0;
        static decimal disCountMiscell = 0;
        static decimal other = 0;
        static decimal total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPercentLevel();
                fillActive();
                BindMonthDDL();
            }
        }
        public void BindPercentLevel()
        {
            string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select Code, convert( varchar(20),Percentage) + '% ( ' + convert(varchar(20),MinReference) + ' to ' + convert(varchar(20), ISNULL(MaxReference,''))   + ' Members )' AS Text from PayoutLevelSetting"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlPayPercent.DataSource = cmd.ExecuteReader();
                    ddlPayPercent.DataTextField = "Text";
                    ddlPayPercent.DataValueField = "Code";
                    ddlPayPercent.DataBind();
                    con.Close();
                }
            }
            ddlPayPercent.Items.Insert(0, new ListItem("--Select % --", "0"));
        }
        public void fillActive()
        {
            try
            {
                List<USERPROFILEMASTER> _state = USERPROFILEMASTERCollection.GetAll().FindAll(x => x.Status == "Active");
                USERPROFILEMASTER sm = new USERPROFILEMASTER();
                sm.Registration_ID = 0;
                sm.User_Name = "-select Active User-";
                _state.Insert(0, sm);
                dropActive.DataSource = _state;
                dropActive.DataTextField = "User_Name";
                dropActive.DataValueField = "Registration_ID";
                dropActive.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void GetQualifier()
        {
            var selectedMonthDate = DateTime.ParseExact(ddlmonth.SelectedValue, "ddMMyyyy", CultureInfo.InvariantCulture);
            //SELECT count(1) FROM PayoutAmount WHERE PayoutMonth= @PayoutMonth and PayoutYear= @PayoutYear
            if (hdnPayoutGenerated.Value == "")
            {
            }
            decimal TotalSale = decimal.Parse(txttotalAmount.Text);
            string PayoutLevel = ddlPayPercent.SelectedValue;
            String strConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_CalculatePayoutAmount";
            cmd.Parameters.AddWithValue("@TotalSale", TotalSale);
            cmd.Parameters.AddWithValue("@PayoutLevelCode", PayoutLevel);
            cmd.Parameters.AddWithValue("@PayoutMonth", selectedMonthDate.Month);
            cmd.Parameters.AddWithValue("@PayoutYear", selectedMonthDate.Year);
            cmd.Connection = con;
            try
            {
                con.Open();
                gdvActiveUser.EmptyDataText = "No Records Found";
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                gdvActiveUser.DataSource = dt;
                gdvActiveUser.DataBind();
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
        public void BindMonthDDL()
        {
            var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            DateTime dt = DateTime.Now;
            for (int i = 1; i <= 12; i++)
            {
                ddlmonth.Items.Add(new ListItem(dt.AddMonths(-1 * i).ToString("MMMM-yyyy"), dt.AddMonths(-1 * i).ToString("ddMMyyyy")));
            }
            ddlmonth.Items.Insert(0, new ListItem("--Select Date --", "0"));
        }
        public void TotalAmount()
        {
            DateTime dtMonth = DateTime.ParseExact(ddlmonth.SelectedValue, "ddMMyyyy", CultureInfo.InvariantCulture);
            DateTime from = new DateTime(dtMonth.Year, dtMonth.Month, 1);
            DateTime to = (from.AddMonths(1)).AddDays(-1);
            string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_TotalPayoutAmount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@From", from);
            cmd.Parameters.AddWithValue("@To", to);
            ViewState["TotalAmount"] = txttotalAmount.Text = cmd.ExecuteScalar().ToString();
            con.Close();
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
        public void Total()
        {
            decimal TotalAmountByData = decimal.Parse(ViewState["TotalAmount"].ToString());

            if (chkTDS.Checked == true)
            {
                TDS();
                decimal Total = total - disCountTDS - disCountWel;
                txttotalAmount.Text = Total.ToString();
            }
            else
            {
                TDS();
                decimal Total = total - disCountTDS - DisWel - DisChar - DisMiscell - other;
                txttotalAmount.Text = Total.ToString();
            }
            if (chkWel.Checked == true)
            {
                Welfare();
                decimal Total = total - disCountTDS - disCountWel;
                txttotalAmount.Text = Total.ToString();
            }
            else
            {
                Welfare();
                decimal Total = total - disCountTDS - disCountWel - DisChar - DisMiscell - other;
                txttotalAmount.Text = Total.ToString();
            }
        }

        public void TDS()
        {
            decimal TotalAmount = decimal.Parse(ViewState["TotalAmount"].ToString());
            if (chkTDS.Checked == true)
            {
                taxableTDS = TotalAmount - ((TotalAmount * disCountTDS) / 100);
                disCountTDS = (TotalAmount * disCountTDS) / 100;
                taxableTDS = Math.Round(taxableTDS, 2);
            }
        }
        public void Welfare()
        {
            decimal TotalAmount = decimal.Parse(ViewState["TotalAmount"].ToString());
            if (chkWel.Checked == true)
            {
                taxableWel = TotalAmount - ((TotalAmount * disCountWel) / 100);
                disCountWel = (TotalAmount * disCountWel) / 100;
                taxableWel = Math.Round(taxableWel, 2);
            }
        }
        public void Charity()
        {
            decimal TotalAmount = decimal.Parse(ViewState["TotalAmount"].ToString());
            if (chkCharity.Checked == true)
            {
                taxableTDS = TotalAmount - ((TotalAmount * disCountTDS) / 100);
                disCountTDS = (TotalAmount * disCountTDS) / 100;
                taxableTDS = Math.Round(taxableTDS, 2);
            }
        }
        public void Miscell()
        {
            decimal TotalAmount = decimal.Parse(ViewState["TotalAmount"].ToString());
            if (chkMiscell.Checked == true)
            {
                taxableTDS = TotalAmount - ((TotalAmount * disCountTDS) / 100);
                disCountTDS = (TotalAmount * disCountTDS) / 100;
                taxableTDS = Math.Round(taxableTDS, 2);
            }
        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            try
            {

                PeyoutMaster cm = new PeyoutMaster();
                if (btnsubmit.Text == "Submit")
                {
                    cm.PeyoutID = PeyoutMaster.MaxId() + 1;
                    if (dropActive.SelectedIndex == 0)
                    { }
                    cm.User_ID = dropActive.SelectedIndex;
                    for (int i = 0; i < gdvActiveUser.Rows.Count; i++)
                    {

                    }
                    cm.TotalAmount = decimal.Parse(txttotalAmount.Text);

                    cm.TDS = decimal.Parse(txtTds.Text);
                    #region TDS
                    if (chkTDS.Checked == true)
                    {
                        if (DisTDS > 100)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script> alert('You Enter only atmost 100 value') </script>", false);
                            txtTds.Focus();
                            return;
                        }
                        disInPer = "Yes";
                        taxableTDS = total - ((total * DisTDS) / 100);
                        disCountTDS = (total * DisTDS) / 100;
                        taxableTDS = Math.Round(taxableTDS, 2);
                    }
                    else
                    {
                        if (DisTDS > total)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script> alert('Discount value is greate than total value') </script>", false);
                            txtTds.Focus();
                            return;
                        }
                        DisTDS = decimal.Parse(txtTds.Text.Trim());
                        disCountTDS = DisTDS;
                        disInPer = "No";
                        taxableTDS = total - DisTDS;
                    }
                    #endregion
                    cm.DisInPerTDS = disInPer;
                    cm.TaxableValueTDS = taxableTDS;
                    cm.DiscountValueTDS = disCountTDS;



                    #region Welfare
                    if (chkWel.Checked == true)
                    {
                        if (DisWel > 100)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script> alert('You Enter only atmost 100 value') </script>", false);
                            txtwelfare.Focus();
                            return;
                        }
                        disInPer = "Yes";
                        taxableWel = total - ((total * DisWel) / 100);
                        disCountWel = (total * DisWel) / 100;
                        taxableWel = Math.Round(taxableWel, 2);
                    }
                    else
                    {
                        if (DisWel > total)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script> alert('Discount value is greate than total value') </script>", false);
                            txtTds.Focus();
                            return;
                        }
                        DisWel = decimal.Parse(txtTds.Text.Trim());
                        disCountWel = DisWel;
                        disInPer = "No";
                        taxableWel = total - DisWel;
                    }
                    #endregion
                    cm.Welfare = decimal.Parse(txtwelfare.Text);
                    cm.DisInPerWel = disInPer;
                    cm.TaxableValueWel = taxableWel;
                    cm.DiscountValueWel = disCountWel;

                    #region Charity
                    if (chkCharity.Checked == true)
                    {
                        if (DisChar > 100)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script> alert('You Enter only atmost 100 value') </script>", false);
                            txtCharity.Focus();
                            return;
                        }
                        disInPer = "Yes";
                        taxableChar = total - ((total * DisChar) / 100);
                        disCountChar = (total * DisChar) / 100;
                        taxableChar = Math.Round(taxableChar, 2);
                    }
                    else
                    {
                        if (DisChar > total)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script> alert('Discount value is greate than total value') </script>", false);
                            txtTds.Focus();
                            return;
                        }
                        DisChar = decimal.Parse(txtTds.Text.Trim());
                        disCountChar = DisChar;
                        disInPer = "No";
                        taxableChar = total - DisChar;
                    }
                    #endregion
                    cm.Charity = decimal.Parse(txtCharity.Text);
                    cm.DisInPerChar = disInPer;
                    cm.TaxableValueChar = taxableChar;
                    cm.DiscountValuChar = disCountChar;

                    #region Miscell
                    if (chkMiscell.Checked == true)
                    {
                        if (DisMiscell > 100)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script> alert('You Enter only atmost 100 value') </script>", false);
                            txtMiscell.Focus();
                            return;
                        }
                        disInPer = "Yes";
                        taxableMiscell = total - ((total * DisMiscell) / 100);
                        disCountMiscell = (total * DisMiscell) / 100;
                        taxableMiscell = Math.Round(taxableMiscell, 2);
                    }
                    else
                    {
                        if (DisMiscell > total)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script> alert('Discount value is greate than total value') </script>", false);
                            txtTds.Focus();
                            return;
                        }
                        DisMiscell = decimal.Parse(txtTds.Text.Trim());
                        disCountMiscell = DisMiscell;
                        disInPer = "No";
                        taxableMiscell = total - DisMiscell;
                    }
                    #endregion
                    cm.Miscell = decimal.Parse(txtMiscell.Text);
                    cm.DisInPerMis = disInPer;
                    cm.TaxableValueMis = taxableMiscell;
                    cm.DiscountValMis = disCountMiscell;

                    cm.OtherAmount = decimal.Parse(txtOtherAmount.Text);
                    cm.Save();

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Submit Successfully....');</Script>", false);
                }
                else if (btnsubmit.Text == "Update")
                {
                    cm = PeyoutMaster.GetById(int.Parse(ViewState["id"].ToString()));
                    cm.PeyoutID = int.Parse(ViewState["id"].ToString());
                    //cm.Color_NAME = txtcolor.Text;
                    //cm.REMARK = txtremark.Text;
                    cm.Save();

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<Script>alert('Update Successfully...');</Script>", false);
                }
                ClearInputs(Page.Controls);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert(error);</script>", false);
            }






        }

        protected void linkbtnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void linkbtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void gdvNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void dropActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    USERPROFILEMASTER im = USERPROFILEMASTER.GetByRegistration_ID(int.Parse(dropActive.SelectedValue.ToString()));
            //    lblUserName.Text = im.User_Name;
            //    lblUseId.Text = im.User_ID;
            //    lblBank.Text = im.BankName;
            //    lblAccount.Text = im.AccountNo;
            //    lblIFSC.Text = im.IFSCCode;
            //    lblbranch.Text = im.Branch;
            //}
            //catch (Exception ew) { ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script> alert('" + ew.Message + "') </script>", false); }
        }

        protected void ddlPayPercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetQualifier();
        }
        protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        protected void txtTds_TextChanged(object sender, EventArgs e)
        {
            disCountTDS = string.IsNullOrEmpty(txtTds.Text) ? 0 : Convert.ToDecimal(txtTds.Text);
            Total();
        }
        protected void txtwelfare_TextChanged(object sender, EventArgs e)
        {
            disCountWel = string.IsNullOrEmpty(txtwelfare.Text) ? 0 : Convert.ToDecimal(txtwelfare.Text);
            Total();
        }

        protected void txtCharity_TextChanged(object sender, EventArgs e)
        {
            disCountChar = string.IsNullOrEmpty(txtCharity.Text) ? 0 : Convert.ToDecimal(txtCharity.Text);
            Total();
        }

        protected void txtMiscell_TextChanged(object sender, EventArgs e)
        {
            disCountMiscell = string.IsNullOrEmpty(txtMiscell.Text) ? 0 : Convert.ToDecimal(txtMiscell.Text);
            Total();
        }

        protected void txtOtherAmount_TextChanged(object sender, EventArgs e)
        {
            other = string.IsNullOrEmpty(txtOtherAmount.Text) ? 0 : Convert.ToDecimal(txtOtherAmount.Text);
            Total();
        }
    }
}