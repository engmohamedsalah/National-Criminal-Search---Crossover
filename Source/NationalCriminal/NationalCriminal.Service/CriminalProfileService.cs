using System;
using System.Collections.Generic;
using NationalCriminal.DAL;
using NationalCriminal.Repository;
using NationalCriminal.Helper;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NationalCriminal.Service
{
    /// <summary>
    /// CriminalProfile Service  :contain the service can be done on CriminalProfile repository
    /// </summary>
    /// <seealso cref="NationalCriminal.Service.EntityService{NationalCriminal.DAL.CriminalProfile}" />
    /// <seealso cref="NationalCriminal.Service.ICriminalProfileService" />
    public class CriminalProfileService : EntityService<CriminalProfile>, ICriminalProfileService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        IUnitOfWork _unitOfWork;
        /// <summary>
        /// The criminal profile repository
        /// </summary>
        ICriminalProfileRepository _criminalProfileRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="CriminalProfileService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="criminalProfileRepository">The criminal profile repository.</param>
        public CriminalProfileService(IUnitOfWork unitOfWork, ICriminalProfileRepository criminalProfileRepository)
            : base(unitOfWork, criminalProfileRepository)
        {
            _unitOfWork = unitOfWork;
            _criminalProfileRepository = criminalProfileRepository;
        }
      

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public CriminalProfile GetById(int Id) {
            return _criminalProfileRepository.GetById(Id);
        }

        /// <summary>
        /// Searches the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns></returns>
        public IEnumerable<CriminalProfile> Search(CriminalSearchParameter param)
        {
            return _criminalProfileRepository.Search(param);
        }
        
    }
}
