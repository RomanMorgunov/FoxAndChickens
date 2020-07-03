using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MovingEventArgs : EventArgs
    {
        public MovingEventArgs(IDictionary<string, bool> isMovablePairs)
        {
            IsMovablePairs = isMovablePairs;
        }

        public IDictionary<string, bool> IsMovablePairs { get; protected internal set; }
    }
}
