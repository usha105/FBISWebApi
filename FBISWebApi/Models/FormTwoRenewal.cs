using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBISWebApi.Models
{
    public class FormRenewal
    {
        public FormTwoRenewal Form { get; set; }
        public List<Files> File { get; set; }
    }
    public class FormTwoRenewal
    {
        public string FAC_ID { get; set; }
        public string FAC_TYPE { get; set; }
        public string FAC_LICENSE_NO { get; set; }
        public string LICENSE_YEARS { get; set; }
        public int FRM_YR { get; set; }
        public int TO_YR { get; set; }
        public string FACTORY_NAME { get; set; }
        public string FAC_ADD_LINE1 { get; set; }
        public string FAC_ADD_LINE2 { get; set; }
        public string FAC_PINCODE { get; set; }
        public string FAC_PHONE_NO { get; set; }
        public string FAC_MOBILE_NO { get; set; }
        public string FAC_EMAIL_ID { get; set; }
        public string FAC_POST { get; set; }
        public string FAC_TALUK { get; set; }
        public string FAC_DISTRICT { get; set; }
        public string COM_ADD_LINE1 { get; set; }
        public string COM_ADD_LINE2 { get; set; }
        public string COM_PINCODE { get; set; }
        public string COM_PHONE_NO { get; set; }
        public string COM_MOBILE_NO { get; set; }
        public string COM_POST { get; set; }
        public string COM_TALUK { get; set; }
        public string COM_DISTRICT { get; set; }
        public string NATURE_OF_MANUFACTURE_NEXT { get; set; }
        public string NATURE_OF_MANUFACTURE_PREV { get; set; }
        public string PRODUCT_TO_BE_MANUFACTURED { get; set; }
        public int PROPOSED_MEN_CNT { get; set; }
        public int PROPOSED_WOMEN_CNT { get; set; }
        public int PROPOSED_TOTAL_CNT { get; set; }
        public int EMPLOYED_MEN_CNT { get; set; }
        public int EMPLOYED_WOMEN_CNT { get; set; }
        public int EMPLOYED_TOTAL_CNT { get; set; }
        public int TOTAL_WORKER_EMPLOYED_MEN { get; set; }
        public int TOTAL_WORKER_EMPLOYED_WOMEN { get; set; }
        public int TOTAL_WORKER_EMPLOYED { get; set; }
        public string POWER_INSTLD { get; set; }
        public string PROPOSED_POWER { get; set; }
        public string KW_ELEC_FAC { get; set; }
        public string MGR_NAME { get; set; }
        public string MGR_ADD_LINE1 { get; set; }
        public string MGR_ADD_LINE2 { get; set; }
        public string MGR_PINCODE { get; set; }
        public string MGR_PHONE_NO { get; set; }
        public string MGR_MOBILE_NO { get; set; }
        public string MGR_POST { get; set; }
        public string MGR_TALUK { get; set; }
        public string MGR_DISTRICT { get; set; }
        public string OCCUPIER_NAME { get; set; }
        public string OCCUPIER_ADD_LINE1 { get; set; }
        public string OCCUPIER_ADD_LINE2 { get; set; }
        public string OCCUPIER_PINCODE { get; set; }
        public string OCCUPIER_PHONE_NO { get; set; }
        public string OCCUPIER_MOBILE_NO { get; set; }
        public string OCCUPIER_EMAIL_ID { get; set; }
        public string OCCUPIER_POST { get; set; }
        public string OCCUPIER_TALUK { get; set; }
        public string OCCUPIER_DISTRICT { get; set; }
        public string FAC_PREMISES_OWNR_NAME { get; set; }
        public string FAC_PREMISES_OWNR_ADD_LINE1 { get; set; }
        public string FAC_PREMISES_OWNR_ADD_LINE2 { get; set; }
        public string FAC_PREMISES_OWNR_PINCODE { get; set; }
        public string FAC_PREMISES_OWNR_PHONE_NO { get; set; }
        public string FAC_PREMISES_OWNR_MOBILE_NO { get; set; }
        public string FAC_PREMISES_OWNR_POST { get; set; }
        public string FAC_PREMISES_OWNR_TALUK { get; set; }
        public string FAC_PREMISES_OWNR_DISTRICT { get; set; }
        public string REF_NO_DATE_OF_APPROVAL { get; set; }
        public string REF_NO_DATE_OF_TRADE_WASTE { get; set; }
        public string AMT_PAID { get; set; }
        public string PAID_IN_TO { get; set; }
        public string FEE_PAID_DATE { get; set; }
        public string CHALLEN_NO { get; set; }
        public string APP_STATUS { get; set; }
        public string SUBMTD_DATE { get; set; }
        public decimal SEQ_NO { get; set; }
        public string userid { get; set; }
        public string REMARKS { get; set; }
        public string CIRCLE_CD { get; set; }
        public string DIVISION_CD { get; set; }
        public string AMT_IN_WORDS { get; set; }
        public int Form_id { get; set; }
        public string DocsbyDO { get; set; }
        public string Resubmit_Date { get; set; }
        public string License_IssueDt { get; set; }
        public string License_EndDt { get; set; }
        public string F2_FAC_ID { get; set; }
        public string FORWARD_DATE { get; set; }
        public string APPR_REMARKS { get; set; }
        public string Forwarded_divCd { get; set; }
        public string Back_Remarks { get; set; }
        public string comPhoneNumber { get; set; }
        public string comEmailid { get; set; }
        public string MGR_FATHERNAME { get; set; }
        public string MGR_AGE { get; set; }
        public string OCCUPIER_FATHERNAME { get; set; }
        public string OCCUPIER_AGE { get; set; }
        public string Reference_No { get; set; }
        public string Approved_date { get; set; }
        public string Partner_List { get; set; }
    }
}