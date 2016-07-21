using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BuckeyeGolf.Models;
using System.Threading.Tasks;

namespace BuckeyeGolf.Repos
{
    public class PlayerRepository : EntityRepository<PlayerModel>
    {
        public PlayerRepository() : base() { }

        public PlayerRepository(GolfDbContext context) : base(context) { }

        public async Task<PlayerModel> Get(Guid id)
        {
            return await DataSet.SingleAsync(p => p.PlayerId.CompareTo(id) == 0);
        }

        public async Task<PlayerModel> Get(string name)
        {
            return await DataSet.SingleOrDefaultAsync(p => p.Name.Trim().Equals(name));
        }
    }
}