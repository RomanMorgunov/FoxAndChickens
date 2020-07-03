using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class WinEventArgs
    {
        public WinEventArgs(PlayerPerson playerPerson)
        {
            this.Winner = playerPerson;
        }

        public PlayerPerson Winner { get; protected internal set; }
    }
}
