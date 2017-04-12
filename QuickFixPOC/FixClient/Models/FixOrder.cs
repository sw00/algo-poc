using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FixClient.Models
{
    public class FixOrder
    {
        
        public readonly int OrderBook = 1;
        public readonly char MsgType = 'D';
        public readonly OrderType OrderType = OrderType.Limit;
        public readonly int DisplayQuantity = 0;
        public readonly char OrderCapacity = 'A';

        public readonly int SecurityIdSource = 8;
        public readonly DateTime TransactionTime = DateTime.Now;

        public int OrderQuantity { get; set; }
        public Decimal Price { get; set; }

        public OrderSide Side { get; set; }

        private string _account;
        public string Account
        {
            set
            {
                bool valid = Regex.IsMatch(value, "^\\d{8}$");
                if (!valid)
                {
                    throw new FormatException("Invalid account number. Expected 8 digit number");
                }
                _account = value;
            }
            get { return _account; }
        }

        private string _securityId;
        public string SecurityId
        {
            set
            {
                bool valid = Regex.IsMatch(value, "^[A-Za-z0-9]+$");
                if (!valid)
                {
                    throw new FormatException("Invalid instrument/security identifier. Must be alpha-numeric.");
                }
                _securityId = value;
            }
            get
            {
                return _securityId;
            }
        }
    }


    public enum OrderType
    {
        Market = 1,
        Limit = 2,
        Stop = 3,
        StopLimit = 4,
        PeggedOrder = 'P',
        PeggedLimitOrder = 'R'
    }

    public enum OrderSide
    {
        Buy = 1,
        Sell = 2
    }
}
