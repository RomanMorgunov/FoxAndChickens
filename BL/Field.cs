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
        protected List<Dictionary<string, Entity>> _bestsWays;

        public PlayerPerson LastPerson { get; protected internal set; }

        public bool GameOver { get; protected set; }

        protected internal Field()
        {
            //The field consist of 33 cells
            _entities = new Dictionary<string, Entity>(33);
            _bestsWays = new List<Dictionary<string, Entity>>(8);
            GameOver = false;
            InitEntities();
        }

        protected Field(IDictionary<string, Entity> entities)
        {
            GameOver = false;
            _entities = new Dictionary<string, Entity>(entities);
            _bestsWays = new List<Dictionary<string, Entity>>(8);
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

        protected void UpdateIsMovable(Dictionary<string, Entity> moves)
        {
            foreach (var item in _entities.Values)
            {
                item.IsMovable = false;
            }

            int count = 0;
            foreach (var item in moves.Values)
            {
                count++;
                item.IsMovable = true;
            }

            if (count == 0)
                GameOver = true;
        }

        protected internal void CheckOnTheEndOfTheGame()
        {
            if (_entities.Values.Where(e => e.EntityType == EntityType.Chicken).Count() - 8 == 0)
            {
                UpdateIsMovable(new Dictionary<string, Entity>(1));
            }

            int count = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 2; x < 5; x++)
                {
                    if (_entities[$"{x}{y}"].EntityType == EntityType.Chicken)
                        count++;
                }
            }
            if (count == 9)
            {
                UpdateIsMovable(new Dictionary<string, Entity>(1));
            }
        }

        protected internal EntityType GetEntityTypeOfMovingCharacters()
        {
            var item = _entities.Where(p => p.Value.IsMovable == true).FirstOrDefault();
            if (item.Key is null || item.Value is null)
                throw new ArgumentNullException("It is impossible to obtain data of moving characters.");
            return item.Value.EntityType;
        }

        protected internal abstract void UpdateEntitiesProperty(string entityKey);
    }
}
