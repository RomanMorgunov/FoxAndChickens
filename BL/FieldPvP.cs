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
            : base()
        {

        }

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
            }
            else
            {
                FindFoxWays(entity, out moves);
            }

            foreach (var item in _entities.Values)
            {
                item.IsMovable = false;
            }

            int count = 0;
            foreach (var item in moves.Values)
            {
                item.IsMovable = true;
                count++;
            }

            //check on Game over
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
