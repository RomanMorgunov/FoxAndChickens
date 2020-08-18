using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BL
{
    sealed public class Game
    {
        private readonly List<Field> _fields;
        private readonly ArtificialIntelligence _ai;

        public AI_level AI_Level { get; private set; }
        public GameMode GameMode { get; private set; }
        public Character PlayerCharacter { get; private set; }

        private Field LastField => _fields[_fields.Count - 1];

        public event EventHandler<WinEventArgs> OnWin;
        public event EventHandler<EntitiesPropertiesEventArgs> OnChangeEntitiesProperties;

        public Game(Character playerCharacter, AI_level aiLevel, GameMode gameMode, 
            EventHandler<EntitiesPropertiesEventArgs> onChangeEntitiesProperties, EventHandler<WinEventArgs> onWin,
            Dictionary<Direction, bool> eatingRuleForTheFox,
            Dictionary<Direction, bool> availableMovementsForTheFox,
            Dictionary<Direction, bool> availableMovementsForChickens,
            Dictionary<Point, EntityType> gameMap, Evaluation evaluation)
        {
            this.PlayerCharacter = playerCharacter;
            this.AI_Level = aiLevel;
            this.GameMode = gameMode;
            _fields = new List<Field>(64);
            _fields.Add(new Field(eatingRuleForTheFox, availableMovementsForTheFox, availableMovementsForChickens, gameMap));
            OnChangeEntitiesProperties += onChangeEntitiesProperties;
            OnWin += onWin;

            if (LastField.GameOver)
            {
                OnWin?.Invoke(this, new WinEventArgs(LastField.LastCharacterType));
            }
            else
            {
                if (gameMode == GameMode.PlayerVsAI)
                {
                    _ai = new MinMaxAI(this.PlayerCharacter, this.AI_Level, evaluation);
                    if (this.PlayerCharacter == Character.Fox)
                    {
                        MovingForAI();
                    }
                }
            }

            InvokeUpdateEvents();
        }

        private IDictionary<Point, bool> GetDictionaryWithMovingStatus() => LastField.GetDictionaryWithMovingStatus();
        private IDictionary<Point, ImageType> GetDictionaryWithImageTypes() => LastField.GetDictionaryWithImageTypes();

        private int GetLeftChickens()
        {
            return LastField.GetChickensCount() - 8;
        }

        public void InvokeUpdateEvents()
        {
            OnChangeEntitiesProperties?.Invoke(this, new EntitiesPropertiesEventArgs(
                    GetDictionaryWithMovingStatus(), GetDictionaryWithImageTypes(), GetLeftChickens()));
        }

        public void Move(Point entityCoordinates)
        {
            var movingCharacterType = LastField.GetEntityTypeOfMovingCharacters();

            //create a copy field
            if (movingCharacterType != EntityType.EmptyCell)
            {
                _fields.Add(LastField.Clone());
            }

            //Moving
            LastField.Move(ref entityCoordinates);

            if (this.GameMode == GameMode.PlayerVsAI && movingCharacterType == EntityType.EmptyCell && 
                !LastField.GameOver)
            {
                MovingForAI();
            }

            InvokeUpdateEvents();

            if (LastField.GameOver)
            {
                OnWin?.Invoke(this, new WinEventArgs(LastField.LastCharacterType));
            }
        }

        private void MovingForAI()
        {
            //calculation move
            Point[] moves = _ai.RunAI(this.LastField.Clone());

            //Moving
            LastField.Move(ref moves[0]);
            LastField.Move(ref moves[1]);
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

    public enum Character
    {
        Fox,
        Chicken
    }

    public enum Direction
    {
        Top,
        Left,
        Right,
        Bottom,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}
