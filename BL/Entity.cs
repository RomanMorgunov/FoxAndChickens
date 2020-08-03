using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BL
{
    sealed internal class Entity
    {
        private Point _coordinates;

        internal Point Coordinates
        {
            get => _coordinates;
            private set
            {
                if (value.X < 0 || value.X > 6 || value.Y < 0 || value.Y > 6)
                    throw new IndexOutOfRangeException("Coordinate \"X\" must be between 0 and 6.");
                _coordinates = value;
            }
        }

        internal EntityType EntityType { get; set; }
        internal ImageType ImageType { get; set; }
        internal bool IsMovable { get; set; }

        internal Entity() { }

        internal Entity(Point coordinates, EntityType entityType, ImageType imageType, bool isMovable)
        {
            _coordinates = coordinates;
            this.EntityType = entityType;
            this.ImageType = imageType;
            this.IsMovable = isMovable;
        }

        internal Entity Clone()
        {
            return new Entity(this.Coordinates, this.EntityType, this.ImageType, this.IsMovable);
        }

        public override bool Equals(object obj)
        {
            return obj is Entity entity &&
                   EqualityComparer<Point>.Default.Equals(Coordinates, entity.Coordinates) &&
                   EntityType == entity.EntityType &&
                   ImageType == entity.ImageType &&
                   IsMovable == entity.IsMovable;
        }

        public override int GetHashCode()
        {
            int hashCode = -1107326715;
            hashCode = hashCode * -1521134295 + Coordinates.GetHashCode();
            hashCode = hashCode * -1521134295 + EntityType.GetHashCode();
            hashCode = hashCode * -1521134295 + ImageType.GetHashCode();
            hashCode = hashCode * -1521134295 + IsMovable.GetHashCode();
            return hashCode;
        }
    }

    public enum EntityType
    {
        EmptyCell,
        Chicken,
        Fox
    }

    public enum ImageType
    {
        EmptyCellImage,
        ChickenImage,
        FoxImage,
        DeadChickenImage,
        StartPositionOfMovementImage,
        TrackImage
    }
}
