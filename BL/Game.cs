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

        public Game(PlayerPerson playerPerson, AI_level aiLevel, GameMode gameMode)
        {
            this.PlayerPerson = playerPerson;
            this.AI_Level = aiLevel;
            this.GameMode = gameMode;
            _fields = new List<Field>(64);

            if (gameMode == GameMode.PlayerVsPlayer)
                _fields.Add(new Field());
            else
            {
                _fields.Add(new Field_MinMax(this.PlayerPerson, this.AI_Level));
                LastField.EntityKey = string.Empty;
                LastField.UpdateEntitiesProperty();
            }
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

        public void InvokeUpdateEvents()
        {
            OnChangeMovingStatus?.Invoke(this, new MovingEventArgs(GetDictionaryWithMovingStatus()));
            OnChangeImageType?.Invoke(this, new ImageTypeEventArgs(GetDictionaryWithImageTypes(), GetLeftChickens()));
        }

        public void Moving(string entityKey)
        {
            EntityType movableEntity = LastField.GetEntityTypeOfMovingCharacters();

            //create a copy field
            if (movableEntity != EntityType.EmptyCell)
            {
                _fields.Add(LastField.Clone());
            }

            //Moving
            LastField.EntityKey = entityKey;
            LastField.UpdateEntitiesProperty();

            //game over
            if (LastField.GameOver)
            {
                OnWin?.Invoke(this, new WinEventArgs(LastField.LastPerson));
            }

            //invoke events
            if (movableEntity == EntityType.EmptyCell)
            {
                OnChangeImageType?.Invoke(this, new ImageTypeEventArgs(GetDictionaryWithImageTypes(), GetLeftChickens()));
            }
            OnChangeMovingStatus?.Invoke(this, new MovingEventArgs(GetDictionaryWithMovingStatus()));
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
