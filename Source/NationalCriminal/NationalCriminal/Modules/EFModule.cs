using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using NationalCriminal.DAL;
using NationalCriminal.Repository;
using System.Data.Linq;

namespace NationalCriminal.Modules
{


    /// <summary>
    /// this is Module for  dependency injection Autofac
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class DALModule : Autofac.Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(NationalCriminalDataContext)).As(typeof(DataContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();         

        }

    }
}