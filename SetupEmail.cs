using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Jescil2
{
    public class SetupEmail
    {
        //public string SendEmailToCustomer(string email, string title, string refNo, string telephone, string lastName)
        public string SendEmailToCustomerXXX(EmailParameters emailParameters)
        {
            RegexUtilities myvar = new RegexUtilities();
            if (myvar.IsValidEmail(emailParameters.ClientEmail))
            {
                string messageBody = "Hello World"; //string.Format("Hello " + title + "  " + lastName + "{0} " + "Thank you for sending your goods with Paco Shipping Limited. {0} Your Reference number is: " + refNo + " and Items Details attached.{0} As our cherrished customr we will ensure that your beneficiary receives the goods in approximately 14 working days.{0} In the event of any complications or clarifications please contact us via email on: info@pacoshipping.com. {0} Thank you. {0} Kind regards {0} System Administrator", Environment.NewLine);
                string.Format("", messageBody);
                MailMessage myMessage = new MailMessage(emailParameters.ClientEmail, "info@iprosystem.co.uk", "Customer Message", messageBody);
                //MailMessage myMessage1 = new MailMessage("rayaduboatjc@hotmail.com", email, "Shipping Receipt", messageBody);
                NetworkCredential netCredentialAccounttFrom = new NetworkCredential(emailParameters.SmtpUser, emailParameters.SmtpPassword);
                SmtpClient smtpobj = new SmtpClient(emailParameters.SmtpAddress, emailParameters.PortNo);
                smtpobj.EnableSsl = false;
                smtpobj.Credentials = netCredentialAccounttFrom;
                smtpobj.Send(myMessage);
                //smtpobj.Send(myMessage1);
                DateTime mydate = new DateTime();
            }
            return "";
        }
        public string SendEmailToAdmin(EmailParameters emailParameters)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(emailParameters.ClientEmail, "Customer Visit");
            message.Subject = "Customer's visit";
            string bodyText = emailParameters.Fullname + ";\r\n";
            bodyText += "Has visited the site on" + DateTime.Now.ToShortDateString() + " at " + DateTime.Now.ToShortTimeString() + "\r\n";
            bodyText += "and has posted the below comment: \r\n";
            bodyText += emailParameters.Comment;
            bodyText += "\r\n";
            bodyText += "Thank you \r\n";
            bodyText += "\r\n";
            bodyText += "SysAdmin";
            message.Body = bodyText;
            //message.To.Add(emailParameters.SysAdminEmail);
            message.To.Add(emailParameters.SysAdminEmail);

            SmtpClient client = new SmtpClient();
            client.Host = emailParameters.SmtpAddress;
            client.Port = emailParameters.PortNo;
            client.Credentials = new System.Net.NetworkCredential(emailParameters.SmtpUser, emailParameters.SmtpPassword);

            client.EnableSsl = true;
            //client.Timeout = 600000;
            client.Send(message);
            return "";
        }

        //private void btnSend_Click(object sender, System.EventArgs e)
        //{

        //    MailMessage m = new MailMessage();
        //    SmtpClient sc = new SmtpClient();
        //    m.From = new MailAddress(txtFrom.Text);
        //    m.To.Add(txtTo.Text);
        //    m.Subject = "This is a test";
        //    m.Body = "This is a sample message using SMTP authentication";
        //    sc.Host = txtMailServer.Text;
        //    string str1 = "gmail.com";
        //    string str2 = txtFrom.Text.ToLower();
        //    if (str2.Contains(str1))
        //    {
        //        try
        //        {
        //            sc.Port = 587;
        //            sc.Credentials = new System.Net.NetworkCredential(txtFrom.Text, txtPass.Text);
        //            sc.EnableSsl = true;
        //            sc.Send(m);
        //            Response.Write("Email Send successfully");
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("<BR><BR>* Please double check the From Address and Password to confirm that both of them are correct. <br>");
        //            Response.Write("<BR><BR>If you are using gmail smtp to send email for the first time, please refer to this KB to setup your gmail account: http://www.smarterasp.net/support/kb/a1546/send-email-from-gmail-with-smtp-authentication-but-got-5_5_1-authentication-required-error.aspx?KBSearchID=137388");
        //            Response.End();
        //            throw ex;
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            sc.Port = 25;
        //            sc.Credentials = new System.Net.NetworkCredential(txtFrom.Text, txtPass.Text);
        //            sc.EnableSsl = false;
        //            sc.Send(m);
        //            Response.Write("Email Send successfully");
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("<BR><BR>* Please double check the From Address and Password to confirm that both of them are correct. <br>");
        //            Response.End();
        //            throw ex;
        //        }
        //    }
        //}

        public string SendEmailToCustomer(EmailParameters emailParameters)
        {
            string msg = "";
            RegexUtilities myvar = new RegexUtilities();
            if (myvar.IsValidEmail(emailParameters.ClientEmail))
            {
                MailMessage m = new MailMessage();
                SmtpClient sc = new SmtpClient();
                try
                {
                    m.From = new MailAddress("admin@rabcomsolutions.com");
                    m.To.Add(emailParameters.SysAdminEmail);
                    m.Subject = "Client Site Visit";
                    m.IsBodyHtml = true;
                    m.Body = "A user with an email address of "+emailParameters.ClientEmail + " Has visited your site with the following comments: \r\n";
                    m.Body +=emailParameters.Comment + ". \r\n";
                    sc.Host = emailParameters.SmtpAddress;// "smtp.gmail.com";
                    sc.Port = emailParameters.PortNo;// 587;
                    sc.Credentials = new System.Net.NetworkCredential("rayaduboat@gmail.com", "Ray4455rab");

                    sc.EnableSsl = true;
                    sc.Send(m);
                   msg="Email Send successfully";
                }
                catch (Exception ex)
                {
                    msg=ex.Message;
                }
            }
            return msg;
        }
    }
}
