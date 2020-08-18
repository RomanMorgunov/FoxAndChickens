namespace WinForms
{
    partial class GameMechanicsSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.availableMovementsGB = new System.Windows.Forms.GroupBox();
            this.availableMovementsForChickensGB = new System.Windows.Forms.GroupBox();
            this.topLeftAvailableMovementsChickensCB = new System.Windows.Forms.CheckBox();
            this.bottomLeftAvailableMovementsChickensCB = new System.Windows.Forms.CheckBox();
            this.bottomRightAvailableMovementsChickensCB = new System.Windows.Forms.CheckBox();
            this.topRightAvailableMovementsChickensCB = new System.Windows.Forms.CheckBox();
            this.rightAvailableMovementsChickensCB = new System.Windows.Forms.CheckBox();
            this.topAvailableMovementsChickensCB = new System.Windows.Forms.CheckBox();
            this.bottomAvailableMovementsChickensCB = new System.Windows.Forms.CheckBox();
            this.leftAvailableMovementsChickensCB = new System.Windows.Forms.CheckBox();
            this.availableMovementsForFoxesGB = new System.Windows.Forms.GroupBox();
            this.topLeftAvailableMovementsFoxCB = new System.Windows.Forms.CheckBox();
            this.bottomLeftAvailableMovementsFoxCB = new System.Windows.Forms.CheckBox();
            this.bottomRightAvailableMovementsFoxCB = new System.Windows.Forms.CheckBox();
            this.topRightAvailableMovementsFoxCB = new System.Windows.Forms.CheckBox();
            this.rightAvailableMovementsFoxCB = new System.Windows.Forms.CheckBox();
            this.topAvailableMovementsFoxCB = new System.Windows.Forms.CheckBox();
            this.bottomAvailableMovementsFoxCB = new System.Windows.Forms.CheckBox();
            this.leftAvailableMovementsFoxCB = new System.Windows.Forms.CheckBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.eatingRuleGB = new System.Windows.Forms.GroupBox();
            this.topLeftEatingRuleCB = new System.Windows.Forms.CheckBox();
            this.bottomLeftEatingRuleCB = new System.Windows.Forms.CheckBox();
            this.bottomRightEatingRuleCB = new System.Windows.Forms.CheckBox();
            this.topRightEatingRuleCB = new System.Windows.Forms.CheckBox();
            this.rightEatingRuleCB = new System.Windows.Forms.CheckBox();
            this.topEatingRuleCB = new System.Windows.Forms.CheckBox();
            this.bottomEatingRuleCB = new System.Windows.Forms.CheckBox();
            this.leftEatingRuleCB = new System.Windows.Forms.CheckBox();
            this.controlsGB = new System.Windows.Forms.GroupBox();
            this.restoreToDefault = new System.Windows.Forms.Button();
            this.map = new WinForms.Map();
            this.mechanicsGB = new System.Windows.Forms.GroupBox();
            this.heuristicEvaluationGB = new System.Windows.Forms.GroupBox();
            this.evaluationMap = new WinForms.EvaluationMap();
            this.evaluationForOneLiveChickenNUD = new System.Windows.Forms.NumericUpDown();
            this.gameMapGB = new System.Windows.Forms.GroupBox();
            this.evaluationMapGB = new System.Windows.Forms.GroupBox();
            this.otherEvaluationsGB = new System.Windows.Forms.GroupBox();
            this.evaluationForOneLiveChickenLbl = new System.Windows.Forms.Label();
            this.EvaluationForBlockedOneFoxLbl = new System.Windows.Forms.Label();
            this.EvaluationForBlockedOneFoxNUD = new System.Windows.Forms.NumericUpDown();
            this.availableMovementsGB.SuspendLayout();
            this.availableMovementsForChickensGB.SuspendLayout();
            this.availableMovementsForFoxesGB.SuspendLayout();
            this.eatingRuleGB.SuspendLayout();
            this.controlsGB.SuspendLayout();
            this.mechanicsGB.SuspendLayout();
            this.heuristicEvaluationGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationForOneLiveChickenNUD)).BeginInit();
            this.gameMapGB.SuspendLayout();
            this.evaluationMapGB.SuspendLayout();
            this.otherEvaluationsGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EvaluationForBlockedOneFoxNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // availableMovementsGB
            // 
            this.availableMovementsGB.Controls.Add(this.availableMovementsForChickensGB);
            this.availableMovementsGB.Controls.Add(this.availableMovementsForFoxesGB);
            this.availableMovementsGB.Location = new System.Drawing.Point(3, 257);
            this.availableMovementsGB.Name = "availableMovementsGB";
            this.availableMovementsGB.Size = new System.Drawing.Size(207, 224);
            this.availableMovementsGB.TabIndex = 0;
            this.availableMovementsGB.TabStop = false;
            this.availableMovementsGB.Text = "Available movements";
            // 
            // availableMovementsForChickensGB
            // 
            this.availableMovementsForChickensGB.Controls.Add(this.topLeftAvailableMovementsChickensCB);
            this.availableMovementsForChickensGB.Controls.Add(this.bottomLeftAvailableMovementsChickensCB);
            this.availableMovementsForChickensGB.Controls.Add(this.bottomRightAvailableMovementsChickensCB);
            this.availableMovementsForChickensGB.Controls.Add(this.topRightAvailableMovementsChickensCB);
            this.availableMovementsForChickensGB.Controls.Add(this.rightAvailableMovementsChickensCB);
            this.availableMovementsForChickensGB.Controls.Add(this.topAvailableMovementsChickensCB);
            this.availableMovementsForChickensGB.Controls.Add(this.bottomAvailableMovementsChickensCB);
            this.availableMovementsForChickensGB.Controls.Add(this.leftAvailableMovementsChickensCB);
            this.availableMovementsForChickensGB.Dock = System.Windows.Forms.DockStyle.Right;
            this.availableMovementsForChickensGB.Location = new System.Drawing.Point(104, 16);
            this.availableMovementsForChickensGB.Name = "availableMovementsForChickensGB";
            this.availableMovementsForChickensGB.Size = new System.Drawing.Size(100, 205);
            this.availableMovementsForChickensGB.TabIndex = 8;
            this.availableMovementsForChickensGB.TabStop = false;
            this.availableMovementsForChickensGB.Text = "For chickens";
            // 
            // topLeftAvailableMovementsChickensCB
            // 
            this.topLeftAvailableMovementsChickensCB.AutoSize = true;
            this.topLeftAvailableMovementsChickensCB.Checked = true;
            this.topLeftAvailableMovementsChickensCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topLeftAvailableMovementsChickensCB.Location = new System.Drawing.Point(9, 113);
            this.topLeftAvailableMovementsChickensCB.Name = "topLeftAvailableMovementsChickensCB";
            this.topLeftAvailableMovementsChickensCB.Size = new System.Drawing.Size(66, 17);
            this.topLeftAvailableMovementsChickensCB.TabIndex = 7;
            this.topLeftAvailableMovementsChickensCB.Text = "Top Left";
            this.topLeftAvailableMovementsChickensCB.UseVisualStyleBackColor = true;
            // 
            // bottomLeftAvailableMovementsChickensCB
            // 
            this.bottomLeftAvailableMovementsChickensCB.AutoSize = true;
            this.bottomLeftAvailableMovementsChickensCB.Location = new System.Drawing.Point(9, 159);
            this.bottomLeftAvailableMovementsChickensCB.Name = "bottomLeftAvailableMovementsChickensCB";
            this.bottomLeftAvailableMovementsChickensCB.Size = new System.Drawing.Size(80, 17);
            this.bottomLeftAvailableMovementsChickensCB.TabIndex = 5;
            this.bottomLeftAvailableMovementsChickensCB.Text = "Bottom Left";
            this.bottomLeftAvailableMovementsChickensCB.UseVisualStyleBackColor = true;
            // 
            // bottomRightAvailableMovementsChickensCB
            // 
            this.bottomRightAvailableMovementsChickensCB.AutoSize = true;
            this.bottomRightAvailableMovementsChickensCB.Location = new System.Drawing.Point(9, 182);
            this.bottomRightAvailableMovementsChickensCB.Name = "bottomRightAvailableMovementsChickensCB";
            this.bottomRightAvailableMovementsChickensCB.Size = new System.Drawing.Size(87, 17);
            this.bottomRightAvailableMovementsChickensCB.TabIndex = 4;
            this.bottomRightAvailableMovementsChickensCB.Text = "Bottom Right";
            this.bottomRightAvailableMovementsChickensCB.UseVisualStyleBackColor = true;
            // 
            // topRightAvailableMovementsChickensCB
            // 
            this.topRightAvailableMovementsChickensCB.AutoSize = true;
            this.topRightAvailableMovementsChickensCB.Checked = true;
            this.topRightAvailableMovementsChickensCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topRightAvailableMovementsChickensCB.Location = new System.Drawing.Point(9, 136);
            this.topRightAvailableMovementsChickensCB.Name = "topRightAvailableMovementsChickensCB";
            this.topRightAvailableMovementsChickensCB.Size = new System.Drawing.Size(73, 17);
            this.topRightAvailableMovementsChickensCB.TabIndex = 6;
            this.topRightAvailableMovementsChickensCB.Text = "Top Right";
            this.topRightAvailableMovementsChickensCB.UseVisualStyleBackColor = true;
            // 
            // rightAvailableMovementsChickensCB
            // 
            this.rightAvailableMovementsChickensCB.AutoSize = true;
            this.rightAvailableMovementsChickensCB.Checked = true;
            this.rightAvailableMovementsChickensCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rightAvailableMovementsChickensCB.Location = new System.Drawing.Point(9, 42);
            this.rightAvailableMovementsChickensCB.Name = "rightAvailableMovementsChickensCB";
            this.rightAvailableMovementsChickensCB.Size = new System.Drawing.Size(51, 17);
            this.rightAvailableMovementsChickensCB.TabIndex = 3;
            this.rightAvailableMovementsChickensCB.Text = "Right";
            this.rightAvailableMovementsChickensCB.UseVisualStyleBackColor = true;
            // 
            // topAvailableMovementsChickensCB
            // 
            this.topAvailableMovementsChickensCB.AutoSize = true;
            this.topAvailableMovementsChickensCB.Checked = true;
            this.topAvailableMovementsChickensCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topAvailableMovementsChickensCB.Location = new System.Drawing.Point(9, 67);
            this.topAvailableMovementsChickensCB.Name = "topAvailableMovementsChickensCB";
            this.topAvailableMovementsChickensCB.Size = new System.Drawing.Size(45, 17);
            this.topAvailableMovementsChickensCB.TabIndex = 2;
            this.topAvailableMovementsChickensCB.Text = "Top";
            this.topAvailableMovementsChickensCB.UseVisualStyleBackColor = true;
            // 
            // bottomAvailableMovementsChickensCB
            // 
            this.bottomAvailableMovementsChickensCB.AutoSize = true;
            this.bottomAvailableMovementsChickensCB.Location = new System.Drawing.Point(9, 90);
            this.bottomAvailableMovementsChickensCB.Name = "bottomAvailableMovementsChickensCB";
            this.bottomAvailableMovementsChickensCB.Size = new System.Drawing.Size(59, 17);
            this.bottomAvailableMovementsChickensCB.TabIndex = 1;
            this.bottomAvailableMovementsChickensCB.Text = "Bottom";
            this.bottomAvailableMovementsChickensCB.UseVisualStyleBackColor = true;
            // 
            // leftAvailableMovementsChickensCB
            // 
            this.leftAvailableMovementsChickensCB.AutoSize = true;
            this.leftAvailableMovementsChickensCB.Checked = true;
            this.leftAvailableMovementsChickensCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.leftAvailableMovementsChickensCB.Location = new System.Drawing.Point(9, 19);
            this.leftAvailableMovementsChickensCB.Name = "leftAvailableMovementsChickensCB";
            this.leftAvailableMovementsChickensCB.Size = new System.Drawing.Size(44, 17);
            this.leftAvailableMovementsChickensCB.TabIndex = 0;
            this.leftAvailableMovementsChickensCB.Text = "Left";
            this.leftAvailableMovementsChickensCB.UseVisualStyleBackColor = true;
            // 
            // availableMovementsForFoxesGB
            // 
            this.availableMovementsForFoxesGB.Controls.Add(this.topLeftAvailableMovementsFoxCB);
            this.availableMovementsForFoxesGB.Controls.Add(this.bottomLeftAvailableMovementsFoxCB);
            this.availableMovementsForFoxesGB.Controls.Add(this.bottomRightAvailableMovementsFoxCB);
            this.availableMovementsForFoxesGB.Controls.Add(this.topRightAvailableMovementsFoxCB);
            this.availableMovementsForFoxesGB.Controls.Add(this.rightAvailableMovementsFoxCB);
            this.availableMovementsForFoxesGB.Controls.Add(this.topAvailableMovementsFoxCB);
            this.availableMovementsForFoxesGB.Controls.Add(this.bottomAvailableMovementsFoxCB);
            this.availableMovementsForFoxesGB.Controls.Add(this.leftAvailableMovementsFoxCB);
            this.availableMovementsForFoxesGB.Dock = System.Windows.Forms.DockStyle.Left;
            this.availableMovementsForFoxesGB.Location = new System.Drawing.Point(3, 16);
            this.availableMovementsForFoxesGB.Name = "availableMovementsForFoxesGB";
            this.availableMovementsForFoxesGB.Size = new System.Drawing.Size(100, 205);
            this.availableMovementsForFoxesGB.TabIndex = 1;
            this.availableMovementsForFoxesGB.TabStop = false;
            this.availableMovementsForFoxesGB.Text = "For foxes";
            // 
            // topLeftAvailableMovementsFoxCB
            // 
            this.topLeftAvailableMovementsFoxCB.AutoSize = true;
            this.topLeftAvailableMovementsFoxCB.Checked = true;
            this.topLeftAvailableMovementsFoxCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topLeftAvailableMovementsFoxCB.Location = new System.Drawing.Point(9, 113);
            this.topLeftAvailableMovementsFoxCB.Name = "topLeftAvailableMovementsFoxCB";
            this.topLeftAvailableMovementsFoxCB.Size = new System.Drawing.Size(66, 17);
            this.topLeftAvailableMovementsFoxCB.TabIndex = 7;
            this.topLeftAvailableMovementsFoxCB.Text = "Top Left";
            this.topLeftAvailableMovementsFoxCB.UseVisualStyleBackColor = true;
            // 
            // bottomLeftAvailableMovementsFoxCB
            // 
            this.bottomLeftAvailableMovementsFoxCB.AutoSize = true;
            this.bottomLeftAvailableMovementsFoxCB.Checked = true;
            this.bottomLeftAvailableMovementsFoxCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bottomLeftAvailableMovementsFoxCB.Location = new System.Drawing.Point(9, 159);
            this.bottomLeftAvailableMovementsFoxCB.Name = "bottomLeftAvailableMovementsFoxCB";
            this.bottomLeftAvailableMovementsFoxCB.Size = new System.Drawing.Size(80, 17);
            this.bottomLeftAvailableMovementsFoxCB.TabIndex = 5;
            this.bottomLeftAvailableMovementsFoxCB.Text = "Bottom Left";
            this.bottomLeftAvailableMovementsFoxCB.UseVisualStyleBackColor = true;
            // 
            // bottomRightAvailableMovementsFoxCB
            // 
            this.bottomRightAvailableMovementsFoxCB.AutoSize = true;
            this.bottomRightAvailableMovementsFoxCB.Checked = true;
            this.bottomRightAvailableMovementsFoxCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bottomRightAvailableMovementsFoxCB.Location = new System.Drawing.Point(9, 182);
            this.bottomRightAvailableMovementsFoxCB.Name = "bottomRightAvailableMovementsFoxCB";
            this.bottomRightAvailableMovementsFoxCB.Size = new System.Drawing.Size(87, 17);
            this.bottomRightAvailableMovementsFoxCB.TabIndex = 4;
            this.bottomRightAvailableMovementsFoxCB.Text = "Bottom Right";
            this.bottomRightAvailableMovementsFoxCB.UseVisualStyleBackColor = true;
            // 
            // topRightAvailableMovementsFoxCB
            // 
            this.topRightAvailableMovementsFoxCB.AutoSize = true;
            this.topRightAvailableMovementsFoxCB.Checked = true;
            this.topRightAvailableMovementsFoxCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topRightAvailableMovementsFoxCB.Location = new System.Drawing.Point(9, 136);
            this.topRightAvailableMovementsFoxCB.Name = "topRightAvailableMovementsFoxCB";
            this.topRightAvailableMovementsFoxCB.Size = new System.Drawing.Size(73, 17);
            this.topRightAvailableMovementsFoxCB.TabIndex = 6;
            this.topRightAvailableMovementsFoxCB.Text = "Top Right";
            this.topRightAvailableMovementsFoxCB.UseVisualStyleBackColor = true;
            // 
            // rightAvailableMovementsFoxCB
            // 
            this.rightAvailableMovementsFoxCB.AutoSize = true;
            this.rightAvailableMovementsFoxCB.Checked = true;
            this.rightAvailableMovementsFoxCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rightAvailableMovementsFoxCB.Location = new System.Drawing.Point(9, 42);
            this.rightAvailableMovementsFoxCB.Name = "rightAvailableMovementsFoxCB";
            this.rightAvailableMovementsFoxCB.Size = new System.Drawing.Size(51, 17);
            this.rightAvailableMovementsFoxCB.TabIndex = 3;
            this.rightAvailableMovementsFoxCB.Text = "Right";
            this.rightAvailableMovementsFoxCB.UseVisualStyleBackColor = true;
            // 
            // topAvailableMovementsFoxCB
            // 
            this.topAvailableMovementsFoxCB.AutoSize = true;
            this.topAvailableMovementsFoxCB.Checked = true;
            this.topAvailableMovementsFoxCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topAvailableMovementsFoxCB.Location = new System.Drawing.Point(9, 67);
            this.topAvailableMovementsFoxCB.Name = "topAvailableMovementsFoxCB";
            this.topAvailableMovementsFoxCB.Size = new System.Drawing.Size(45, 17);
            this.topAvailableMovementsFoxCB.TabIndex = 2;
            this.topAvailableMovementsFoxCB.Text = "Top";
            this.topAvailableMovementsFoxCB.UseVisualStyleBackColor = true;
            // 
            // bottomAvailableMovementsFoxCB
            // 
            this.bottomAvailableMovementsFoxCB.AutoSize = true;
            this.bottomAvailableMovementsFoxCB.Checked = true;
            this.bottomAvailableMovementsFoxCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bottomAvailableMovementsFoxCB.Location = new System.Drawing.Point(9, 90);
            this.bottomAvailableMovementsFoxCB.Name = "bottomAvailableMovementsFoxCB";
            this.bottomAvailableMovementsFoxCB.Size = new System.Drawing.Size(59, 17);
            this.bottomAvailableMovementsFoxCB.TabIndex = 1;
            this.bottomAvailableMovementsFoxCB.Text = "Bottom";
            this.bottomAvailableMovementsFoxCB.UseVisualStyleBackColor = true;
            // 
            // leftAvailableMovementsFoxCB
            // 
            this.leftAvailableMovementsFoxCB.AutoSize = true;
            this.leftAvailableMovementsFoxCB.Checked = true;
            this.leftAvailableMovementsFoxCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.leftAvailableMovementsFoxCB.Location = new System.Drawing.Point(9, 19);
            this.leftAvailableMovementsFoxCB.Name = "leftAvailableMovementsFoxCB";
            this.leftAvailableMovementsFoxCB.Size = new System.Drawing.Size(44, 17);
            this.leftAvailableMovementsFoxCB.TabIndex = 0;
            this.leftAvailableMovementsFoxCB.Text = "Left";
            this.leftAvailableMovementsFoxCB.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveBtn.Location = new System.Drawing.Point(6, 12);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(219, 34);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(456, 12);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(219, 34);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // eatingRuleGB
            // 
            this.eatingRuleGB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eatingRuleGB.Controls.Add(this.topLeftEatingRuleCB);
            this.eatingRuleGB.Controls.Add(this.bottomLeftEatingRuleCB);
            this.eatingRuleGB.Controls.Add(this.bottomRightEatingRuleCB);
            this.eatingRuleGB.Controls.Add(this.topRightEatingRuleCB);
            this.eatingRuleGB.Controls.Add(this.rightEatingRuleCB);
            this.eatingRuleGB.Controls.Add(this.topEatingRuleCB);
            this.eatingRuleGB.Controls.Add(this.bottomEatingRuleCB);
            this.eatingRuleGB.Controls.Add(this.leftEatingRuleCB);
            this.eatingRuleGB.Location = new System.Drawing.Point(213, 257);
            this.eatingRuleGB.Name = "eatingRuleGB";
            this.eatingRuleGB.Size = new System.Drawing.Size(122, 205);
            this.eatingRuleGB.TabIndex = 1;
            this.eatingRuleGB.TabStop = false;
            this.eatingRuleGB.Text = "Eating rule for foxes";
            // 
            // topLeftEatingRuleCB
            // 
            this.topLeftEatingRuleCB.AutoSize = true;
            this.topLeftEatingRuleCB.Location = new System.Drawing.Point(9, 113);
            this.topLeftEatingRuleCB.Name = "topLeftEatingRuleCB";
            this.topLeftEatingRuleCB.Size = new System.Drawing.Size(66, 17);
            this.topLeftEatingRuleCB.TabIndex = 7;
            this.topLeftEatingRuleCB.Text = "Top Left";
            this.topLeftEatingRuleCB.UseVisualStyleBackColor = true;
            // 
            // bottomLeftEatingRuleCB
            // 
            this.bottomLeftEatingRuleCB.AutoSize = true;
            this.bottomLeftEatingRuleCB.Location = new System.Drawing.Point(9, 159);
            this.bottomLeftEatingRuleCB.Name = "bottomLeftEatingRuleCB";
            this.bottomLeftEatingRuleCB.Size = new System.Drawing.Size(80, 17);
            this.bottomLeftEatingRuleCB.TabIndex = 5;
            this.bottomLeftEatingRuleCB.Text = "Bottom Left";
            this.bottomLeftEatingRuleCB.UseVisualStyleBackColor = true;
            // 
            // bottomRightEatingRuleCB
            // 
            this.bottomRightEatingRuleCB.AutoSize = true;
            this.bottomRightEatingRuleCB.Location = new System.Drawing.Point(9, 182);
            this.bottomRightEatingRuleCB.Name = "bottomRightEatingRuleCB";
            this.bottomRightEatingRuleCB.Size = new System.Drawing.Size(87, 17);
            this.bottomRightEatingRuleCB.TabIndex = 4;
            this.bottomRightEatingRuleCB.Text = "Bottom Right";
            this.bottomRightEatingRuleCB.UseVisualStyleBackColor = true;
            // 
            // topRightEatingRuleCB
            // 
            this.topRightEatingRuleCB.AutoSize = true;
            this.topRightEatingRuleCB.Location = new System.Drawing.Point(9, 136);
            this.topRightEatingRuleCB.Name = "topRightEatingRuleCB";
            this.topRightEatingRuleCB.Size = new System.Drawing.Size(73, 17);
            this.topRightEatingRuleCB.TabIndex = 6;
            this.topRightEatingRuleCB.Text = "Top Right";
            this.topRightEatingRuleCB.UseVisualStyleBackColor = true;
            // 
            // rightEatingRuleCB
            // 
            this.rightEatingRuleCB.AutoSize = true;
            this.rightEatingRuleCB.Checked = true;
            this.rightEatingRuleCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rightEatingRuleCB.Location = new System.Drawing.Point(9, 42);
            this.rightEatingRuleCB.Name = "rightEatingRuleCB";
            this.rightEatingRuleCB.Size = new System.Drawing.Size(51, 17);
            this.rightEatingRuleCB.TabIndex = 3;
            this.rightEatingRuleCB.Text = "Right";
            this.rightEatingRuleCB.UseVisualStyleBackColor = true;
            // 
            // topEatingRuleCB
            // 
            this.topEatingRuleCB.AutoSize = true;
            this.topEatingRuleCB.Checked = true;
            this.topEatingRuleCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topEatingRuleCB.Location = new System.Drawing.Point(9, 67);
            this.topEatingRuleCB.Name = "topEatingRuleCB";
            this.topEatingRuleCB.Size = new System.Drawing.Size(45, 17);
            this.topEatingRuleCB.TabIndex = 2;
            this.topEatingRuleCB.Text = "Top";
            this.topEatingRuleCB.UseVisualStyleBackColor = true;
            // 
            // bottomEatingRuleCB
            // 
            this.bottomEatingRuleCB.AutoSize = true;
            this.bottomEatingRuleCB.Checked = true;
            this.bottomEatingRuleCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bottomEatingRuleCB.Location = new System.Drawing.Point(9, 90);
            this.bottomEatingRuleCB.Name = "bottomEatingRuleCB";
            this.bottomEatingRuleCB.Size = new System.Drawing.Size(59, 17);
            this.bottomEatingRuleCB.TabIndex = 1;
            this.bottomEatingRuleCB.Text = "Bottom";
            this.bottomEatingRuleCB.UseVisualStyleBackColor = true;
            // 
            // leftEatingRuleCB
            // 
            this.leftEatingRuleCB.AutoSize = true;
            this.leftEatingRuleCB.Checked = true;
            this.leftEatingRuleCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.leftEatingRuleCB.Location = new System.Drawing.Point(9, 19);
            this.leftEatingRuleCB.Name = "leftEatingRuleCB";
            this.leftEatingRuleCB.Size = new System.Drawing.Size(44, 17);
            this.leftEatingRuleCB.TabIndex = 0;
            this.leftEatingRuleCB.Text = "Left";
            this.leftEatingRuleCB.UseVisualStyleBackColor = true;
            // 
            // controlsGB
            // 
            this.controlsGB.Controls.Add(this.restoreToDefault);
            this.controlsGB.Controls.Add(this.saveBtn);
            this.controlsGB.Controls.Add(this.cancelBtn);
            this.controlsGB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlsGB.Location = new System.Drawing.Point(0, 479);
            this.controlsGB.Name = "controlsGB";
            this.controlsGB.Size = new System.Drawing.Size(681, 52);
            this.controlsGB.TabIndex = 2;
            this.controlsGB.TabStop = false;
            // 
            // restoreToDefault
            // 
            this.restoreToDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreToDefault.Location = new System.Drawing.Point(231, 12);
            this.restoreToDefault.Name = "restoreToDefault";
            this.restoreToDefault.Size = new System.Drawing.Size(219, 34);
            this.restoreToDefault.TabIndex = 2;
            this.restoreToDefault.Text = "Restore to default";
            this.restoreToDefault.UseVisualStyleBackColor = true;
            this.restoreToDefault.Click += new System.EventHandler(this.restoreToDefault_Click);
            // 
            // map
            // 
            this.map.Location = new System.Drawing.Point(50, 16);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(217, 217);
            this.map.TabIndex = 3;
            // 
            // mechanicsGB
            // 
            this.mechanicsGB.Controls.Add(this.gameMapGB);
            this.mechanicsGB.Controls.Add(this.availableMovementsGB);
            this.mechanicsGB.Controls.Add(this.eatingRuleGB);
            this.mechanicsGB.Location = new System.Drawing.Point(1, 0);
            this.mechanicsGB.Name = "mechanicsGB";
            this.mechanicsGB.Size = new System.Drawing.Size(338, 484);
            this.mechanicsGB.TabIndex = 4;
            this.mechanicsGB.TabStop = false;
            this.mechanicsGB.Text = "Mechanics";
            // 
            // heuristicEvaluationGB
            // 
            this.heuristicEvaluationGB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.heuristicEvaluationGB.Controls.Add(this.otherEvaluationsGB);
            this.heuristicEvaluationGB.Controls.Add(this.evaluationMapGB);
            this.heuristicEvaluationGB.Location = new System.Drawing.Point(345, 0);
            this.heuristicEvaluationGB.Name = "heuristicEvaluationGB";
            this.heuristicEvaluationGB.Size = new System.Drawing.Size(334, 484);
            this.heuristicEvaluationGB.TabIndex = 5;
            this.heuristicEvaluationGB.TabStop = false;
            this.heuristicEvaluationGB.Text = "Heuristic evaluation";
            // 
            // evaluationMap
            // 
            this.evaluationMap.Location = new System.Drawing.Point(3, 16);
            this.evaluationMap.Name = "evaluationMap";
            this.evaluationMap.Size = new System.Drawing.Size(322, 182);
            this.evaluationMap.TabIndex = 0;
            // 
            // evaluationForOneLiveChickenNUD
            // 
            this.evaluationForOneLiveChickenNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evaluationForOneLiveChickenNUD.Location = new System.Drawing.Point(261, 19);
            this.evaluationForOneLiveChickenNUD.Name = "evaluationForOneLiveChickenNUD";
            this.evaluationForOneLiveChickenNUD.Size = new System.Drawing.Size(60, 20);
            this.evaluationForOneLiveChickenNUD.TabIndex = 1;
            this.evaluationForOneLiveChickenNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.evaluationForOneLiveChickenNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // gameMapGB
            // 
            this.gameMapGB.Controls.Add(this.map);
            this.gameMapGB.Location = new System.Drawing.Point(3, 16);
            this.gameMapGB.Name = "gameMapGB";
            this.gameMapGB.Size = new System.Drawing.Size(332, 238);
            this.gameMapGB.TabIndex = 2;
            this.gameMapGB.TabStop = false;
            this.gameMapGB.Text = "Game map";
            // 
            // evaluationMapGB
            // 
            this.evaluationMapGB.Controls.Add(this.evaluationMap);
            this.evaluationMapGB.Location = new System.Drawing.Point(3, 16);
            this.evaluationMapGB.Name = "evaluationMapGB";
            this.evaluationMapGB.Size = new System.Drawing.Size(328, 203);
            this.evaluationMapGB.TabIndex = 2;
            this.evaluationMapGB.TabStop = false;
            this.evaluationMapGB.Text = "Evaluating the chicken in position";
            // 
            // otherEvaluationsGB
            // 
            this.otherEvaluationsGB.Controls.Add(this.EvaluationForBlockedOneFoxLbl);
            this.otherEvaluationsGB.Controls.Add(this.EvaluationForBlockedOneFoxNUD);
            this.otherEvaluationsGB.Controls.Add(this.evaluationForOneLiveChickenLbl);
            this.otherEvaluationsGB.Controls.Add(this.evaluationForOneLiveChickenNUD);
            this.otherEvaluationsGB.Location = new System.Drawing.Point(3, 222);
            this.otherEvaluationsGB.Name = "otherEvaluationsGB";
            this.otherEvaluationsGB.Size = new System.Drawing.Size(328, 259);
            this.otherEvaluationsGB.TabIndex = 3;
            this.otherEvaluationsGB.TabStop = false;
            this.otherEvaluationsGB.Text = "Other evaluations";
            // 
            // evaluationForOneLiveChickenLbl
            // 
            this.evaluationForOneLiveChickenLbl.AutoSize = true;
            this.evaluationForOneLiveChickenLbl.Location = new System.Drawing.Point(6, 21);
            this.evaluationForOneLiveChickenLbl.Name = "evaluationForOneLiveChickenLbl";
            this.evaluationForOneLiveChickenLbl.Size = new System.Drawing.Size(168, 13);
            this.evaluationForOneLiveChickenLbl.TabIndex = 2;
            this.evaluationForOneLiveChickenLbl.Text = "Evaluation of the one live chicken";
            // 
            // EvaluationForBlockedOneFoxLbl
            // 
            this.EvaluationForBlockedOneFoxLbl.AutoSize = true;
            this.EvaluationForBlockedOneFoxLbl.Location = new System.Drawing.Point(6, 47);
            this.EvaluationForBlockedOneFoxLbl.Name = "EvaluationForBlockedOneFoxLbl";
            this.EvaluationForBlockedOneFoxLbl.Size = new System.Drawing.Size(151, 13);
            this.EvaluationForBlockedOneFoxLbl.TabIndex = 4;
            this.EvaluationForBlockedOneFoxLbl.Text = "Evaluation for blocked one fox";
            // 
            // EvaluationForBlockedOneFoxNUD
            // 
            this.EvaluationForBlockedOneFoxNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EvaluationForBlockedOneFoxNUD.Location = new System.Drawing.Point(261, 45);
            this.EvaluationForBlockedOneFoxNUD.Name = "EvaluationForBlockedOneFoxNUD";
            this.EvaluationForBlockedOneFoxNUD.Size = new System.Drawing.Size(60, 20);
            this.EvaluationForBlockedOneFoxNUD.TabIndex = 3;
            this.EvaluationForBlockedOneFoxNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GameMechanicsSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 531);
            this.Controls.Add(this.heuristicEvaluationGB);
            this.Controls.Add(this.mechanicsGB);
            this.Controls.Add(this.controlsGB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(697, 570);
            this.Name = "GameMechanicsSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game mechanics settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameMechanicsSettingsForm_FormClosing);
            this.availableMovementsGB.ResumeLayout(false);
            this.availableMovementsForChickensGB.ResumeLayout(false);
            this.availableMovementsForChickensGB.PerformLayout();
            this.availableMovementsForFoxesGB.ResumeLayout(false);
            this.availableMovementsForFoxesGB.PerformLayout();
            this.eatingRuleGB.ResumeLayout(false);
            this.eatingRuleGB.PerformLayout();
            this.controlsGB.ResumeLayout(false);
            this.mechanicsGB.ResumeLayout(false);
            this.heuristicEvaluationGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.evaluationForOneLiveChickenNUD)).EndInit();
            this.gameMapGB.ResumeLayout(false);
            this.evaluationMapGB.ResumeLayout(false);
            this.otherEvaluationsGB.ResumeLayout(false);
            this.otherEvaluationsGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EvaluationForBlockedOneFoxNUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox availableMovementsGB;
        private System.Windows.Forms.GroupBox availableMovementsForFoxesGB;
        private System.Windows.Forms.CheckBox leftAvailableMovementsFoxCB;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.CheckBox rightAvailableMovementsFoxCB;
        private System.Windows.Forms.CheckBox topAvailableMovementsFoxCB;
        private System.Windows.Forms.CheckBox bottomAvailableMovementsFoxCB;
        private System.Windows.Forms.CheckBox topLeftAvailableMovementsFoxCB;
        private System.Windows.Forms.CheckBox bottomLeftAvailableMovementsFoxCB;
        private System.Windows.Forms.CheckBox bottomRightAvailableMovementsFoxCB;
        private System.Windows.Forms.CheckBox topRightAvailableMovementsFoxCB;
        private System.Windows.Forms.GroupBox availableMovementsForChickensGB;
        private System.Windows.Forms.CheckBox topLeftAvailableMovementsChickensCB;
        private System.Windows.Forms.CheckBox bottomLeftAvailableMovementsChickensCB;
        private System.Windows.Forms.CheckBox bottomRightAvailableMovementsChickensCB;
        private System.Windows.Forms.CheckBox topRightAvailableMovementsChickensCB;
        private System.Windows.Forms.CheckBox rightAvailableMovementsChickensCB;
        private System.Windows.Forms.CheckBox topAvailableMovementsChickensCB;
        private System.Windows.Forms.CheckBox bottomAvailableMovementsChickensCB;
        private System.Windows.Forms.CheckBox leftAvailableMovementsChickensCB;
        private System.Windows.Forms.GroupBox eatingRuleGB;
        private System.Windows.Forms.CheckBox topLeftEatingRuleCB;
        private System.Windows.Forms.CheckBox bottomLeftEatingRuleCB;
        private System.Windows.Forms.CheckBox bottomRightEatingRuleCB;
        private System.Windows.Forms.CheckBox topRightEatingRuleCB;
        private System.Windows.Forms.CheckBox rightEatingRuleCB;
        private System.Windows.Forms.CheckBox topEatingRuleCB;
        private System.Windows.Forms.CheckBox bottomEatingRuleCB;
        private System.Windows.Forms.CheckBox leftEatingRuleCB;
        private System.Windows.Forms.GroupBox controlsGB;
        private System.Windows.Forms.Button restoreToDefault;
        private Map map;
        private System.Windows.Forms.GroupBox mechanicsGB;
        private System.Windows.Forms.GroupBox heuristicEvaluationGB;
        private EvaluationMap evaluationMap;
        private System.Windows.Forms.NumericUpDown evaluationForOneLiveChickenNUD;
        private System.Windows.Forms.GroupBox gameMapGB;
        private System.Windows.Forms.GroupBox evaluationMapGB;
        private System.Windows.Forms.GroupBox otherEvaluationsGB;
        private System.Windows.Forms.Label evaluationForOneLiveChickenLbl;
        private System.Windows.Forms.Label EvaluationForBlockedOneFoxLbl;
        private System.Windows.Forms.NumericUpDown EvaluationForBlockedOneFoxNUD;
    }
}