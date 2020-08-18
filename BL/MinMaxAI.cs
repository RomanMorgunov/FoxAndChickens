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
        private int _recursiveLevelLimit;
        private readonly Evaluation _evaluation;

        internal MinMaxAI(Character playerCharacter, AI_level aiLevel, Evaluation evaluation)
            : base(playerCharacter, aiLevel)
        {
            _aiMoves = new Point[2];
            _evaluation = evaluation;
            _recursiveLevelLimit = GetRecursiveLevelLimit(_playerCharacter, _aiLevel);
        }

        private int GetRecursiveLevelLimit(Character playerCharacter, AI_level aiLevel)
        {
            if (playerCharacter == Character.Chicken && aiLevel == AI_level.Low)
                return 3;
            if (playerCharacter == Character.Fox && aiLevel == AI_level.Low)
                return 2;
            if (playerCharacter == Character.Chicken && aiLevel == AI_level.Medium)
                return 5;
            if (playerCharacter == Character.Fox && aiLevel == AI_level.Medium)
                return 4;

            throw new ArgumentException();
        }

        protected internal override Point[] RunAI(Field field)
        {
            RunMinMax(field, 0, MIN_EVALUATION_VALUE - 1, MAX_EVALUATION_VALUE + 1);
            return _aiMoves;
        }

        private int RunMinMax(Field initialField, int recursiveLevel, int alpha, int beta)
        {
            //if the last level of the tree or game over
            if ((recursiveLevel >= _recursiveLevelLimit) || initialField.GameOver)
                return GetHeuristicEvaluation(initialField);

            //if the fox is move now, then we give it the maximum value
            int bestEvaluation = initialField.LastCharacterType == Character.Chicken ?
                MAX_EVALUATION_VALUE : MIN_EVALUATION_VALUE;

            Point[] bestMove = new Point[2];

            //iterate over all possible moves of this character
            foreach (var item in initialField.AllWays)
            {
                //to move
                Field newField = initialField.Clone();
                Point cell1 = item.Keys.First();
                Point cell2 = item.Keys.Last();
                newField.Move(ref cell1);
                newField.Move(ref cell2);

                //evaluate the move we have chosen
                int currentEvaluation = RunMinMax(newField, recursiveLevel + 1, alpha, beta);

                //if it is better than everyone that was before this - remember that it is the best
                //foxes minimize evaluation, chicken - maximize
                if (currentEvaluation >= bestEvaluation && initialField.LastCharacterType == Character.Fox ||    //for chicken
                    currentEvaluation < bestEvaluation && initialField.LastCharacterType == Character.Chicken || //for fox
                    bestMove[0].X == 0 && bestMove[0].Y == 0 || bestMove[1].X == 0 && bestMove[1].Y == 0) //if there is nowhere to move
                {
                    bestEvaluation = currentEvaluation;
                    bestMove[0] = cell1;
                    bestMove[1] = cell2;
                }

                //alpha-beta pruning
                //if the fox is move now
                if (initialField.LastCharacterType == Character.Chicken)
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
                if (field.LastCharacterType == Character.Chicken)
                {
                    return MAX_EVALUATION_VALUE;
                }
                else
                {
                    return MIN_EVALUATION_VALUE;
                }
            }

            int score = 0;
            score += _evaluation.EvaluationForOneLiveChicken * field.GetChickensCount();
            foreach (var item in _evaluation.EvaluationMap)
            {
                switch (field.GetEntityType(item.Key))
                {
                    case EntityType.Chicken:
                        score += item.Value;
                        break;
                    case EntityType.Fox:
                        if (field.GetFoxesCount() > 1 && _evaluation.EvaluationForBlockedOneFox != 0)
                            if (!field.IsMovable(item.Key, Character.Fox))
                                score += _evaluation.EvaluationForBlockedOneFox;
                        break;
                }
            }

            return score;
        }
    }
}
