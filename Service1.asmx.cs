using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net.Mail;
using System.Net;

namespace Castomech
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public void SendMail()
        {
            sendInquiry("Hello How are you","Castomech Inquery From Website","antonymathew021@gmail.com");
        }


        protected int  sendInquiry(string body, string sub, string emailid)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("webmunktechnologymail@gmail.com", "webmunk@123");

                MailMessage msg = new MailMessage();

                string se = emailid;
                //string se = "antonymathew021@gmail.com";
                MailAddress esender = new MailAddress("webmunktechnologymail@gmail.com");
                msg.From = esender;

                MailAddress erec = new MailAddress(se);
                msg.To.Add(erec);

                msg.Subject = sub; 
                msg.Body = body;
                
                msg.IsBodyHtml = true;
                client.Send(msg);
                return 1;
            }

            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}