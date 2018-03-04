using NationalCriminal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCriminal.Repository
{
    /// <summary>
    /// generic Repository Interface for Country
    /// </summary>
    /// <seealso cref="NationalCriminal.Repository.IGenericRepository{NationalCriminal.DAL.Country}" />
    public interface ICountryRepository : IGenericRepository<Country>
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Country GetById(int id);
        /// <summary>
        /// Gets the by country code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Country GetByCountryCode(string code);


    }
}
