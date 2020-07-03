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

        protected Field LastField
        {
            get
            {
                return _fields[_fields.Count - 1];
            }
        }

        //events
        public event EventHandler<MovingEventArgs> OnChangeMovingStatus;

        public event EventHandler<ImageTypeEventArgs> OnChangeImageType;

        public event EventHandler<WinEventArgs> OnWin;

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

        protected internal IDictionary<string, bool> GetDictionaryWithMovingStatus()
        {
            Dictionary<string, bool> pairs = new Dictionary<string, bool>(33);
            foreach (var item in LastField.GetEntities())
            {
                pairs[item.Key] = item.Value.IsMovable;
            }

            return pairs;
        }

        protected internal IDictionary<string, ImageType> GetDictionaryWithImageTypes()
        {
            Dictionary<string, ImageType> pairs = new Dictionary<string, ImageType>(33);
            foreach (var item in LastField.GetEntities())
            {
                pairs[item.Key] = item.Value.ImageType;
            }

            return pairs;
        }

        protected internal int GetLeftChickens()
        {
            return LastField.GetChickensCount() - 8;
        }

        public void CallUpdateEvents()
        {
            OnChangeMovingStatus?.Invoke(this, new MovingEventArgs(GetDictionaryWithMovingStatus()));
            OnChangeImageType?.Invoke(this, new ImageTypeEventArgs(GetDictionaryWithImageTypes(), GetLeftChickens()));
        }

        public void Moving(string entityKey)
        {
            //create a copy field
            if (LastField.GetEntityTypeOfMovingCharacters() != EntityType.EmptyCell)
            {
                _fields.Add(LastField.Clone());
            }

            //Moving
            LastField.UpdateEntitiesProperty(entityKey);

            if (LastField.GameOver)
            {
                OnWin?.Invoke(this, new WinEventArgs(LastField.LastPerson));
            }

            CallUpdateEvents();
        }

        public void CancelMove()
        {
            if (_fields.Count > 1)
            {
                _fields.RemoveAt(_fields.Count - 1);
                CallUpdateEvents();
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

    public enum AI_level
    {
        Low,
        Medium
    }
}
