using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace DataSync.BioNetSync
{
    public class GuiMail
    {
            public class Email
        {
        }
            public string Send_Email(string SendFrom, string SendTo, string Subject, string Body)
            {
                try
                {
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

                    string to = SendTo;
                    bool result = regex.IsMatch(to);
                    if (result == false)
                    {
                        return "Địa chỉ email không hợp lệ.";
                    }
                    else
                    {
                        System.Net.Mail.SmtpClient smtp = new SmtpClient();
                        System.Net.Mail.MailMessage msg = new MailMessage(SendFrom, SendTo, Subject, Body);
                        msg.IsBodyHtml = true;
                        smtp.Host = "smtp.gmail.com";//Sử dụng SMTP của gmail
                        smtp.Send(msg);
                        return "Email đã được gửi đến: " + SendTo + ".";
                    }
                }
                catch
                {
                    return "";
                }
            }

            public static int Send_Email_With_Attachment(string SendTo, string SendFrom, string AttachmentPath)
            {
                try
                {
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
               
                    string from = SendFrom;
                    string to = SendTo;
                    string subject = "Kết quả phiếu xét nghiệm sàn lọc trẻ sơ sinh";
                    string body = "Kết quả phiếu xét nghiệm sàn lọc trẻ sơ sinh của Trung tâm Bionet";

                    bool result = regex.IsMatch(to);
                    if (result == false)
                    {
                    //Lỗi địa chỉ mail
                        return 2;
                    }
                    else
                    {
                        try
                        {
                            MailMessage em = new MailMessage(from, to, subject, body);
                            Attachment attach = new Attachment(AttachmentPath);
                            em.Attachments.Add(attach);
                            em.Bcc.Add(from);
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
                            smtp.EnableSsl = true;
                            smtp.Credentials = new NetworkCredential(from, "bionetbenhvien");
                            smtp.Send(em);
                            em.Dispose();
                        return 0;
                        }
                        catch 
                        {
                            return 1;
                        }
                    }
                }
                catch 
                {
                    return 1;
                }
            }
            public string Send_Email_With_BCC_Attachment(string SendTo, string SendBCC, string SendFrom, string Subject, string Body, string AttachmentPath)
            {
                try
                {
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                    string from = SendFrom;
                    string to = SendTo; //Danh sách email được ngăn cách nhau bởi dấu ";"
                    string subject = Subject;
                    string body = Body;
                    string bcc = SendBCC;
                    bool result = true;
                    String[] ALL_EMAILS = to.Split(';');
                    foreach (string emailaddress in ALL_EMAILS)
                    {
                        result = regex.IsMatch(emailaddress);
                        if (result == false)
                        {
                            return "Địa chỉ email không hợp lệ.";
                        }
                    }
                    if (result == true)
                    {
                        try
                        {
                            MailMessage em = new MailMessage(from, to, subject, body);
                            Attachment attach = new Attachment(AttachmentPath);
                            em.Attachments.Add(attach);
                            em.Bcc.Add(bcc);

                            System.Net.Mail.SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";//Ví dụ xử dụng SMTP của gmail
                            smtp.Send(em);

                            return "";
                        }
                        catch (Exception ex)
                        {
                            return ex.Message;
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

      
        
    }
}
