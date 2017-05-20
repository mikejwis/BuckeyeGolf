using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BuckeyeGolf.Models;
using System.Threading.Tasks;

namespace BuckeyeGolf.Repos
{
    public class WeekRepository : EntityRepository<WeekModel>
    {
        public WeekRepository() : base() { }

        public WeekRepository(GolfDbContext context) : base(context) { }

        public async Task<WeekModel> Get(Guid id)
        {
            return await DataSet.SingleAsync(w => w.WeekId.CompareTo(id) == 0);
        }

        public int GetHighestWeekNumber()
        {
            var retVal = 0;
            if (DataSet.Count() > 0) retVal = DataSet.Max(w => w.WeekNbr);
            return retVal;
        }

        public WeekModel GetWeekByNumber(int weekNbr)
        {
            return DataSet.FirstOrDefault(w => w.WeekNbr == weekNbr);
        }

        public WeekModel GetHighestWeek(bool beenPlayed)
        {
            WeekModel retVal = null;
            var weekNbr = this.GetHighestWeekNumber();
            if (weekNbr != 0) retVal = DataSet.FirstOrDefault(w => w.WeekNbr == weekNbr && w.BeenPlayed == beenPlayed);
            return retVal;
        }

        public void DeleteWeek(Guid weekId)
        {
            var result = DataSet.FirstOrDefault(w=>w.WeekId.CompareTo(weekId) == 0);
            if (result != null) DataSet.Remove(result);
        }

        public void DeleteWeek(WeekModel week)
        {
            DataSet.Remove(week);
        }

        public async Task<List<WeekModel>> GetPlayedWeeks()
        {
            return await DataSet.Where(w => w.BeenPlayed == true).ToListAsync();
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