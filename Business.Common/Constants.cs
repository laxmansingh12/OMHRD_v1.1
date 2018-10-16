using System;
using System.Web.UI.WebControls;
using System.Web;

namespace Business.Common
{
    public sealed class Constants
    {
        public static string NullString = string.Empty;
        public static DateTime NullDateTime = DateTime.MinValue;
        public static decimal NullDecimal = decimal.MinValue;
        public static int NullInt = int.MinValue;
        public static long NullLong = long.MinValue;
        public static float NullFloat = float.MinValue;
        public static double NullDouble = double.MinValue;
        public static char NullChar = char.MinValue;
        public static byte[] NullByteArray = null;
        public static Guid NullGuid = Guid.Empty;
        // Maximum DateTime value allowed by SQL Server
        public static DateTime SqlMaxDate = new DateTime(9999, 1, 3, 23, 59, 59);
        
        // Minimum DateTime valsue allowed by SQL Server
        public static DateTime SqlMinDate = new DateTime(1753, 1, 1, 00, 00, 00);
 

    }

    public sealed class Util
    {

        public static string GetstringFormattedDate(DateTime newDate)
        {
            string[] NewDate = newDate.GetDateTimeFormats();
            string DateFormat = NewDate[0];
            return DateFormat;
        }
        public static int  ConvertToInt32(string strVal)
        {
            int defaultVal = 0;
            try
            {
                defaultVal = Convert.ToInt32(strVal);

            }
            catch (Exception ex)
            {
            }
            return defaultVal;
        }
        public static DateTime stringToDate(string strDt, char[] separator)
        {
            string[] dateparts1;
            dateparts1 = strDt.Split(separator);
            DateTime sdate = new DateTime(Convert.ToInt32(dateparts1[2]), Convert.ToInt32(dateparts1[1]), Convert.ToInt32(dateparts1[0]));
            return sdate;
        }
        public static DateTime stringToDate(string strDt)
        {
            return stringToDate(strDt, new char[] { '-', '/' });

        }
        public static string DateToString(DateTime dt)
        {

            string strDt = Convert.ToString(dt.Day) + "/" + Convert.ToString(dt.Month) + "/" + Convert.ToString(dt.Year);
            return strDt;
        }
        public static string DateToString1(DateTime dt)
        {

            string strDt = Convert.ToString(dt.Day) + "-" + Convert.ToString(dt.Month) + "-" + Convert.ToString(dt.Year);
            return strDt;
        }
             
    }
    public sealed class CommonFunction
    {
        public static bool IsCheckBoxChecked(GridView gvr, string chkName)
        {
            foreach (GridViewRow grdVwRow in gvr.Rows)
            {
                CheckBox chkTenderWork = (CheckBox)grdVwRow.FindControl(chkName);
                if (chkTenderWork.Checked)
                    return true;
            }
            return false;
        }

        public static string BaseURL
        {
            get
            {
                try
                {
                    return string.Format("http://{0}{1}",
                                         HttpContext.Current.Request.ServerVariables["HTTP_HOST"],
                                         (VirtualFolder.Equals("/")) ? string.Empty : VirtualFolder);
                }
                catch
                {
                    // This is for design time
                    return null;
                }
            }
        }

        /// <summary>
        /// Returns the name of the virtual folder where our project lives
        /// </summary>
        private static string VirtualFolder
        {
            get { return HttpContext.Current.Request.ApplicationPath; }
        }
    }


}
