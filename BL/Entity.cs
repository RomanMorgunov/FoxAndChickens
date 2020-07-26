using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class Entity
    {
        protected int _x;
        protected int _y;

        protected internal int X
        {
            get => _x;
            set
            {
                if (value < 0 || value > 6)
                    throw new IndexOutOfRangeException("Coordinate \"X\" must be between 0 and 6.");
                _x = value;
            }
        }

        protected internal int Y
        {
            get => _y;
            set
            {
                if (value < 0 || value > 6)
                    throw new IndexOutOfRangeException("Coordinate \"Y\" must be between 0 and 6.");
                _y = value;
            }
        }

        protected internal EntityType EntityType { get; set; }
        protected internal ImageType ImageType { get; set; }
        protected internal bool IsMovable { get; set; }

        protected internal Entity() { }

        protected internal Entity(int x, int y, EntityType entityType, ImageType pictureType, bool isMovable)
        {
            X = x;
            Y = y;
            this.EntityType = entityType;
            this.ImageType = ImageType;
            this.IsMovable = isMovable;
        }

        protected internal Entity Clone()
        {
            return new Entity()
            {
                X = _x,
                Y = _y,
                EntityType = this.EntityType,
                ImageType = this.ImageType,
                IsMovable = this.IsMovable
            };
        }

        protected internal string GetKey()
        {
            return $"{X}{Y}";
        }

        public override bool Equals(object obj)
        {
            return obj is Entity entity &&
                   X == entity.X &&
                   Y == entity.Y &&
                   EntityType == entity.EntityType &&
                   ImageType == entity.ImageType &&
                   IsMovable == entity.IsMovable;
        }

        public override int GetHashCode()
        {
            int hashCode = -1038328219;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + EntityType.GetHashCode();
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
