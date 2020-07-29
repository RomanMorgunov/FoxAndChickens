﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class MinMaxAI : ArtificialIntelligence
    {
        private const int MIN_EVALUATION_VALUE = 0;
        private const int MAX_EVALUATION_VALUE = int.MaxValue - 1;
        private string[] _aiMoves;

        internal MinMaxAI(PlayerPerson playerPerson, AI_level aiLevel)
            : base(playerPerson, aiLevel)
        {
            _aiMoves = new string[2];
        }

        protected internal override string[] RunAI(Field field)
        {
            RunMinMax(in field, 0, MIN_EVALUATION_VALUE - 1, MAX_EVALUATION_VALUE + 1);
            return _aiMoves;
        }

        private int RunMinMax(in Field initialField, int recursiveLevel, int alpha, int beta)
        {
            //if the AI plays as a fox
            int coefficient = this._playerPerson == PlayerPerson.Chicken ? 1 : 0;

            //at the last level of the tree, return the value of the heuristic function
            if (recursiveLevel >= ((int)_aiLevel) * 2 + coefficient)
                return GetHeuristicEvaluation(initialField);

            //if GameOver
            if (initialField.GameOver)
                return GetHeuristicEvaluation(initialField);

            //if the fox is move now, then we give it the maximum value
            int bestEvaluation = initialField.LastPerson == PlayerPerson.Chicken ? 
                MAX_EVALUATION_VALUE : MIN_EVALUATION_VALUE;

            string[] bestMove = new string[2];

            //iterate over all possible moves of this person
            foreach (var item in initialField.BestsWays)
            {
                //to move
                Field newField = initialField.Clone();
                newField.UpdateEntitiesProperties(item.Keys.First());
                newField.UpdateEntitiesProperties(item.Keys.Last());

                //evaluate the move we have chosen
                int currentEvaluation = RunMinMax(in newField, recursiveLevel + 1, alpha, beta);

                //if it is better than everyone that was before this - remember that it is the best
                //foxes minimize evaluation, chicken - maximize
                if (currentEvaluation >= bestEvaluation && initialField.LastPerson == PlayerPerson.Fox ||    //for chicken
                    currentEvaluation < bestEvaluation && initialField.LastPerson == PlayerPerson.Chicken || //for fox
                    bestMove[0] == null)
                {
                    bestEvaluation = currentEvaluation;
                    bestMove[0] = item.Keys.First();
                    bestMove[1] = item.Keys.Last();
                }

                //alpha-beta pruning
                //if the fox is move now
                if (initialField.LastPerson == PlayerPerson.Chicken)
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

            if (bestMove[0] == null)
            {
                throw new ArgumentException("Character can't move.");
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
                if (field.LastPerson == PlayerPerson.Chicken)
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

                    if (field.GetEntityType(x, y) == EntityType.Chicken)
                        evaluation += 6 - y;
                }
            }

            for (int y = 0; y < 3; y++)
            {
                for (int x = 2; x < 5; x++)
                {
                    if (field.GetEntityType(x, y) == EntityType.Chicken)
                        evaluation += 7 - y;
                }
            }

            return evaluation;
        }
    }
}