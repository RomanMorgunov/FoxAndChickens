using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GamePvP : Game
    {
        public GamePvP()
        {
            _fields.Add(new Field());
        }

        public override void Update(string entityKey)
        {
            throw new NotImplementedException();
        }
    }
}
