using NationalCriminal.DAL;
using NationalCriminal.Helper;
using NationalCriminal.Repository;
using System.Collections.Generic;
namespace NationalCriminal.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NationalCriminal.Service.IEntityService{NationalCriminal.DAL.CriminalProfile}" />
    public interface ICriminalProfileService : IEntityService<CriminalProfile>
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        CriminalProfile GetById(int Id);
        /// <summary>
        /// Searches the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns></returns>
        IEnumerable<CriminalProfile> Search(CriminalSearchParameter param);
        
    }
}
