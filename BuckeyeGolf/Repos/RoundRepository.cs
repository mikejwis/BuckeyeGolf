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
            var tmpAvg = 0.0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.TotalScore != 0);
            if (rounds.Count() > 0) tmpAvg = rounds.Average(r => r.TotalScore);
            return Math.Round(tmpAvg, 2);
        }

        public int GetPlayerLowRound(Guid playerId)
        {
            var tmpLow = 0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.TotalScore != 0);
            if (rounds.Count() > 0) tmpLow = rounds.Min(r => r.TotalScore);
            return tmpLow;
        }

        public int GetPlayerHighRound(Guid playerId)
        {
            var tmpHigh = 0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.TotalScore != 0);
            if (rounds.Count() > 0) tmpHigh = rounds.Max(r => r.TotalScore);
            return tmpHigh;
        }

        public double GetPlayerTotalPoints(Guid playerId)
        {
            var totalPts = 0.0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0);
            if (rounds.Count() > 0) totalPts = rounds.Sum(r => r.TotalPoints);
            return totalPts;
        }

        public int GetPlayerBirieTotal(Guid playerId)
        {
            var total = 0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0);
            if (rounds.Count() > 0) total = rounds.Sum(r => r.BirdieCnt);
            return total;
        }

        public int GetPlayerParTotal(Guid playerId)
        {
            var total = 0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0);
            if (rounds.Count() > 0) total = rounds.Sum(r => r.ParCnt);
            return total;
        }

        public int GetPlayerBogeyTotal(Guid playerId)
        {
            var total = 0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0);
            if (rounds.Count() > 0) total = rounds.Sum(r => r.BogeyCnt);
            return total;
        }
        
        public RoundModel GetWeeklyRound(Guid playerId, Guid weekId)
        {
            return DataSet.Single(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.WeekId.CompareTo(weekId) == 0);
        }
    }
}