using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.PickUp
{
    public partial class frmProfileUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillstate();
                Member_detail(int.Parse(Session["PickupID"].ToString()));
                decimal Am = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).PickUpWallet;
                lblWallet.Text = Am.ToString();
            }
        }
        public void fillstate()
        {
            try
            {
                List<StateMaster> _state = StateMasterCollection.GetAll();
                StateMaster sm = new StateMaster();
                sm.STATE_ID = 0;
                sm.STATE_NAME = "-select state-";
                _state.Insert(0, sm);
                DropState.DataSource = _state;
                DropState.DataTextField = "STATE_NAME";
                DropState.DataValueField = "STATE_ID";
                DropState.DataBind();
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }
        public void fillcity()
        {
            List<CityMaster> _city = CityMasterCollection.GetAll().Where(x => x.STATE_ID == int.Parse(DropState.SelectedValue.ToString())).OrderBy(x => x.CITY_NAME).ToList();
            CityMaster cm = new CityMaster();
            cm.CITY_ID = 0;
            cm.CITY_NAME = "-Select City-";
            _city.Insert(0, cm);
            DropCity.DataSource = _city;
            DropCity.DataTextField = "CITY_NAME";
            DropCity.DataValueField = ("CITY_ID");
            DropCity.DataBind();

        }
        public void Member_detail(int MID)
        {
            try
            {
                PickupMaster drms = PickupMaster.GetByPickupID((int.Parse(Session["PickupID"].ToString())));
                if (drms.PickupID > 0)
                {
                    #region
                    txtFname.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).FirstName;
                    txtLName.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).LastName;
                    lblUsername.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).UserName;
                    lblCname.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).CenterName;
                    lblCCode.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).CenterCode;
                    txtadd.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).Address;
                    txtPincode.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).Pincode;
                    txtContact.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).ContactNo;
                    txtAlternate1.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).Alternate1;
                    txtAlternate2.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).Alternate2;
                    txtgst.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).GstinNo;
                    lblRegdate.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).Regdate.ToShortDateString();
                    lblstatus.Text = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).Status;
                    DropState.SelectedIndex = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).State;
                    fillcity();
                    DropCity.SelectedIndex = PickupMaster.GetByPickupID(int.Parse(Session["PickupID"].ToString())).City;

                    #endregion
                }
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
            }
        }

        protected void DropState_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillcity();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            #region
            PickupMaster um = new PickupMaster();
            um.PickupID = int.Parse(Session["PickupID"].ToString());
            um.FirstName = txtFname.Text.Trim();
            um.LastName = txtLName.Text.Trim();
            um.UserName = lblUsername.Text.Trim();
            um.Password = PickupMaster.GetByPickupID(um.PickupID).Password;
            um.CenterName = lblCname.Text.Trim();
            um.CenterCode = lblCCode.Text.Trim();
            um.Address = txtadd.Text.Trim();
            um.Pincode = txtPincode.Text;
            um.City = DropCity.SelectedIndex;
            um.State = DropState.SelectedIndex;
            um.ContactNo = txtContact.Text.Trim();
            um.Alternate1 = txtAlternate1.Text.Trim();
            um.Alternate2 = txtAlternate2.Text.Trim();
            um.GstinNo = txtgst.Text.Trim();
            um.Regdate = PickupMaster.GetByPickupID(um.PickupID).Regdate;
            um.Status = PickupMaster.GetByPickupID(um.PickupID).Status;
            um.Action = PickupMaster.GetByPickupID(um.PickupID).Action;
            um.PickUpWallet = PickupMaster.GetByPickupID(um.PickupID).PickUpWallet;
            um.Save();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Save Sucessfull...!!');</script>", false);
            Response.Redirect("frmProfileUpdate.aspx");
        }
        #endregion
    }
}