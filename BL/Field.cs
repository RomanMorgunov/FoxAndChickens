using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace BL
{
    sealed internal class Field
    {
        internal Point _lastCharacterCoordinates;
        readonly private List<Point> _eatingRuleForTheFox;
        readonly private Dictionary<Point, Entity> _entities;
        readonly private List<Point> _availableMovementsForTheFox;
        readonly private List<Point> _availableMovementsForChickens;

        internal bool GameOver { get; private set; }
        internal PlayerCharacter LastCharacterType { get; private set; }
        internal List<Dictionary<Point, Entity>> AllWays { get; private set; }

        internal Field(Dictionary<Direction, bool> eatingRuleForTheFox,
            Dictionary<Direction, bool> availableMovementsForTheFox,
            Dictionary<Direction, bool> availableMovementsForChickens,
            Dictionary<Point, EntityType> gameMap)
        {
            GameOver = false;
            LastCharacterType = PlayerCharacter.Fox;
            _entities = new Dictionary<Point, Entity>(33);       //The field consist of 33 cells
            AllWays = new List<Dictionary<Point, Entity>>(8);
            _eatingRuleForTheFox = new List<Point>(4);
            _availableMovementsForTheFox = new List<Point>(8);
            _availableMovementsForChickens = new List<Point>(5);

            InitDirections(eatingRuleForTheFox, availableMovementsForTheFox, availableMovementsForChickens);
            InitEntities(gameMap);
            UpdateAllWays();
            UpdateIsMovableProperty(true, new Point(0, 0));
            CheckCountEntities();
        }

        private Field(Dictionary<Point, Entity> entities, PlayerCharacter lastCharacterType, bool gameOver,
            List<Point> eatingRuleForTheFox,
            List<Point> availableMovementsForTheFox,
            List<Point> availableMovementsForChickens)
        {
            GameOver = gameOver;
            _entities = entities;
            LastCharacterType = lastCharacterType;
            AllWays = new List<Dictionary<Point, Entity>>(8);
            _eatingRuleForTheFox = eatingRuleForTheFox;
            _availableMovementsForTheFox = availableMovementsForTheFox;
            _availableMovementsForChickens = availableMovementsForChickens;

            UpdateAllWays();
        }

        internal Field Clone()
        {
            Dictionary<Point, Entity> entities = new Dictionary<Point, Entity>(33);
            foreach (var item in _entities)
            {
                entities.Add(item.Key, item.Value.Clone());
            }
            return new Field(entities, LastCharacterType, GameOver, 
                _eatingRuleForTheFox, _availableMovementsForTheFox, _availableMovementsForChickens);
        }

        private void InitEntities(Dictionary<Point, EntityType> gameMap)
        {
            Dictionary<EntityType, ImageType> pairs = new Dictionary<EntityType, ImageType>(3);
            pairs[EntityType.EmptyCell] = ImageType.EmptyCellImage;
            pairs[EntityType.Chicken] = ImageType.ChickenImage;
            pairs[EntityType.Fox] = ImageType.FoxImage;

            foreach (var item in gameMap.Reverse())
            {
                _entities.Add(item.Key, new Entity(item.Key, item.Value, pairs[item.Value], false));
            }
        }

        private void InitDirections(Dictionary<Direction, bool> eatingRuleForTheFox,
            Dictionary<Direction, bool> availableMovementsForTheFox,
            Dictionary<Direction, bool> availableMovementsForChickens)
        {
            Dictionary<Direction, Point> pairs = new Dictionary<Direction, Point>();
            pairs[Direction.Top] = new Point(0, -1);
            pairs[Direction.Left] = new Point(-1, 0);
            pairs[Direction.Right] = new Point(1, 0);
            pairs[Direction.Bottom] = new Point(0, 1);
            pairs[Direction.TopLeft] = new Point(-1, -1);
            pairs[Direction.TopRight] = new Point(1, -1);
            pairs[Direction.BottomLeft] = new Point(-1, 1);
            pairs[Direction.BottomRight] = new Point(1, 1);

            foreach (var item in eatingRuleForTheFox)
            {
                if (item.Value)
                    _eatingRuleForTheFox.Add(pairs[item.Key]);
            }
            foreach (var item in availableMovementsForTheFox)
            {
                if (item.Value)
                    _availableMovementsForTheFox.Add(pairs[item.Key]);
            }
            foreach (var item in availableMovementsForChickens)
            {
                if (item.Value)
                    _availableMovementsForChickens.Add(pairs[item.Key]);
            }
        }

        internal void Move(Point entityCoordinates)
        {
            Entity entity = _entities[entityCoordinates];
            if (entity.IsMovable == false)
                throw new ArgumentException("This is not a moving Character.");

            if (entity.EntityType != EntityType.EmptyCell)
            {
                _lastCharacterCoordinates = entity.Coordinates;
                LastCharacterType = entity.EntityType == EntityType.Fox ? PlayerCharacter.Fox : PlayerCharacter.Chicken;
                UpdateIsMovableProperty(false, _lastCharacterCoordinates);
                ConvertDeadChickenAndTrackAndStartPositionOfMovementImageTypesToEmptyCell();
            }
            else
            {
                UpdateEntityTypeAndImageType(entityCoordinates);
                UpdateAllWays();
                UpdateIsMovableProperty(true, new Point(0, 0));
                CheckOnTheEndOfTheGame();
            }
        }

        private void UpdateIsMovableProperty(bool unlockCharacterCell, Point CharacterCoordinates)
        {
            BlockThePropertyOfMovableForAllEntities();

            //unlock empty cell
            if (!unlockCharacterCell)
            {
                var collection = AllWays.Where(d => d.First().Key.Equals(CharacterCoordinates));
                foreach (var item in collection)
                {
                    item.Last().Value.IsMovable = true;
                }
            }
            else
            {
                foreach (var way in AllWays)
                {
                    way.First().Value.IsMovable = true;
                }
            }
        }

        private void BlockThePropertyOfMovableForAllEntities()
        {
            foreach (var item in _entities.Values)
            {
                item.IsMovable = false;
            }
        }

        internal void CheckOnTheEndOfTheGame()
        {
            if (!(GetChickensCount() - 8 == 0))
            {
                int count = 0;
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 2; x < 5; x++)
                    {
                        if (_entities[new Point(x, y)].EntityType == EntityType.Chicken)
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
                    GameOver = true;
                    return;
                }
            }

            BlockThePropertyOfMovableForAllEntities();
            GameOver = true;
        }

        private void ConvertDeadChickenAndTrackAndStartPositionOfMovementImageTypesToEmptyCell()
        {
            foreach (var item in _entities.Values)
            {
                if (item.ImageType == ImageType.DeadChickenImage ||
                    item.ImageType == ImageType.TrackImage ||
                    item.ImageType == ImageType.StartPositionOfMovementImage)
                    item.ImageType = ImageType.EmptyCellImage;
            }
        }

        private void UpdateEntityTypeAndImageType(Point entityCoordinates)
        {
            Entity emptyCell = _entities[entityCoordinates];
            if (AllWays is null)
                throw new ArgumentException("Invalid killing list.");

            var dict = AllWays.FirstOrDefault(d => 
                                                d.First().Key.Equals(_lastCharacterCoordinates) && 
                                                d.Last().Key.Equals(emptyCell.Coordinates));
            if (dict is null)
                throw new ArgumentException("Invalid entity key.");
            var array = dict.ToArray();

            Entity newEntity = array[array.Length - 1].Value;
            if (newEntity.EntityType != EntityType.EmptyCell)
                throw new ArgumentException("Invalid bests ways.");

            Entity lastEntity = array[0].Value;

            if (LastCharacterType == PlayerCharacter.Chicken)
            {
                newEntity.EntityType = EntityType.Chicken;
                newEntity.ImageType = ImageType.ChickenImage;

                lastEntity.EntityType = EntityType.EmptyCell;
                lastEntity.ImageType = ImageType.StartPositionOfMovementImage;
            }
            else
            {
                newEntity.EntityType = EntityType.Fox;
                newEntity.ImageType = ImageType.FoxImage;
                
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

        private void UpdateAllWays()
        {
            //if the next move per fox
            if (LastCharacterType == PlayerCharacter.Chicken)
            {
                AllWays.Clear();
                List<Entity> foxes = _entities.Where(p => p.Value.EntityType == EntityType.Fox).Select(p => p.Value).ToList();
                foreach (var item in foxes)
                {
                    FindFoxEatingWays(item);
                }
                if (AllWays.Count == 0)
                {
                    foreach (var item in foxes)
                    {
                        FindFoxWays(item);
                    }
                }
            }
            else
            {
                AllWays.Clear();
                foreach (var item in _entities.Values)
                {
                    if (item.EntityType == EntityType.Chicken)
                    {
                        FindChickenWays(item);
                    }
                }
            }
        }

        private Dictionary<Point, Entity> FindTheMovingWays(Entity entity, PlayerCharacter character)
        {
            Dictionary<Point, Entity> moves = new Dictionary<Point, Entity>(8);
            
            for (int y = -1; y < 2; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    //does not move
                    if (x == 0 && y == 0 || 
                        (character == PlayerCharacter.Fox && 
                        !_availableMovementsForTheFox.Any(p => p.X == x && p.Y == y)) ||
                        (character == PlayerCharacter.Chicken &&
                        !_availableMovementsForChickens.Any(p => p.X == x && p.Y == y)))
                    {
                        continue;
                    }

                    Point coordinates = new Point(entity.Coordinates.X + x, entity.Coordinates.Y + y);
                    if (_entities.TryGetValue(coordinates, out Entity cell) && cell.EntityType == EntityType.EmptyCell)
                        moves.Add(coordinates, cell);
                }
            }

            return moves;
        }

        private void FindChickenWays(Entity entity)
        {
            Dictionary<Point, Entity> moves = FindTheMovingWays(entity, PlayerCharacter.Chicken);

            foreach (var item in moves)
            {
                var d = new Dictionary<Point, Entity>(2);
                d.Add(entity.Coordinates, entity);
                d.Add(item.Key, item.Value);
                AllWays.Add(d);
            }
        }

        private void FindFoxEatingWays(Entity entity)
        {
            Dictionary<Point, Entity> moves;

            //finding biggests killing lists
            List<Dictionary<Point, Entity>> ways = new List<Dictionary<Point, Entity>>();
            Dictionary<Point, Entity> dict = new Dictionary<Point, Entity>(5);
            dict.Add(entity.Coordinates, entity);

            FindingKillingWays(dict, in ways);

            //delete faulty ways
            ways.RemoveAll(d => d.Count < 3);

            //killing list is empty
            if (ways.Count == 0)
            {                
                return;
            }

            //find ways with max length and add it in BestWays
            ways.Sort(delegate (Dictionary<Point, Entity> x, Dictionary<Point, Entity> y)
            {
                if (x.Count == y.Count) return 0;
                else if (x.Count > y.Count) return -1;
                else return 1;
            });
            AllWays.AddRange(ways.Where(d => d.Count == ways[0].Count));

            moves = new Dictionary<Point, Entity>(4);
            foreach (var item in AllWays)
            {
                var pair = item.Last();
                moves[pair.Key] = pair.Value;
            }
        }

        private void FindFoxWays(Entity entity)
        {
            Dictionary<Point, Entity> moves = FindTheMovingWays(entity, PlayerCharacter.Fox);
            foreach (var item in moves)
            {
                var d = new Dictionary<Point, Entity>(2);
                d.Add(entity.Coordinates, entity);
                d.Add(item.Key, item.Value);
                AllWays.Add(d);
            }
        }

        private void FindingKillingWays(Dictionary<Point, Entity> currentWay, in List<Dictionary<Point, Entity>> allWays)
        {
            int count = 0;

            for (int shiftY = -1; shiftY < 2; shiftY++)
            {
                for (int shiftX = -1; shiftX < 2; shiftX++)
                {
                    if ((shiftX == 0 && shiftY == 0) || 
                        !_eatingRuleForTheFox.Any(p => p.X == shiftX && p.Y == shiftY)) 
                        continue;

                    var cell = currentWay.Last().Value;
                    Point coordCh = new Point(cell.Coordinates.X + shiftX, cell.Coordinates.Y + shiftY);
                    if (_entities.TryGetValue(coordCh, out Entity chicken) && chicken.EntityType == EntityType.Chicken)
                    {
                        Point coordEmpty = new Point(cell.Coordinates.X + 2 * shiftX, cell.Coordinates.Y + 2 * shiftY);
                        if (_entities.TryGetValue(coordEmpty, out Entity empty) && empty.EntityType == EntityType.EmptyCell)
                        {
                            //forbid to move back
                            if (currentWay.ContainsKey(coordCh))
                                continue;

                            count++;
                            currentWay.Add(coordCh, chicken);
                            currentWay.Add(coordEmpty, empty);
                            FindingKillingWays(new Dictionary<Point, Entity>(currentWay), in allWays);
                            currentWay.Remove(coordEmpty);
                            currentWay.Remove(coordCh);
                        }
                    }
                }
            }

            if (count == 0)
                allWays.Add(currentWay);
        }

        private void CheckCountEntities()
        {
            if (GetChickensCount() - 8 <= 0)
            {
                GameOver = true;
                LastCharacterType = PlayerCharacter.Fox;
                BlockThePropertyOfMovableForAllEntities();
            }
            if (GetFoxesCount() == 0)
            {
                GameOver = true;
                LastCharacterType = PlayerCharacter.Chicken;
                BlockThePropertyOfMovableForAllEntities();
            }
        }

        internal int GetChickensCount()
        {
            return _entities.Values.Where(e => e.EntityType == EntityType.Chicken).Count();
        }

        internal int GetFoxesCount()
        {
            return _entities.Values.Where(e => e.EntityType == EntityType.Fox).Count();
        }

        internal EntityType GetEntityTypeOfMovingCharacters()
        {
            return _entities.Where(p => p.Value.IsMovable == true).First().Value.EntityType;
        }

        internal EntityType GetEntityType(Point coordinates)
        {
            return _entities[coordinates].EntityType;
        }

        internal IDictionary<Point, bool> GetDictionaryWithMovingStatus()
        {
            Dictionary<Point, bool> pairs = new Dictionary<Point, bool>(33);
            foreach (var item in _entities)
            {
                pairs[item.Key] = item.Value.IsMovable;
            }
            return pairs;
        }

        internal IDictionary<Point, ImageType> GetDictionaryWithImageTypes()
        {
            Dictionary<Point, ImageType> pairs = new Dictionary<Point, ImageType>(33);
            foreach (var item in _entities)
            {
                pairs[item.Key] = item.Value.ImageType;
            }
            return pairs;
        }
    }
}
