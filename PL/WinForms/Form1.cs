using BL;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WinForms
{
    public partial class GameForm : Form
    {
        private Game _game;
        readonly GameMechanicsSettingsForm _settingsForm;
        private Dictionary<ImageType, Image> _conformityImageTypeWithImage;
        private Dictionary<Point, Button> _conformityButtonWithHisIndex;

        private GameMode GameMode
        {
            get
            {
                return this.playerVsAiTSMI.Checked ? GameMode.PlayerVsAI : GameMode.PlayerVsPlayer;
            }
        }

        private PlayerCharacter PlayerCharacter
        {
            get
            {
                return this.chickenTSMI.Checked ? PlayerCharacter.Chicken : PlayerCharacter.Fox;
            }
        }

        private AI_level AI_Level
        {
            get
            {
                if (this.lowLevelTSMI.Checked)
                    return AI_level.Low;
                else //if (this.mediumLevelTSMI.Checked)
                    return AI_level.Medium;
            }
        }

        public GameForm()
        {
            InitializeComponent();

            InitDictionaryConformityImages();
            InitDictionaryConformityButtons();
            _settingsForm = new GameMechanicsSettingsForm();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {            
            NewGame();
        }

        private void NewGame()
        {
            GameFieldTLP.Enabled = false;
            if (_game != null)
            {
                _game.OnChangeEntitiesProperties -= UpdateFieldDisplay;
                _game.OnWin -= GameOver;
            }

            _game = new Game(this.PlayerCharacter, this.AI_Level, this.GameMode, UpdateFieldDisplay, GameOver, 
                _settingsForm.EatingRuleForTheFox, 
                _settingsForm.AvailableMovementsForTheFox, 
                _settingsForm.AvailableMovementsForChickens,
                _settingsForm.GameMap);
            GameFieldTLP.Enabled = true;
        }

        private void InitDictionaryConformityImages()
        {
            _conformityImageTypeWithImage = new Dictionary<ImageType, Image>();
            _conformityImageTypeWithImage[ImageType.FoxImage] = imageList.Images[0];
            _conformityImageTypeWithImage[ImageType.ChickenImage] = imageList.Images[1];
            _conformityImageTypeWithImage[ImageType.EmptyCellImage] = imageList.Images[2];
            _conformityImageTypeWithImage[ImageType.DeadChickenImage] = imageList.Images[3];
            _conformityImageTypeWithImage[ImageType.StartPositionOfMovementImage] = imageList.Images[4];
            _conformityImageTypeWithImage[ImageType.TrackImage] = imageList.Images[5];
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

        private void CellButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            GameFieldTLP.Enabled = false;
            Button button = sender as Button;
            if (button == null)
                throw new NullReferenceException("The event was triggered not by a button");
            
            stopwatch.Start();
            string coord = button.Tag.ToString();
            _game.Move(new Point(int.Parse(coord[0].ToString()), int.Parse(coord[1].ToString())));
            stopwatch.Stop();
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
        }

        private void CancelMoveButton_Click(object sender, EventArgs e)
        {
            _game.CancelMove();
        }

        private void UpdateFieldDisplay(object sender, EntitiesPropertiesEventArgs e)
        {
            UpdateEnableStatusOfButtonsOnField(e.IsMovablePairs);
            UpdateImagesOnField(e.ImageTypePairs);
            UpdateChickensLeftLabel(e.ChickensLeftBeforeLosing);
            GameFieldTLP.Enabled = true;
        }

        private void UpdateEnableStatusOfButtonsOnField(IDictionary<Point, bool> isMovablePairs)
        {
            foreach (var pair in isMovablePairs)
            {
                _conformityButtonWithHisIndex[pair.Key].Enabled = pair.Value;
            }
        }

        private void UpdateImagesOnField(IDictionary<Point, ImageType> imageTypePairs)
        {
            foreach (var pair in _conformityButtonWithHisIndex)
            {
                pair.Value.Image = _conformityImageTypeWithImage[imageTypePairs[pair.Key]];
            }
        }

        private void UpdateChickensLeftLabel(int chickenLeft)
        {
            chickensLeftLbl.Text = $"To win, foxes need to eat {chickenLeft}";
        }

        //****************************interface begin
        private void GameOver(object sender, WinEventArgs e)
        {
            MessageBox.Show($"The {e.Winner} wons!!!", "Game Over", MessageBoxButtons.OK);
        }

        private void NewGameTSMI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "Game restart", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                NewGame();
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "Game closure.",
                MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GameModeChanged(object sender, EventArgs e)
        {
            if (object.ReferenceEquals(sender, this.playerVsPlayerTSMI) && this.playerVsAiTSMI.Checked)
            {
                if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "Game mode change",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.playerVsAiTSMI.Checked = false;
                    this.playerVsPlayerTSMI.Checked = true;
                    this.characterTSMI.Enabled = false;
                    this.ai_LevelTSMI.Enabled = false;
                    NewGame();
                }
            }
            if (object.ReferenceEquals(sender, this.playerVsAiTSMI) && this.playerVsPlayerTSMI.Checked)
            {
                if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "Game mode change",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.playerVsAiTSMI.Checked = true;
                    this.playerVsPlayerTSMI.Checked = false;
                    this.characterTSMI.Enabled = true;
                    this.ai_LevelTSMI.Enabled = true;
                    NewGame();
                }
            }
        }

        private void GameCharacterChanged(object sender, EventArgs e)
        {
            if (object.ReferenceEquals(sender, this.foxTSMI) && this.chickenTSMI.Checked)
            {
                if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "Game Character change",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.foxTSMI.Checked = true;
                    this.chickenTSMI.Checked = false;
                    NewGame();
                }
            }
            if (object.ReferenceEquals(sender, this.chickenTSMI) && this.foxTSMI.Checked)
            {
                if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "Game Character change",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.foxTSMI.Checked = false;
                    this.chickenTSMI.Checked = true;
                    NewGame();
                }
            }
        }

        private void AI_LevelChanged(object sender, EventArgs e)
        {
            if (object.ReferenceEquals(sender, this.lowLevelTSMI) && this.mediumLevelTSMI.Checked)
            {
                if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "AI level change",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.lowLevelTSMI.Checked = true;
                    this.mediumLevelTSMI.Checked = false;
                    NewGame();
                }
            }
            if (object.ReferenceEquals(sender, this.mediumLevelTSMI) && this.lowLevelTSMI.Checked)
            {
                if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "AI level change",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.lowLevelTSMI.Checked = false;
                    this.mediumLevelTSMI.Checked = true;
                    NewGame();
                }
            }
        }

        private void GameFieldTLP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CancelMoveButton_Click(sender, EventArgs.Empty);
            }
        }

        private void gameMechanicsSettingsTSMI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", 
                "Game mechanics settings change", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _settingsForm.ShowDialog();
                NewGame();
            }
        }
        //****************************interface end
    }
}
