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

        protected internal override void UpdateEntitiesProperty(string entityKey)
        {
            Entity entity = _entities[entityKey];
            Dictionary<string, Entity> moves;

            if (entity.IsMovable == false)
                throw new ArgumentException("This is not a moving person.");

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

        protected void UpdateEntityTypeAndImageType(string entityKey)
        {
            Entity emptyCell = _entities[entityKey];
            if (emptyCell.IsMovable == false || emptyCell.EntityType != EntityType.EmptyCell)
                throw new ArgumentException("Invalid entity key.");

            var list = bestsWays.FirstOrDefault(d => object.ReferenceEquals(d.Values.Last(), emptyCell)).ToList();
            if (list is null || list.Count == 0)
                throw new ArgumentException("Invalid entity key.");

            Entity lastFox = list[0].Value;
            if (lastFox.EntityType != EntityType.Fox)
                throw new ArgumentException("Invalid killing list.");
            lastFox.EntityType = EntityType.EmptyCell;
            lastFox.ImageType = ImageType.StartPositionOfMovementImage;

            Entity newFox = list[list.Count - 1].Value;
            if (newFox.EntityType != EntityType.EmptyCell)
                throw new ArgumentException("Invalid killing list.");
            newFox.EntityType = EntityType.Fox;
            newFox.ImageType = ImageType.FoxImage;

            for (int i = 1; i < list.Count - 1; i++)
            {
                Entity cell = list[i].Value;                

                //if even
                if (i % 2 == 0)
                {
                    if (cell.EntityType != EntityType.EmptyCell)
                        throw new ArgumentException("Invalid killing list.");
                    cell.ImageType = ImageType.TrackImage;
                }
                else
                {
                    if (cell.EntityType != EntityType.Chicken)
                        throw new ArgumentException("Invalid killing list.");
                    cell.EntityType = EntityType.EmptyCell;
                    cell.ImageType = ImageType.DeadChickenImage;
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
            FindTheMovingWays(entity, out moves, PlayerPerson.Chicken);
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
            //finding biggests killing lists
            BeginFindingKillingWays(entity, out List<Dictionary<string, Entity>> ways);

            bestsWays = new List<Dictionary<string, Entity>>();
            int maximum = ways[0].Count;

            for (int i = 1; i < ways.Count; i++)
            {
                if (maximum < ways[i].Count)
                    maximum = ways[i].Count;
            }

            //killing list is empty
            if (maximum == 0)
            {
                FindTheMovingWays(entity, out moves, PlayerPerson.Fox);
                return;
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

            int lastX = Convert.ToInt32(last[0]);
            int lastY = Convert.ToInt32(last[1]);
            int shiftX = lastX - Convert.ToInt32(penult[0]);
            int shiftY = lastY - Convert.ToInt32(penult[1]);

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
