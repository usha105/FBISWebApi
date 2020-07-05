using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FBISWebApi.Models;

namespace FBISWebApi.Models
{
    public class FormTwoRegistration
    {
         public FormTwoEntity form { get; set; }
        public List<Files> File { get; set; }
    }
    public class FormTwoEntity
    {
        public string Fac_Id { get; set; }
        public string Fac_Type { get; set; }
        public string Fac_License_No { get; set; }
        public string License_Years { get; set; }
        public int From_Year { get; set; }
        public int To_Year { get; set; }
        public string Factory_Name { get; set; }
        public string Fac_Add_Line1 { get; set; }
        public string Fac_Add_Line2 { get; set; }
        public string Fac_Pincode { get; set; }
        public string Fac_Phone_No { get; set; }
        public string Fac_Mobile_No { get; set; }
        public string Fac_Email_Id { get; set; }
        public string Fac_Post { get; set; }
        public string Fac_Taluk { get; set; }
        public string Fac_District { get; set; }
        public string Com_Add_Line1 { get; set; }
        public string Com_Add_Line2 { get; set; }
        public string Com_Pincode { get; set; }
        public string Com_Phone_No { get; set; }
        public string Com_Mobile_No { get; set; }
        public string Com_Post { get; set; }
        public string Com_Taluk { get; set; }
        public string Com_District { get; set; }
        public string Nature_Of_Manufacture_Next { get; set; }
        public string Nature_Of_Manufacture_Prev { get; set; }
        public string Product_To_Be_Manufactured { get; set; }
        public int Proposed_Men_Cnt { get; set; }
        public int Proposed_Women_Cnt { get; set; }
        public int Proposed_Total_Cnt { get; set; }
        public int Employed_Men_Cnt { get; set; }
        public int Employed_Women_Cnt { get; set; }
        public int Employed_Total_Cnt { get; set; }
        public int Total_Worker_Employed_Men { get; set; }
        public int Total_Worker_Employed_Women { get; set; }
        public int Total_Worker_Employed { get; set; }
        public string Power_Installed { get; set; }
        public string Proposed_Power { get; set; }
        public string Kw_Elec_Fac { get; set; }
        public string Mgr_Name { get; set; }
        public string Mgr_Add_Line1 { get; set; }
        public string Mgr_Add_Line2 { get; set; }
        public string Mgr_Pincode { get; set; }
        public string Mgr_Phone_No { get; set; }
        public string Mgr_Mobile_No { get; set; }
        public string Mgr_Post { get; set; }
        public string Mgr_Taluk { get; set; }
        public string Mgr_District { get; set; }
        public string Occupier_Name { get; set; }
        public string Occupier_Add_Line1 { get; set; }
        public string Occupier_Add_Line2 { get; set; }
        public string Occupier_Pincode { get; set; }
        public string Occupier_Phone_No { get; set; }
        public string Occupier_Mobile_No { get; set; }
        public string Occupier_Email_Id { get; set; }
        public string Occupier_Post { get; set; }
        public string Occupier_Taluk { get; set; }
        public string Occupier_District { get; set; }
        public string Fac_Premises_Owner_Name { get; set; }
        public string Fac_Premises_Owner_Add_Line1 { get; set; }
        public string Fac_Premises_Owner_Add_Line2 { get; set; }
        public string Fac_Premises_Owner_Pincode { get; set; }
        public string Fac_Premises_Owner_Phone_No { get; set; }
        public string Fac_Premises_Owner_Mobile_No { get; set; }
        public string Fac_Premises_Owner_Post { get; set; }
        public string Fac_Premises_Owner_Taluk { get; set; }
        public string Fac_Premises_Owner_District { get; set; }
        public string Ref_No_Date_Of_Approval { get; set; }
        public string Ref_No_DAate_Of_Trade_Waste { get; set; }
        public string Amount_Paid { get; set; }
        public string Paid_In_To { get; set; }
        public string Fee_Paid_Date { get; set; }
        public string Challen_No { get; set; }
        public string App_Status { get; set; }
        public DateTime Submited_Date { get; set; }
        public decimal Seq_No { get; set; }
        public string Userid { get; set; }
        public string Remarks { get; set; }
        public string Circle_Cd { get; set; }
        public string Division_Cd { get; set; }
        public string Amount_In_Words { get; set; }
        public short Form_id { get; set; }
        public string DocsbyDO { get; set; }
        public DateTime Resubmit_Date { get; set; }
        public string License_IssueDt { get; set; }
        public string License_EndDt { get; set; }
        public string Factory_User_Remarks { get; set; }
        public int Year2 { get; set; }
        public string Value_1 { get; set; }
        public string Product_2 { get; set; }
        public string Value_2 { get; set; }
        public string Product_3 { get; set; }
        public string Value_3 { get; set; }
        public string Occupier_Type { get; set; }
        public string Partner2_Name { get; set; }
        public string Partner2__L1 { get; set; }
        public string Partner2__L2 { get; set; }
        public string Partner_City { get; set; }
        public string Partner2_Pincode { get; set; }
        public string Partner3_Name { get; set; }
        public string Partner3__L1 { get; set; }
        public string Partner3__L2 { get; set; }
        public string Partner3_City { get; set; }
        public string Partner3_Pincode { get; set; }
        public string Partner4_Name { get; set; }
        public string Partner4__L1 { get; set; }
        public string Partner4__L2 { get; set; }
        public string Partner4_City { get; set; }
        public string Partner4_Pincode { get; set; }
        public string Partner5_Name { get; set; }
        public string Partner5__L1 { get; set; }
        public string Partner5__L2 { get; set; }
        public string Partner5_City { get; set; }
        public string Partner5_Pincode { get; set; }
        public string Factory_Constructed_i { get; set; }
        public string Factory_Constructed_ii { get; set; }
        public decimal Power_KVA { get; set; }
        public string PROB_DT { get; set; }
        public string GSC_NO { get; set; }
        public string GSC_DT { get; set; }
        public string Appr_DT { get; set; }
        public string Ncr_Value { get; set; }
        public string Forward_Date { get; set; }
        public string Appr_Remarks { get; set; }
        public string Forwarded_div_Cd { get; set; }
        public string Back_Remarks { get; set; }
        public string Revision_Remarks { get; set; }
        public int Revision_Code { get; set; }
        public string NIC_Code { get; set; }
        public string NIC_Description { get; set; }
        public string ASICC_Description { get; set; }
        public string CIN_Number { get; set; }
        public string Occupier_FatherName { get; set; }
        public int Occupier_Age { get; set; }
        public string Manager_FatherName { get; set; }
        public int Manager_Age { get; set; }
        public string Application_Number { get; set; }
        public string Industry_Type { get; set; }
        public string Manager_Name { get; set; }
        public string CompanyType { get; set; }
        public string Partner_List { get; set; }

    }
    public class CountEntity
    {
        public string count { get; set; }
    }
    public class ApproverEntity
    {
        public string Fac_Id { get; set; }
        public string App_Status { get; set; }
        public string Factory_Name { get; set; }
         public string Occupier_Name { get; set; }
        public string Mgr_Name { get; set; }
        public int Proposed_Total_Cnt { get; set; }
        public string Power_Installed { get; set; }
        public string Proposed_Power { get; set; }
        public DateTime Submited_Date { get; set; }

    }
}


