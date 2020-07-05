using FBISWebApi.DBAccess;
using FBISWebApi.Models;
using FBISWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace FBISWebApi.Logics
{
    public class Renewal
    {
       readonly Operation dbOperation = new Operation();
        public DataSet GetRenewalDetail(string userId)
        {
            DataSet dtls1 = dbOperation.DDL("sp_GetFormTwoDtls", userId);
            var formTwoLicNo = dtls1.Tables[0].Rows[0]["FAC_LICENSE_NO"];
            DataSet dtls2 = dbOperation.DDL("usersp_FetchRenewalDtls", formTwoLicNo);
            return dtls2;
        }
        public bool InsertRenewal(FormRenewal renewal)
        {
            FolderCreate folder = new FolderCreate();
            FormTwoRenewal form = renewal.Form;
            List<Files> documents = renewal.File;
            bool flag=Convert.ToBoolean(dbOperation.DML("sp_ss_insert_Form2Renewal", form.F2_FAC_ID, form.FAC_DISTRICT, form.FAC_LICENSE_NO, form.LICENSE_YEARS, form.FRM_YR, form.TO_YR, form.FACTORY_NAME, form.FAC_ADD_LINE1, form.FAC_ADD_LINE2, form.FAC_PINCODE, form.FAC_PHONE_NO, form.FAC_MOBILE_NO, form.FAC_EMAIL_ID, form.FAC_POST, form.FAC_TALUK, form.COM_ADD_LINE1, form.COM_ADD_LINE2, form.COM_PINCODE, form.COM_PHONE_NO, form.COM_MOBILE_NO, form.COM_POST, form.COM_TALUK, form.COM_DISTRICT, form.NATURE_OF_MANUFACTURE_NEXT, form.NATURE_OF_MANUFACTURE_PREV, form.PRODUCT_TO_BE_MANUFACTURED, form.PROPOSED_MEN_CNT, form.PROPOSED_WOMEN_CNT, form.PROPOSED_TOTAL_CNT, form.EMPLOYED_MEN_CNT, form.EMPLOYED_WOMEN_CNT, form.EMPLOYED_TOTAL_CNT, form.TOTAL_WORKER_EMPLOYED_MEN, form.TOTAL_WORKER_EMPLOYED_WOMEN, form.TOTAL_WORKER_EMPLOYED, form.POWER_INSTLD, form.PROPOSED_POWER, form.KW_ELEC_FAC, form.MGR_NAME, form.MGR_ADD_LINE1, form.MGR_ADD_LINE2, form.MGR_PINCODE, form.MGR_MOBILE_NO, form.MGR_FATHERNAME, form.MGR_AGE, form.MGR_POST, form.MGR_TALUK, form.MGR_DISTRICT, form.OCCUPIER_NAME, form.OCCUPIER_ADD_LINE1, form.OCCUPIER_ADD_LINE2, form.OCCUPIER_PINCODE, form.OCCUPIER_PHONE_NO, form.OCCUPIER_MOBILE_NO, form.OCCUPIER_FATHERNAME, form.OCCUPIER_AGE, form.OCCUPIER_EMAIL_ID, form.OCCUPIER_POST, form.OCCUPIER_TALUK, form.OCCUPIER_DISTRICT, form.FAC_PREMISES_OWNR_NAME, form.FAC_PREMISES_OWNR_ADD_LINE1, form.FAC_PREMISES_OWNR_ADD_LINE2, form.FAC_PREMISES_OWNR_PINCODE, form.FAC_PREMISES_OWNR_PHONE_NO, form.FAC_PREMISES_OWNR_MOBILE_NO, form.FAC_PREMISES_OWNR_POST, form.FAC_PREMISES_OWNR_TALUK, form.FAC_PREMISES_OWNR_DISTRICT, form.REF_NO_DATE_OF_APPROVAL, form.REF_NO_DATE_OF_TRADE_WASTE, form.AMT_PAID, form.PAID_IN_TO, form.FEE_PAID_DATE, form.CHALLEN_NO, form.userid, form.DIVISION_CD, form.AMT_IN_WORDS));
            DataSet dtls = dbOperation.DDL("usersp_FetchRenewalLicNo", form.FAC_LICENSE_NO);
            var facId = dtls.Tables[0].Rows[0]["FAC_ID"].ToString();
            if (flag)
            {
                flag = folder.CreateDirectory(facId, documents);
            }
            return flag;
        }
        public DataSet GetSubmitFormTwoRenewalData()
        {
            DataSet dtl = dbOperation.DDL("GetDivCodeByApprLogin", "VerBlrD10");
            var Div_cd = dtl.Tables[0].Rows[0]["Div_cd"];
            DataSet dtls = dbOperation.DDL("GetFormTwoRenewalVer", Div_cd, "SI");
            return dtls;
        }
        public DataSet GetVerifiedFormtwoRenewalData()
        {
            DataSet dtl = dbOperation.DDL("GetDivCodeByApprLogin", "VerBlrD10");
            var Div_cd = dtl.Tables[0].Rows[0]["Div_cd"];
            DataSet dtls = dbOperation.DDL("GetFormTwoRenewalVer", Div_cd, "SV");
            return dtls;
        }
        public List<Files> PrintSubmitFormtwoRenewalData(string facId)
        {
            FolderCreate folder = new FolderCreate();
            var list = folder.FetchFiles(facId);
            return list;
        }
        public bool ForwardRenewalVerifier(ForwardRenewal forward)
        {
            bool flag = false;
            var currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            var remarks = currentDate + ": " + forward.Remarks;
            if (forward.Decision == "Reject")
            {
               flag = Convert.ToBoolean(dbOperation.DML("UpdateRenewalDtls", "SR", remarks, forward.Fac_Id));
            }
            else if(forward.Decision == "Approve")
            {
                flag = Convert.ToBoolean(dbOperation.DML("UpdateRenewalDtls", "SA", remarks, forward.Fac_Id));
            }
            else if(forward.Decision == "Seek")
            {
                flag = true;
            }
            return flag;
        }
     }
}