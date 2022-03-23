using Extract_Information_SalesForce.Infra.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Spire.Email;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Extract_Information_SalesForce.Infra.Service
{
    public class AnalyzeEmailService : IAnalyzeEmailService
    {
        private readonly ILogger<AnalyzeEmailService> _logger;
        private readonly EmailFolder _emailFolder;

        public AnalyzeEmailService(ILogger<AnalyzeEmailService> logger, IOptions<EmailFolder> options)
        {
            _logger = logger;
            _emailFolder = options.Value;
        }

        public string ReturnIdSalesForce(string emailFile)
        {
            if (emailFile != null)
            {   
                var base64BytesEmail = Convert.FromBase64String(emailFile);
                var path = _emailFolder.pathFile;
                File.WriteAllBytes(path, base64BytesEmail);

                MailMessage mail = MailMessage.Load(path);
                var body_email = mail.BodyText;

                File.Delete(path);

                if (body_email != null && body_email.Contains("SFDC ID"))
                {
                    string value_SFDC_Id = Regex.Match(body_email.Replace("\t", "").Replace("\n", "").Replace("\r", ""),
                        @"SFDC ID:(.*?)BUSINESS CASE").Groups[1].Value.Trim();

                    return "SalesForce ID :" + value_SFDC_Id;
                }
                else
                {
                    return "Cannot find Sales Force ID";
                }
            }
            else
            {
                return "Please enter a valid file";
            }
        }
     }
}
