using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCriminal.Repository
{
    /// <summary>
    /// Sends a minimal amount of SQL to the database during the commit by updating only the exact changes down to the field level
    /// Reduces database traffic by isolating transaction operations in their own memory space
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
}
