using NationalCriminal.DAL;
using NationalCriminal.Helper;
using System;
using System.Collections.Generic;
namespace NationalCriminal.Repository
{
    public class CriminalProfileRepository : GenericRepository<CriminalProfile>, ICriminalProfileRepository
    {
        CriminalProfile ICriminalProfileRepository.GetById(int id)
        {
            return Single(a => a.ID == id);
        }

        /// <summary>
        /// Searches the specified parameters in Criminal Profile table and get the data that match that prameters.
        /// </summary>
        /// <param name="parameters">The parameters class contains all paramters that user filled in UI.</param>
        /// <returns></returns>
        IEnumerable<CriminalProfile> ICriminalProfileRepository.Search(CriminalSearchParameter parameters)
        {
            //return all records from the database that match the paramters
            return FindAll(a => 
            (string.IsNullOrEmpty(parameters.Name) || a.CriminalName.ToLower().Contains(parameters.Name.ToLower()))
            &&(!parameters.AgeFrom.HasValue || DateTime.Today.Year - a.DateOfBirth.Value.Year >= parameters.AgeFrom)
             && (!parameters.AgeTo.HasValue || DateTime.Today.Year - a.DateOfBirth.Value.Year <= parameters.AgeTo)
            && (!parameters.HeightFrom.HasValue || a.Height<=parameters.HeightFrom)
            && (!parameters.HeightTo.HasValue || a.Height >= parameters.HeightTo)
            && (!parameters.WeightFrom.HasValue || a.Weight <= parameters.WeightFrom)
            && (!parameters.WeightTo.HasValue || a.Weight <= parameters.WeightTo)
            && (!parameters.NationalityId.HasValue || a.NationalityID == parameters.NationalityId)
            );
        }
    }
}
