using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Game
    {
        //to determine size
        protected List<Field> _fields;

        public PlayerPerson PlayerPerson { get; set; }

        public AI_level AI_Level { get; set; }

        public GameMode GameMode { get; set; }

        protected Field LastField { 
            get
            {
                return _fields[_fields.Count - 1];
            }
        }

        public PlayerPerson Winner
        {
            get
            {
                return LastField.LastPerson;
            }
        }

        public Game()
        {
            this.GameMode = GameMode.PlayerVsPlayer;
            _fields = new List<Field>();
            _fields.Add(new FieldPvP());
        }

        public Game(PlayerPerson playerPerson, AI_level aiLevel, GameMode gameMode)
        {
            this.PlayerPerson = playerPerson;
            this.AI_Level = aiLevel;
            this.GameMode = gameMode;
            _fields = new List<Field>();

            if (gameMode == GameMode.PlayerVsPlayer)
                _fields.Add(new FieldPvP());
            else
                _fields.Add(new FieldAI());
        }

        public IDictionary<string, Entity> GetLastEntities()
        {
            return LastField.GetEntities();
        }

        public int GetLeftChickens()
        {
            return GetLastEntities().Values.Where(e => e.EntityType == EntityType.Chicken).Count() - 8;
        }

        public void Moving(string entityKey, out bool gameOver)
        {
            LastField.UpdateEntitiesProperty(entityKey, out EntityType entityType);
            gameOver = LastField.GameOver;

            if (entityType == EntityType.EmptyCell && !gameOver)
            {
                _fields.Add(LastField.Clone());
            }
        }

        public void CancelSelectedPerson()
        {
            LastField.LastPerson = LastField.LastPerson == PlayerPerson.Chicken ? PlayerPerson.Fox : PlayerPerson.Chicken;
            foreach (var item in GetLastEntities())
                if (item.Value.EntityType == EntityType.EmptyCell)
                    LastField.UpdateEntitiesProperty(item.Key, out EntityType et, true);
        }
    }

    public enum GameMode
    {
        PlayerVsPlayer,
        PlayerVsAI
    }

    public enum PlayerPerson
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
