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
    public partial class GameForm : Form
    {
        private Game _game;
        private Dictionary<ImageType, Image> _conformityImageTypeWithImage;
        private Dictionary<string, Button> _conformityButtonWithHisIndex;

        private GameMode GameMode
        {
            get
            {
                return this.playerVsAiTSMI.Checked ? GameMode.PlayerVsAI : GameMode.PlayerVsPlayer;
            }
        }

        private PlayerPerson PlayerPerson
        {
            get
            {
                return this.chickenTSMI.Checked ? PlayerPerson.Chicken : PlayerPerson.Fox;
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
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            NewGame();            
        }

        private void NewGame()
        {
            _game = new Game(this.PlayerPerson, this.AI_Level, this.GameMode);

            UpdateFieldOnTheForm();
        }

        private void UpdateFieldOnTheForm()
        {
            LoadPictureInTheForm();
            BlockButtonsOnTheForm();
            UpdateChickensLeftLabel();
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
            _conformityButtonWithHisIndex = new Dictionary<string, Button>();
            foreach (var control in GameFieldTLP.Controls)
            {
                Button button = control as Button;
                if (button != null)
                {                    
                    _conformityButtonWithHisIndex[button.Tag.ToString()] = button;
                }
            }
        }

        private void LoadPictureInTheForm()
        {
            var entities = _game.GetLastEntities();
            foreach (var pair in _conformityButtonWithHisIndex)
            {
                pair.Value.Image = _conformityImageTypeWithImage[entities[pair.Key].ImageType];
            }
        }

        private void BlockButtonsOnTheForm()
        {
            foreach (var pair in _game.GetLastEntities())
            {
                _conformityButtonWithHisIndex[pair.Key].Enabled = pair.Value.IsMovable;               
            }
        }

        private void CellButton_Click(object sender, EventArgs e)
        {
            countLabel.Text = (int.Parse(countLabel.Text) + 1).ToString();
            Button button = sender as Button;
            if (button == null)
                throw new NullReferenceException("The event was triggered not by a button");

            _game.Moving(button.Tag.ToString(), out bool gameOver);
            UpdateFieldOnTheForm();

            if (gameOver)
                GameOver(_game.Winner);
        }

        private void GameOver(PlayerPerson winner)
        {
            MessageBox.Show($"The {winner} wons!!!", "Game Over", MessageBoxButtons.OK);
        }

        private void CancelSelectedPersonButton_Click(object sender, EventArgs e)
        {
            _game.CancelSelectedPerson();
            BlockButtonsOnTheForm();
        }

        //****************************interface begin
        private void UpdateChickensLeftLabel()
        {
            chickensLeftLbl.Text = $"To win, foxes need to eat {_game.GetLeftChickens()}";
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
                    this.personTSMI.Enabled = false;
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
                    this.personTSMI.Enabled = true;
                    this.ai_LevelTSMI.Enabled = true;
                    NewGame();
                }
            }
        }

        private void GamePersonChanged(object sender, EventArgs e)
        {
            if (object.ReferenceEquals(sender, this.foxTSMI) && this.chickenTSMI.Checked)
            {
                if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "Game person change",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.foxTSMI.Checked = true;
                    this.chickenTSMI.Checked = false;
                    NewGame();
                }
            }
            if (object.ReferenceEquals(sender, this.chickenTSMI) && this.foxTSMI.Checked)
            {
                if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "Game person change",
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
                    this.lowLevelTSMI.Checked = false;
                    this.mediumLevelTSMI.Checked = true;
                    NewGame();
                }
            }
            if (object.ReferenceEquals(sender, this.mediumLevelTSMI) && this.lowLevelTSMI.Checked)
            {
                if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "AI level change",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.lowLevelTSMI.Checked = true;
                    this.mediumLevelTSMI.Checked = false;
                    NewGame();
                }
            }
        }
        //****************************interface end
    }
}
