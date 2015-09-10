using BuckeyeGolf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Repos
{
    public class ConfigRepository : EntityRepository<ConfigurationModel>
    {
        public ConfigRepository() : base() { }

        public ConfigRepository(GolfDbContext context) : base(context) { }

        public ConfigurationModel Get()
        {
            return DataSet.First();
        }
    }
}