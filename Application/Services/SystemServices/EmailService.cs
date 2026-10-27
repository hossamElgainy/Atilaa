using Core.DomainModels;
using Core.Enums;
using Core.Interfaces.IServices.SystemIServices;
using Core.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;



namespace Application.Services.SystemServices
{
    public class EmailService(EmailSettings emailSettings) : IEmailService
    {
        private readonly EmailSettings _emailSettings = emailSettings;

        public async Task 
            SendEmailAsync(List<string> to, EmailEnum emailType,User? user,string? Pass,string? code)
        {
            var (subject, body) = EmailContent(emailType,code,user,Pass);
            // create message
            var receivers = to.Select(x => MailboxAddress.Parse(x));
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailSettings.EmailFrom));
            email.To.AddRange(receivers);
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            // send email
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, SecureSocketOptions.SslOnConnect);
            await smtp.AuthenticateAsync(_emailSettings.EmailFrom, _emailSettings.SmtpPass);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        private (string subject,string body) EmailContent(EmailEnum emailType,string? code,User? user,string? Pass)
        {
            var Subject = string.Empty;
            var Body = string.Empty;
            if (emailType == EmailEnum.VerifyUser)
            {
                Subject = "Verify Your Email";
                Body = $@"
                <div dir='rtl' style='text-align: right; font-family: Arial, sans-serif;'>
                    <h2>مرحباً بك في كابتنى</h2>
                    <p>نشكرك لثقتك بنا! يرجى استخدام كود التحقق التالي لإكمال عملية التسجيل:</p>
                    <h1 style='color: #4CAF50;'>🎉 {code} 🎉</h1>
                    <p>هذا الكود صالح لمدة 10 دقائق. لا تشاركه مع أي شخص لأسباب أمنية.</p>
                    <p>إذا لم تطلب هذا الكود، يرجى تجاهل هذه الرسالة.</p>
                    <p>فريق كابتنى</p>
                </div>
                <hr>
                <div dir='ltr' style='text-align: left; font-family: Arial, sans-serif;'>
                    <h2>Welcome to Captainy</h2>
                    <p>Thank you for choosing us! Please use the following verification code to complete your registration:</p>
                    <h1 style='color: #4CAF50;'>🎉 {code} 🎉</h1>
                    <p>This code is valid for 10 minutes. Do not share it with anyone for security reasons.</p>
                    <p>If you didn't request this code, please ignore this email.</p>
                    <p>Captainy Team</p>
                </div>";
                return (Subject, Body);
            }
            else if (emailType == EmailEnum.ResetPassword)
            {
                Subject = "Reset Your Password";
                Body = $@"
                <div dir='rtl' style='text-align: right; font-family: Arial, sans-serif;'>
                    <h2>إعادة تعيين كلمة المرور</h2>
                    <p>لقد تلقينا طلبًا لإعادة تعيين كلمة المرور الخاصة بحسابك في كابتنى.</p>
                    <p>يرجى استخدام كود التحقق التالي لإكمال عملية إعادة تعيين كلمة المرور:</p>
                    <h1 style='color: #4CAF50;'>🎉 {code} 🎉</h1>
                    <p>هذا الكود صالح لمدة 10 دقائق. لا تشاركه مع أي شخص لأسباب أمنية.</p>
                    <p>إذا لم تطلب إعادة تعيين كلمة المرور، يرجى تجاهل هذه الرسالة.</p>
                    <p>فريق كابتنى</p>
                </div>
                <hr>
                <div dir='ltr' style='text-align: left; font-family: Arial, sans-serif;'>
                    <h2>Password Reset</h2>
                    <p>We received a request to reset the password for your Captainy account.</p>
                    <p>Please use the following verification code to complete the password reset process:</p>
                    <h1 style='color: #4CAF50;'>🎉 {code} 🎉</h1>
                    <p>This code is valid for 10 minutes. Do not share it with anyone for security reasons.</p>
                    <p>If you did not request a password reset, please ignore this email.</p>
                    <p>Captainy Team</p>
                </div>";
                return (Subject, Body);
            }
               
            else
            {
                return (Subject, Body);
            }
        }
    }
}
