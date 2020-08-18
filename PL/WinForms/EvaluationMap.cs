using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class EvaluationMap : UserControl
    {
        private Dictionary<Point, NumericUpDown> _conformityNUDWithHisIndex;

        public EvaluationMap()
        {
            InitializeComponent();
            InitDictionaryConformityButtons();
        }

        private void InitDictionaryConformityButtons()
        {
            _conformityNUDWithHisIndex = new Dictionary<Point, NumericUpDown>();
            foreach (var control in GameFieldTLP.Controls)
            {
                NumericUpDown nud = control as NumericUpDown;
                if (nud != null)
                {
                    string coord = nud.Tag.ToString();
                    _conformityNUDWithHisIndex[new Point(int.Parse(coord[0].ToString()),
                        int.Parse(coord[1].ToString()))] = nud;
                }
            }
        }

        public void SetDefaultSettings()
        {
            for (int y = 2; y < 6; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    if (y == 5 && (x != 2 && x != 3 && x != 4))
                        continue;

                    //winning position
                    if (y == 2 && (x == 2 || x == 3 || x == 4))
                        continue;

                    _conformityNUDWithHisIndex[new Point(x, y)].Value = 6 - y;
                }
            }

            for (int y = 0; y < 3; y++)
            {
                for (int x = 2; x < 5; x++)
                {
                    _conformityNUDWithHisIndex[new Point(x, y)].Value = 7 - y;
                }
            }
        }

        public Dictionary<Point, int> GetEvaluationMap()
        {
            Dictionary<Point, int> map = new Dictionary<Point, int>(33);
            foreach (var item in _conformityNUDWithHisIndex)
            {
                map[item.Key] = Convert.ToInt32(item.Value.Value);
            }
            return map;
        }
    }
}
