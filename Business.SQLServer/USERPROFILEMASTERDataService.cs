using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Common;
using System.Data.SqlClient;
using System.Data;

namespace Business.SQLServer
{
    public class USERPROFILEMASTERDataService : DataServiceBase
    {
        #region Consturctor
        public USERPROFILEMASTERDataService() : base() { }
        public USERPROFILEMASTERDataService(IDbTransaction txn) : base(txn) { }
        #endregion
        #region Methods
        public void USERPROFILEMASTER_Save(int Registration_ID, string First_Name, string Last_Name, string Email, string User_Name, string User_ID, string Password, DateTime DOB, string ContactNumber,
                                           string NomineeName, string NomineeId, string NomineeRelation, string Reference_Id, DateTime RegDate, string COUNTRY, string Individual_Company, string IdentificationType,
                                           string TaxExempt, string Commission, string WFile, DateTime AnniversaryDate, DateTime SmartDeliveryDate, string Website, string Address, string AddressLine2, int City,
                                           int State, string StateOther, string ZipCode, string ShippingFirstName, string ShippingLastName, string ShippingAddress, string ShippingAddressLine2, int ShippingCity,
                                           int ShippingState, string ShippingZip, string ShippingStateOther, string AlternativeNumber, string Fax, string Co_Applicant, string Language, string Skype, string Twitter,
                                           string Facebook, string AadharVerified, string AadharImage, string PanVerified, string PanImage, string ChequeVerified, string ChequeImage, string GstinVerified,
                                           string AddressVerified, string AddressImage, string Image_Name, string Status, string BankName, string AccountNo, string IFSCCode, string Branch, int? UserParentId, decimal UserWallet)
        {
            SqlCommand cmd;
            // NoofPaper,NoofPratical,MaxMarks,MinMarks,
            DataSet ds = USERPROFILEMASTER_GetByRegistration_ID(Registration_ID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExecuteNonQuery(out cmd, @"UPDATE USERPROFILEMASTER set First_Name=@First_Name,Last_Name=@Last_Name, Email=@Email, User_Name=@User_Name, User_ID=@User_ID, Password=@Password, DOB=@DOB, ContactNumber=@ContactNumber, NomineeName=@NomineeName,NomineeId=@NomineeId,NomineeRelation=@NomineeRelation,
                                                                        Reference_Id=@Reference_Id, RegDate=@RegDate,COUNTRY=@COUNTRY,Individual_Company=@Individual_Company,IdentificationType=@IdentificationType,TaxExempt=@TaxExempt,Commission=@Commission,WFile=@WFile,AnniversaryDate=@AnniversaryDate,SmartDeliveryDate=@SmartDeliveryDate,
                                                                        Website=@Website,Address=@Address,AddressLine2=@AddressLine2,City=@City,State=@State,StateOther=@StateOther,ZipCode=@ZipCode,ShippingFirstName=@ShippingFirstName,ShippingLastName=@ShippingLastName,ShippingAddress=@ShippingAddress,ShippingAddressLine2=@ShippingAddressLine2,
                                                                        ShippingCity=@ShippingCity,ShippingState=@ShippingState,ShippingZip=@ShippingZip,ShippingStateOther=@ShippingStateOther,AlternativeNumber=@AlternativeNumber,Fax=@Fax,Co_Applicant=@Co_Applicant,Language=@Language,Skype=@Skype,Twitter=@Twitter,Facebook=@Facebook,
                                                                        AadharVerified=@AadharVerified,AadharImage=@AadharImage,PanVerified=@PanVerified,PanImage=@PanImage,ChequeVerified=@ChequeVerified,ChequeImage=@ChequeImage,GstinVerified=@GstinVerified, AddressVerified=@AddressVerified,AddressImage=@AddressImage,Image_Name=@Image_Name,
                                                                        Status=@Status,BankName=@BankName,AccountNo=@AccountNo,IFSCCode=@IFSCCode,Branch=@Branch,UserParentId=@UserParentId,UserWallet=@UserWallet where Registration_ID=@Registration_ID",
                         CreateParameter("@First_Name", SqlDbType.VarChar, First_Name),
                         CreateParameter("@Last_Name", SqlDbType.VarChar, Last_Name),
                         CreateParameter("@Email", SqlDbType.VarChar, Email),
                         CreateParameter("@User_Name", SqlDbType.VarChar, User_Name),
                         CreateParameter("@User_ID", SqlDbType.VarChar, User_ID),
                         CreateParameter("@Password", SqlDbType.VarChar, Password),
                         CreateParameter("@DOB", SqlDbType.DateTime, DOB),
                         CreateParameter("@ContactNumber", SqlDbType.VarChar, ContactNumber),
                         CreateParameter("@NomineeName", SqlDbType.VarChar, NomineeName),
                         CreateParameter("@NomineeId", SqlDbType.VarChar, NomineeId),
                         CreateParameter("@NomineeRelation", SqlDbType.VarChar, NomineeRelation),
                         CreateParameter("@Reference_Id", SqlDbType.VarChar, Reference_Id),
                         CreateParameter("@RegDate", SqlDbType.DateTime, RegDate),
                         CreateParameter("@COUNTRY", SqlDbType.VarChar, COUNTRY),
                         CreateParameter("@Individual_Company", SqlDbType.VarChar, Individual_Company),
                         CreateParameter("@IdentificationType", SqlDbType.VarChar, IdentificationType),
                         CreateParameter("@TaxExempt", SqlDbType.VarChar, TaxExempt),
                         CreateParameter("@Commission", SqlDbType.VarChar, Commission),
                         CreateParameter("@WFile", SqlDbType.VarChar, WFile),
                         CreateParameter("@AnniversaryDate", SqlDbType.DateTime, AnniversaryDate),
                         CreateParameter("@SmartDeliveryDate", SqlDbType.DateTime, SmartDeliveryDate),
                         CreateParameter("@Website", SqlDbType.VarChar, Website),
                         CreateParameter("@Address", SqlDbType.VarChar, Address),
                         CreateParameter("@AddressLine2", SqlDbType.VarChar, AddressLine2),
                         CreateParameter("@City", SqlDbType.Int, City),
                         CreateParameter("@State", SqlDbType.Int, State),
                         CreateParameter("@StateOther", SqlDbType.VarChar, StateOther),
                         CreateParameter("@ZipCode", SqlDbType.VarChar, ZipCode),
                         CreateParameter("@ShippingFirstName", SqlDbType.VarChar, ShippingFirstName),
                         CreateParameter("@ShippingLastName", SqlDbType.VarChar, ShippingLastName),
                         CreateParameter("@ShippingAddress", SqlDbType.VarChar, ShippingAddress),
                         CreateParameter("@ShippingAddressLine2", SqlDbType.VarChar, ShippingAddressLine2),
                         CreateParameter("@ShippingCity", SqlDbType.Int, ShippingCity),
                         CreateParameter("@ShippingState", SqlDbType.Int, ShippingState),
                         CreateParameter("@ShippingZip", SqlDbType.VarChar, ShippingZip),
                         CreateParameter("@ShippingStateOther", SqlDbType.VarChar, ShippingStateOther),
                         CreateParameter("@AlternativeNumber", SqlDbType.VarChar, AlternativeNumber),
                         CreateParameter("@Fax", SqlDbType.VarChar, Fax),
                         CreateParameter("@Co_Applicant", SqlDbType.VarChar, Co_Applicant),
                         CreateParameter("@Language", SqlDbType.VarChar, Language),
                         CreateParameter("@Skype", SqlDbType.VarChar, Skype),
                         CreateParameter("@Twitter", SqlDbType.VarChar, Twitter),
                         CreateParameter("@Facebook", SqlDbType.VarChar, Facebook),
                         CreateParameter("@AadharVerified", SqlDbType.VarChar, AadharVerified),
                         CreateParameter("@AadharImage", SqlDbType.VarChar, AadharImage),
                         CreateParameter("@PanVerified", SqlDbType.VarChar, PanVerified),
                         CreateParameter("@PanImage", SqlDbType.VarChar, PanImage),
                         CreateParameter("@ChequeVerified", SqlDbType.VarChar, ChequeVerified),
                         CreateParameter("@ChequeImage", SqlDbType.VarChar, ChequeImage),
                         CreateParameter("@GstinVerified", SqlDbType.VarChar, GstinVerified),
                         CreateParameter("@AddressVerified", SqlDbType.VarChar, AddressVerified),
                         CreateParameter("@AddressImage", SqlDbType.VarChar, AddressImage),
                         CreateParameter("@Image_Name", SqlDbType.VarChar, Image_Name),
                         CreateParameter("@Status", SqlDbType.VarChar, Status),
                         CreateParameter("@BankName", SqlDbType.VarChar, BankName),
                         CreateParameter("@AccountNo", SqlDbType.VarChar, AccountNo),
                         CreateParameter("@IFSCCode", SqlDbType.VarChar, IFSCCode),
                         CreateParameter("@Branch", SqlDbType.VarChar, Branch),
                         CreateParameter("@UserParentId", SqlDbType.Int, UserParentId),
                           CreateParameter("@UserWallet", SqlDbType.Decimal, UserWallet),
                         CreateParameter("@Registration_ID", SqlDbType.Int, Registration_ID));
            }
            else
            {
                ExecuteNonQuery(out cmd, @"INSERT INTO USERPROFILEMASTER(Registration_ID,First_Name,Last_Name, Email, User_Name, User_ID, Password, DOB,ContactNumber, NomineeName,NomineeId,NomineeRelation,
                                                                        Reference_Id, RegDate,COUNTRY,Individual_Company,IdentificationType,TaxExempt,Commission,WFile,AnniversaryDate,SmartDeliveryDate,
                                                                        Website,Address,AddressLine2,City,State,StateOther,ZipCode,ShippingFirstName,ShippingLastName,ShippingAddress,ShippingAddressLine2,
                                                                        ShippingCity,ShippingState,ShippingZip,ShippingStateOther,AlternativeNumber,Fax,Co_Applicant,Language,Skype,Twitter,Facebook,
                                                                        AadharVerified,AadharImage,PanVerified,PanImage,ChequeVerified,ChequeImage,GstinVerified, AddressVerified,AddressImage,Image_Name,
                                                                        Status,BankName,AccountNo,IFSCCode,Branch,UserParentId,UserWallet)
                                                                VALUES (@Registration_ID,@First_Name,@Last_Name, @Email, @User_Name,@User_ID,  @Password, @DOB, @ContactNumber, @NomineeName,@NomineeId,@NomineeRelation,@Reference_Id,@RegDate,@COUNTRY,
                                                                        @Individual_Company,@IdentificationType,@TaxExempt,@Commission,@WFile,@AnniversaryDate,@SmartDeliveryDate,
                                                                        @Website,@Address,@AddressLine2,@City,@State,@StateOther,@ZipCode,@ShippingFirstName,
                                                                        @ShippingLastName,@ShippingAddress,@ShippingAddressLine2,@ShippingCity,@ShippingState,@ShippingZip,@ShippingStateOther,@AlternativeNumber,@Fax,
                                                                        @Co_Applicant,@Language,@Skype,@Twitter,@Facebook,@AadharVerified,@AadharImage,@PanVerified,@PanImage,@ChequeVerified,@ChequeImage,@GstinVerified, @AddressVerified,@AddressImage,@Image_Name,
                                                                        @Status,@BankName,@AccountNo,@IFSCCode,@Branch,@UserParentId,@UserWallet)",
                         CreateParameter("@Registration_ID", SqlDbType.Int, Registration_ID),
                         CreateParameter("@First_Name", SqlDbType.VarChar, First_Name),
                        CreateParameter("@Last_Name", SqlDbType.VarChar, Last_Name),
                         CreateParameter("@Email", SqlDbType.VarChar, Email),
                         CreateParameter("@User_Name", SqlDbType.VarChar, User_Name),
                         CreateParameter("@User_ID", SqlDbType.VarChar, User_ID),
                         CreateParameter("@Password", SqlDbType.VarChar, Password),
                         CreateParameter("@DOB", SqlDbType.DateTime, DOB),
                         CreateParameter("@ContactNumber", SqlDbType.VarChar, ContactNumber),
                         CreateParameter("@NomineeName", SqlDbType.VarChar, NomineeName),
                         CreateParameter("@NomineeId", SqlDbType.VarChar, NomineeId),
                         CreateParameter("@NomineeRelation", SqlDbType.VarChar, NomineeRelation),
                         CreateParameter("@Reference_Id", SqlDbType.VarChar, Reference_Id),
                         CreateParameter("@RegDate", SqlDbType.DateTime, RegDate),
                         CreateParameter("@COUNTRY", SqlDbType.VarChar, COUNTRY),
                         CreateParameter("@Individual_Company", SqlDbType.VarChar, Individual_Company),
                         CreateParameter("@IdentificationType", SqlDbType.VarChar, IdentificationType),
                         CreateParameter("@TaxExempt", SqlDbType.VarChar, TaxExempt),
                         CreateParameter("@Commission", SqlDbType.VarChar, Commission),
                         CreateParameter("@WFile", SqlDbType.VarChar, WFile),
                         CreateParameter("@AnniversaryDate", SqlDbType.DateTime, AnniversaryDate),
                         CreateParameter("@SmartDeliveryDate", SqlDbType.DateTime, SmartDeliveryDate),
                         CreateParameter("@Website", SqlDbType.VarChar, Website),
                         CreateParameter("@Address", SqlDbType.VarChar, Address),
                         CreateParameter("@AddressLine2", SqlDbType.VarChar, AddressLine2),
                         CreateParameter("@City", SqlDbType.Int, City),
                         CreateParameter("@State", SqlDbType.Int, State),
                         CreateParameter("@StateOther", SqlDbType.VarChar, StateOther),
                         CreateParameter("@ZipCode", SqlDbType.VarChar, ZipCode),
                         CreateParameter("@ShippingFirstName", SqlDbType.VarChar, ShippingFirstName),
                         CreateParameter("@ShippingLastName", SqlDbType.VarChar, ShippingLastName),
                         CreateParameter("@ShippingAddress", SqlDbType.VarChar, ShippingAddress),
                         CreateParameter("@ShippingAddressLine2", SqlDbType.VarChar, ShippingAddressLine2),
                         CreateParameter("@ShippingCity", SqlDbType.Int, ShippingCity),
                         CreateParameter("@ShippingState", SqlDbType.Int, ShippingState),
                         CreateParameter("@ShippingZip", SqlDbType.VarChar, ShippingZip),
                         CreateParameter("@ShippingStateOther", SqlDbType.VarChar, ShippingStateOther),
                         CreateParameter("@AlternativeNumber", SqlDbType.VarChar, AlternativeNumber),
                         CreateParameter("@Fax", SqlDbType.VarChar, Fax),
                         CreateParameter("@Co_Applicant", SqlDbType.VarChar, Co_Applicant),
                         CreateParameter("@Language", SqlDbType.VarChar, Language),
                         CreateParameter("@Skype", SqlDbType.VarChar, Skype),
                         CreateParameter("@Twitter", SqlDbType.VarChar, Twitter),
                         CreateParameter("@Facebook", SqlDbType.VarChar, Facebook),
                        CreateParameter("@AadharVerified", SqlDbType.VarChar, AadharVerified),
                         CreateParameter("@AadharImage", SqlDbType.VarChar, AadharImage),
                         CreateParameter("@PanVerified", SqlDbType.VarChar, PanVerified),
                         CreateParameter("@PanImage", SqlDbType.VarChar, PanImage),
                         CreateParameter("@ChequeVerified", SqlDbType.VarChar, ChequeVerified),
                         CreateParameter("@ChequeImage", SqlDbType.VarChar, ChequeImage),
                         CreateParameter("@GstinVerified", SqlDbType.VarChar, GstinVerified),
                         CreateParameter("@AddressVerified", SqlDbType.VarChar, AddressVerified),
                         CreateParameter("@AddressImage", SqlDbType.VarChar, AddressImage),
                         CreateParameter("@Image_Name", SqlDbType.VarChar, Image_Name),
                         CreateParameter("@Status", SqlDbType.VarChar, Status),
                         CreateParameter("@BankName", SqlDbType.VarChar, BankName),
                         CreateParameter("@AccountNo", SqlDbType.VarChar, AccountNo),
                         CreateParameter("@IFSCCode", SqlDbType.VarChar, IFSCCode),
                         CreateParameter("@Branch", SqlDbType.VarChar, Branch),
                         CreateParameter("@UserParentId", SqlDbType.Int, UserParentId),
                             CreateParameter("@UserWallet", SqlDbType.Decimal, UserWallet));
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
        }

