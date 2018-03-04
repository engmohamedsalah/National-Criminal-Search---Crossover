using NationalCriminal.DAL;
using NationalCriminal.Repository;

namespace NationalCriminal.Service
{
    /// <summary>
    /// Country Service  :contain the service can be done on Coutry repository
    /// </summary>
    /// <seealso cref="NationalCriminal.Service.EntityService{NationalCriminal.DAL.Country}" />
    /// <seealso cref="NationalCriminal.Service.ICountryService" />
    public class CountryService : EntityService<Country>, ICountryService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        IUnitOfWork _unitOfWork;
        /// <summary>
        /// The country repository
        /// </summary>
        ICountryRepository _countryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="countryRepository">The country repository.</param>
        public CountryService(IUnitOfWork unitOfWork, ICountryRepository countryRepository)
            : base(unitOfWork, countryRepository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
        }


        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Country GetById(int Id) {
            return _countryRepository.GetById(Id);
        }
    }
}
