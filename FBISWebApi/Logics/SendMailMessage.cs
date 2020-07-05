using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Configuration;

namespace FBISWebApi.Logics
{
	public class SendMailMessage
	{
		public bool FormSubmitConfirmationEmail(string facid, string Recipient_Name, string Recipient_Email, string initiatedDate, string SakaladDate)
		{

			string FromMailID = ConfigurationManager.AppSettings["FromEmailID"].ToString();
			string Hostname = ConfigurationManager.AppSettings["Host"].ToString();
			string Password = ConfigurationManager.AppSettings["Password"].ToString();
			string Username = ConfigurationManager.AppSettings["Username"].ToString();
			Int32 PortNumber = Convert.ToInt32(ConfigurationManager.AppSettings["PortNumber"].ToString());


			string subject = "FBIS - Credentials for Internet Application";
			string bodyText = "Dear " + Recipient_Name +
		   "," + "\n " + "\n" +
		   "Your application has been submitted for Verification." + "\n" + "\n"
		  + "Unique case No  :" + facid + "\n" + "Initiated Date  :" +
		   initiatedDate +
		   "\n " + "Thanks and Regards," + "\n" +
		   "Department of Factories,Boilers,Industrial Safety & Health Karnataka"
			;


			MailMessage message = new MailMessage();

			message.To.Add(Recipient_Email);
			message.Subject = subject;

			message.From = new System.Net.Mail.MailAddress(FromMailID);
			message.IsBodyHtml = true;
			message.Body = bodyText;
			SmtpClient SmtpMail = new SmtpClient();

			System.Net.NetworkCredential Mailauthontication = new System.Net.NetworkCredential(Username, Password);
			SmtpMail.Host = Hostname;
			SmtpMail.Port = Convert.ToInt32(PortNumber);


			SmtpMail.UseDefaultCredentials = false;
			SmtpMail.Credentials = Mailauthontication;
			SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
			SmtpMail.EnableSsl = true;
			SmtpMail.ServicePoint.MaxIdleTime = 0;
			SmtpMail.ServicePoint.SetTcpKeepAlive(true, 2000, 2000);
			message.BodyEncoding = Encoding.Default;
			message.Priority = MailPriority.High;
			SmtpMail.Send(message);
			return true;

		}

	}
}