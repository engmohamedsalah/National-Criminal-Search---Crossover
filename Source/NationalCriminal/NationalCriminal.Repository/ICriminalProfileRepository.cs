using NationalCriminal.DAL;
using NationalCriminal.Helper;
using System.Collections.Generic;

namespace NationalCriminal.Repository
{
    /// <summary>
    /// Repository Interface of CriminalProfile
    /// </summary>
    /// <seealso cref="NationalCriminal.Repository.IGenericRepository{NationalCriminal.DAL.CriminalProfile}" />
    public interface ICriminalProfileRepository : IGenericRepository<CriminalProfile>
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        CriminalProfile GetById(int id);
        /// <summary>
        /// Searches the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns></returns>
        IEnumerable<CriminalProfile> Search(CriminalSearchParameter param);
    }
}
