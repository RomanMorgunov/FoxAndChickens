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

        public PlayerPerson Winner { get; protected set; }

        public Game()
        {
            this.GameMode = GameMode.PlayerVsPlayer;
            _fields = new List<Field>(64);
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
            //create a copy field
            if (LastField.GetEntityTypeOfMovingCharacters() != EntityType.EmptyCell)
            {
                _fields.Add(LastField.Clone());
            }

            //
            LastField.UpdateEntitiesProperty(entityKey);

            gameOver = false;
            if (LastField.GameOver)
            {
                gameOver = true;
                Winner = LastField.LastPerson;
            }
            else
            {
                LastField.CheckOnTheEndOfTheGame();
                if (LastField.GameOver)
                {
                    gameOver = true;
                    Winner = LastField.LastPerson;
                }
            }
        }

        public void CancelMove()
        {
            if (_fields.Count > 1)
                _fields.RemoveAt(_fields.Count - 1);
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
