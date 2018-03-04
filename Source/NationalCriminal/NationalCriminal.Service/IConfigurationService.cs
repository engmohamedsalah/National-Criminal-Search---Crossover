using NationalCriminal.DAL;

namespace NationalCriminal.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NationalCriminal.Service.IEntityService{NationalCriminal.DAL.Configuration}" />
    public interface IConfigurationService : IEntityService<Configuration>
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns></returns>
        Configuration GetConfiguration();
    }
}
