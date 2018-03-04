using NationalCriminal.DAL;

namespace NationalCriminal.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NationalCriminal.Service.IEntityService{NationalCriminal.DAL.Country}" />
    public interface ICountryService : IEntityService<Country>
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Country GetById(int Id);
    }
}
