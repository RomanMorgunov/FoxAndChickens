using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BL
{
    public class WinEventArgs : EventArgs
    {
        public WinEventArgs(PlayerCharacter playerCharacter)
        {
            this.Winner = playerCharacter;
        }

        public PlayerCharacter Winner { get; protected internal set; }
    }

    public class EntitiesPropertiesEventArgs : EventArgs
    {
        public IDictionary<Point, bool> IsMovablePairs { get; protected internal set; }
        public IDictionary<Point, ImageType> ImageTypePairs { get; protected internal set; }
        public int ChickensLeftBeforeLosing { get; protected internal set; }

        public EntitiesPropertiesEventArgs(IDictionary<Point, bool> isMovablePairs, IDictionary<Point, ImageType> imageTypePairs, int chickensLeftBeforeLosing)
        {
            IsMovablePairs = isMovablePairs;
            ImageTypePairs = imageTypePairs;
            ChickensLeftBeforeLosing = chickensLeftBeforeLosing;
        }
    }
}
