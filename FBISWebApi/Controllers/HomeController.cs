using FBISWebApi.Logics;
using FBISWebApi.Models;
using FBISWebApi.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace FBISWebApi.Controllers
{

    [Authorize]
    public class HomeController : ApiController
    {
      readonly string appRunningId = Guid.NewGuid().ToString();

        [HttpGet]
        [Route("getallregion")]
        public IHttpActionResult Region()
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);
                Circle c = new Circle();
                var religion = JsonConvert.SerializeObject(c.GetRegion().Tables[0]).ToString();
                var json1 = religion.ToString().Replace("[{", "{Region:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("getdivisionbyregion")]
        public IHttpActionResult Division(string regionName)
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                Circle c = new Circle();
                var division = JsonConvert.SerializeObject(c.GetDivision(regionName).Tables[0]).ToString();
                var json1 = division.ToString().Replace("[{", "{Division:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);
                return BadRequest();
            }


        }
        
        [HttpPost]
        [Route("insertplanapproval")]
        public IHttpActionResult InsertPlanApproval(Form1Approval request)
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                PlanApproval PA = new PlanApproval();
                if (PA.InsertForm1Details(request))
                {
                    JsonResponse json = new JsonResponse();
                    json.Status = "200 OK";
                    json.StatusMsg = "Record Inserted Successfully";
                    string jo = JsonConvert.SerializeObject(json).ToString();
                    JObject job = JObject.Parse(jo);
                    return Ok(job);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Application No: " + request.form1.Fac_id, appRunningId);
                log.LogFile("ApplicantName: " + request.form1.Appname, appRunningId);
                log.LogFile("Designation: " + request.form1.Designation, appRunningId);
                log.LogFile("App_add_line1: " + request.form1.App_add_line1, appRunningId);
                log.LogFile("App_add_line2: " + request.form1.App_add_line2, appRunningId);
                log.LogFile("App_post: " + request.form1.App_post, appRunningId);
                log.LogFile("App_taluk: " + request.form1.App_taluk, appRunningId);
                log.LogFile("App_district: " + request.form1.App_district, appRunningId);
                log.LogFile("App_Pincode: " + request.form1.App_Pincode, appRunningId);
                log.LogFile("Phone_no: " + request.form1.Phone_no, appRunningId);
                log.LogFile("Factory_add_line1: " + request.form1.Factory_add_line1, appRunningId);
                log.LogFile("Factory_add_line2: " + request.form1.Factory_add_line2, appRunningId);
                log.LogFile("Factory_post: " + request.form1.Factory_post, appRunningId);
                log.LogFile("Factory_taluk: " + request.form1.Factory_taluk, appRunningId);
                log.LogFile("Factory_district: " + request.form1.Factory_district, appRunningId);
                log.LogFile("Factory_pincode: " + request.form1.Factory_pincode, appRunningId);
                log.LogFile("Factory_phone_no: " + request.form1.Factory_phone_no, appRunningId);
                log.LogFile("Factory_name: " + request.form1.Factory_name, appRunningId);
                log.LogFile("Situation_f_district: " + request.form1.Situation_f_district, appRunningId);
                log.LogFile("Situation_f_town_village: " + request.form1.Situation_f_town_village, appRunningId);
                log.LogFile("nearest_police_station: " + request.form1.nearest_police_station, appRunningId);
                log.LogFile("nearest_rlystation: " + request.form1.nearest_rlystation, appRunningId);
                log.LogFile("buldng_approval: " + request.form1.buldng_approval, appRunningId);
                log.LogFile("Userid: " + request.form1.Userid, appRunningId);
                log.LogFile("division_cd: " + request.form1.division_cd, appRunningId);
                log.LogFile("circle_cd: " + request.form1.circle_cd, appRunningId);
                log.LogFile("App_mob_No1: " + request.form1.App_mob_No1, appRunningId);
                log.LogFile("Email_id: " + request.form1.Email_id, appRunningId);
                log.LogFile("App_mob_No2: " + request.form1.App_mob_No2, appRunningId);
                log.LogFile("CompanyType: " + request.form1.CompanyType, appRunningId);
                log.LogFile("Total_wrkr_emplyd: " + request.form1.Total_wrkr_emplyd, appRunningId);
                log.LogFile("Amount: " + request.form1.Amount, appRunningId);
                log.LogFile("Error" + ex, appRunningId);
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("GetApproverDetails")]
        public IHttpActionResult FetchForm1detailsfromApprLogin(string userid)
        {
            try
            {

                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                PlanApproval form1 = new PlanApproval();
                var details = JsonConvert.SerializeObject(form1.getSubmitedForm1Details(userid).Tables[0]).ToString();
                var json1 = details.ToString().Replace("[{", "{Form1Details:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("GetVerifierDetails")]
        public IHttpActionResult FetchForm1detailsfromVerifierLogin(string userid)
        {
            try
            {

                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                PlanApproval form1 = new PlanApproval();
                var details = JsonConvert.SerializeObject(form1.getSubmitedVForm1Details(userid).Tables[0]).ToString();
                var json1 = details.ToString().Replace("[{", "{Form1Details:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);
                return BadRequest();
            }

        }
        
        [HttpPost]
        [Route("UpdateVerifierDetails")]
        public IHttpActionResult UpdateVerifierDetails(Form1Approval request)
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);
                PlanApproval PA = new PlanApproval();
                if (PA.UpdateVerifierForm1Details(request.form1))
                {

                    JsonResponse json = new JsonResponse();
                    json.Status = "200 OK";
                    json.StatusMsg = "Record Inserted Successfully";
                    string jo = JsonConvert.SerializeObject(json).ToString();
                    JObject job = JObject.Parse(jo);
                    return Ok(job);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        
        //for approver
        [HttpPost]
        [Route("UpdateApproverDetails")]
        public IHttpActionResult UpdateApproverDetails(Form1Approval request)
        {
            try
            {

                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                PlanApproval PA = new PlanApproval();
                if (PA.UpdateApproverForm1Details(request.form1))
                {
                    JsonResponse json = new JsonResponse();
                    json.Status = "200 OK";
                    json.StatusMsg = "Record Inserted Successfully";
                    string jo = JsonConvert.SerializeObject(json).ToString();
                    JObject job = JObject.Parse(jo);
                    return Ok(job);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }


        //for renewal
        //for citizen
        [HttpGet]
        [Route("getrenewaldtls")]
        public IHttpActionResult GetDetailRenewFormTwo(string userId)
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                Renewal re = new Renewal();
                var dtls = JsonConvert.SerializeObject(re.GetRenewalDetail(userId).Tables[0]).ToString();
                var json1 = dtls.ToString().Replace("[{", "{FormTwoDetails:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }

        //for citizen
        [HttpPost]
        [Route("insertrenewalform")]
        public IHttpActionResult InsertFormTwoRenewal(FormRenewal renewal)
        {
            try
            {

                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                Renewal re = new Renewal();
                bool dtls = re.InsertRenewal(renewal);
                if (dtls)
                {
                    JsonResponse json = new JsonResponse();
                    json.Status = "200 OK";
                    json.StatusMsg = "Record Inserted Successfully";
                    string jo = JsonConvert.SerializeObject(json).ToString();
                    JObject job = JObject.Parse(jo);
                    return Ok(job);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }

        }
        //for verifier
        [HttpGet]
        [Route("getrenewalsubmit")]
        public IHttpActionResult GetFormTwoRenewalSubmit()
        {
            try
            {

                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                Renewal re = new Renewal();
                var dtls = JsonConvert.SerializeObject(re.GetSubmitFormTwoRenewalData().Tables[0]).ToString();
                var json1 = dtls.ToString().Replace("[{", "{FormTwoRenewalSubmit:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        //for verifier
      
        [HttpGet]
        [Route("getrenewalverified")]
        public IHttpActionResult GetFormTwoRenewalVerified()
        {
            try
            {

                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                Renewal re = new Renewal();
                var dtls = JsonConvert.SerializeObject(re.GetVerifiedFormtwoRenewalData().Tables[0]).ToString();
                var json1 = dtls.ToString().Replace("[{", "{FormTwoRenewalVerified:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        //for verifier
        [HttpGet]
        [Route("printsubmitformrenewal")]
        public IHttpActionResult PrintSubmitFormTwoRenewal(string facId)
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                Renewal re = new Renewal();
                var dtls = JsonConvert.SerializeObject(re.PrintSubmitFormtwoRenewalData(facId)).ToString();
                var json1 = dtls.ToString().Replace("[{", "{FormTwoRenewalSubmited:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        //for verifier
        [HttpPost]
        [Route("forwardsubmitrenewal")]
        public IHttpActionResult ForwardSubmitRenewal(ForwardRenewal forward)
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                Renewal re = new Renewal();
                bool flag = re.ForwardRenewalVerifier(forward);
                if (flag)
                {
                    JsonResponse json = new JsonResponse
                    {
                        Status = "200 Ok",
                        StatusMsg = "Record Updated Successfully"
                    };
                    string jo = JsonConvert.SerializeObject(json).ToString();
                    JObject job = JObject.Parse(jo);
                    return Ok(job);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        //for registration
        [HttpGet]
        [Route("getSubmitedForm2Details")]
        public IHttpActionResult FetchForm2detailsfromApprLogin()
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                LicenseRegistration registration = new LicenseRegistration();
                var details = JsonConvert.SerializeObject(registration.getSubmitedForm2Details().Tables[0]).ToString();
                var json1 = details.ToString().Replace("[{", "{Form2Details:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("getForm2DDVerifier")]
        public IHttpActionResult FetchForm2detailsfromDDVerifier()
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                LicenseRegistration registration = new LicenseRegistration();
                var details = JsonConvert.SerializeObject(registration.getForm2DDVerifier().Tables[0]).ToString();
                var json1 = details.ToString().Replace("[{", "{Form2Details:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("getForm2Verifier")]
        public IHttpActionResult FetchForm2details(string App_Status, string Division_Cd)
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                LicenseRegistration registration = new LicenseRegistration();
                var details = JsonConvert.SerializeObject(registration.getForm2Verifier(App_Status, Division_Cd)).ToString();
                var json1 = details.ToString().Replace("[{", "{Form2:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("getVerifierForward")]
        public IHttpActionResult FetchForm2VerForwardDetails(string Fac_id)
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                LicenseRegistration registration = new LicenseRegistration();
                var details = JsonConvert.SerializeObject(registration.getVerifierForward(Fac_id)).ToString();
                var json1 = details.ToString().Replace("[{", "{Form2:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("postUpdateVerifier")]
        public IHttpActionResult UpdateF2Verifier(FormTwoEntity request)
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                LicenseRegistration licenseRegistration = new LicenseRegistration();
                if (licenseRegistration.UpdateVerifier(request))
                {
                    JsonResponse json = new JsonResponse();
                    json.Status = "200 OK";
                    json.StatusMsg = "Record Update Successfully";
                    string jo = JsonConvert.SerializeObject(json).ToString();
                    JObject job = JObject.Parse(jo);
                    return Ok(job);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("insertform2details")]
        public IHttpActionResult InsertForm2Details(FormTwoRegistration request)
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                LicenseRegistration licenceReg = new LicenseRegistration();
                if (licenceReg.InsertForm2Details(request))
                {

                    JsonResponse json = new JsonResponse();
                    json.Status = "200 OK";
                    json.StatusMsg = "Record Inserted Successfully";
                    string jo = JsonConvert.SerializeObject(json).ToString();
                    JObject job = JObject.Parse(jo);
                    return Ok(job);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("getFileFromFolder")]
        public IHttpActionResult FetchFilesFromF2details(string Fac_Id)
        {
            try
            {
                string host = Dns.GetHostName();
                string ip = Dns.GetHostAddresses(host)[0].ToString();
                FbisLogger.Log("Method Entry", ip, System.Reflection.MethodBase.GetCurrentMethod().ToString(), this.Request.RequestUri.AbsoluteUri);

                LicenseRegistration registration = new LicenseRegistration();
                var details = JsonConvert.SerializeObject(registration.printSubmitedFormTwoDetail(Fac_Id)).ToString();
                var json1 = details.ToString().Replace("[{", "{Form2Details:[{");
                var json2 = json1.ToString().Replace("}]", "}]}");
                JObject json = JObject.Parse(json2);
                return Ok(json);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.LogFile("Exception:" + ex.Message.ToString(), appRunningId);
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("getform1details")]
        public IHttpActionResult FetchForm1details(string userid)
        {
            LicenseRegistration registration = new LicenseRegistration();
            var details = JsonConvert.SerializeObject(registration.getform1details(userid)).ToString();
            var json1 = details.ToString().Replace("[{", "{Form1:[{");
            var json2 = json1.ToString().Replace("}]", "}]}");
            JObject json = JObject.Parse(json2);
            return Ok(json);
        }

        public IHttpActionResult InsertFormAmendmentDetails()
        {
            return Ok();
        }

    }

}
