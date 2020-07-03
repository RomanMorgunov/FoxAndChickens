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

        protected internal abstract void UpdateEntitiesProperty(string entityKey);

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
            
            foreach (var item in moves.Values)
            {
                item.IsMovable = true;
            }
        }

        protected internal void CheckOnTheEndOfTheGame()
        {
            if (!(GetChickensCount() - 8 == 0))
            {
                int count = 0;
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 2; x < 5; x++)
                    {
                        if (_entities[$"{x}{y}"].EntityType == EntityType.Chicken)
                            count++;
                    }
                }
                if (count != 9)
                {
                    if (!(_entities.Values.All(e => e.IsMovable == false)))
                    {
                        GameOver = false;
                        return;
                    }
                }
            }

            UpdateIsMovable(new Dictionary<string, Entity>(1));
            GameOver = true;
        }

        protected internal int GetChickensCount()
        {
            return _entities.Values.Where(e => e.EntityType == EntityType.Chicken).Count();
        }

        protected internal EntityType GetEntityTypeOfMovingCharacters()
        {
            var item = _entities.Where(p => p.Value.IsMovable == true).FirstOrDefault();
            if (item.Key is null || item.Value is null)
                throw new ArgumentNullException("It is impossible to obtain data of moving characters.");
            return item.Value.EntityType;
        }

        protected void ConvertDeadChickenTrackAndAndStartPositionOfMovementImageTypeToEmptyCell()
        {
            foreach (var item in _entities.Values)
            {
                if (item.ImageType == ImageType.DeadChickenImage ||
                    item.ImageType == ImageType.TrackImage ||
                    item.ImageType == ImageType.StartPositionOfMovementImage)
                    item.ImageType = ImageType.EmptyCellImage;
            }
        }

        protected void UpdateEntityTypeAndImageType(string entityKey)
        {
            Entity emptyCell = _entities[entityKey];
            if (_bestsWays is null)
                throw new ArgumentException("Invalid killing list.");

            var dict = _bestsWays.FirstOrDefault(d => d.Values.Last().Equals(emptyCell));
            if (dict is null)
                throw new ArgumentException("Invalid entity key.");
            var array = dict.ToArray();

            Entity newEntity = array[array.Length - 1].Value;
            if (newEntity.EntityType != EntityType.EmptyCell)
                throw new ArgumentException("Invalid bests ways.");

            Entity lastEntity = array[0].Value;

            if (LastPerson == PlayerPerson.Chicken)
            {
                newEntity.EntityType = EntityType.Chicken;
                newEntity.ImageType = ImageType.ChickenImage;

                if (lastEntity.EntityType != EntityType.Chicken)
                    throw new ArgumentException("Invalid bests ways.");
                lastEntity.EntityType = EntityType.EmptyCell;
                lastEntity.ImageType = ImageType.StartPositionOfMovementImage;
            }
            else
            {
                newEntity.EntityType = EntityType.Fox;
                newEntity.ImageType = ImageType.FoxImage;

                if (lastEntity.EntityType != EntityType.Fox)
                    throw new ArgumentException("Invalid bests ways.");
                lastEntity.EntityType = EntityType.EmptyCell;
                lastEntity.ImageType = ImageType.StartPositionOfMovementImage;

                for (int i = 1; i < array.Length - 1; i++)
                {
                    Entity cell = array[i].Value;

                    //if even
                    if (i % 2 == 0)
                    {
                        if (cell.EntityType != EntityType.EmptyCell)
                            throw new ArgumentException("Invalid bests ways.");
                        cell.ImageType = ImageType.TrackImage;
                    }
                    else
                    {
                        if (cell.EntityType != EntityType.Chicken)
                            throw new ArgumentException("Invalid bests ways.");
                        cell.EntityType = EntityType.EmptyCell;
                        cell.ImageType = ImageType.DeadChickenImage;
                    }
                }
            }
        }

        protected void FindMovableCharacters(out Dictionary<string, Entity> availableCharacters)
        {
            availableCharacters = new Dictionary<string, Entity>();

            //if the next move per fox
            if (LastPerson == PlayerPerson.Chicken)
            {
                foreach (var item in _entities.Values)
                {
                    if (item.EntityType == EntityType.Fox)
                    {
                        FindFoxWays(item, out Dictionary<string, Entity> moves);
                        if (moves.Count != 0)
                            availableCharacters.Add(item.GetKey(), item);

                        break;
                    }
                }
            }
            else
            {
                int countOfChikens = 0;
                foreach (var item in _entities.Values)
                {
                    //13 chickens in the game
                    if (countOfChikens == 13)
                        break;

                    if (item.EntityType == EntityType.Chicken)
                    {
                        countOfChikens++;
                        FindChickenWays(item, out Dictionary<string, Entity> moves);
                        if (moves.Count != 0)
                            availableCharacters.Add(item.GetKey(), item);
                    }
                }
            }
        }

        protected void FindChickenWays(Entity entity, out Dictionary<string, Entity> moves)
        {
            _bestsWays.Clear();
            FindTheMovingWays(entity, out moves, PlayerPerson.Chicken);

            foreach (var item in moves)
            {
                var d = new Dictionary<string, Entity>(2);
                d.Add(entity.GetKey(), entity);
                d.Add(item.Key, item.Value);
                _bestsWays.Add(d);
            }
        }

        protected void FindTheMovingWays(Entity entity, out Dictionary<string, Entity> moves, PlayerPerson playerPerson)
        {
            int y_max = playerPerson == PlayerPerson.Chicken ? 1 : 2;
            moves = new Dictionary<string, Entity>(8);

            for (int y = -1; y < y_max; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    string key = $"{entity.X + x}{entity.Y + y}";
                    if (_entities.TryGetValue(key, out Entity cell) && cell.EntityType == EntityType.EmptyCell)
                        moves.Add(key, cell);
                }
            }
        }

        protected void FindFoxWays(Entity entity, out Dictionary<string, Entity> moves)
        {
            _bestsWays.Clear();
            //finding biggests killing lists
            BeginFindingKillingWays(entity, out List<Dictionary<string, Entity>> ways);

            //killing list is empty
            if (ways.Count == 0)
            {
                FindTheMovingWays(entity, out moves, PlayerPerson.Fox);

                foreach (var item in moves)
                {
                    var d = new Dictionary<string, Entity>(2);
                    d.Add(entity.GetKey(), entity);
                    d.Add(item.Key, item.Value);
                    _bestsWays.Add(d);
                }
                return;
            }

            int maximum = ways[0].Count;

            for (int i = 1; i < ways.Count; i++)
            {
                if (maximum < ways[i].Count)
                    maximum = ways[i].Count;
            }

            foreach (var item in ways)
            {
                if (item.Count == maximum)
                    _bestsWays.Add(item);
            }

            moves = new Dictionary<string, Entity>(4);
            foreach (var item in _bestsWays)
            {
                var pair = item.Last();
                moves[pair.Key] = pair.Value;
            }
        }

        protected void BeginFindingKillingWays(Entity entity, out List<Dictionary<string, Entity>> ways)
        {
            ways = new List<Dictionary<string, Entity>>();

            for (int y = -1; y < 2; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    if (!(x == 0 || y == 0) || (x == 0 && y == 0))
                        continue;

                    string key = $"{entity.X + x}{entity.Y + y}";
                    if (_entities.TryGetValue(key, out Entity cell) && cell.EntityType == EntityType.Chicken)
                    {
                        Dictionary<string, Entity> d = new Dictionary<string, Entity>(5);
                        d.Add(entity.GetKey(), entity);
                        d.Add(key, cell);
                        FindKillingWays(d, ways);
                    }
                }
            }

            //delete faulty ways
            ways.RemoveAll(d => d.Count < 3);
        }

        protected void FindKillingWays(Dictionary<string, Entity> entities, in List<Dictionary<string, Entity>> ways)
        {
            //finding shifts
            var arr = entities.ToArray();
            string penult = arr[arr.Length - 2].Key;
            string last = arr[arr.Length - 1].Key;

            int lastX = int.Parse(last[0].ToString());
            int lastY = int.Parse(last[1].ToString());
            int shiftX = lastX - int.Parse(penult[0].ToString());
            int shiftY = lastY - int.Parse(penult[1].ToString());

            //checking on a empty cell
            string newKey = $"{lastX + shiftX}{lastY + shiftY}";
            if (!(_entities.TryGetValue(newKey, out Entity newEntity) && newEntity.EntityType == EntityType.EmptyCell))
            {
                //end of killing way
                entities.Remove(entities.Last().Key);
                ways.Add(entities);
                return;
            }
            entities.Add(newKey, newEntity);

            int count = 0;
            for (int y = -1; y < 2; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    if (!(x == 0 || y == 0) || (x == 0 && y == 0) || (x == -shiftX && y == -shiftY) /*prohibit back*/)
                        continue;

                    string key = $"{newEntity.X + x}{newEntity.Y + y}";
                    if (_entities.TryGetValue(key, out Entity cell) && cell.EntityType == EntityType.Chicken)
                    {
                        entities.Add(key, cell);
                        FindKillingWays(new Dictionary<string, Entity>(entities), ways);
                        entities.Remove(key);
                        count++;
                    }
                }
            }

            if (count == 0)
                ways.Add(entities);
        }
    }
}
