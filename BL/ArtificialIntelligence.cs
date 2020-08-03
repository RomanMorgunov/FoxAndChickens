using System;
using System.Drawing;

namespace BL
{
    internal abstract class ArtificialIntelligence
    {
        protected PlayerCharacter _playerCharacter;
        protected AI_level _aiLevel;

        protected internal ArtificialIntelligence(PlayerCharacter playerCharacter, AI_level aiLevel)
        {
            this._playerCharacter = playerCharacter;
            this._aiLevel = aiLevel;
        }

        protected internal abstract Point[] RunAI(Field initialField);
    }

    //the value of an enumeration element is the level of recursion for MinMax algorithm
    public enum AI_level
    {
        Low = 1,
        Medium = 2
    }
}
