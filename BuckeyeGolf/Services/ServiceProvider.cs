using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Services
{
    public class ServiceProvider
    {
        private static HandicapService _handicapInstance;

        private ServiceProvider() { }

        public static HandicapService HandicapInstance
        {
            get
            {
                if (_handicapInstance == null) _handicapInstance = new HandicapService();
                return _handicapInstance;
            }
        }
    }
}