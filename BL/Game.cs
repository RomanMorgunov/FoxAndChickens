using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class Game
    {
        //to determine size
        protected List<Field> _fields;

        public Game()
        {
            _fields = new List<Field>();
        }

        public IDictionary<string, Entity> GetLastEntities()
        {
            return _fields[_fields.Count - 1].GetEntities();
        }

        public int GetLeftChickens()
        {
            return GetLastEntities().Values.Where(e => e.EntityType == EntityType.Chicken).Count() - 8;
        }

        public abstract void Update(string entityKey);
    }

    public enum GameMode
    {
        PlayerVsPlayer,
        PlayerVsAI
    }

    public enum GamePerson
    {
        Fox,
        Chicken
    }

    public enum AI_level
    {
        Low,
        Medium
    }
}
