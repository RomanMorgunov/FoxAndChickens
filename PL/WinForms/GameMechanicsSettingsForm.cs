using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class GameMechanicsSettingsForm : Form
    {
        public Evaluation Evaluation { get; private set; }
        public Dictionary<Point, EntityType> GameMap { get; private set; }
        public Dictionary<Direction, bool> EatingRuleForTheFox { get; private set; }
        public Dictionary<Direction, bool> AvailableMovementsForTheFox { get; private set; }
        public Dictionary<Direction, bool> AvailableMovementsForChickens { get; private set; }

        public GameMechanicsSettingsForm()
        {
            InitializeComponent();

            EatingRuleForTheFox = new Dictionary<Direction, bool>(8);
            AvailableMovementsForTheFox = new Dictionary<Direction, bool>(8);
            AvailableMovementsForChickens = new Dictionary<Direction, bool>(8);
            SetDefaultSettings();
            UpdateProperties();
        }

        private void UpdateProperties()
        {
            Dictionary<string, Direction> pairs = new Dictionary<string, Direction>(8);
            pairs[topEatingRuleCB.Text] = Direction.Top;
            pairs[leftEatingRuleCB.Text] = Direction.Left;
            pairs[rightEatingRuleCB.Text] = Direction.Right;
            pairs[bottomEatingRuleCB.Text] = Direction.Bottom;
            pairs[topLeftEatingRuleCB.Text] = Direction.TopLeft;
            pairs[topRightEatingRuleCB.Text] = Direction.TopRight;
            pairs[bottomLeftEatingRuleCB.Text] = Direction.BottomLeft;
            pairs[bottomRightEatingRuleCB.Text] = Direction.BottomRight;

            foreach (var item in availableMovementsForFoxesGB.Controls)
            {
                CheckBox ch = item as CheckBox;
                if (ch is null) continue;
                AvailableMovementsForTheFox[pairs[ch.Text]] = ch.Checked;
            }
            foreach (var item in availableMovementsForChickensGB.Controls)
            {
                CheckBox ch = item as CheckBox;
                if (ch is null) continue;
                AvailableMovementsForChickens[pairs[ch.Text]] = ch.Checked;
            }
            foreach (var item in eatingRuleGB.Controls)
            {
                CheckBox ch = item as CheckBox;
                if (ch is null) continue;
                EatingRuleForTheFox[pairs[ch.Text]] = ch.Checked;
            }

            GameMap = map.GetGameMap();
            Evaluation = new Evaluation(Convert.ToInt32(EvaluationForBlockedOneFoxNUD.Value),
                                                   Convert.ToInt32(evaluationForOneLiveChickenNUD.Value), 
                                                   evaluationMap.GetEvaluationMap());
        }
        private void SetDefaultSettings()
        {
            SetDefaultSettingsForCheckBoxes();
            map.SetDefaultSettings();
            evaluationMap.SetDefaultSettings();
        }

        private void SetDefaultSettingsForCheckBoxes()
        {
            foreach (var item in availableMovementsForFoxesGB.Controls)
            {
                CheckBox ch = item as CheckBox;
                if (ch is null) continue;
                ch.Checked = false;
            }
            foreach (var item in availableMovementsForChickensGB.Controls)
            {
                CheckBox ch = item as CheckBox;
                if (ch is null) continue;
                ch.Checked = false;
            }
            foreach (var item in eatingRuleGB.Controls)
            {
                CheckBox ch = item as CheckBox;
                if (ch is null) continue;
                ch.Checked = false;
            }
            
            foreach (var item in availableMovementsForFoxesGB.Controls)
            {
                CheckBox ch = item as CheckBox;
                if (ch is null) continue;
                ch.Checked = true;
            }
            
            leftAvailableMovementsChickensCB.Checked = true;
            rightAvailableMovementsChickensCB.Checked = true;
            topLeftAvailableMovementsChickensCB.Checked = true;
            topRightAvailableMovementsChickensCB.Checked = true;
            topAvailableMovementsChickensCB.Checked = true;
            
            leftEatingRuleCB.Checked = true;
            rightEatingRuleCB.Checked = true;
            topEatingRuleCB.Checked = true;
            bottomEatingRuleCB.Checked = true;
            //Evaluations
            evaluationForOneLiveChickenNUD.Value = 10;
            EvaluationForBlockedOneFoxNUD.Value = 0;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            SetDefaultSettings();            
        }

        private void restoreToDefault_Click(object sender, EventArgs e)
        {
            SetDefaultSettings();
        }

        private void GameMechanicsSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateProperties();
        }
    }
}
