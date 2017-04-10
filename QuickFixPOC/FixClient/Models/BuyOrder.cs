using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FixClient.Models
{
    public class BuyOrder : FixOrder
    {
        private readonly int _side = 1;

        public override int Side {
            get { return this._side;  }
        }
    }

}
