using FBISWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using FBISWebApi.DBAccess;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.Services.Protocols;
using System.Xml;
using System.Net;
using System.IO;
using System.Threading;

namespace FBISWebApi.Logics
{
	public class PostingDataToSakala
	{
		readonly Operation opr = new Operation();
		readonly string appRunningId = Guid.NewGuid().ToString();

		private static string ACCEPT_DATA = "Accept_Data_XML";
		private static string UPDATE_DATA = "Update_Data_XML";

		public string postingDataToSakala(string Fac_id, string div_code, string service_code, string applicantname, string appl_Address1, string appl_Address2)
		{

			string fac_id = Fac_id;

			string sa_app_dept_code = "IS";
			string sa_desig_off_code = getNicDeptCode(div_code);
			string sa_service_code = service_code;
			string sa_gsc_no = null;
			try
			{
				string sql = opr.DML("Sp_Insert_Sakala_dtls", fac_id, sa_desig_off_code, sa_service_code).ToString();
				if (sql != null)
				{
					sa_gsc_no = getGscNumber(fac_id);
				}
			}
			catch (Exception e)
			{
				Log log = new Log();
				log.LogFile("Exception:" + e.Message.ToString(), appRunningId);


			}

			string sa_gsc_date = DateTime.Now.ToString("dd/MM/yyyy");
			string sa_appl_name = applicantname;
			string sa_appl_addr1 = appl_Address1;
			string sa_appl_addr2 = appl_Address2;

			string sendXml = "";
			string recvXml = "";

			StringBuilder xmlData = new StringBuilder();
			xmlData.Append("<acpt_sakala>");
			xmlData.Append("<acpt_gscdata>");
			xmlData.Append("<DEPT_CODE>").Append(sa_app_dept_code)
					.Append("</DEPT_CODE>");
			xmlData.Append("<DESIG_OFF_CODE>").Append(sa_desig_off_code)
					.Append("</DESIG_OFF_CODE>");
			xmlData.Append("<SERVICE_CODE>").Append(sa_service_code)
					.Append("</SERVICE_CODE>");
			xmlData.Append("<SUB_SERVICE_CODE>").Append("00")
					.Append("</SUB_SERVICE_CODE>");
			xmlData.Append("<GSC_NO>").Append(sa_gsc_no).Append("</GSC_NO>");
			xmlData.Append("<GSC_DT>").Append(sa_gsc_date).Append("</GSC_DT>");
			xmlData.Append("<APPL_NAME>").Append(sa_appl_name)
					.Append("</APPL_NAME>");
			xmlData.Append("<APPL_ADDRESS1>").Append(sa_appl_addr1)
					.Append("</APPL_ADDRESS1>");
			xmlData.Append("<APPL_ADDRESS2>").Append(sa_appl_addr2)
					.Append("</APPL_ADDRESS2>");
			xmlData.Append("<APPL_MOBILE>").Append(0)
					.Append("</APPL_MOBILE>");
			xmlData.Append("<DOC_SUBMITTED>").Append("Y")
					.Append("</DOC_SUBMITTED>");
			xmlData.Append("<GSC_UPD_FLAG>").Append("N").Append("</GSC_UPD_FLAG>");
			xmlData.Append("</acpt_gscdata>");
			xmlData.Append("</acpt_sakala>");
			sendXml = xmlData.ToString();
			SakalaHandler sa = new SakalaHandler();
			recvXml = sa.sendData2NIC(sendXml, ACCEPT_DATA);

			Thread.Sleep(1000);
		
			try
			{
				/*string sql = opr.DML("sp_Update_Form1_Details", sa_gsc_no, sa_gsc_date, sa_appl_name, sendXml, recvXml, fac_id).ToString();
				*/
			}
			catch (Exception e)
			{
				Log log = new Log();
				log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

			}


			return sa_gsc_no;
		}
	
public string getNicDeptCode(string fbisDeptName)
		{
			string nic_dept_code = null;
			string div_code = null;
			try
			{
				DataSet ds = opr.DDL("Sp_Division_Code", fbisDeptName);
				foreach (DataRow item in ds.Tables[0].Rows)
				{
				div_code = item[0].ToString();
				}

				DataSet ds1 = opr.DDL("fetch_sakala_nic_dept_maping_tbl", div_code);
				foreach (DataRow item in ds1.Tables[0].Rows)
				{
					nic_dept_code = item[0].ToString();
				}

			}
			catch (Exception e)
			{
				Log log = new Log();
				log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

			}
			return nic_dept_code;
		}


		public string UpdateDataToSakala(string Fac_Id, string App_Status, string Remarks)
		{
			string gsc_no = null;
			string sendXml = null, recvXml = null;
			try
			{
				DataSet ds = opr.DDL("sp_Get_GSCNO", Fac_Id);
				foreach (DataRow item in ds.Tables[0].Rows)
				{
					gsc_no =(item[0].ToString());

				}

				if (gsc_no != null)
				{

					StringBuilder xmlData = new StringBuilder();
					xmlData.Append("<upd_sakala>").Append("<upd_gscdata>");
					xmlData.Append("<DEPT_CODE>").Append("IS")
							.Append("</DEPT_CODE>");
					xmlData.Append("<GSC_NO>").Append(gsc_no).Append("</GSC_NO>");
					xmlData.Append("<GSC_STATUS_CODE>").Append(App_Status)
							.Append("</GSC_STATUS_CODE>");
					xmlData.Append("<GSC_STATUS_DESC>").Append(Remarks)
							.Append("</GSC_STATUS_DESC>");
					xmlData.Append("<UPD_DT>").Append(DateTime.Now.ToString("dd-MM-yyyy")).Append("</UPD_DT>");
					xmlData.Append("</upd_gscdata>").Append("</upd_sakala>");

					sendXml = xmlData.ToString();
					SakalaHandler sa = new SakalaHandler();
					//recvXml = sa.sendData2NIC(sendXml,UPDATE_DATA);
					Thread.Sleep(1000);
				/*	string sql = opr.DML("sp_Update_sakala_dtls", App_Status, Remarks, sendXml, recvXml,Fac_Id).ToString();
				*/	
				}
				return gsc_no;


			}
			catch (Exception e)
			{
				Log log = new Log();
				log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

			}
			return gsc_no;
		}

		public string GeneratedGscAck(string Fac_id)
		{
			string GscNO = "";
			int seq_no = 0;
			string softcode = "01";
			try
			{
				DataSet ds = opr.DDL("Sp_GetSeqNo", Fac_id);
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


		public string getGscNumber(string fb_id)
		{
			int id = 0;
			try
			{
				DataSet ds = opr.DDL("fetch_sakala_data_tbl", fb_id);
				foreach (DataRow item in ds.Tables[0].Rows)
				{
					id = Convert.ToInt32(item[0]);

				}
			}
			catch (Exception e)
			{
				Log log = new Log();
				log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

			}

			StringBuilder gsc_build = new StringBuilder();
			string str = string.Format("{0:D10}", Convert.ToInt32(id));
			gsc_build.Append("IS0FB").Append(str);
			return gsc_build.ToString();
		}
	}
}
