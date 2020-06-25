using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GameAI : Game
    {
        public GamePerson GamePerson { get; set; }

        public AI_level AI_Level { get; set; }

        public GameAI()
        {
            this.GamePerson = GamePerson.Chicken;
            this.AI_Level = AI_level.Low;
            //_fields.Add(new Field(this.GamePerson));
        }

        public GameAI(GamePerson gamePerson, AI_level aiLevel)
        {
            this.GamePerson = gamePerson;
            this.AI_Level = aiLevel;
            //_fields.Add(new Field(this.GamePerson));
        }

        public override void Update(string entityKey)
        {
            throw new NotImplementedException();
        }
    }
}
