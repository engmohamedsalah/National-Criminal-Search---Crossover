using System;
using NationalCriminal.DAL;
using NationalCriminal.Repository;

namespace NationalCriminal.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NationalCriminal.Service.EntityService{NationalCriminal.DAL.Configuration}" />
    /// <seealso cref="NationalCriminal.Service.IConfigurationService" />
    public class ConfigurationService : EntityService<Configuration>, IConfigurationService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        IUnitOfWork _unitOfWork;
        /// <summary>
        /// The configuration repository
        /// </summary>
        IConfigurationRepository _configurationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="configurationRepository">The configuration repository.</param>
        public ConfigurationService(IUnitOfWork unitOfWork, IConfigurationRepository configurationRepository)
            : base(unitOfWork, configurationRepository)
        {
            _unitOfWork = unitOfWork;
            _configurationRepository = configurationRepository;
        }
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns></returns>
        public Configuration GetConfiguration()
        {
            return _configurationRepository.GetConfiguration();
        }
    }
}
