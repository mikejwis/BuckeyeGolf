using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuckeyeGolf.Models;

namespace BuckeyeGolf.Repos
{
    public class PlayerRepository : EntityRepository<PlayerModel>
    {
        public PlayerRepository() : base() { }

        public PlayerRepository(GolfDbContext context) : base(context) { }

        public PlayerModel Get(Guid id)
        {
            return DataSet.Single(p => p.PlayerId.CompareTo(id) == 0);
        }
    }
}