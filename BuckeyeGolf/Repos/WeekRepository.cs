using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuckeyeGolf.Models;

namespace BuckeyeGolf.Repos
{
    public class WeekRepository : EntityRepository<WeekModel>
    {
        public WeekRepository() : base() { }

        public WeekRepository(GolfDbContext context) : base(context) { }

        public WeekModel Get(Guid id)
        {
            return DataSet.Single(w => w.WeekId.CompareTo(id) == 0);
        }

        public int GetHighestWeekNumber()
        {
            return DataSet.Max(w => w.WeekNbr);
        }

        public List<WeekModel> GetPlayedWeeks()
        {
            return DataSet.Where(w => w.BeenPlayed == true).ToList();
        }

        public List<WeekModel> GetUnplayedWeeks()
        {
            return DataSet.Where(w => w.BeenPlayed == false).ToList();
        }

        public WeekModel GetFirstUnplayedWeek()
        {
            WeekModel retVal = null;
            var weeks = GetUnplayedWeeks();
            if(weeks.Count() > 0)
            {
                var minWeekNbr = weeks.Min(m => m.WeekNbr);
                retVal = weeks.Single(w => w.WeekNbr == minWeekNbr);
            }
            return retVal;
        }
    }
}