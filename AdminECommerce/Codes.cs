﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using BCrypt.Net;

namespace AdminECommerceAPI
{
    public class Codes
    {
        public void SendEmail(string subjectline, string mailbody, string toMail)
        {
            string fromMail = "ShopX.IndiaPvtLtd@gmail.com";
            MailMessage mailMessage = new MailMessage(fromMail, toMail);
            mailMessage.Subject = subjectline;
            mailMessage.Body = mailbody;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(fromMail, "owqjogevprfskdsn");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        public string Hash(string password)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            return hash;
        }
        public bool Verify(string pass1, string passHash)
        {
            var istrue = BCrypt.Net.BCrypt.Verify(pass1, passHash);
            return istrue;
        }
    }
}
