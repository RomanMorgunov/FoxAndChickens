using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class WinEventArgs : EventArgs
    {
        public WinEventArgs(PlayerPerson playerPerson)
        {
            this.Winner = playerPerson;
        }

        public PlayerPerson Winner { get; protected internal set; }
    }

    public class EntitiesPropertiesEventArgs : EventArgs
    {
        public EntitiesPropertiesEventArgs(IDictionary<string, bool> isMovablePairs, IDictionary<string, ImageType> imageTypePairs, int chickensLeftBeforeLosing)
        {
            IsMovablePairs = isMovablePairs;
            ImageTypePairs = imageTypePairs;
            ChickensLeftBeforeLosing = chickensLeftBeforeLosing;
        }

        public IDictionary<string, bool> IsMovablePairs { get; protected internal set; }
        public IDictionary<string, ImageType> ImageTypePairs { get; protected internal set; }
        public int ChickensLeftBeforeLosing { get; protected internal set; }
    }
}
