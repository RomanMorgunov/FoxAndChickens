using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Entity
    {
        protected int _x;
        protected int _y;

        public int X
        {
            get => _x;
            protected internal set
            {
                if (value < 0 || value > 6)
                    throw new IndexOutOfRangeException("Coordinate \"X\" must be between 0 and 6.");
                _x = value;
            }
        }
        public int Y
        {
            get => _y;
            protected internal set
            {
                if (value < 0 || value > 6)
                    throw new IndexOutOfRangeException("Coordinate \"Y\" must be between 0 and 6.");
                _y = value;
            }
        }

        public EntityType EntityType { get; protected internal set; }

        public ImageType ImageType { get; protected internal set; }

        public bool IsMovable { get; protected internal set; }

        protected internal Entity() 
        {
            IsMovable = false;
        }

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

        public string GetKey()
        {
            return $"{X}{Y}";
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
