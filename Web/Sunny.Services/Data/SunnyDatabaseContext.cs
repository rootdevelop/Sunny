using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Sunny.Services.Domain;

namespace Sunny.Services.Data
{
    public class SunnyDatabaseContext : DbContext
    {
        public SunnyDatabaseContext()
            : base(WebConfigurationManager.AppSettings["DatabaseConnectionString"])
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Media> Medias { get; set; }
        public DbSet<Mission> Missions { get; set; }
    }
}