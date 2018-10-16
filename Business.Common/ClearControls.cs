using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Business.Common
{
    public class ClearControls
    {
        #region Reset All Web server Control

        public void ResetFormControlValues(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControlValues(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = "";
                            break;
                        case "System.Web.UI.WebControls.CheckBox":
                            ((CheckBox)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.DropDownList":
                            if (((DropDownList)c).Items.Count > 0)
                            {
                                ((DropDownList)c).SelectedIndex = 0;
                            }
                            break;
                        case "System.Web.UI.WebControls.ListBox":
                            if (((ListBox)c).Items.Count > 0)
                            {
                                ((ListBox)c).SelectedIndex = 0;
                            }
                            break;
                        case "System.Web.UI.WebControls.ListControl":
                            if (((ListControl)c).Items.Count > 0)
                            {
                                ((ListControl)c).SelectedIndex = 0;
                            }
                            break;
                        case "System.Web.UI.WebControls.Panel":
                            if (((Panel)c).Visible == true)
                            {
                                foreach (Control controlPanel in c.Controls)
                                {
                                    if (controlPanel is TextBox)
                                    {
                                        ((TextBox)controlPanel).Text = "";
                                    }
                                    if (controlPanel is ListControl)
                                    {
                                        ((ListControl)controlPanel).SelectedIndex = 0;
                                    }
                                    if (controlPanel is CheckBox)
                                    {
                                        ((CheckBox)controlPanel).Checked = true;
                                    }
                                    if (controlPanel is HtmlInputText)
                                    {
                                        ((HtmlInputText)controlPanel).Value = "";
                                    }
                                    if (controlPanel is FileUpload)
                                    {

                                    }
                                }
                            }
                            break;
                        //case "System.Web.UI.WebControls.DropDownList":
                        // ((DropDownList)c).SelectedValue = "Select";
                        //  break;

                    }
                }
            }
        }

        #endregion
    }
}
