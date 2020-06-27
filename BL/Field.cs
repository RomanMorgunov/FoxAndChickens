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
        protected List<Dictionary<string, Entity>> bestsWays;

        public PlayerPerson LastPerson { get; protected set; }

        public bool GameOver { get; protected set; }

        protected internal Field()
        {
            //The field consist of 33 cells
            _entities = new Dictionary<string, Entity>(33);
            GameOver = false;
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
                        ImageType = ImageType.EmptyCellImage
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
                        ImageType = ImageType.EmptyCellImage
                    };

                    if (x == 3 && y == 2)
                    {
                        entity.EntityType = EntityType.Fox;
                        entity.ImageType = ImageType.FoxImage;
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
                        ImageType = ImageType.ChickenImage
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
                        ImageType = ImageType.ChickenImage
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
