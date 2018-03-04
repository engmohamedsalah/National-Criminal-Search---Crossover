using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// this Constant class contains the constat values that used in the system
/// like email configuration and messages 
/// for message it should be add to localization files 
/// </summary>
namespace NationalCriminal.Helper
{
    public class Constant
    {
        #region Email constant
        public const int MAX_NUMBER_OF_ATTACH_PER_EMAIL = 10;
        public const string EMAIL_HOST = "smtp.google.com";
        public const string EMAIL_FROM = "eng.mohamed.tawab@gmail.com";
        public static string EMAIL_SUBJECT = "Criminal Profiles searched at : " + DateTime.Now.ToString();
        public const string EMAIL_BODY_IF_FOUND_RECORDS = "Dear Sir,\r\n Please find in the attachements the profiles for the criminals that match the search parameters";
        public const string EMAIL_BODY_IF_NOT_FOUND_RECORDS = "Dear Sir,\r\n So Sorry to inform you that search paramters not matched any criminal at our database ";
        #endregion
        #region fields that used in PDF template
        public const string PDF_PARAM_NAME = "Name";
        public const string PDF_PARAM_DOB = "DateOfBirth";
        public const string PDF_PARAM_HEIGHT = "Height";
        public const string PDF_PARAM_WEIGHT = "Weight";
        public const string PDF_PARAM_NATIONALITY = "Nationality";

        public const string PDF_TEMPLATE_PATH = @"\PDFTemplate\ProfileTemplate.pdf";

        public static string SuccessfulMessage = "System Will Search and send email to you with the result, Please check your email";
        #endregion 
    }
}
