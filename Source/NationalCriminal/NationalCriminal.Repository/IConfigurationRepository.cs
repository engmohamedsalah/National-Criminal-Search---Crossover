using NationalCriminal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCriminal.Repository
{
    /// <summary>
    /// Generic interface for Configuration Repository
    /// </summary>
    /// <seealso cref="NationalCriminal.Repository.IGenericRepository{NationalCriminal.DAL.Configuration}" />
    public interface IConfigurationRepository : IGenericRepository<Configuration>
    {
        Configuration GetConfiguration();

    }
}
