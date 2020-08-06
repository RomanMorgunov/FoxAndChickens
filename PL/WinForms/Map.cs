using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace WinForms
{
    public partial class Map : UserControl
    {
        private Dictionary<Point, Button> _conformityButtonWithHisIndex;

        public Map()
        {
            InitializeComponent();
            InitDictionaryConformityButtons();
        }

        private void InitDictionaryConformityButtons()
        {
            _conformityButtonWithHisIndex = new Dictionary<Point, Button>();
            foreach (var control in GameFieldTLP.Controls)
            {
                Button button = control as Button;
                if (button != null)
                {
                    string coord = button.Tag.ToString();
                    _conformityButtonWithHisIndex[new Point(int.Parse(coord[0].ToString()),
                        int.Parse(coord[1].ToString()))] = button;
                }
            }
        }

        public void SetDefaultSettings()
        {
            foreach (var item in _conformityButtonWithHisIndex.Values)
            {
                item.Text = "";
            }

            _conformityButtonWithHisIndex[new Point(3, 2)].Text = "F";

            var collection = _conformityButtonWithHisIndex.Where(p => p.Key.Y >= 4);
            foreach (var item in collection)
            {
                item.Value.Text = "C";
            }
        }

        private void CellButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
                throw new ArgumentException("The event was triggered not by a button");
            
            string coord = button.Tag.ToString();
            Button btn = _conformityButtonWithHisIndex[new Point(int.Parse(coord[0].ToString()), int.Parse(coord[1].ToString()))];
            switch (btn.Text)
            {
                case "":
                    btn.Text = "C";
                    break;
                case "C":
                    btn.Text = "F";
                    break;
                case "F":
                    btn.Text = "";
                    break;
                default:
                    throw new ArgumentException("Invalid button text.");
            }
        }

        public Dictionary<Point, EntityType> GetGameMap()
        {
            Dictionary<Point, EntityType> map = new Dictionary<Point, EntityType>(33);
            foreach (var item in _conformityButtonWithHisIndex)
            {
                string text = item.Value.Text;
                map[item.Key] = text == "" ? EntityType.EmptyCell : text == "C" ? EntityType.Chicken : EntityType.Fox;
            }
            return map;
        }
    }
}
