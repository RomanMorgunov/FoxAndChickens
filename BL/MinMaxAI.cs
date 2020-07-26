using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class MinMaxAI : ArtificialIntelligence
    {
        private string[] _aiMoves;

        internal MinMaxAI(Field field, PlayerPerson playerPerson, AI_level aiLevel)
            : base(field, playerPerson, aiLevel)
        {
            _aiMoves = new string[2];
        }

        protected internal override string[] RunAI()
        {
            RunMinMax(in _initialField, 0, 0, 0);
            return _aiMoves;
        }

        private int RunMinMax(in Field initialField, int recursiveLevel, int alpha, int beta)
        {
            //at the last level of the tree, return the value of the heuristic function
            if (recursiveLevel >= ((int)_aiLevel) * 2)
                return GetHeuristicEvaluation();

            //iterate over all possible moves of this person
            foreach (var item in initialField.BestsWays)
            {
                //to move
                Field newField = initialField.Clone();
                //newField.UpdateEntitiesProperties();

            }


            //evaluate the move we have chosen

            //if he is better than everyone that was before this - remember that he is the best

            //restore the original state

            //move

            throw new NotImplementedException();
        }

        private int GetHeuristicEvaluation()
        {
            throw new NotImplementedException();
        }
    }
}
