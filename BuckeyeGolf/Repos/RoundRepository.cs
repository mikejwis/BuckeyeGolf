using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuckeyeGolf.Models;

namespace BuckeyeGolf.Repos
{
    public class RoundRepository : EntityRepository<RoundModel>
    {
        public RoundRepository() : base() { }

        public RoundRepository(GolfDbContext context) : base(context) { }

        public List<RoundModel> GetWeeklyRounds(Guid weekId)
        {
            return DataSet.Where(r => r.WeekId.CompareTo(weekId) == 0).ToList();
        }

        public double GetPlayerScoreAverage(Guid playerId)
        {
            var tmpAvg = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.TotalScore != 0).Average(r => r.TotalScore);
            return Math.Round(tmpAvg, 2);
        }

        public double GetPlayerTotalPoints(Guid playerId)
        {
            return DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0).Sum(r => r.TotalPoints);
        }

        public int GetPlayerBirieTotal(Guid playerId)
        {
            return DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0).Sum(r => r.BirdieCnt);
        }

        public int GetPlayerParTotal(Guid playerId)
        {
            return DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0).Sum(r => r.ParCnt);
        }

        public int GetPlayerBogeyTotal(Guid playerId)
        {
            return DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0).Sum(r => r.BogeyCnt);
        }
        
        public RoundModel GetWeeklyRound(Guid playerId, Guid weekId)
        {
            return DataSet.Single(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.WeekId.CompareTo(weekId) == 0);
        }
    }
}