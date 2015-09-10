using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuckeyeGolf.Models;

namespace BuckeyeGolf.Repos
{
    public class MatchupRepository : EntityRepository<MatchupModel>
    {
        public MatchupRepository() : base() { }

        public MatchupRepository(GolfDbContext context) : base(context) { }

        public List<MatchupModel> GetAllWeeklyMatchups(Guid weekId)
        {
            return DataSet.Where(m => m.WeekId.CompareTo(weekId) == 0).ToList();
        }

    }
}