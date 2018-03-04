using iTextSharp.text;
using iTextSharp.text.pdf;
using NationalCriminal.DAL;
using NationalCriminal.Helper;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace NationalCriminal.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class PDFProcessing
    {
        /// <summary>
        /// Exports the data to PDF from template file.
        /// </summary>
        /// <param name="criminals">The criminals.</param>
        /// <returns></returns>
        public static List<Attachment> ExportDataToPdfFromTemplate(List<CriminalProfile> criminals)
        {
            List<Attachment> attachmentResult = new List<Attachment>();
            foreach (var criminal in criminals)
            {
                //open the pdf template
                string formFile = Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory) + Constant.PDF_TEMPLATE_PATH; 
                PdfReader reader = new PdfReader(formFile);
                MemoryStream ms = new MemoryStream();
                PdfStamper stamper = new PdfStamper(reader, ms);
                //get the fields that exist in the pdf template
                AcroFields fields = stamper.AcroFields;
                //set criminal name
                fields.SetField(Constant.PDF_PARAM_NAME, criminal.CriminalName);
                //set criminal DOB
                fields.SetField(Constant.PDF_PARAM_DOB, (criminal.DateOfBirth.HasValue) ? criminal.DateOfBirth.Value.ToShortDateString() : "");
                //set criminal HEIGHT
                fields.SetField(Constant.PDF_PARAM_HEIGHT, (criminal.Height.HasValue) ? criminal.Height.ToString() : "");
                //set criminal WEIGHT
                fields.SetField(Constant.PDF_PARAM_WEIGHT, (criminal.Weight.HasValue) ? criminal.Weight.ToString() : "");
                //set criminal NATIONALITY
                fields.SetField(Constant.PDF_PARAM_NATIONALITY, (criminal.NationalityID.HasValue) ? criminal.Country.Nationality.ToString() : "");

                stamper.Writer.CloseStream = false;

                stamper.FormFlattening = true;
                stamper.Close();

                ms.Position = 0;
                //save as attachemnt
                var attachment = new Attachment(ms, new System.Net.Mime.ContentType("application/pdf"));
                attachment.Name = criminal.CriminalName;
                attachmentResult.Add(attachment);
            }
            return attachmentResult;


        }
    }
}
