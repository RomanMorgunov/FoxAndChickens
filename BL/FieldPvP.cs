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
            Dictionary<string, Entity> entities = new Dictionary<string, Entity>(33);
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

            ConvertDeadChickenTrackAndAndStartPositionOfMovementImageTypeToEmptyCell();

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
    }
}
