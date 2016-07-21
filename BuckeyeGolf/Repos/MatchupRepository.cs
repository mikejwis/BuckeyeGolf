using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BuckeyeGolf.Models;
using System.Threading.Tasks;

namespace BuckeyeGolf.Repos
{
    public class MatchupRepository : EntityRepository<MatchupModel>
    {
        public MatchupRepository() : base() { }

        public MatchupRepository(GolfDbContext context) : base(context) { }

        public async Task<List<MatchupModel>> GetAllWeeklyMatchups(Guid weekId)
        {
            return await DataSet.Where(m => m.WeekId.CompareTo(weekId) == 0).ToListAsync();
        }

    }
}