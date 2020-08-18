using System;
using System.Drawing;

namespace BL
{
    internal abstract class ArtificialIntelligence
    {
        protected Character _playerCharacter;
        protected AI_level _aiLevel;

        protected internal ArtificialIntelligence(Character playerCharacter, AI_level aiLevel)
        {
            this._playerCharacter = playerCharacter;
            this._aiLevel = aiLevel;
        }

        protected internal abstract Point[] RunAI(Field initialField);
    }

    public enum AI_level
    {
        Low,
        Medium
    }
}
