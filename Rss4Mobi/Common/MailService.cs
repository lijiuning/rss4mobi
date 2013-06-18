namespace Rss4Mobi.Common
{
    using System.Net.Mail;
    using System.Text;
    /// <summary>
    ///发送邮件类
    /// </summary>
    public class MailService
    {
        /// <summary>
        /// 发送邮件的方法
        /// </summary>
        /// <param name="toMail">目的邮件地址</param>
        /// <param name="title">发送邮件的标题</param>
        /// <param name="content">发送邮件的内容</param>
        public static void SendMail(string toMail, string title, string content)
        {
            var mailMessage = new MailMessage();
            var client = new SmtpClient();
            //收件人邮箱地址
            //第一个参数是发信人邮件地址
            //第二参数是发信人显示的名称
            //第三个参数是 第二个参数所使用的编码，如果指定不正确，则对方收到后显示乱码
            mailMessage.To.Add(new MailAddress(toMail, "Rss4Mobi", Encoding.UTF8));
            //邮件标题编码
            mailMessage.SubjectEncoding = Encoding.UTF8;
            //邮件主题
            mailMessage.Subject = title;
            //邮件内容
            //mailMessage.Body = content;
            mailMessage.Body = System.Web.HttpContext.Current.Server.HtmlDecode(content);
            
            //邮件内容编码
            mailMessage.BodyEncoding = Encoding.UTF8;
            //设置正文内容是否是包含Html的格式
            mailMessage.IsBodyHtml = true;
            //发送邮件的优先等级（有效值为High,Low,Normal）
            mailMessage.Priority = MailPriority.Normal;
            //client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);
            //发送邮件
            //client.Send(mailMessage);   //同步发送
            client.SendAsync(mailMessage, mailMessage.To); //异步发送 （异步发送时页面上要加上Async="true" ）
        }

        //static void client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        //{
        //    if (e.Cancelled)
        //    {
        //        System.Web.HttpContext.Current.Response.Write("<script>alert('Sending of email message was cancelled.');</script>");
        //    }
        //    if (e.Error == null)
        //    {
        //        System.Web.HttpContext.Current.Response.Write("<script>alert('Mail sent successfully');</script>");
        //    }
        //    else
        //    {
        //        System.Web.HttpContext.Current.Response.Write("<script>alert('Error occured, info=" + e.Error.Message + "');</script>");
        //    }
        //}
    }
}