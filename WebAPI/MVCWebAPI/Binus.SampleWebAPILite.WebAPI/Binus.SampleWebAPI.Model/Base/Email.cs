using System;
using System.ComponentModel.DataAnnotations;

namespace Binus.SampleWebAPI.Model.Base
{
    [Serializable]
    public class Email
    { 
        public string RequestID { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string SMTP { get; set; }
        public string Port { get; set; }
        
        #region "Email Template"
        public int? EmailTaskID { get; set; }
        public string EmailSubject { get; set; }
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string EmailBCC { get; set; }
        public string EmailToGroupID { get; set; }
        public string EmailCCGroupID { get; set; }
        public string EmailBCCGroupID { get; set; }
        public string EmailToSubGroupID { get; set; }
        public string EmailCCSubGroupID { get; set; }
        public string EmailBCCSubGroupID { get; set; }
        public string EmailContent { get; set; }
        #endregion

        #region "Email Batch"
        public Int64? EmailBatchID { get; set; }
        public string EmailRecipient { get; set; }
        public string EmailType { get; set; }
        
        public string Emailed { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? SentDate { get; set; }
        public string SentBy { get; set; }
       
        #endregion

        public string Stsrc { get; set; }
        public string UserIn { get; set; }
        public string UserUp { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateUp { get; set; }
    }
}
