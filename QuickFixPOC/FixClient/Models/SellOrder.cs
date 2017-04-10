using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixClient.Models
{
    public class SellOrder : FixOrder
    {
        private readonly int _side = 2;

        public override int Side
        {
            get { return this._side; }
        }
    }
}
