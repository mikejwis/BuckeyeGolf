using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BuckeyeGolf.Models;
using System.Threading.Tasks;

namespace BuckeyeGolf.Repos
{
    public class RoundRepository : EntityRepository<RoundModel>
    {
        public RoundRepository() : base() { }

        public RoundRepository(GolfDbContext context) : base(context) { }

        public async Task<List<RoundModel>> GetWeeklyRounds(Guid weekId)
        {
            return await DataSet.Where(r => r.WeekId.CompareTo(weekId) == 0).ToListAsync();
        }

        public async Task<List<RoundModel>> GetPlayerRounds(Guid playerId)
        {
            return await DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0).ToListAsync();
        }

        public int GetPlayerWins(Guid playerId)
        {
            return DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.Result == MatchupResult.Win).Count();
        }

        public int GetPlayerLosses(Guid playerId)
        {
            return DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.Result == MatchupResult.Loss).Count();
        }

        public int GetPlayerTies(Guid playerId)
        {
            return DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.Result == MatchupResult.Tie).Count();
        }

        public double GetPlayerScoreAverage(Guid playerId)
        {
            var tmpAvg = 0.0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.TotalScore != 0);
            if (rounds.Count() > 0) tmpAvg = rounds.Average(r => r.TotalScore);
            return Math.Round(tmpAvg, 2);
        }

        public double GetPlayerScoreAverage(Guid playerId, bool firstHalf)
        {
            var tmpAvg = 0.0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.TotalScore != 0 && r.SeasonFirstHalf == firstHalf);
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

        public double GetPlayerTotalPoints(Guid playerId, bool firstHalf)
        {
            var totalPts = 0.0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.SeasonFirstHalf == firstHalf);
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

        public int GetPlayerBirieTotal(Guid playerId, bool firstHalf)
        {
            var total = 0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.SeasonFirstHalf == firstHalf);
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

        public int GetPlayerParTotal(Guid playerId, bool firstHalf)
        {
            var total = 0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.SeasonFirstHalf == firstHalf);
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

        public int GetPlayerBogeyTotal(Guid playerId, bool firstHalf)
        {
            var total = 0;
            var rounds = DataSet.Where(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.SeasonFirstHalf == firstHalf);
            if (rounds.Count() > 0) total = rounds.Sum(r => r.BogeyCnt);
            return total;
        }

        public RoundModel GetWeeklyRound(Guid playerId, Guid weekId)
        {
            return DataSet.Single(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.WeekId.CompareTo(weekId) == 0);
        }
    }
}