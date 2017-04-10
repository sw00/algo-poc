using FixClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixClient.Contracts
{
    public interface ITradeClient
    {
        bool Send(BuyOrder order);

        bool Send(SellOrder order);
    }
}
