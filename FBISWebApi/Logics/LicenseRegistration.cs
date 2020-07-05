
using FBISWebApi.DBAccess;
using FBISWebApi.Logics;
using FBISWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
/** Document
 * Done by Anjali 
 */
namespace FBISWebApi.Logics
{
    public class LicenseRegistration
    {
       readonly string appRunningId = Guid.NewGuid().ToString();

        readonly Operation operation = new Operation();
        public FormOneEntity getform1details(string Userid)
        {
            
            FormOneEntity form = new FormOneEntity();
            try
            {
                DataSet ds = operation.DDL("Sp_fetch_Form1_dtls", Userid);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    form.Factory_add_line1 = item[0].ToString();
                    form.Factory_add_line2 = item[1].ToString();
                    form.Factory_pincode = item[2].ToString();
                    form.Factory_phone_no = item[3].ToString();
                    form.App_mob_No2 = item[4].ToString();
                    form.Factory_post = item[5].ToString();
                    form.Factory_taluk = item[6].ToString();
                    form.Factory_district = item[7].ToString();
                    form.Factory_name = item[8].ToString();
                }
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

            }

            return form;
        }

        public bool InsertForm2Details(FormTwoRegistration formReg)
        {
           
                FolderCreate fc = new FolderCreate();
                FormTwoEntity form = formReg.form;
            bool flag = false;
            try
            {
                List<Files> file = formReg.File;

                 flag = Convert.ToBoolean(operation.DML("insert_Form2", form.License_Years, form.From_Year, form.To_Year,
                    form.Factory_Name, form.Fac_Add_Line1, form.Fac_Add_Line2, form.Fac_Pincode, form.Fac_Phone_No, form.Fac_Post, form.Fac_Taluk, form.Fac_District, form.Fac_Mobile_No,
                    form.Fac_Email_Id, form.Com_Add_Line1, form.Com_Add_Line2, form.Com_Pincode, form.Com_Phone_No, form.Com_Post, form.Com_Taluk, form.Com_District, form.Com_Mobile_No,
                    form.Nature_Of_Manufacture_Next, form.Nature_Of_Manufacture_Prev, form.Product_To_Be_Manufactured, form.Proposed_Men_Cnt, form.Proposed_Women_Cnt, form.Proposed_Total_Cnt,
                    form.Employed_Men_Cnt, form.Employed_Women_Cnt, form.Employed_Total_Cnt, form.Total_Worker_Employed_Men, form.Total_Worker_Employed_Women, form.Total_Worker_Employed, form.Power_Installed,
                    form.Proposed_Power, form.Kw_Elec_Fac, form.Manager_Name, form.Mgr_Add_Line1, form.Mgr_Add_Line2, form.Mgr_Pincode, form.Mgr_Phone_No, form.Mgr_Post, form.Mgr_Taluk, form.Mgr_District, form.Mgr_Mobile_No,
                    form.Occupier_Name, form.Occupier_Add_Line1, form.Occupier_Add_Line2, form.Occupier_Pincode, form.Occupier_Phone_No, form.Occupier_Post, form.Occupier_Taluk, form.Occupier_District, form.Occupier_Mobile_No, form.Occupier_Email_Id, form.Fac_Premises_Owner_Name,
                    form.Fac_Premises_Owner_Add_Line1, form.Fac_Premises_Owner_Add_Line2, form.Fac_Premises_Owner_Pincode, form.Fac_Premises_Owner_Phone_No, form.Fac_Premises_Owner_Post, form.Fac_Premises_Owner_Taluk, form.Fac_Premises_Owner_District, form.Fac_Premises_Owner_Mobile_No,
                    form.Ref_No_Date_Of_Approval, form.Ref_No_DAate_Of_Trade_Waste, form.Amount_Paid, form.Paid_In_To, form.Fee_Paid_Date, form.Challen_No, form.Userid, form.Circle_Cd, form.Division_Cd, form.Amount_In_Words, form.CompanyType, form.NIC_Code, form.NIC_Description,
                    form.ASICC_Description, form.Occupier_FatherName, form.Occupier_Age, form.Manager_FatherName, form.Manager_Age));
                if (flag)
                {
                    string str = getFacIdFromForm2Details(form);
                    if (str != null)
                    {
                        flag = Convert.ToBoolean(fc.CreateDirectory(str, file));
                    }
                    else
                    {
                        flag = false;
                    }

                }
            }
            catch(Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

            }
            return flag;

        }

        public string getFacIdFromForm2Details(FormTwoEntity formTwo)
        {
            string Fac_Id = null;
            try
            {
                DataSet ds = operation.DDL("Sp_Get_Form2Details", formTwo.Factory_Name, formTwo.Fac_Pincode);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Fac_Id = item[0].ToString();
                }
               
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

            }
            formTwo.Fac_Id = Fac_Id;
            List<FormTwoEntity> lst = new List<FormTwoEntity>();
            lst.Add(formTwo);
            return Fac_Id;

        }
        public List<CountEntity> getForm2Verifier(string App_Status, string Division_Cd)
        {
            List<CountEntity> lst = new List<CountEntity>();
            try
            {
                DataSet ds = operation.DDL("Sp_get_Form2_details", App_Status, Division_Cd);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var str = new CountEntity
                    {
                        count = item[0].ToString()
                    };
                    lst.Add(str);
                }
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

            }
            return lst;
        }
        
       

        public DataSet getSubmitedForm2Details()
        {
            string Userid = "VerBlrD12";
            DataSet ds = operation.DDL("GetDivCodeByApprLogin", Userid);
            string Div_Cd = ds.Tables[0].Rows[0]["Div_cd"].ToString();
            DataSet ds1 = operation.DDL("GetForm2DetailsByDivCode", Div_Cd, "SI");
            return ds1;
        }
        
        public DataSet getForm2DDVerifier()
        {
            string Userid = "DDFBNG1";
            DataSet ds = operation.DDL("GetDivCodeByApprLogin", Userid);
            string Div_Cd = ds.Tables[0].Rows[0]["Div_cd"].ToString();
            DataSet ds1 = operation.DDL("GetF2DDVerifierDetailsByDivCode", Div_Cd, "SV");
            return ds1;

        }

        public List<FormTwoEntity> getVerifierForward(string Fac_Id)
        {
            List<FormTwoEntity> list = new List<FormTwoEntity>();
            try
            {
                DataSet ds = operation.DDL("sp_get_verifierForm2_dtls", Fac_Id);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var str = new FormTwoEntity
                    {
                        Remarks = item[0].ToString()
                    };
                    list.Add(str);
                }        
                               
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

            }
            return list;
        }

        public bool UpdateVerifier(FormTwoEntity formTwo)
        {
            bool flag = Convert.ToBoolean(operation.DML("usersp_Update_VerifierForm2Details", formTwo.Fac_Id, formTwo.App_Status,formTwo.Revision_Code,formTwo.Remarks));

            return flag;
        }
       
        public List<Files> printSubmitedFormTwoDetail(String Fac_Id)
        {
            List<Files> list;
            FolderCreate folder = new FolderCreate();
            list=folder.FetchFiles(Fac_Id);
            return list;
        }

       }
}