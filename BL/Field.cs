using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class Field
    {
        protected IDictionary<string, Entity> _entities;

        protected internal Field()
        {
            //The field consist of 33 cells
            _entities = new Dictionary<string, Entity>(33);
            InitEntities();
        }

        protected Field(IDictionary<string, Entity> entities)
        {
            _entities = new Dictionary<string, Entity>(entities);
        }

        protected internal abstract Field Clone();

        protected void InitEntities()
        {
            for (int y = 0; y < 2; y++)
            {
                for (int x = 2; x < 5; x++)
                {
                    Entity entity = new Entity()
                    {
                        X = x,
                        Y = y,
                        EntityType = EntityType.EmptyCell,
                        ImageType = ImageType.EmptyCellPicture
                    };
                    _entities.Add(entity.GetKey(), entity);
                }
            }

            for (int y = 2; y < 4; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    Entity entity = new Entity()
                    {
                        X = x,
                        Y = y,
                        EntityType = EntityType.EmptyCell,
                        ImageType = ImageType.EmptyCellPicture
                    };

                    if (x == 3 && y == 2)
                    {
                        entity.EntityType = EntityType.Fox;
                        entity.ImageType = ImageType.FoxPicture;
                    }

                    _entities.Add(entity.GetKey(), entity);
                }
            }

            for (int y = 4; y < 5; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    Entity entity = new Entity()
                    {
                        X = x,
                        Y = y,
                        IsMovable = true,
                        EntityType = EntityType.Chicken,
                        ImageType = ImageType.ChickenPicture
                    };

                    _entities.Add(entity.GetKey(), entity);
                }
            }

            for (int y = 5; y < 7; y++)
            {
                for (int x = 2; x < 5; x++)
                {
                    Entity entity = new Entity()
                    {
                        X = x,
                        Y = y,
                        EntityType = EntityType.Chicken,
                        ImageType = ImageType.ChickenPicture
                    };

                    _entities.Add(entity.GetKey(), entity);
                }
            }
        }

        protected internal IDictionary<string, Entity> GetEntities()
        {
            return _entities;
        }

        protected internal abstract void UpdateEntitiesProperty(string entityKey);
    }
}
