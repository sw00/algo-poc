using FixClient.Contracts;
using FixClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FixClientServices
{
    /// <summary>
    /// Summary description for FixClientService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FixClientService : System.Web.Services.WebService
    {

        ITradeClient _tradeClient;

        public FixClientService(ITradeClient tradeClient)
        {
            _tradeClient = tradeClient;
        }

        [WebMethod]
        public bool IssueBuyOrder(FixOrder buyOrder)
        {
            return _tradeClient.Send(buyOrder);
        }

        [WebMethod]
        public bool IssueSellOrder(SellOrder sellOrder)
        {
            return _tradeClient.Send(sellOrder);
        }
    }
}
