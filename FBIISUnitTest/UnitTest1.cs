using System;
using System.Collections.Generic;
using FBISWebApi.Controllers;
using FBISWebApi.Logics;
using FBISWebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FBIISUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void InsertForm1Details()
        {
            var hc = new PlanApproval();
            Form1Approval form1 = getAlldata();
            hc.InsertForm1Details(form1);
            Assert.IsNotNull(form1.form1.Appname);
        }
        [TestMethod]
        public void appRunningId()
        {
            Assert.IsNotNull(1234564646);
        }

        [TestMethod]
        public void DDL()
        {
            Assert.IsNotNull(565232);
        }

        private Form1Approval getAlldata()
        {
            var formone = new Form1Approval();
            FormOneEntity form=new FormOneEntity();
         //   formone=new {form1={
                form.Appname = "Shivashankar";
            form.Designation = "Manager";
            form.App_add_line1 = "BENGALURU";
            form.App_add_line2 = "BENGALURU";
            form.App_post = "Anekal";
            form.App_taluk = "Anekal";
            form.App_district = "BENGALURU";
            form.App_Pincode = "560040";
           
            form.Phone_no = "7899285626";
            form.Factory_add_line1 = "BENGALURU";
            form.Factory_add_line2 = "BENGALURU";
            form.Factory_post = "Anekal";
            form.Factory_taluk = "Anekal";
            form.Factory_district = "BENGALURU";
            form.Factory_pincode = "560040";
            form.Factory_phone_no = "7899285626";
            form.Factory_name = "Sugar";
            form.Situation_f_district = "BENGALURU";
            form.Situation_f_town_village = "town";
            form.nearest_police_station = "yes";
            form.nearest_rlystation = "yes";
            form.buldng_approval = "Proposed Building";
            form.Userid = "Demo";
            form.division_cd = "Senior Assistant Director  of Factories, Bangalore Division-10";
            form.circle_cd = "BANGALORE REGION";
            form.App_mob_No1 = "8656565655";
            form.Email_id = "ushabiradar33@gmail.com";
            form.App_mob_No2 = "8565652322";
            form.CompanyType = "Proprietory";
            form.Total_wrkr_emplyd = 21;
            form.Amount = "100";
            form.Amt_words = "One Hundred";

            formone.form1 = form;
            formone.File = null;
            return formone;
        }
    }
}
