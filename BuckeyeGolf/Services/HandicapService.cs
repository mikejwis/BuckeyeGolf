using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuckeyeGolf.Models;

namespace BuckeyeGolf.Services
{
    public class HandicapService
    {
        public int CalculateHandicap(Guid playerId)
        {
            //HttpContext.Current.Application.Lock();
            //HttpContext.Current.Application["Name"] = "Value";
            //HttpContext.Current.Application.UnLock();
            var retVal = 0;
            var handicapConfigSetting = int.Parse(HttpContext.Current.Application["HandicapWeeks"].ToString());

            using(var context = new GolfDbContext())
            {
                var weeks = context.Weeks.Where(w=>w.BeenPlayed == true).OrderByDescending(w=>w.WeekNbr).ToList();
                var runningTotal = 0;
                var nbrRoundsWithScore = 0;
                for(int i=0; i<handicapConfigSetting && i<weeks.Count(); i++)
                {
                    var weekId = weeks[i].WeekId;
                    var round = context.Rounds.Single(r => r.PlayerRefId.CompareTo(playerId) == 0 && r.WeekId.CompareTo(weekId) == 0);
                    runningTotal = runningTotal + round.TotalScore;
                    if (round.TotalScore != 0) nbrRoundsWithScore++;
                }
                double avg = runningTotal / nbrRoundsWithScore;
                retVal = (int)Math.Round(avg, 0, MidpointRounding.AwayFromZero);
            }
            return retVal;
        }
    }
}