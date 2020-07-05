
using FBISWebApi.DBAccess;
using FBISWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace FBISWebApi.Logics
{
    public class PlanApproval
    {
        private string appRunningId;

        private Operation IOperation;
        
        public bool InsertForm1Details(Form1Approval formApp)
        {
            IOperation = new Operation();
            appRunningId = Guid.NewGuid().ToString();
            FormOneEntity form = formApp.form1;
            FolderCreate fc = new FolderCreate();
            List<Files> file = formApp.File;
            bool flag = Convert.ToBoolean(IOperation.DML("sp_SS_Insert_Form_One", form.Appname, form.Designation, form.App_add_line1, form.App_add_line2, form.App_post, form.App_taluk, form.App_district, form.App_Pincode, form.Phone_no, form.Factory_add_line1, form.Factory_add_line2, form.Factory_post, form.Factory_taluk, form.Factory_district, form.Factory_pincode, form.Factory_phone_no, form.Factory_name, form.Situation_f_district, form.Situation_f_town_village, form.nearest_police_station, form.nearest_rlystation, form.buldng_approval, form.Userid, form.division_cd, form.circle_cd, form.App_mob_No1, form.Email_id, form.App_mob_No2, form.CompanyType, form.Total_wrkr_emplyd, form.Amount, form.Amt_words));
           
            if (flag)
            {
                string str = GetFactId(form);
                if (str != null)
                {
                    flag = Convert.ToBoolean(fc.CreateDirectory(str, file));
                  }
                else
                {
                    flag = false;
                }

            }
            return flag;
        }




        public bool UpdateVerifierForm1Details(FormOneEntity form)
        {
            bool flag = Convert.ToBoolean(IOperation.DML("sp_Updat_Form1ByAppStatus", form.division_cd, form.Forwarded_divCd, form.Remarks,form.Fac_id));
            if (flag)
            {
               
                    flag = true;
                }
                else
                {
                    flag = false;
                }

            
            return flag;
        }


        public bool UpdateApproverForm1Details(FormOneEntity form)
        {
            bool flag = false;
            string Status = null;
            if (form.Action == "Rejected")
            {
                Status = "SR";
                flag = Convert.ToBoolean(IOperation.DML("sp_Update_RejectedForm ", form.Fac_id,Status, form.Remarks));
            }
            else if (form.Action == "Forward")
            {
                if (form.Forward_To == "User")
                {
                    DataSet ds = IOperation.DDL("sp_Get_BacktoUser", form.Fac_id);
                    string FDiv_Cd = ds.Tables[0].Rows[0]["Forwarded_divCd"].ToString();
                    Status = "SI";
                    flag = Convert.ToBoolean(IOperation.DML("sp_Update_BacktoUser", form.Fac_id,Status, FDiv_Cd, form.Remarks));
                }
                else if (form.Forward_To == "Approver")
                {
                    DataSet ds = IOperation.DDL("sp_Get_BacktoApprover", form.Fac_id);
                    string Remarks = ds.Tables[0].Rows[0]["Back_Remarks"].ToString();

                    Status = "SV";
                    flag = Convert.ToBoolean(IOperation.DML("sp_Update_BacktoApprover", form.Fac_id,Status, form.division_cd, Remarks));
                }

            }
            else if (form.Action == "Approve")
            {
                Status = "SA";
                flag = Convert.ToBoolean(IOperation.DML("sp_Update_ApprovedForm1_dtls ", form.Fac_id,Status,form.Remarks, form.ApplicationNumber, form.Conditions));
              
            }
           
            if (flag)
            {
                     flag = true;
                }
                else
                {
                    flag = false;
                }

            
            return flag;
        }

        //By usha on 13/02/2020 to Posting data to sakala
        public string GetFactId(FormOneEntity form)
        {
            string fac_name = form.Factory_name;
            string fac_pincode = form.Factory_pincode;
            string Fac_id = null;
            DataSet ds = IOperation.DDL("Sp_Fac_Id", fac_name, fac_pincode);
            foreach (DataRow item in ds.Tables[0].Rows)
            {

                Fac_id = item[0].ToString();


            }
            return Fac_id;
        }

        //By usha on 13/02/2020 to Update details of plan approval
  
        public string GeneratedGscAck(string Fac_id)
        {
            string GscNO = "";
            int seq_no = 0;
            string softcode = "01";
            try
            {
                DataSet ds = IOperation.DDL("Sp_GetSeqNo", Fac_id);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    seq_no = Convert.ToInt32(item[0]);
                }


                string runningSerialNo = string.Format("{0:D5}", seq_no);
                GscNO = "IS0" + softcode + "00000" + runningSerialNo;


            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

            }

            return GscNO;
        }
  
        public string gscDate()
        {
            DateTime date = DateTime.Now;
            string regDate = date.ToString("dd/MM/yyyy");
                                                         
            return regDate;
        }

        public string dueDateFactory()
        {
            appRunningId = Guid.NewGuid().ToString();
            DateTime dt = DateTime.Now;
string s2 = "";
            int count = 0;




            for (int i = 0; i <= 200; i++)
            {
                count++;

                try
                {

                    DateTime dt2;
                    dt2 = dt.AddDays(1);
                    dt = dt2;
                    if (count >= 90)
                    {
                        s2 = dt2.ToString("dd/MM/yyy");




                        break;
                    }
                }
                catch (Exception e)
                {
                    Log log = new Log();
                    log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

                }

            }

            return s2;
        }


        public DataSet getSubmitedForm1Details(string userid)
        {
            DataSet ds = IOperation.DDL("GetDivCodeByApprLogin", userid);
            string Div_Cd = ds.Tables[0].Rows[0]["Div_cd"].ToString();
            DataSet ds1 = IOperation.DDL("sp_Get_DetailsByAppStatus", Div_Cd, "SV");
            return ds1;
        }


        public DataSet getSubmitedVForm1Details(string userid)
        {
            DataSet ds = IOperation.DDL("GetDivCodeByApprLogin", userid);
            string Div_Cd = ds.Tables[0].Rows[0]["Div_cd"].ToString();
            DataSet ds1 = IOperation.DDL("sp_Get_DetailsByAppStatus", Div_Cd, "SI");
            return ds1;
        }




    }
}