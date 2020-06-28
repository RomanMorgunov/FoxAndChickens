using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FieldAI : Field
    {
        public FieldAI()
            :base()
        {

        }

        protected FieldAI(IDictionary<string, Entity> entities)
            : base(entities) { }

        protected internal override Field Clone()
        {
            Dictionary<string, Entity> entities = new Dictionary<string, Entity>();
            foreach (var item in _entities)
            {
                entities.Add(item.Key, item.Value.Clone());
            }

            return new FieldAI(entities);
        }

        protected internal override void UpdateEntitiesProperty(string entityKey)
        {
            throw new NotImplementedException();
        }
    }    
}
