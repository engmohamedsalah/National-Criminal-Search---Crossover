using NationalCriminal.DAL;

namespace NationalCriminal.Repository
{
    /// <summary>
    /// this is Repository so that i can got the coutries names and also nationalities
    /// </summary>
    /// <seealso cref="NationalCriminal.Repository.GenericRepository{NationalCriminal.DAL.Country}" />
    /// <seealso cref="NationalCriminal.Repository.ICountryRepository" />
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {

        //search by id
        Country ICountryRepository.GetById(int id)
        {
            return Single(x => x.ID == id);
        }
        //search by code
        Country ICountryRepository.GetByCountryCode(string code)
        {
            return Single(x => x.CountryCode == code);
        }


    }
}
