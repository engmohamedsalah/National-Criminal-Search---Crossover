using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NationalCriminal.Service;
using NationalCriminal.Helper;
using NationalCriminal.Repository;
using System.Threading;
using Autofac.Integration.Wcf;
using Autofac;
using System.ServiceModel.Activation;
using System.Data.Linq;

namespace NationalCriminal.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SearchCriminalService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SearchCriminalService.svc or SearchCriminalService.svc.cs at the Solution Explorer and start debugging.
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NationalCriminal.WCF.ISearchCriminalService" />
    public class SearchCriminalService : ISearchCriminalService
    {

        /// <summary>
        /// The unit of work
        /// </summary>
        private IUnitOfWork unitOfWork;
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCriminalService"/> class.
        /// </summary>
        public SearchCriminalService()
        {

        }
        /// <summary>
        /// Searches the criminal.
        /// </summary>
        /// <param name="toEmail">To email.</param>
        /// <param name="name">The name.</param>
        /// <param name="ageFrom">The age from.</param>
        /// <param name="ageTo">The age to.</param>
        /// <param name="heightFrom">The height from.</param>
        /// <param name="heightTo">The height to.</param>
        /// <param name="weightFrom">The weight from.</param>
        /// <param name="weightTo">The weight to.</param>
        /// <param name="nationalityId">The nationality identifier.</param>
        /// <returns></returns>
        public ResultResponse SearchCriminal(string toEmail,string name, int? ageFrom, int? ageTo, int? heightFrom, int? heightTo, int? weightFrom, int? weightTo, int? nationalityId)
        {
            //do some validation to insure that parameters are correct
            //look at NationalCriminal.Helper.MappingError for more information about error meaning
            var result = new ResultResponse();
            if (string.IsNullOrEmpty(name) && !ageFrom.HasValue && !ageTo.HasValue && !heightFrom.HasValue && !heightTo.HasValue && !weightFrom.HasValue
                && !weightTo.HasValue && !nationalityId.HasValue)
            {
                result.hasError = true;
                result.ErrorCode = "01";
            }
            else if (ageFrom.HasValue && ageTo.HasValue && ageFrom.Value > ageTo.Value)
            {

                result.hasError = true;
                result.ErrorCode = "02";
            }
            else if (heightFrom.HasValue && heightTo.HasValue && heightFrom.Value > heightTo.Value)
            {

                result.hasError = true;
                result.ErrorCode = "03";
            }
            else if (weightFrom.HasValue && weightTo.HasValue && weightFrom.Value > weightTo.Value)
            {

                result.hasError = true;
                result.ErrorCode = "04";

            }
            else
            {
                //if the input was valid 
                //run Thread
                Thread t = new Thread(()=>GetDataAndEmailResult(toEmail,name, ageFrom, ageTo,  heightFrom,  heightTo,  weightFrom,  weightTo,nationalityId));
                t.Start();
                
              
            }
            return result;
        }
        ////////////////////////////////////////////////////
        /// <summary>
        /// Gets the data and email result.
        /// </summary>
        /// <param name="toEmail">To email.</param>
        /// <param name="name">The name.</param>
        /// <param name="ageFrom">The age from.</param>
        /// <param name="ageTo">The age to.</param>
        /// <param name="heightFrom">The height from.</param>
        /// <param name="heightTo">The height to.</param>
        /// <param name="weightFrom">The weight from.</param>
        /// <param name="weightTo">The weight to.</param>
        /// <param name="nationalityId">The nationality identifier.</param>
        private void GetDataAndEmailResult(string toEmail, string name, int? ageFrom, int? ageTo, int? heightFrom, int? heightTo, int? weightFrom, int? weightTo, int? nationalityId)
        {
            //prepare CriminalSearchParameter and send tp service 
            var service = new CriminalProfileService(unitOfWork, new CriminalProfileRepository());
            var profiles = service.Search(new CriminalSearchParameter()
            {
                Name = name,
                AgeFrom = ageFrom,
                AgeTo = ageTo,
                HeightFrom = heightFrom,
                HeightTo = heightTo,
                WeightFrom = weightFrom,
                WeightTo = weightTo,
                NationalityId = nationalityId
            });
            //var profiles = service.GetAll();

            var attachements = PDFProcessing.ExportDataToPdfFromTemplate(profiles.ToList());
            MailProcessing.sendMail(toEmail, attachements);

        }
    }
}
