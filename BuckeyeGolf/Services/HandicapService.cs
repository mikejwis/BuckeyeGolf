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
        private int _roundParFront;
        private int _roundParBack;

        public HandicapService(int handicapWeeks, double roundAdjustment, int roundParFront, int roundParBack)
        {
            _handicapWeeks = handicapWeeks;
            _roundAdjustment = roundAdjustment;
            _roundParFront = roundParFront;
            _roundParBack = roundParBack;
        }

        public int GetHandicap(RepoProvider repoProvider, WeekModel week, Guid playerId)
        {
            var result = 0;
            if (week.BeenPlayed)
            {
                result = repoProvider.RoundRepo.GetWeeklyRound(playerId, week.WeekId).Handicap;
            }
            else
            {
                result = ServiceProvider.HandicapInstance.CalculateHandicap(playerId);
            }
            return result;
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
                var parTotal = 0;
                var overParTotal = 0.0;
                var player = repoProvider.PlayerRepo.Get(playerId);
                for (int i = 0; i < _handicapWeeks && i < weeks.Count(); i++)
                {
                    var round = repoProvider.RoundRepo.GetWeeklyRound(playerId, weeks[i].WeekId);
                    runningTotal += (round.TotalScore * _roundAdjustment);
                    if (round.TotalScore != 0)
                    {
                        nbrRoundsWithScore++;
                        var thisPar = round.Front?_roundParFront:_roundParBack;
                        parTotal += thisPar;
                        var diff = (round.TotalScore - thisPar) * _roundAdjustment;
                        overParTotal += diff;
                    }
                }
                if (player.HandicapRound1 > 0)
                {
                    runningTotal += (player.HandicapRound1 * _roundAdjustment);
                    nbrRoundsWithScore++;
                    parTotal += _roundParFront;
                    var diff = (player.HandicapRound1 - _roundParFront) * _roundAdjustment;
                    overParTotal += diff;
                }
                if (player.HandicapRound2 > 0)
                {
                    runningTotal += (player.HandicapRound2 * _roundAdjustment);
                    nbrRoundsWithScore++;
                    parTotal += _roundParBack;
                    var diff = (player.HandicapRound2 - _roundParBack) * _roundAdjustment;
                    overParTotal += diff;
                }
                if(nbrRoundsWithScore > 0 && runningTotal > 0.0)
                {
                    //Third Scoring Method
                    double avg = overParTotal / nbrRoundsWithScore;

                    //Second Version
                    //double totalOverPar = runningTotal - parTotal;
                    //double avg = totalOverPar / nbrRoundsWithScore;
                    
                    retVal = (int)Math.Round(avg, 0, MidpointRounding.AwayFromZero);
                    
                    //First version
                    //double avg = runningTotal / nbrRoundsWithScore;
                    //retVal = (int)Math.Round(avg, 0, MidpointRounding.AwayFromZero) - _roundPar;
                }
            }
            return retVal;
        }
    }
}