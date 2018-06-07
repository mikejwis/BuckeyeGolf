using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Services
{
    // Ideally flight would be a prop on the player
    public class FlightService
    {
        private static Hashtable _flightHash = new Hashtable();

        public FlightService()
        {
            _flightHash.Add("Mike","A");
            _flightHash.Add("Kevin", "A");
            _flightHash.Add("Keith","A");
            _flightHash.Add("Len", "A");
            _flightHash.Add("Tom S", "A");
            _flightHash.Add("Ron", "A");
            _flightHash.Add("Bill L", "A");
            _flightHash.Add("John", "A");

            _flightHash.Add("B Robinson", "B");
            _flightHash.Add("Mark", "B");
            _flightHash.Add("Todd", "B");
            _flightHash.Add("Emil", "B");
            _flightHash.Add("Bill H", "B");
            _flightHash.Add("Bill B", "B");
            _flightHash.Add("Vince", "B");
            _flightHash.Add("B Roberto", "B");
        }


        public string GetAssignedFlight(string playerName)
        {
            return _flightHash[playerName] as string;
        }
    }
}