using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Field_MinMax : Field
    {
        protected PlayerPerson _playerPerson;
        protected AI_level _aiLevel;

        protected internal Field_MinMax(PlayerPerson playerPerson, AI_level aiLevel)
            : base()
        {
            this._playerPerson = playerPerson;
            this._aiLevel = aiLevel;
        }

        protected Field_MinMax(IDictionary<string, Entity> entities, PlayerPerson playerPerson, AI_level aiLevel)
            : base(entities)
        {
            this._playerPerson = playerPerson;
            this._aiLevel = aiLevel;
        }

        protected internal override Field Clone()
        {
            Dictionary<string, Entity> entities = new Dictionary<string, Entity>();
            foreach (var item in _entities)
            {
                entities.Add(item.Key, item.Value.Clone());
            }

            return new Field_MinMax(entities, this._playerPerson, this._aiLevel);
        }

        protected internal override void UpdateEntitiesProperty()
        {
            //AI is chicken
            if (this._playerPerson == PlayerPerson.Fox)
            {
                if (this.EntityKey is null)
                    throw new NullReferenceException("Property \"EntityKey\" is null.");

                //if move AI
                //first move
                if (this.EntityKey is "")
                {
                    this.EntityKey = "32"; //fox initial position
                    RunAI();
                    return;
                }

                Entity entity = _entities[this.EntityKey];

                if (entity.EntityType == EntityType.Chicken)
                {
                    throw new ArgumentException("Property \"EntityKey\" is invalid.");
                }
                //user move
                else if (entity.EntityType == EntityType.Fox)
                {
                    base.UpdateEntitiesProperty();
                }
                else
                {
                    //user move
                    base.UpdateEntitiesProperty();
                    if (this.GameOver)
                        return;

                    //AI move
                    RunAI();
                }
            }
            //AI is fox
            else
            {
                if (string.IsNullOrEmpty(this.EntityKey))
                    throw new NullReferenceException("Property \"EntityKey\" is null or empty.");

                Entity entity = _entities[this.EntityKey];

                //user move
                if (entity.EntityType == EntityType.Chicken)
                {
                    base.UpdateEntitiesProperty();
                }
                else if (entity.EntityType == EntityType.Fox)
                {
                    throw new ArgumentException("Property \"EntityKey\" is invalid.");
                }
                else
                {
                    //user move
                    base.UpdateEntitiesProperty();
                    if (this.GameOver)
                        return;

                    //AI move
                    RunAI();
                }
            }
        }

        protected void RunAI()
        {
            base.UpdateEntitiesProperty();
            RunMinMax();
            base.UpdateEntitiesProperty();
        }

        protected int RunMinMax()
        {
            throw new NotImplementedException();
        }
    }

    //the value of an enumeration element is the level of recursion
    public enum AI_level : int
    {
        Low = 1,
        Medium = 2
    }
}
