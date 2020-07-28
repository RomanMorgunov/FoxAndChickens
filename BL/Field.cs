using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BL
{
    internal class Field
    {
        protected IDictionary<string, Entity> _entities;

        protected internal bool GameOver { get; protected set; }
        protected internal PlayerPerson LastPerson { get; protected set; }
        protected internal List<Dictionary<string, Entity>> BestsWays { get; protected set; }

        protected internal Field()
        {
            GameOver = false;
            LastPerson = PlayerPerson.Fox;            
            _entities = new Dictionary<string, Entity>(33);       //The field consist of 33 cells
            BestsWays = new List<Dictionary<string, Entity>>(8);

            InitEntities();
            InitMovablePersons();
        }

        protected Field(IDictionary<string, Entity> entities, PlayerPerson lastPerson, bool gameOver, 
            List<Dictionary<string, Entity>> bestWays)
        {
            GameOver = gameOver;
            BestsWays = bestWays;
            LastPerson = lastPerson;
            _entities = new Dictionary<string, Entity>(entities);
        }

        protected internal Field Clone(bool isCopyBestWays = false)
        {
            Dictionary<string, Entity> entities = new Dictionary<string, Entity>(33);
            foreach (var item in _entities)
            {
                entities.Add(item.Key, item.Value.Clone());
            }

            List<Dictionary<string, Entity>> bestWays = new List<Dictionary<string, Entity>>(8);
            if (isCopyBestWays)
            {
                foreach (var way in this.BestsWays)
                {
                    Dictionary<string, Entity> copyOfTheWay = new Dictionary<string, Entity>(2);
                    foreach (var item in way)
                    {
                        copyOfTheWay.Add(item.Key, item.Value.Clone());
                    }
                    bestWays.Add(copyOfTheWay);
                }
            }

            return new Field(entities, this.LastPerson, GameOver, bestWays);
        }

        protected void InitEntities()
        {
            for (int y = 0; y < 2; y++)
            {
                for (int x = 2; x < 5; x++)
                {
                    Entity entity = new Entity(x, y, EntityType.EmptyCell, ImageType.EmptyCellImage, false);
                    _entities.Add(entity.GetKey(), entity);
                }
            }

            for (int y = 2; y < 4; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    Entity entity = new Entity(x, y, EntityType.EmptyCell, ImageType.EmptyCellImage, false);

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
                    Entity entity = new Entity(x, y, EntityType.Chicken, ImageType.ChickenImage, true);
                    _entities.Add(entity.GetKey(), entity);
                }
            }

            for (int y = 5; y < 7; y++)
            {
                for (int x = 2; x < 5; x++)
                {
                    Entity entity = new Entity(x, y, EntityType.Chicken, ImageType.ChickenImage, false);
                    _entities.Add(entity.GetKey(), entity);
                }
            }
        }

        //initializes BestsWays for AI
        protected void InitMovablePersons()
        {
            Dictionary<string, Entity> moves;
            FindMovableCharacters(out moves);
            UpdateIsMovable(moves);
        }

        protected internal IDictionary<string, Entity> GetEntities()
        {
            return _entities;
        }

        protected internal void UpdateEntitiesProperties(string entityKey)
        {
            if (string.IsNullOrEmpty(entityKey))
                throw new NullReferenceException("Variable \"entityKey\" is null or empty.");

            Entity entity = _entities[entityKey];
            Dictionary<string, Entity> moves;

            if (entity.IsMovable == false)
                throw new ArgumentException("This is not a moving person.");

            ConvertDeadChickenAndTrackAndStartPositionOfMovementImageTypesToEmptyCell();

            if (entity.EntityType == EntityType.Chicken)
            {
                FindChickenWays(entity, out moves);
                LastPerson = PlayerPerson.Chicken;
            }
            else if (entity.EntityType == EntityType.Fox)
            {
                FindFoxWays(entity, out moves);
                LastPerson = PlayerPerson.Fox;
            }
            //empty cell
            else
            {
                UpdateEntityTypeAndImageType(entityKey);
                FindMovableCharacters(out moves);
            }

            UpdateIsMovable(moves);
            CheckOnTheEndOfTheGame();
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
                    //if anybody can move
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

        protected void ConvertDeadChickenAndTrackAndStartPositionOfMovementImageTypesToEmptyCell()
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
            if (BestsWays is null)
                throw new ArgumentException("Invalid killing list.");

            var dict = BestsWays.FirstOrDefault(d => d.Values.Last().Equals(emptyCell));
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
            availableCharacters = new Dictionary<string, Entity>(14);

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
                BestsWays.Clear();

                int countOfChikens = 0;
                foreach (var item in _entities.Values)
                {
                    //13 chickens in the game
                    if (countOfChikens == 13)
                        break;

                    if (item.EntityType == EntityType.Chicken)
                    {
                        countOfChikens++;
                        FindChickenWays(item, out Dictionary<string, Entity> moves, clearBestWays: false);
                        if (moves.Count != 0)
                            availableCharacters.Add(item.GetKey(), item);
                    }
                }
            }
        }

        protected void FindChickenWays(Entity entity, out Dictionary<string, Entity> moves, bool clearBestWays = true)
        {
            if (clearBestWays) BestsWays.Clear();

            FindTheMovingWays(entity, out moves, PlayerPerson.Chicken);

            foreach (var item in moves)
            {
                var d = new Dictionary<string, Entity>(2);
                d.Add(entity.GetKey(), entity);
                d.Add(item.Key, item.Value);
                BestsWays.Add(d);
            }
        }

        protected void FindTheMovingWays(Entity entity, out Dictionary<string, Entity> moves, PlayerPerson playerPerson)
        {
            //chicken can't move down
            int y_max = playerPerson == PlayerPerson.Chicken ? 1 : 2;

            moves = new Dictionary<string, Entity>(8);

            for (int y = -1; y < y_max; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    //does not move
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
            BestsWays.Clear();

            //finding biggests killing lists
            List<Dictionary<string, Entity>> ways = new List<Dictionary<string, Entity>>();
            Dictionary<string, Entity> dict = new Dictionary<string, Entity>(5);
            dict.Add(entity.GetKey(), entity);

            FindingKillingWays(dict, in ways, new Point(0, 0));

            //delete faulty ways
            ways.RemoveAll(d => d.Count < 3);

            //killing list is empty
            if (ways.Count == 0)
            {
                FindTheMovingWays(entity, out moves, PlayerPerson.Fox);

                foreach (var item in moves)
                {
                    var d = new Dictionary<string, Entity>(2);
                    d.Add(entity.GetKey(), entity);
                    d.Add(item.Key, item.Value);
                    BestsWays.Add(d);
                }
                return;
            }

            //find ways with max length and add it in BestWays
            ways.Sort(delegate (Dictionary<string, Entity> x, Dictionary<string, Entity> y)
            {
                if (x.Count == y.Count) return 0;
                else if (x.Count > y.Count) return -1;
                else return 1;
            });
            BestsWays.AddRange(ways.Where(d => d.Count == ways[0].Count));

            moves = new Dictionary<string, Entity>(4);
            foreach (var item in BestsWays)
            {
                var pair = item.Last();
                moves[pair.Key] = pair.Value;
            }
        }

        protected void FindingKillingWays(Dictionary<string, Entity> currentWay, 
            in List<Dictionary<string, Entity>> allWays, Point lastShift)
        {
            int count = 0;

            for (int shiftY = -1; shiftY < 2; shiftY++)
            {
                for (int shiftX = -1; shiftX < 2; shiftX++)
                {
                    if ((shiftX != 0 && shiftY != 0) || (shiftX == 0 && shiftY == 0) || 
                        (lastShift.X == -shiftX && lastShift.Y == -shiftY) /*forbid to move back*/) 
                        continue;

                    var cell = currentWay.Last().Value;
                    string keyCh = $"{cell.X + shiftX}{cell.Y + shiftY}";
                    if (_entities.TryGetValue(keyCh, out Entity chicken) && chicken.EntityType == EntityType.Chicken)
                    {
                        string keyEmpty = $"{cell.X + 2 * shiftX}{cell.Y + 2 * shiftY}";
                        if (_entities.TryGetValue(keyEmpty, out Entity empty) && empty.EntityType == EntityType.EmptyCell)
                        {
                            count++;
                            currentWay.Add(keyCh, chicken);
                            currentWay.Add(keyEmpty, empty);
                            FindingKillingWays(new Dictionary<string, Entity>(currentWay), in allWays, 
                                new Point(shiftX, shiftY));
                            currentWay.Remove(keyEmpty);
                            currentWay.Remove(keyCh);
                        }
                    }
                }
            }

            if (count == 0)
                allWays.Add(currentWay);
        }

        protected internal int GetCountOfChickensOnWinningPosition()
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
            return count;
        }
    }
}
