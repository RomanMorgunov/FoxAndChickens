namespace WinForms
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.newGameTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.gameModeTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsPlayerTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsAiTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.characterTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.chickenTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.foxTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ai_LevelTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.lowLevelTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumLevelTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.GameFieldTLP = new System.Windows.Forms.TableLayoutPanel();
            this.cell46Btn = new System.Windows.Forms.Button();
            this.cell36Btn = new System.Windows.Forms.Button();
            this.cell26Btn = new System.Windows.Forms.Button();
            this.cell45Btn = new System.Windows.Forms.Button();
            this.cell35Btn = new System.Windows.Forms.Button();
            this.cell25Btn = new System.Windows.Forms.Button();
            this.cell64Btn = new System.Windows.Forms.Button();
            this.cell54Btn = new System.Windows.Forms.Button();
            this.cell44Btn = new System.Windows.Forms.Button();
            this.cell34Btn = new System.Windows.Forms.Button();
            this.cell24Btn = new System.Windows.Forms.Button();
            this.cell14Btn = new System.Windows.Forms.Button();
            this.cell04Btn = new System.Windows.Forms.Button();
            this.cell63Btn = new System.Windows.Forms.Button();
            this.cell53Btn = new System.Windows.Forms.Button();
            this.cell43Btn = new System.Windows.Forms.Button();
            this.cell33Btn = new System.Windows.Forms.Button();
            this.cell23Btn = new System.Windows.Forms.Button();
            this.cell13Btn = new System.Windows.Forms.Button();
            this.cell03Btn = new System.Windows.Forms.Button();
            this.cell62Btn = new System.Windows.Forms.Button();
            this.cell52Btn = new System.Windows.Forms.Button();
            this.cell42Btn = new System.Windows.Forms.Button();
            this.cell32Btn = new System.Windows.Forms.Button();
            this.cell22Btn = new System.Windows.Forms.Button();
            this.cell12Btn = new System.Windows.Forms.Button();
            this.cell02Btn = new System.Windows.Forms.Button();
            this.cell41Btn = new System.Windows.Forms.Button();
            this.cell31Btn = new System.Windows.Forms.Button();
            this.cell21Btn = new System.Windows.Forms.Button();
            this.cell40Btn = new System.Windows.Forms.Button();
            this.cell30Btn = new System.Windows.Forms.Button();
            this.cell20Btn = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.cancelMoveBtn = new System.Windows.Forms.ToolStripButton();
            this.chickensLeftLbl = new System.Windows.Forms.ToolStripLabel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip.SuspendLayout();
            this.GameFieldTLP.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameTSMI,
            this.gameModeTSMI,
            this.characterTSMI,
            this.ai_LevelTSMI,
            this.exitTSMI});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(676, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "Панель меню";
            // 
            // newGameTSMI
            // 
            this.newGameTSMI.ForeColor = System.Drawing.Color.Maroon;
            this.newGameTSMI.Name = "newGameTSMI";
            this.newGameTSMI.Size = new System.Drawing.Size(76, 20);
            this.newGameTSMI.Text = "New game";
            this.newGameTSMI.Click += new System.EventHandler(this.NewGameTSMI_Click);
            // 
            // gameModeTSMI
            // 
            this.gameModeTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerVsPlayerTSMI,
            this.playerVsAiTSMI});
            this.gameModeTSMI.ForeColor = System.Drawing.Color.Maroon;
            this.gameModeTSMI.Name = "gameModeTSMI";
            this.gameModeTSMI.Size = new System.Drawing.Size(84, 20);
            this.gameModeTSMI.Text = "Game mode";
            // 
            // playerVsPlayerTSMI
            // 
            this.playerVsPlayerTSMI.BackColor = System.Drawing.Color.DarkGray;
            this.playerVsPlayerTSMI.Name = "playerVsPlayerTSMI";
            this.playerVsPlayerTSMI.Size = new System.Drawing.Size(155, 22);
            this.playerVsPlayerTSMI.Text = "Player vs Player";
            this.playerVsPlayerTSMI.Click += new System.EventHandler(this.GameModeChanged);
            // 
            // playerVsAiTSMI
            // 
            this.playerVsAiTSMI.BackColor = System.Drawing.Color.DarkGray;
            this.playerVsAiTSMI.Checked = true;
            this.playerVsAiTSMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playerVsAiTSMI.Name = "playerVsAiTSMI";
            this.playerVsAiTSMI.Size = new System.Drawing.Size(155, 22);
            this.playerVsAiTSMI.Text = "Player vs AI";
            this.playerVsAiTSMI.Click += new System.EventHandler(this.GameModeChanged);
            // 
            // characterTSMI
            // 
            this.characterTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chickenTSMI,
            this.foxTSMI});
            this.characterTSMI.ForeColor = System.Drawing.Color.Maroon;
            this.characterTSMI.Name = "characterTSMI";
            this.characterTSMI.Size = new System.Drawing.Size(120, 20);
            this.characterTSMI.Text = "Character selection";
            // 
            // chickenTSMI
            // 
            this.chickenTSMI.BackColor = System.Drawing.Color.DarkGray;
            this.chickenTSMI.Checked = true;
            this.chickenTSMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chickenTSMI.Name = "chickenTSMI";
            this.chickenTSMI.Size = new System.Drawing.Size(122, 22);
            this.chickenTSMI.Text = "Chickens";
            this.chickenTSMI.Click += new System.EventHandler(this.GameCharacterChanged);
            // 
            // foxTSMI
            // 
            this.foxTSMI.BackColor = System.Drawing.Color.DarkGray;
            this.foxTSMI.Name = "foxTSMI";
            this.foxTSMI.Size = new System.Drawing.Size(122, 22);
            this.foxTSMI.Text = "Fox";
            this.foxTSMI.Click += new System.EventHandler(this.GameCharacterChanged);
            // 
            // ai_LevelTSMI
            // 
            this.ai_LevelTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowLevelTSMI,
            this.mediumLevelTSMI});
            this.ai_LevelTSMI.ForeColor = System.Drawing.Color.Maroon;
            this.ai_LevelTSMI.Name = "ai_LevelTSMI";
            this.ai_LevelTSMI.Size = new System.Drawing.Size(57, 20);
            this.ai_LevelTSMI.Text = "AI level";
            // 
            // lowLevelTSMI
            // 
            this.lowLevelTSMI.BackColor = System.Drawing.Color.DarkGray;
            this.lowLevelTSMI.Checked = true;
            this.lowLevelTSMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lowLevelTSMI.Name = "lowLevelTSMI";
            this.lowLevelTSMI.Size = new System.Drawing.Size(119, 22);
            this.lowLevelTSMI.Text = "Low";
            this.lowLevelTSMI.Click += new System.EventHandler(this.AI_LevelChanged);
            // 
            // mediumLevelTSMI
            // 
            this.mediumLevelTSMI.BackColor = System.Drawing.Color.DarkGray;
            this.mediumLevelTSMI.Name = "mediumLevelTSMI";
            this.mediumLevelTSMI.Size = new System.Drawing.Size(119, 22);
            this.mediumLevelTSMI.Text = "Medium";
            this.mediumLevelTSMI.Click += new System.EventHandler(this.AI_LevelChanged);
            // 
            // exitTSMI
            // 
            this.exitTSMI.ForeColor = System.Drawing.Color.Maroon;
            this.exitTSMI.Name = "exitTSMI";
            this.exitTSMI.Size = new System.Drawing.Size(38, 20);
            this.exitTSMI.Text = "Exit";
            this.exitTSMI.Click += new System.EventHandler(this.Exit);
            // 
            // GameFieldTLP
            // 
            this.GameFieldTLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameFieldTLP.ColumnCount = 7;
            this.GameFieldTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.GameFieldTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.GameFieldTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.GameFieldTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.GameFieldTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.GameFieldTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.GameFieldTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.GameFieldTLP.Controls.Add(this.cell46Btn, 4, 6);
            this.GameFieldTLP.Controls.Add(this.cell36Btn, 3, 6);
            this.GameFieldTLP.Controls.Add(this.cell26Btn, 2, 6);
            this.GameFieldTLP.Controls.Add(this.cell45Btn, 4, 5);
            this.GameFieldTLP.Controls.Add(this.cell35Btn, 3, 5);
            this.GameFieldTLP.Controls.Add(this.cell25Btn, 2, 5);
            this.GameFieldTLP.Controls.Add(this.cell64Btn, 6, 4);
            this.GameFieldTLP.Controls.Add(this.cell54Btn, 5, 4);
            this.GameFieldTLP.Controls.Add(this.cell44Btn, 4, 4);
            this.GameFieldTLP.Controls.Add(this.cell34Btn, 3, 4);
            this.GameFieldTLP.Controls.Add(this.cell24Btn, 2, 4);
            this.GameFieldTLP.Controls.Add(this.cell14Btn, 1, 4);
            this.GameFieldTLP.Controls.Add(this.cell04Btn, 0, 4);
            this.GameFieldTLP.Controls.Add(this.cell63Btn, 6, 3);
            this.GameFieldTLP.Controls.Add(this.cell53Btn, 5, 3);
            this.GameFieldTLP.Controls.Add(this.cell43Btn, 4, 3);
            this.GameFieldTLP.Controls.Add(this.cell33Btn, 3, 3);
            this.GameFieldTLP.Controls.Add(this.cell23Btn, 2, 3);
            this.GameFieldTLP.Controls.Add(this.cell13Btn, 1, 3);
            this.GameFieldTLP.Controls.Add(this.cell03Btn, 0, 3);
            this.GameFieldTLP.Controls.Add(this.cell62Btn, 6, 2);
            this.GameFieldTLP.Controls.Add(this.cell52Btn, 5, 2);
            this.GameFieldTLP.Controls.Add(this.cell42Btn, 4, 2);
            this.GameFieldTLP.Controls.Add(this.cell32Btn, 3, 2);
            this.GameFieldTLP.Controls.Add(this.cell22Btn, 2, 2);
            this.GameFieldTLP.Controls.Add(this.cell12Btn, 1, 2);
            this.GameFieldTLP.Controls.Add(this.cell02Btn, 0, 2);
            this.GameFieldTLP.Controls.Add(this.cell41Btn, 4, 1);
            this.GameFieldTLP.Controls.Add(this.cell31Btn, 3, 1);
            this.GameFieldTLP.Controls.Add(this.cell21Btn, 2, 1);
            this.GameFieldTLP.Controls.Add(this.cell40Btn, 4, 0);
            this.GameFieldTLP.Controls.Add(this.cell30Btn, 3, 0);
            this.GameFieldTLP.Controls.Add(this.cell20Btn, 2, 0);
            this.GameFieldTLP.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.GameFieldTLP.Location = new System.Drawing.Point(2, 29);
            this.GameFieldTLP.MaximumSize = new System.Drawing.Size(672, 532);
            this.GameFieldTLP.MinimumSize = new System.Drawing.Size(672, 532);
            this.GameFieldTLP.Name = "GameFieldTLP";
            this.GameFieldTLP.RowCount = 7;
            this.GameFieldTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.GameFieldTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.GameFieldTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.GameFieldTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.GameFieldTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.GameFieldTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.GameFieldTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.GameFieldTLP.Size = new System.Drawing.Size(672, 532);
            this.GameFieldTLP.TabIndex = 5;
            this.GameFieldTLP.Tag = "";
            this.GameFieldTLP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell46Btn
            // 
            this.cell46Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell46Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell46Btn.FlatAppearance.BorderSize = 2;
            this.cell46Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell46Btn.Location = new System.Drawing.Point(387, 459);
            this.cell46Btn.Name = "cell46Btn";
            this.cell46Btn.Size = new System.Drawing.Size(90, 70);
            this.cell46Btn.TabIndex = 46;
            this.cell46Btn.TabStop = false;
            this.cell46Btn.Tag = "46";
            this.cell46Btn.UseVisualStyleBackColor = true;
            this.cell46Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell46Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell36Btn
            // 
            this.cell36Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell36Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell36Btn.FlatAppearance.BorderSize = 2;
            this.cell36Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell36Btn.Location = new System.Drawing.Point(291, 459);
            this.cell36Btn.Name = "cell36Btn";
            this.cell36Btn.Size = new System.Drawing.Size(90, 70);
            this.cell36Btn.TabIndex = 45;
            this.cell36Btn.TabStop = false;
            this.cell36Btn.Tag = "36";
            this.cell36Btn.UseVisualStyleBackColor = true;
            this.cell36Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell36Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell26Btn
            // 
            this.cell26Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell26Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell26Btn.FlatAppearance.BorderSize = 2;
            this.cell26Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell26Btn.Location = new System.Drawing.Point(195, 459);
            this.cell26Btn.Name = "cell26Btn";
            this.cell26Btn.Size = new System.Drawing.Size(90, 70);
            this.cell26Btn.TabIndex = 44;
            this.cell26Btn.TabStop = false;
            this.cell26Btn.Tag = "26";
            this.cell26Btn.UseVisualStyleBackColor = true;
            this.cell26Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell26Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell45Btn
            // 
            this.cell45Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell45Btn.Enabled = false;
            this.cell45Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell45Btn.FlatAppearance.BorderSize = 2;
            this.cell45Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell45Btn.Location = new System.Drawing.Point(387, 383);
            this.cell45Btn.Name = "cell45Btn";
            this.cell45Btn.Size = new System.Drawing.Size(90, 70);
            this.cell45Btn.TabIndex = 39;
            this.cell45Btn.TabStop = false;
            this.cell45Btn.Tag = "45";
            this.cell45Btn.UseVisualStyleBackColor = true;
            this.cell45Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell45Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell35Btn
            // 
            this.cell35Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell35Btn.Enabled = false;
            this.cell35Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell35Btn.FlatAppearance.BorderSize = 2;
            this.cell35Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell35Btn.Location = new System.Drawing.Point(291, 383);
            this.cell35Btn.Name = "cell35Btn";
            this.cell35Btn.Size = new System.Drawing.Size(90, 70);
            this.cell35Btn.TabIndex = 38;
            this.cell35Btn.TabStop = false;
            this.cell35Btn.Tag = "35";
            this.cell35Btn.UseVisualStyleBackColor = true;
            this.cell35Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell35Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell25Btn
            // 
            this.cell25Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell25Btn.Enabled = false;
            this.cell25Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell25Btn.FlatAppearance.BorderSize = 2;
            this.cell25Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell25Btn.Location = new System.Drawing.Point(195, 383);
            this.cell25Btn.Name = "cell25Btn";
            this.cell25Btn.Size = new System.Drawing.Size(90, 70);
            this.cell25Btn.TabIndex = 37;
            this.cell25Btn.TabStop = false;
            this.cell25Btn.Tag = "25";
            this.cell25Btn.UseVisualStyleBackColor = true;
            this.cell25Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell25Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell64Btn
            // 
            this.cell64Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell64Btn.Enabled = false;
            this.cell64Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell64Btn.FlatAppearance.BorderSize = 2;
            this.cell64Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell64Btn.Location = new System.Drawing.Point(579, 307);
            this.cell64Btn.Name = "cell64Btn";
            this.cell64Btn.Size = new System.Drawing.Size(90, 70);
            this.cell64Btn.TabIndex = 34;
            this.cell64Btn.TabStop = false;
            this.cell64Btn.Tag = "64";
            this.cell64Btn.UseVisualStyleBackColor = true;
            this.cell64Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell64Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell54Btn
            // 
            this.cell54Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell54Btn.Enabled = false;
            this.cell54Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell54Btn.FlatAppearance.BorderSize = 2;
            this.cell54Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell54Btn.ForeColor = System.Drawing.Color.Maroon;
            this.cell54Btn.Location = new System.Drawing.Point(483, 307);
            this.cell54Btn.Name = "cell54Btn";
            this.cell54Btn.Size = new System.Drawing.Size(90, 70);
            this.cell54Btn.TabIndex = 33;
            this.cell54Btn.TabStop = false;
            this.cell54Btn.Tag = "54";
            this.cell54Btn.UseVisualStyleBackColor = true;
            this.cell54Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell54Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell44Btn
            // 
            this.cell44Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell44Btn.Enabled = false;
            this.cell44Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell44Btn.FlatAppearance.BorderSize = 2;
            this.cell44Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell44Btn.Location = new System.Drawing.Point(387, 307);
            this.cell44Btn.Name = "cell44Btn";
            this.cell44Btn.Size = new System.Drawing.Size(90, 70);
            this.cell44Btn.TabIndex = 32;
            this.cell44Btn.TabStop = false;
            this.cell44Btn.Tag = "44";
            this.cell44Btn.UseVisualStyleBackColor = true;
            this.cell44Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell44Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell34Btn
            // 
            this.cell34Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell34Btn.Enabled = false;
            this.cell34Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell34Btn.FlatAppearance.BorderSize = 2;
            this.cell34Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell34Btn.Location = new System.Drawing.Point(291, 307);
            this.cell34Btn.Name = "cell34Btn";
            this.cell34Btn.Size = new System.Drawing.Size(90, 70);
            this.cell34Btn.TabIndex = 31;
            this.cell34Btn.TabStop = false;
            this.cell34Btn.Tag = "34";
            this.cell34Btn.UseVisualStyleBackColor = true;
            this.cell34Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell34Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell24Btn
            // 
            this.cell24Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell24Btn.Enabled = false;
            this.cell24Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell24Btn.FlatAppearance.BorderSize = 2;
            this.cell24Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell24Btn.Location = new System.Drawing.Point(195, 307);
            this.cell24Btn.Name = "cell24Btn";
            this.cell24Btn.Size = new System.Drawing.Size(90, 70);
            this.cell24Btn.TabIndex = 30;
            this.cell24Btn.TabStop = false;
            this.cell24Btn.Tag = "24";
            this.cell24Btn.UseVisualStyleBackColor = true;
            this.cell24Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell24Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell14Btn
            // 
            this.cell14Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell14Btn.Enabled = false;
            this.cell14Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell14Btn.FlatAppearance.BorderSize = 2;
            this.cell14Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell14Btn.Location = new System.Drawing.Point(99, 307);
            this.cell14Btn.Name = "cell14Btn";
            this.cell14Btn.Size = new System.Drawing.Size(90, 70);
            this.cell14Btn.TabIndex = 29;
            this.cell14Btn.TabStop = false;
            this.cell14Btn.Tag = "14";
            this.cell14Btn.UseVisualStyleBackColor = true;
            this.cell14Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell14Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell04Btn
            // 
            this.cell04Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell04Btn.Enabled = false;
            this.cell04Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell04Btn.FlatAppearance.BorderSize = 2;
            this.cell04Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell04Btn.Location = new System.Drawing.Point(3, 307);
            this.cell04Btn.Name = "cell04Btn";
            this.cell04Btn.Size = new System.Drawing.Size(90, 70);
            this.cell04Btn.TabIndex = 28;
            this.cell04Btn.TabStop = false;
            this.cell04Btn.Tag = "04";
            this.cell04Btn.UseVisualStyleBackColor = true;
            this.cell04Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell04Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell63Btn
            // 
            this.cell63Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell63Btn.Enabled = false;
            this.cell63Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell63Btn.FlatAppearance.BorderSize = 2;
            this.cell63Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell63Btn.Location = new System.Drawing.Point(579, 231);
            this.cell63Btn.Name = "cell63Btn";
            this.cell63Btn.Size = new System.Drawing.Size(90, 70);
            this.cell63Btn.TabIndex = 27;
            this.cell63Btn.TabStop = false;
            this.cell63Btn.Tag = "63";
            this.cell63Btn.UseVisualStyleBackColor = true;
            this.cell63Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell63Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell53Btn
            // 
            this.cell53Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell53Btn.Enabled = false;
            this.cell53Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell53Btn.FlatAppearance.BorderSize = 2;
            this.cell53Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell53Btn.Location = new System.Drawing.Point(483, 231);
            this.cell53Btn.Name = "cell53Btn";
            this.cell53Btn.Size = new System.Drawing.Size(90, 70);
            this.cell53Btn.TabIndex = 26;
            this.cell53Btn.TabStop = false;
            this.cell53Btn.Tag = "53";
            this.cell53Btn.UseVisualStyleBackColor = true;
            this.cell53Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell53Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell43Btn
            // 
            this.cell43Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell43Btn.Enabled = false;
            this.cell43Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell43Btn.FlatAppearance.BorderSize = 2;
            this.cell43Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell43Btn.Location = new System.Drawing.Point(387, 231);
            this.cell43Btn.Name = "cell43Btn";
            this.cell43Btn.Size = new System.Drawing.Size(90, 70);
            this.cell43Btn.TabIndex = 25;
            this.cell43Btn.TabStop = false;
            this.cell43Btn.Tag = "43";
            this.cell43Btn.UseVisualStyleBackColor = true;
            this.cell43Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell43Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell33Btn
            // 
            this.cell33Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell33Btn.Enabled = false;
            this.cell33Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell33Btn.FlatAppearance.BorderSize = 2;
            this.cell33Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell33Btn.Location = new System.Drawing.Point(291, 231);
            this.cell33Btn.Name = "cell33Btn";
            this.cell33Btn.Size = new System.Drawing.Size(90, 70);
            this.cell33Btn.TabIndex = 24;
            this.cell33Btn.TabStop = false;
            this.cell33Btn.Tag = "33";
            this.cell33Btn.UseVisualStyleBackColor = true;
            this.cell33Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell33Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell23Btn
            // 
            this.cell23Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell23Btn.Enabled = false;
            this.cell23Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell23Btn.FlatAppearance.BorderSize = 2;
            this.cell23Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell23Btn.Location = new System.Drawing.Point(195, 231);
            this.cell23Btn.Name = "cell23Btn";
            this.cell23Btn.Size = new System.Drawing.Size(90, 70);
            this.cell23Btn.TabIndex = 23;
            this.cell23Btn.TabStop = false;
            this.cell23Btn.Tag = "23";
            this.cell23Btn.UseVisualStyleBackColor = true;
            this.cell23Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell23Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell13Btn
            // 
            this.cell13Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell13Btn.Enabled = false;
            this.cell13Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell13Btn.FlatAppearance.BorderSize = 2;
            this.cell13Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell13Btn.Location = new System.Drawing.Point(99, 231);
            this.cell13Btn.Name = "cell13Btn";
            this.cell13Btn.Size = new System.Drawing.Size(90, 70);
            this.cell13Btn.TabIndex = 22;
            this.cell13Btn.TabStop = false;
            this.cell13Btn.Tag = "13";
            this.cell13Btn.UseVisualStyleBackColor = true;
            this.cell13Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell13Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell03Btn
            // 
            this.cell03Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell03Btn.Enabled = false;
            this.cell03Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell03Btn.FlatAppearance.BorderSize = 2;
            this.cell03Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell03Btn.Location = new System.Drawing.Point(3, 231);
            this.cell03Btn.Name = "cell03Btn";
            this.cell03Btn.Size = new System.Drawing.Size(90, 70);
            this.cell03Btn.TabIndex = 21;
            this.cell03Btn.TabStop = false;
            this.cell03Btn.Tag = "03";
            this.cell03Btn.UseVisualStyleBackColor = true;
            this.cell03Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell03Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell62Btn
            // 
            this.cell62Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell62Btn.Enabled = false;
            this.cell62Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell62Btn.FlatAppearance.BorderSize = 2;
            this.cell62Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell62Btn.Location = new System.Drawing.Point(579, 155);
            this.cell62Btn.Name = "cell62Btn";
            this.cell62Btn.Size = new System.Drawing.Size(90, 70);
            this.cell62Btn.TabIndex = 20;
            this.cell62Btn.TabStop = false;
            this.cell62Btn.Tag = "62";
            this.cell62Btn.UseVisualStyleBackColor = true;
            this.cell62Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell62Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell52Btn
            // 
            this.cell52Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell52Btn.Enabled = false;
            this.cell52Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell52Btn.FlatAppearance.BorderSize = 2;
            this.cell52Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell52Btn.Location = new System.Drawing.Point(483, 155);
            this.cell52Btn.Name = "cell52Btn";
            this.cell52Btn.Size = new System.Drawing.Size(90, 70);
            this.cell52Btn.TabIndex = 19;
            this.cell52Btn.TabStop = false;
            this.cell52Btn.Tag = "52";
            this.cell52Btn.UseVisualStyleBackColor = true;
            this.cell52Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell52Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell42Btn
            // 
            this.cell42Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell42Btn.Enabled = false;
            this.cell42Btn.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.cell42Btn.FlatAppearance.BorderSize = 2;
            this.cell42Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell42Btn.Location = new System.Drawing.Point(387, 155);
            this.cell42Btn.Name = "cell42Btn";
            this.cell42Btn.Size = new System.Drawing.Size(90, 70);
            this.cell42Btn.TabIndex = 18;
            this.cell42Btn.TabStop = false;
            this.cell42Btn.Tag = "42";
            this.cell42Btn.UseVisualStyleBackColor = true;
            this.cell42Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell42Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell32Btn
            // 
            this.cell32Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell32Btn.Enabled = false;
            this.cell32Btn.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.cell32Btn.FlatAppearance.BorderSize = 2;
            this.cell32Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell32Btn.Location = new System.Drawing.Point(291, 155);
            this.cell32Btn.Name = "cell32Btn";
            this.cell32Btn.Size = new System.Drawing.Size(90, 70);
            this.cell32Btn.TabIndex = 17;
            this.cell32Btn.TabStop = false;
            this.cell32Btn.Tag = "32";
            this.cell32Btn.UseVisualStyleBackColor = true;
            this.cell32Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell32Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell22Btn
            // 
            this.cell22Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell22Btn.Enabled = false;
            this.cell22Btn.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.cell22Btn.FlatAppearance.BorderSize = 2;
            this.cell22Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell22Btn.Location = new System.Drawing.Point(195, 155);
            this.cell22Btn.Name = "cell22Btn";
            this.cell22Btn.Size = new System.Drawing.Size(90, 70);
            this.cell22Btn.TabIndex = 16;
            this.cell22Btn.TabStop = false;
            this.cell22Btn.Tag = "22";
            this.cell22Btn.UseVisualStyleBackColor = true;
            this.cell22Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell22Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell12Btn
            // 
            this.cell12Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell12Btn.Enabled = false;
            this.cell12Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell12Btn.FlatAppearance.BorderSize = 2;
            this.cell12Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell12Btn.Location = new System.Drawing.Point(99, 155);
            this.cell12Btn.Name = "cell12Btn";
            this.cell12Btn.Size = new System.Drawing.Size(90, 70);
            this.cell12Btn.TabIndex = 15;
            this.cell12Btn.TabStop = false;
            this.cell12Btn.Tag = "12";
            this.cell12Btn.UseVisualStyleBackColor = true;
            this.cell12Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell12Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell02Btn
            // 
            this.cell02Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell02Btn.Enabled = false;
            this.cell02Btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cell02Btn.FlatAppearance.BorderSize = 2;
            this.cell02Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell02Btn.Location = new System.Drawing.Point(3, 155);
            this.cell02Btn.Name = "cell02Btn";
            this.cell02Btn.Size = new System.Drawing.Size(90, 70);
            this.cell02Btn.TabIndex = 14;
            this.cell02Btn.TabStop = false;
            this.cell02Btn.Tag = "02";
            this.cell02Btn.UseVisualStyleBackColor = true;
            this.cell02Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell02Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell41Btn
            // 
            this.cell41Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell41Btn.Enabled = false;
            this.cell41Btn.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.cell41Btn.FlatAppearance.BorderSize = 2;
            this.cell41Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell41Btn.Location = new System.Drawing.Point(387, 79);
            this.cell41Btn.Name = "cell41Btn";
            this.cell41Btn.Size = new System.Drawing.Size(90, 70);
            this.cell41Btn.TabIndex = 11;
            this.cell41Btn.TabStop = false;
            this.cell41Btn.Tag = "41";
            this.cell41Btn.UseVisualStyleBackColor = true;
            this.cell41Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell41Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell31Btn
            // 
            this.cell31Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell31Btn.Enabled = false;
            this.cell31Btn.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.cell31Btn.FlatAppearance.BorderSize = 2;
            this.cell31Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell31Btn.Location = new System.Drawing.Point(291, 79);
            this.cell31Btn.Name = "cell31Btn";
            this.cell31Btn.Size = new System.Drawing.Size(90, 70);
            this.cell31Btn.TabIndex = 10;
            this.cell31Btn.TabStop = false;
            this.cell31Btn.Tag = "31";
            this.cell31Btn.UseVisualStyleBackColor = true;
            this.cell31Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell31Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell21Btn
            // 
            this.cell21Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell21Btn.Enabled = false;
            this.cell21Btn.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.cell21Btn.FlatAppearance.BorderSize = 2;
            this.cell21Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell21Btn.Location = new System.Drawing.Point(195, 79);
            this.cell21Btn.Name = "cell21Btn";
            this.cell21Btn.Size = new System.Drawing.Size(90, 70);
            this.cell21Btn.TabIndex = 9;
            this.cell21Btn.TabStop = false;
            this.cell21Btn.Tag = "21";
            this.cell21Btn.UseVisualStyleBackColor = true;
            this.cell21Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell21Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell40Btn
            // 
            this.cell40Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell40Btn.Enabled = false;
            this.cell40Btn.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.cell40Btn.FlatAppearance.BorderSize = 2;
            this.cell40Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell40Btn.Location = new System.Drawing.Point(387, 3);
            this.cell40Btn.Name = "cell40Btn";
            this.cell40Btn.Size = new System.Drawing.Size(90, 70);
            this.cell40Btn.TabIndex = 4;
            this.cell40Btn.TabStop = false;
            this.cell40Btn.Tag = "40";
            this.cell40Btn.UseVisualStyleBackColor = true;
            this.cell40Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell40Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell30Btn
            // 
            this.cell30Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell30Btn.Enabled = false;
            this.cell30Btn.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.cell30Btn.FlatAppearance.BorderSize = 2;
            this.cell30Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell30Btn.Location = new System.Drawing.Point(291, 3);
            this.cell30Btn.Name = "cell30Btn";
            this.cell30Btn.Size = new System.Drawing.Size(90, 70);
            this.cell30Btn.TabIndex = 3;
            this.cell30Btn.TabStop = false;
            this.cell30Btn.Tag = "30";
            this.cell30Btn.UseVisualStyleBackColor = true;
            this.cell30Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell30Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // cell20Btn
            // 
            this.cell20Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cell20Btn.Enabled = false;
            this.cell20Btn.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.cell20Btn.FlatAppearance.BorderSize = 2;
            this.cell20Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cell20Btn.Location = new System.Drawing.Point(195, 3);
            this.cell20Btn.Name = "cell20Btn";
            this.cell20Btn.Size = new System.Drawing.Size(90, 70);
            this.cell20Btn.TabIndex = 0;
            this.cell20Btn.TabStop = false;
            this.cell20Btn.Tag = "20";
            this.cell20Btn.UseVisualStyleBackColor = true;
            this.cell20Btn.Click += new System.EventHandler(this.CellButton_Click);
            this.cell20Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldTLP_MouseDown);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.DarkGray;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelMoveBtn,
            this.chickensLeftLbl});
            this.toolStrip.Location = new System.Drawing.Point(0, 566);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(676, 25);
            this.toolStrip.TabIndex = 6;
            this.toolStrip.Text = "Панель уведомлений";
            // 
            // cancelMoveBtn
            // 
            this.cancelMoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelMoveBtn.Image")));
            this.cancelMoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelMoveBtn.Name = "cancelMoveBtn";
            this.cancelMoveBtn.Size = new System.Drawing.Size(96, 22);
            this.cancelMoveBtn.Text = "Cancel move";
            this.cancelMoveBtn.Click += new System.EventHandler(this.CancelMoveButton_Click);
            // 
            // chickensLeftLbl
            // 
            this.chickensLeftLbl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.chickensLeftLbl.ForeColor = System.Drawing.Color.Maroon;
            this.chickensLeftLbl.Image = ((System.Drawing.Image)(resources.GetObject("chickensLeftLbl.Image")));
            this.chickensLeftLbl.Name = "chickensLeftLbl";
            this.chickensLeftLbl.Size = new System.Drawing.Size(162, 22);
            this.chickensLeftLbl.Text = "To win, foxes need to eat 5";
            this.chickensLeftLbl.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Fox.png");
            this.imageList.Images.SetKeyName(1, "Chicken.png");
            this.imageList.Images.SetKeyName(2, "empty.png");
            this.imageList.Images.SetKeyName(3, "chickenDead.png");
            this.imageList.Images.SetKeyName(4, "start_position.png");
            this.imageList.Images.SetKeyName(5, "track.png");
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 591);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.GameFieldTLP);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(692, 630);
            this.MinimumSize = new System.Drawing.Size(692, 630);
            this.Name = "GameForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game: Fox and 13 Hens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.GameFieldTLP.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem newGameTSMI;
        private System.Windows.Forms.ToolStripMenuItem gameModeTSMI;
        private System.Windows.Forms.ToolStripMenuItem playerVsPlayerTSMI;
        private System.Windows.Forms.ToolStripMenuItem playerVsAiTSMI;
        private System.Windows.Forms.ToolStripMenuItem characterTSMI;
        private System.Windows.Forms.ToolStripMenuItem chickenTSMI;
        private System.Windows.Forms.ToolStripMenuItem foxTSMI;
        private System.Windows.Forms.ToolStripMenuItem ai_LevelTSMI;
        private System.Windows.Forms.ToolStripMenuItem lowLevelTSMI;
        private System.Windows.Forms.ToolStripMenuItem mediumLevelTSMI;
        private System.Windows.Forms.ToolStripMenuItem exitTSMI;
        private System.Windows.Forms.TableLayoutPanel GameFieldTLP;
        private System.Windows.Forms.Button cell46Btn;
        private System.Windows.Forms.Button cell36Btn;
        private System.Windows.Forms.Button cell26Btn;
        private System.Windows.Forms.Button cell45Btn;
        private System.Windows.Forms.Button cell35Btn;
        private System.Windows.Forms.Button cell25Btn;
        private System.Windows.Forms.Button cell64Btn;
        private System.Windows.Forms.Button cell54Btn;
        private System.Windows.Forms.Button cell44Btn;
        private System.Windows.Forms.Button cell34Btn;
        private System.Windows.Forms.Button cell24Btn;
        private System.Windows.Forms.Button cell14Btn;
        private System.Windows.Forms.Button cell04Btn;
        private System.Windows.Forms.Button cell63Btn;
        private System.Windows.Forms.Button cell53Btn;
        private System.Windows.Forms.Button cell43Btn;
        private System.Windows.Forms.Button cell33Btn;
        private System.Windows.Forms.Button cell23Btn;
        private System.Windows.Forms.Button cell13Btn;
        private System.Windows.Forms.Button cell03Btn;
        private System.Windows.Forms.Button cell62Btn;
        private System.Windows.Forms.Button cell52Btn;
        private System.Windows.Forms.Button cell42Btn;
        private System.Windows.Forms.Button cell32Btn;
        private System.Windows.Forms.Button cell22Btn;
        private System.Windows.Forms.Button cell12Btn;
        private System.Windows.Forms.Button cell02Btn;
        private System.Windows.Forms.Button cell41Btn;
        private System.Windows.Forms.Button cell31Btn;
        private System.Windows.Forms.Button cell21Btn;
        private System.Windows.Forms.Button cell40Btn;
        private System.Windows.Forms.Button cell30Btn;
        private System.Windows.Forms.Button cell20Btn;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton cancelMoveBtn;
        private System.Windows.Forms.ToolStripLabel chickensLeftLbl;
        private System.Windows.Forms.ImageList imageList;
    }
}

