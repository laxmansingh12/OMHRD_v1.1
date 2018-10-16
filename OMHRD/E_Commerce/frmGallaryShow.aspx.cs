using Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMHRD.E_Commerce
{
    public partial class frmGallaryShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                FIllGallery();
            }
        }
        public void FIllGallery()
        {
            List<GallaryMaster> fp = GallarymasterCollection.GetAll().OrderByDescending(x => x.Id).ToList();
            if (fp.Count > 0)
            {
                ListView1.DataSource = fp;
                ListView1.DataBind();
            }
        }
    }
}