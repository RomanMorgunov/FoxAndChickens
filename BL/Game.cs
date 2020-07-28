using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BL
{
    sealed public class Game
    {
        //to determine size
        private List<Field> _fields;
        private ArtificialIntelligence _ai;

        public PlayerPerson PlayerPerson { get; private set; }
        public AI_level AI_Level { get; private set; }
        public GameMode GameMode { get; private set; }
        private Field LastField => _fields[_fields.Count - 1];

        public event EventHandler<EntitiesPropertiesEventArgs> OnChangeEntitiesProperties;
        public event EventHandler<WinEventArgs> OnWin;

        public Game(PlayerPerson playerPerson, AI_level aiLevel, GameMode gameMode, 
            EventHandler<EntitiesPropertiesEventArgs> onChangeEntitiesProperties,
            EventHandler<WinEventArgs> onWin)
        {
            this.PlayerPerson = playerPerson;
            this.AI_Level = aiLevel;
            this.GameMode = gameMode;
            _fields = new List<Field>(64);
            _fields.Add(new Field());
            OnChangeEntitiesProperties += onChangeEntitiesProperties;
            OnWin += onWin;

            if (gameMode == GameMode.PlayerVsAI)
            {
                _ai = new MinMaxAI(this.PlayerPerson, this.AI_Level);
                if (this.PlayerPerson == PlayerPerson.Fox)
                {
                    MovingForAI();
                }
            }

            InvokeUpdateEvents();
        }

        private IDictionary<string, bool> GetDictionaryWithMovingStatus()
        {
            Dictionary<string, bool> pairs = new Dictionary<string, bool>(33);
            foreach (var item in LastField.GetEntities())
            {
                pairs[item.Key] = item.Value.IsMovable;
            }

            return pairs;
        }

        private IDictionary<string, ImageType> GetDictionaryWithImageTypes()
        {
            Dictionary<string, ImageType> pairs = new Dictionary<string, ImageType>(33);
            foreach (var item in LastField.GetEntities())
            {
                pairs[item.Key] = item.Value.ImageType;
            }

            return pairs;
        }

        private int GetLeftChickens()
        {
            return LastField.GetChickensCount() - 8;
        }

        public void InvokeUpdateEvents()
        {
            OnChangeEntitiesProperties?.Invoke(this, new EntitiesPropertiesEventArgs(
                    GetDictionaryWithMovingStatus(), GetDictionaryWithImageTypes(), GetLeftChickens()));
        }

        public void Moving(string entityKey)
        {
            var movingCharacterType = LastField.GetEntityTypeOfMovingCharacters();

            //create a copy field
            if (movingCharacterType != EntityType.EmptyCell)
            {
                _fields.Add(LastField.Clone());
            }

            //Moving
            LastField.UpdateEntitiesProperties(entityKey);

            InvokeUpdateEvents();

            if (LastField.GameOver)
            {
                OnWin?.Invoke(this, new WinEventArgs(LastField.LastPerson));
            }
            else
            {
                if (this.GameMode == GameMode.PlayerVsAI && movingCharacterType == EntityType.EmptyCell)
                {
                    MovingForAI();
                }
            }
        }

        private void MovingForAI()
        {
            //calculation move
            string[] moves = _ai.RunAI(this.LastField.Clone(isCopyBestWays: true));

            //Moving
            LastField.UpdateEntitiesProperties(moves[0]);
            LastField.UpdateEntitiesProperties(moves[1]);

            if (LastField.GameOver)
            {
                OnWin?.Invoke(this, new WinEventArgs(LastField.LastPerson));
            }

            InvokeUpdateEvents();
        }

        public void CancelMove()
        {
            if (_fields.Count > 1)
            {
                _fields.RemoveAt(_fields.Count - 1);
                InvokeUpdateEvents();
            }
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
}
