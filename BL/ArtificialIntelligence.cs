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
        protected Field _initialField;

        protected internal ArtificialIntelligence(Field field, PlayerPerson playerPerson, AI_level aiLevel)
        {
            this._playerPerson = playerPerson;
            this._aiLevel = aiLevel;
            _initialField = field;
        }

        protected internal abstract string[] RunAI();
    }
}
