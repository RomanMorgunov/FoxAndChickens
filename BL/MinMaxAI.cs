using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace BL
{
    sealed internal class MinMaxAI : ArtificialIntelligence
    {
        private const int MIN_EVALUATION_VALUE = 0;
        private const int MAX_EVALUATION_VALUE = int.MaxValue - 1;
        private Point[] _aiMoves;

        internal MinMaxAI(PlayerCharacter playerCharacter, AI_level aiLevel)
            : base(playerCharacter, aiLevel)
        {
            _aiMoves = new Point[2];
        }

        protected internal override Point[] RunAI(Field field)
        {
            RunMinMax(field, 0, MIN_EVALUATION_VALUE - 1, MAX_EVALUATION_VALUE + 1);
            return _aiMoves;
        }

        private int RunMinMax(Field initialField, int recursiveLevel, int alpha, int beta)
        {
            //if the AI plays as a fox then coefficient = 1
            int coefficient = this._playerCharacter == PlayerCharacter.Chicken ? 1 : 0;

            //if the last level of the tree or game over
            if ((recursiveLevel >= ((int)_aiLevel) * 2 + coefficient) ||
                initialField.GameOver)
                return GetHeuristicEvaluation(initialField);

            //if the fox is move now, then we give it the maximum value
            int bestEvaluation = initialField.LastCharacterType == PlayerCharacter.Chicken ?
                MAX_EVALUATION_VALUE : MIN_EVALUATION_VALUE;

            Point[] bestMove = new Point[2];

            //iterate over all possible moves of this character
            foreach (var item in initialField.AllWays)
            {
                //to move
                Field newField = initialField.Clone();
                newField.Move(item.Keys.First());
                newField.Move(item.Keys.Last());

                //evaluate the move we have chosen
                int currentEvaluation = RunMinMax(newField, recursiveLevel + 1, alpha, beta);

                //if it is better than everyone that was before this - remember that it is the best
                //foxes minimize evaluation, chicken - maximize
                if (currentEvaluation >= bestEvaluation && initialField.LastCharacterType == PlayerCharacter.Fox ||    //for chicken
                    currentEvaluation < bestEvaluation && initialField.LastCharacterType == PlayerCharacter.Chicken || //for fox
                    bestMove[0].X == 0 && bestMove[0].Y == 0 || bestMove[1].X == 0 && bestMove[1].Y == 0) //if there is nowhere to move
                {
                    bestEvaluation = currentEvaluation;
                    bestMove[0] = item.Keys.First();
                    bestMove[1] = item.Keys.Last();
                }

                //alpha-beta pruning
                //if the fox is move now
                if (initialField.LastCharacterType == PlayerCharacter.Chicken)
                {
                    beta = Math.Min(beta, currentEvaluation);
                }
                else
                {
                    alpha = Math.Max(alpha, currentEvaluation);
                }

                if (beta < alpha)
                {
                    break;
                }
            }

            //writing down the move
            if (recursiveLevel == 0)
            {
                _aiMoves = bestMove;
            }

            return bestEvaluation;
        }

        private int GetHeuristicEvaluation(Field field)
        {
            if (field.GameOver)
            {
                //if the chickens won
                if (field.LastCharacterType == PlayerCharacter.Chicken)
                {
                    return MAX_EVALUATION_VALUE;
                }
                else
                {
                    return MIN_EVALUATION_VALUE;
                }
            }

            int evaluation = 0;

            evaluation += 10 * field.GetChickensCount();
            for (int y = 2; y < 6; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    if (y == 5 && (x != 2 && x != 3 && x != 4)) 
                        continue;

                    //winning position
                    if (y == 2 && (x == 2 || x == 3 || x == 4))
                        continue;

                    if (field.GetEntityType(new Point(x, y)) == EntityType.Chicken)
                        evaluation += 6 - y;
                }
            }

            for (int y = 0; y < 3; y++)
            {
                for (int x = 2; x < 5; x++)
                {
                    if (field.GetEntityType(new Point(x, y)) == EntityType.Chicken)
                        evaluation += 7 - y;
                }
            }

            return evaluation;
        }
    }
}