        //public DataSet USERPROFILEMASTER_GetByUser_Name(string User_Name)
        //{
        //    return ExecuteDataSet("select * from USERPROFILEMASTER where User_Name=@User_Name", null,
        //    CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        //}

        public DataSet USERPROFILEMASTER_GetAll()
        {
            return ExecuteDataSet("select * from USERPROFILEMASTER  ", null, null);
        }

        public DataSet USERPROFILEMASTER_GetByRegistration_ID(int Registration_ID)
        {
            return ExecuteDataSet("select * from USERPROFILEMASTER where Registration_ID=@Registration_ID", null,
                CreateParameter("@Registration_ID", SqlDbType.Int, Registration_ID));
        }
        public DataSet USERPROFILEMASTERGetByReference_Id(string Reference_Id)
        {
            return ExecuteDataSet("select * from USERPROFILEMASTER where Reference_Id=@Reference_Id", null,
                CreateParameter("@Reference_Id", SqlDbType.VarChar, Reference_Id));
        }
        public DataSet User_Name_And_Password(string User_Name, string Password)
        {
            return ExecuteDataSet("select * from USERPROFILEMASTER where User_Name=@User_Name and Password=@Password", null,
                CreateParameter("@User_Name", SqlDbType.VarChar, User_Name),
                CreateParameter("@Password", SqlDbType.VarChar, Password));
        }
        public DataSet User_GetByquestionand_answer(string User_Name, string QUESTION, string ANSWER)
        {
            return ExecuteDataSet("select * from USERPROFILEMASTER where QUESTION=@QUESTION and ANSWER=@ANSWER and User_Name=@User_Name", null,
                CreateParameter("@QUESTION", SqlDbType.VarChar, QUESTION),
            CreateParameter("@ANSWER", SqlDbType.VarChar, ANSWER),
            CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        }
        public DataSet UserMasterGetByPASSWORD(string Password)
        {
            return ExecuteDataSet("select * from USERPROFILEMASTER where Password=@Password", null,
                CreateParameter("@Password", SqlDbType.VarChar, Password));
        }

        public DataSet USERPROFILEMASTERGetByUser_Name(string User_Name)
        {
            return ExecuteDataSet("select * from USERPROFILEMASTER where User_Name=@User_Name", null,
            CreateParameter("@User_Name", SqlDbType.VarChar, User_Name));
        }
        public DataSet USERPROFILEMASTERGetByEmail(string Email)
        {
            return ExecuteDataSet("select * from USERPROFILEMASTER where Email=@Email", null,
            CreateParameter("@Email", SqlDbType.VarChar, Email));
        }
        public void GetByUpdate_PASSWORD(int Registration_ID, string Password)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "update USERPROFILEMASTER set [Password]=@Password where [Registration_ID]=@Registration_ID",
                  CreateParameter("@Password", SqlDbType.VarChar, Password),
                  CreateParameter("@Registration_ID", SqlDbType.Int, Registration_ID));
        }
        public void GetByWalletRecharge(int Registration_ID, decimal UserWallet)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "update USERPROFILEMASTER set [UserWallet]=@UserWallet where [Registration_ID]=@Registration_ID",
                  CreateParameter("@UserWallet", SqlDbType.Decimal, UserWallet),
                  CreateParameter("@Registration_ID", SqlDbType.Int, Registration_ID));
        }
        public DataSet USERPROFILEMASTER_GetMAXId()
        {
            return ExecuteDataSet("select max(Registration_ID)  from USERPROFILEMASTER", null, null);
        }

        public DataSet USERPROFILEMASTER_Delete(int Registration_ID)
        {
            return ExecuteDataSet("Delete from USERPROFILEMASTER where Registration_ID=@Registration_ID", null,
            CreateParameter("@Registration_ID", SqlDbType.Int, Registration_ID));
        }

        #endregion
    }
}

