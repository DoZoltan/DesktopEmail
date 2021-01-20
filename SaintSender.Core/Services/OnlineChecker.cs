using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SaintSender.Core.Services
{
    public class OnlineChecker
    {
        public static bool CheckIfComputerIsOnline() 
        {
            return (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable());
        }
    
    }
}
