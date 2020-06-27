using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FieldPvP : Field
    {
        public FieldPvP()
            : base() { }

        protected FieldPvP(IDictionary<string, Entity> entities)
            : base(entities) { }

        protected internal override Field Clone()
        {
            Dictionary<string, Entity> entities = new Dictionary<string, Entity>();
            foreach (var item in _entities)
            {
                entities.Add(item.Key, item.Value.Clone());
            }

            return new FieldPvP(entities);
        }

        protected internal override void UpdateEntitiesProperty(string entityKey, out EntityType entityType, 
            bool isCancelSelectPerson = false)
        {
            Entity entity = _entities[entityKey];
            Dictionary<string, Entity> moves;

            if (entity.IsMovable == false && !isCancelSelectPerson)
                throw new ArgumentException("This is not a moving person.");

            ConvertDeadChickenTrackAndAndStartPositionOfMovementImageTypeToEmptyCell();

            if (entity.EntityType == EntityType.Chicken)
            {
                FindChickenWays(entity, out moves);
                LastPerson = PlayerPerson.Chicken;
                entityType = EntityType.Chicken;
            }
            else if (entity.EntityType == EntityType.Fox)
            {
                FindFoxWays(entity, out moves);
                LastPerson = PlayerPerson.Fox;
                entityType = EntityType.Fox;
            }
            //empty cell
            else
            {
                UpdateEntityTypeAndImageType(entityKey);
                FindMovableCharacters(out moves);
                entityType = EntityType.EmptyCell;
            }
            UpdateIsMovable(moves);
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
            if (bestsWays is null)
                throw new ArgumentException("Invalid killing list.");

            var dict = bestsWays.FirstOrDefault(d => object.ReferenceEquals(d.Values.Last(), emptyCell));
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
            bestsWays.Clear();
            FindTheMovingWays(entity, out moves, PlayerPerson.Chicken);

            foreach (var item in moves)
            {
                var d = new Dictionary<string, Entity>(2);
                d.Add(entity.GetKey(), entity);
                d.Add(item.Key, item.Value);
                bestsWays.Add(d);
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
            bestsWays.Clear();
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
                    bestsWays.Add(d);
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
                    bestsWays.Add(item);
            }

            moves = new Dictionary<string, Entity>(4);
            foreach (var item in bestsWays)
            {
                var pair = item.Last();
                moves.Add(pair.Key, pair.Value);
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
                        FindKillingWays(new Dictionary<string, Entity>(entities), ways);
                        count++;
                    }
                }
            }

            if (count == 0)
                ways.Add(entities);
        }
    }
}
