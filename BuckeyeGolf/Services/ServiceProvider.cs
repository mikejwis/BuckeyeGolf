using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Services
{
    //need to refactor to use unity
    public class ServiceProvider
    {
        private static HandicapService _handicapInstance;
        private static ScoringService _scoringInstance;
        private static FlightService _flightService;

        private ServiceProvider() { }

        public static FlightService FlightService
        {
            get
            {
                if(_flightService == null)
                {
                    _flightService = new FlightService();
                }
                return _flightService;
            }
        }

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
                    var roundParFront = int.Parse(HttpContext.Current.Application["RoundParFront"].ToString());
                    var roundParBack = int.Parse(HttpContext.Current.Application["RoundParBack"].ToString());
                    
                    _handicapInstance = new HandicapService(handicapWeekSettings, roundAdj, roundParFront, roundParBack);
                }
                return _handicapInstance;
            }
        }
    }
}