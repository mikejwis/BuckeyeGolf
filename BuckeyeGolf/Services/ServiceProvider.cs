using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Services
{
    public class ServiceProvider
    {
        private static HandicapService _handicapInstance;
        private static ScoringService _scoringInstance;

        private ServiceProvider() { }

        public static ScoringService ScoringInstance
        {
            get
            {
                if(_scoringInstance == null)
                {
                    _scoringInstance = new ScoringService();
                }
                return _scoringInstance;
            }
        }

        public static HandicapService HandicapInstance
        {
            get
            {
                if (_handicapInstance == null)
                {
                    var handicapWeekSettings = int.Parse(HttpContext.Current.Application["HandicapWeeks"].ToString());
                    var roundAdj = double.Parse(HttpContext.Current.Application["HandicapRoundAdj"].ToString());
                    var roundPar = int.Parse(HttpContext.Current.Application["RoundPar"].ToString());
                    _handicapInstance = new HandicapService(handicapWeekSettings, roundAdj, roundPar);
                }
                return _handicapInstance;
            }
        }
    }
}