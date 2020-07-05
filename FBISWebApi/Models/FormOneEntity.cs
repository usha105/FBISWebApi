using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBISWebApi.Models
{
    public class Form1Approval
    {
        public FormOneEntity form1 { get; set; }
        public List<Files> File { get; set; }
    }
    public class FormOneEntity
    {
        public string Fac_id { get; set; }

        public string Action { get; set; }
        public string Appname { get; set; }
        public string Designation { get; set; }
        public string App_add_line1 { get; set; }
        public string App_add_line2 { get; set; }
        public string App_post { get; set; }
        public string App_taluk { get; set; }
        public string App_district { get; set; }
        public string App_Pincode { get; set; }
        public string Phone_no { get; set; }
        public string Factory_add_line1 { get; set; }
        public string Factory_add_line2 { get; set; }
        public string Factory_post { get; set; }
        public string Factory_taluk { get; set; }
        public string Factory_district { get; set; }
        public string Factory_pincode { get; set; }
        public string Factory_phone_no { get; set; }
        public string Factory_name { get; set; }
        public string Situation_f_district { get; set; }
        public string Situation_f_town_village { get; set; }
        public string nearest_police_station { get; set; }
        public string nearest_rlystation { get; set; }
        public string buldng_approval { get; set; }
        public string reg_date { get; set; }
        public string Userid { get; set; }
        public int SEQ_NO { get; set; }
        public string division_cd { get; set; }
        public string circle_cd { get; set; }
        public string App_Status { get; set; }
        public string Fac_type { get; set; }
        public string Email_id { get; set; }
        public string App_mob_No1 { get; set; }
        public string App_mob_No2 { get; set; }
        public string CompanyType { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public int Form_id { get; set; }
        public int Total_wrkr_emplyd { get; set; }
        public int Fee_amt { get; set; }
        public string Amt_words { get; set; }
        public string Resubmit_Date { get; set; }
        public string docsrequired { get; set; }
        public string FAC_APPROVAL_NO { get; set; }
        public string FAC_LICENSE_NO { get; set; }
        public string PROB_DT { get; set; }
        public string GSC_NO { get; set; }
        public string GSC_DT { get; set; }
        public string APPR_DT { get; set; }
        public string APPR_REMARKS { get; set; }
        public string Forwarded_divCd { get; set; }
        public string Back_Remarks { get; set; }
        public string doinspection { get; set; }
        public int workerspresent { get; set; }
        public string Conditions { get; set; }
        public string chename1 { get; set; }
        public string chename2 { get; set; }
        public string chename3 { get; set; }
        public string chename4 { get; set; }
        public string chename5 { get; set; }
        public string chename6 { get; set; }
        public string chename7 { get; set; }
        public string chename8 { get; set; }
        public string chename9 { get; set; }
        public string chename10 { get; set; }
        public string cheQua1 { get; set; }
        public string cheQua2 { get; set; }
        public string cheQua3 { get; set; }
        public string cheQua4 { get; set; }
        public string cheQua5 { get; set; }
        public string cheQua6 { get; set; }
        public string cheQua7 { get; set; }
        public string cheQua8 { get; set; }
        public string cheQua9 { get; set; }
        public string cheQua10 { get; set; }

        public string Forward_To { get; set; }
        public string status_of_onsite_emergency { get; set; }
        public string ApplicationNumber { get; set; }
        public string ApprovalSought { get; set; }

        public string isFactoryExistance { get; set; }
        public string ProposedNoMale { get; set; }
        public string ProposedNoWomen { get; set; }
        public string TotalNoProposed { get; set; }
        public string NoofMale { get; set; }
        public string NoofWomen { get; set; }
        public string TotalNooflast { get; set; }
        public string OrdinaryNoMale { get; set; }
        public string OrdinaryNowomen { get; set; }
        public string TotalNoOrdinaryEmployed { get; set; }

        public string PlantsInstalled { get; set; }
        public string TotalHP { get; set; }
        public string KWElectricity { get; set; }
        public string RoofHeight { get; set; }
        public string LightingVentilation { get; set; }
        public string IsCanteen { get; set; }
        public string IsLunchRoom { get; set; }
        public string IsCreche { get; set; }
        public string IsPermisionOfLocalAuthority { get; set; }
        public string IsAmbulance { get; set; }
        public string OccupasionalHealthCare { get; set; }

    }
}