using NationalCriminal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCriminal.Repository
{
    /// <summary>
    /// this table retun 1 row contain the configuration of the system
    /// </summary>
    /// <seealso cref="NationalCriminal.Repository.GenericRepository{NationalCriminal.DAL.Configuration}" />
    /// <seealso cref="NationalCriminal.Repository.IConfigurationRepository" />
    public class ConfigurationRepository : GenericRepository<Configuration>, IConfigurationRepository
    {
        /// <summary>
        /// Gets the system configuration.
        /// </summary>
        /// <returns></returns>
        public Configuration GetConfiguration()
        {
            // where condition is true as table contain only 1 row
            return First(a => true);
        }



    }
}
