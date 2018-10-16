using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.SQLServer;

namespace Business.Object
{
    public class PaymentMasterCollection : BusinessBaseCollection<PaymentMaster>
    {
        public static PaymentMasterCollection GetAll()
        {
            PaymentMasterCollection obj = new PaymentMasterCollection();
            obj.MapObjects(new PaymentMasterDataSevice().PaymentMasterGetAll());
            return obj;
        }
        public static PaymentMasterCollection GetByPaymemt_ID(int Paymemt_ID)
        {
            PaymentMasterCollection obj = new PaymentMasterCollection();
            obj.MapObjects(new PaymentMasterDataSevice().PaymentMasterGetByPaymemt_ID(Paymemt_ID));
            return obj;
        }
    }
}
