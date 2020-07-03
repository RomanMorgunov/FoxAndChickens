using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ImageTypeEventArgs : EventArgs
    {
        public ImageTypeEventArgs(IDictionary<string, ImageType> imageTypePairs, int chickensLeftBeforeLosing)
        {
            ImageTypePairs = imageTypePairs;
            ChickensLeftBeforeLosing = chickensLeftBeforeLosing;
        }

        public IDictionary<string, ImageType> ImageTypePairs { get; protected internal set; }

        public int ChickensLeftBeforeLosing { get; protected internal set; }
    }
}
