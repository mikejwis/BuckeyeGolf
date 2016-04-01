using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;

namespace BuckeyeGolf.Services
{
    public class HandicapService
    {
        private int _handicapWeeks;
        private double _roundAdjustment;
        private int _roundPar;

        public HandicapService(int handicapWeeks, double roundAdjustment, int roundPar)
        {
            _handicapWeeks = handicapWeeks;
            _roundAdjustment = roundAdjustment;
            _roundPar = roundPar;
        }

        public int CalculateHandicap(Guid playerId)
        {
            //HttpContext.Current.Application.Lock();
            //HttpContext.Current.Application["Name"] = "Value";
            //HttpContext.Current.Application.UnLock();
            var retVal = 0;

            using(var repoProvider = new RepoProvider())
            {
                var weeks = repoProvider.WeekRepo.GetPlayedWeeks().OrderByDescending(w => w.WeekNbr).ToList();
                var runningTotal = 0.0;
                var nbrRoundsWithScore = 0;
                var player = repoProvider.PlayerRepo.Get(playerId);
                for (int i = 0; i < _handicapWeeks && i < weeks.Count(); i++)
                {
                    var round = repoProvider.RoundRepo.GetWeeklyRound(playerId, weeks[i].WeekId);
                    runningTotal += (round.TotalScore * _roundAdjustment);
                    if (round.TotalScore != 0) nbrRoundsWithScore++;
                }
                runningTotal += (player.HandicapRound1 * _roundAdjustment);
                nbrRoundsWithScore++;
                runningTotal += (player.HandicapRound2 * _roundAdjustment);
                nbrRoundsWithScore++;
                if(nbrRoundsWithScore > 0 && runningTotal > 0.0)
                {
                    double avg = runningTotal / nbrRoundsWithScore;
                    retVal = (int)Math.Round(avg, 0, MidpointRounding.AwayFromZero) - _roundPar;
                }
            }
            return retVal;
        }
    }
}