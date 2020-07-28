using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal abstract class ArtificialIntelligence
    {
        protected PlayerPerson _playerPerson;
        protected AI_level _aiLevel;

        protected internal ArtificialIntelligence(PlayerPerson playerPerson, AI_level aiLevel)
        {
            this._playerPerson = playerPerson;
            this._aiLevel = aiLevel;
        }

        protected internal abstract string[] RunAI(Field initialField);
    }

    //the value of an enumeration element is the level of recursion for MinMax algorithm
    public enum AI_level
    {
        Low = 1,
        Medium = 2
    }
}
