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
            :base()
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
                FindTheChickenWay(entity, out moves);
            }
            else
            {
                FindTheFoxWay(entity, out moves);
            }

            foreach (var item in _entities.Values)
            {
                item.IsMovable = false;
            }

            foreach (var item in moves.Values)
            {
                item.IsMovable = true;
            }
        }

        protected void FindTheChickenWay(Entity entity, out Dictionary<string, Entity> moves)
        {
            moves = new Dictionary<string, Entity>(5);
            for (int y = -1; y < 1; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    string key = $"{entity.X + x}{entity.Y + y}";
                    if (_entities.TryGetValue(key, out Entity cell))
                        if (cell.EntityType == EntityType.EmptyCell)
                            moves.Add(key, cell);
                }
            }
        }

        protected void FindTheFoxWay(Entity entity, out Dictionary<string, Entity> moves)
        {
            //finding all ways
            moves = new Dictionary<string, Entity>(8);
            for (int y = -1; y < 2; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    string key = $"{entity.X + x}{entity.Y + y}";
                    if (_entities.TryGetValue(key, out Entity cell))
                        if (cell.EntityType != EntityType.Fox)
                            moves.Add(key, cell);
                }
            }

            //finding chickens
            Dictionary<string, Entity> eating = new Dictionary<string, Entity>(8);
            foreach (var item in moves.Values)
            {
                if (item.EntityType == EntityType.Chicken)
                {
                    eating.Add(item.GetKey(), item);
                }
            }
            if (eating.Count == 0)
                return;

            //finding empty cell after chicken
            List<Dictionary<string, Entity>> ways = new List<Dictionary<string, Entity>>();
            foreach (var item in eating)
            {
                Dictionary<string, Entity> entities = new Dictionary<string, Entity>();
                entities.Add(entity.GetKey(), entity);
                entities.Add(item.Key, item.Value);
                Find(entities, ways);
            }


        }

        protected void Find(Dictionary<string, Entity> entities, in List<Dictionary<string, Entity>> ways)
        {
            entities
        }
    }
}
