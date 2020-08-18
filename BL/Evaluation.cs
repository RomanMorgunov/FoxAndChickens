using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BL
{
    public class Evaluation
    {
        public int EvaluationForBlockedOneFox { get; private set; }
        public int EvaluationForOneLiveChicken { get; private set; }
        public Dictionary<Point, int> EvaluationMap { get; private set; }

        public Evaluation(int evaluationForBlockedOneFox, int evaluationForOneLiveChicken, 
            Dictionary<Point, int> evaluationMap)
        {
            this.EvaluationForBlockedOneFox = evaluationForBlockedOneFox;
            this.EvaluationForOneLiveChicken = evaluationForOneLiveChicken;
            this.EvaluationMap = evaluationMap;
        }
    }
}
