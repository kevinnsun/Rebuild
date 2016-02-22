namespace Rebuild
{
    partial class KevinForm
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
            this.components = new System.ComponentModel.Container();
            this.tmrGameUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnAttack = new System.Windows.Forms.Button();
            this.btnScavenge = new System.Windows.Forms.Button();
            this.txtCols = new System.Windows.Forms.TextBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.lblCols = new System.Windows.Forms.Label();
            this.lblRow = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblColon = new System.Windows.Forms.Label();
            this.lblFood = new System.Windows.Forms.Label();
            this.lblDefence = new System.Windows.Forms.Label();
            this.lblPopulation = new System.Windows.Forms.Label();
            this.btnRecruitSoldier = new System.Windows.Forms.Button();
            this.btnRecruitBuilder = new System.Windows.Forms.Button();
            this.btnRecruitScavenger = new System.Windows.Forms.Button();
            this.btnRecruitLeader = new System.Windows.Forms.Button();
            this.lblSoldier = new System.Windows.Forms.Label();
            this.lblBuilder = new System.Windows.Forms.Label();
            this.lblScavenger = new System.Windows.Forms.Label();
            this.lblLeader = new System.Windows.Forms.Label();
            this.lblPopulationCapacity = new System.Windows.Forms.Label();
            this.btnEndDay = new System.Windows.Forms.Button();
            this.lblFoodProduction = new System.Windows.Forms.Label();
            this.lblBusyBuilders = new System.Windows.Forms.Label();
            this.lblBusySoldiers = new System.Windows.Forms.Label();
            this.lblBusyScavengers = new System.Windows.Forms.Label();
            this.lblBusyLeaders = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tmrGameUpdate
            // 
            this.tmrGameUpdate.Enabled = true;
            this.tmrGameUpdate.Interval = 1;
            this.tmrGameUpdate.Tick += new System.EventHandler(this.tmrGameUpdate_Tick);
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(589, 81);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(75, 23);
            this.btnAttack.TabIndex = 1;
            this.btnAttack.Text = "ATTACK";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // btnScavenge
            // 
            this.btnScavenge.Location = new System.Drawing.Point(589, 110);
            this.btnScavenge.Name = "btnScavenge";
            this.btnScavenge.Size = new System.Drawing.Size(75, 23);
            this.btnScavenge.TabIndex = 2;
            this.btnScavenge.Text = "Scavenge";
            this.btnScavenge.UseVisualStyleBackColor = true;
            this.btnScavenge.Click += new System.EventHandler(this.btnScavenge_Click);
            // 
            // txtCols
            // 
            this.txtCols.Location = new System.Drawing.Point(589, 45);
            this.txtCols.Name = "txtCols";
            this.txtCols.Size = new System.Drawing.Size(48, 20);
            this.txtCols.TabIndex = 3;
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(660, 45);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(48, 20);
            this.txtRows.TabIndex = 4;
            // 
            // lblCols
            // 
            this.lblCols.AutoSize = true;
            this.lblCols.Location = new System.Drawing.Point(586, 29);
            this.lblCols.Name = "lblCols";
            this.lblCols.Size = new System.Drawing.Size(42, 13);
            this.lblCols.TabIndex = 5;
            this.lblCols.Text = "Column";
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(657, 29);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(29, 13);
            this.lblRow.TabIndex = 6;
            this.lblRow.Text = "Row";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(659, 455);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(38, 13);
            this.lblDay.TabIndex = 8;
            this.lblDay.Text = "Day: 0";
            // 
            // lblColon
            // 
            this.lblColon.AutoSize = true;
            this.lblColon.Location = new System.Drawing.Point(643, 48);
            this.lblColon.Name = "lblColon";
            this.lblColon.Size = new System.Drawing.Size(10, 13);
            this.lblColon.TabIndex = 9;
            this.lblColon.Text = ":";
            // 
            // lblFood
            // 
            this.lblFood.AutoSize = true;
            this.lblFood.Location = new System.Drawing.Point(587, 273);
            this.lblFood.Name = "lblFood";
            this.lblFood.Size = new System.Drawing.Size(49, 13);
            this.lblFood.TabIndex = 10;
            this.lblFood.Text = "Food: 15";
            // 
            // lblDefence
            // 
            this.lblDefence.AutoSize = true;
            this.lblDefence.Location = new System.Drawing.Point(587, 299);
            this.lblDefence.Name = "lblDefence";
            this.lblDefence.Size = new System.Drawing.Size(66, 13);
            this.lblDefence.TabIndex = 11;
            this.lblDefence.Text = "Defence: 15";
            // 
            // lblPopulation
            // 
            this.lblPopulation.AutoSize = true;
            this.lblPopulation.Location = new System.Drawing.Point(587, 326);
            this.lblPopulation.Name = "lblPopulation";
            this.lblPopulation.Size = new System.Drawing.Size(80, 13);
            this.lblPopulation.TabIndex = 12;
            this.lblPopulation.Text = "Population: 10/";
            // 
            // btnRecruitSoldier
            // 
            this.btnRecruitSoldier.Location = new System.Drawing.Point(589, 140);
            this.btnRecruitSoldier.Name = "btnRecruitSoldier";
            this.btnRecruitSoldier.Size = new System.Drawing.Size(108, 23);
            this.btnRecruitSoldier.TabIndex = 13;
            this.btnRecruitSoldier.Text = "Recruit Soldier";
            this.btnRecruitSoldier.UseVisualStyleBackColor = true;
            this.btnRecruitSoldier.Click += new System.EventHandler(this.btnRecruitSoldier_Click);
            // 
            // btnRecruitBuilder
            // 
            this.btnRecruitBuilder.Location = new System.Drawing.Point(589, 170);
            this.btnRecruitBuilder.Name = "btnRecruitBuilder";
            this.btnRecruitBuilder.Size = new System.Drawing.Size(108, 23);
            this.btnRecruitBuilder.TabIndex = 14;
            this.btnRecruitBuilder.Text = "Recruit Builder";
            this.btnRecruitBuilder.UseVisualStyleBackColor = true;
            this.btnRecruitBuilder.Click += new System.EventHandler(this.btnRecruitBuilder_Click);
            // 
            // btnRecruitScavenger
            // 
            this.btnRecruitScavenger.Location = new System.Drawing.Point(589, 200);
            this.btnRecruitScavenger.Name = "btnRecruitScavenger";
            this.btnRecruitScavenger.Size = new System.Drawing.Size(108, 23);
            this.btnRecruitScavenger.TabIndex = 15;
            this.btnRecruitScavenger.Text = "Recruit Scavenger";
            this.btnRecruitScavenger.UseVisualStyleBackColor = true;
            this.btnRecruitScavenger.Click += new System.EventHandler(this.btnRecruitScavenger_Click);
            // 
            // btnRecruitLeader
            // 
            this.btnRecruitLeader.Location = new System.Drawing.Point(589, 230);
            this.btnRecruitLeader.Name = "btnRecruitLeader";
            this.btnRecruitLeader.Size = new System.Drawing.Size(108, 23);
            this.btnRecruitLeader.TabIndex = 16;
            this.btnRecruitLeader.Text = "Recruit Leader";
            this.btnRecruitLeader.UseVisualStyleBackColor = true;
            this.btnRecruitLeader.Click += new System.EventHandler(this.btnRecruitLeader_Click);
            // 
            // lblSoldier
            // 
            this.lblSoldier.AutoSize = true;
            this.lblSoldier.Location = new System.Drawing.Point(709, 353);
            this.lblSoldier.Name = "lblSoldier";
            this.lblSoldier.Size = new System.Drawing.Size(51, 13);
            this.lblSoldier.TabIndex = 17;
            this.lblSoldier.Text = "Soldier: 4";
            // 
            // lblBuilder
            // 
            this.lblBuilder.AutoSize = true;
            this.lblBuilder.Location = new System.Drawing.Point(585, 353);
            this.lblBuilder.Name = "lblBuilder";
            this.lblBuilder.Size = new System.Drawing.Size(51, 13);
            this.lblBuilder.TabIndex = 18;
            this.lblBuilder.Text = "Builder: 3";
            // 
            // lblScavenger
            // 
            this.lblScavenger.AutoSize = true;
            this.lblScavenger.Location = new System.Drawing.Point(587, 401);
            this.lblScavenger.Name = "lblScavenger";
            this.lblScavenger.Size = new System.Drawing.Size(71, 13);
            this.lblScavenger.TabIndex = 19;
            this.lblScavenger.Text = "Scavenger: 2";
            // 
            // lblLeader
            // 
            this.lblLeader.AutoSize = true;
            this.lblLeader.Location = new System.Drawing.Point(708, 401);
            this.lblLeader.Name = "lblLeader";
            this.lblLeader.Size = new System.Drawing.Size(52, 13);
            this.lblLeader.TabIndex = 20;
            this.lblLeader.Text = "Leader: 1";
            // 
            // lblPopulationCapacity
            // 
            this.lblPopulationCapacity.AutoSize = true;
            this.lblPopulationCapacity.Location = new System.Drawing.Point(668, 326);
            this.lblPopulationCapacity.Name = "lblPopulationCapacity";
            this.lblPopulationCapacity.Size = new System.Drawing.Size(19, 13);
            this.lblPopulationCapacity.TabIndex = 21;
            this.lblPopulationCapacity.Text = "15";
            // 
            // btnEndDay
            // 
            this.btnEndDay.Location = new System.Drawing.Point(569, 450);
            this.btnEndDay.Name = "btnEndDay";
            this.btnEndDay.Size = new System.Drawing.Size(75, 23);
            this.btnEndDay.TabIndex = 22;
            this.btnEndDay.Text = "End Day";
            this.btnEndDay.UseVisualStyleBackColor = true;
            this.btnEndDay.Click += new System.EventHandler(this.btnEndDay_Click);
            // 
            // lblFoodProduction
            // 
            this.lblFoodProduction.AutoSize = true;
            this.lblFoodProduction.Location = new System.Drawing.Point(642, 273);
            this.lblFoodProduction.Name = "lblFoodProduction";
            this.lblFoodProduction.Size = new System.Drawing.Size(31, 13);
            this.lblFoodProduction.TabIndex = 23;
            this.lblFoodProduction.Text = "(+10)";
            // 
            // lblBusyBuilders
            // 
            this.lblBusyBuilders.AutoSize = true;
            this.lblBusyBuilders.Location = new System.Drawing.Point(586, 377);
            this.lblBusyBuilders.Name = "lblBusyBuilders";
            this.lblBusyBuilders.Size = new System.Drawing.Size(82, 13);
            this.lblBusyBuilders.TabIndex = 24;
            this.lblBusyBuilders.Text = "Busy Builders: 0";
            // 
            // lblBusySoldiers
            // 
            this.lblBusySoldiers.AutoSize = true;
            this.lblBusySoldiers.Location = new System.Drawing.Point(709, 377);
            this.lblBusySoldiers.Name = "lblBusySoldiers";
            this.lblBusySoldiers.Size = new System.Drawing.Size(77, 13);
            this.lblBusySoldiers.TabIndex = 25;
            this.lblBusySoldiers.Text = "Busy Soldier: 0";
            // 
            // lblBusyScavengers
            // 
            this.lblBusyScavengers.AutoSize = true;
            this.lblBusyScavengers.Location = new System.Drawing.Point(586, 424);
            this.lblBusyScavengers.Name = "lblBusyScavengers";
            this.lblBusyScavengers.Size = new System.Drawing.Size(102, 13);
            this.lblBusyScavengers.TabIndex = 26;
            this.lblBusyScavengers.Text = "Busy Scavengers: 0";
            // 
            // lblBusyLeaders
            // 
            this.lblBusyLeaders.AutoSize = true;
            this.lblBusyLeaders.Location = new System.Drawing.Point(711, 424);
            this.lblBusyLeaders.Name = "lblBusyLeaders";
            this.lblBusyLeaders.Size = new System.Drawing.Size(78, 13);
            this.lblBusyLeaders.TabIndex = 27;
            this.lblBusyLeaders.Text = "Busy Leader: 0";
            // 
            // KevinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 509);
            this.Controls.Add(this.lblBusyLeaders);
            this.Controls.Add(this.lblBusyScavengers);
            this.Controls.Add(this.lblBusySoldiers);
            this.Controls.Add(this.lblBusyBuilders);
            this.Controls.Add(this.lblFoodProduction);
            this.Controls.Add(this.btnEndDay);
            this.Controls.Add(this.lblPopulationCapacity);
            this.Controls.Add(this.lblLeader);
            this.Controls.Add(this.lblScavenger);
            this.Controls.Add(this.lblBuilder);
            this.Controls.Add(this.lblSoldier);
            this.Controls.Add(this.btnRecruitLeader);
            this.Controls.Add(this.btnRecruitScavenger);
            this.Controls.Add(this.btnRecruitBuilder);
            this.Controls.Add(this.btnRecruitSoldier);
            this.Controls.Add(this.lblPopulation);
            this.Controls.Add(this.lblDefence);
            this.Controls.Add(this.lblFood);
            this.Controls.Add(this.lblColon);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.lblCols);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.txtCols);
            this.Controls.Add(this.btnScavenge);
            this.Controls.Add(this.btnAttack);
            this.DoubleBuffered = true;
            this.Name = "KevinForm";
            this.Text = "Iowa ";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.KevinForm_MouseUp);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.KevinForm_MouseDoubleClick);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.KevinForm_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KevinForm_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KevinForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.KevinForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrGameUpdate;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Button btnScavenge;
        private System.Windows.Forms.TextBox txtCols;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label lblCols;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblColon;
        private System.Windows.Forms.Label lblFood;
        private System.Windows.Forms.Label lblDefence;
        private System.Windows.Forms.Label lblPopulation;
        private System.Windows.Forms.Button btnRecruitSoldier;
        private System.Windows.Forms.Button btnRecruitBuilder;
        private System.Windows.Forms.Button btnRecruitScavenger;
        private System.Windows.Forms.Button btnRecruitLeader;
        private System.Windows.Forms.Label lblSoldier;
        private System.Windows.Forms.Label lblBuilder;
        private System.Windows.Forms.Label lblScavenger;
        private System.Windows.Forms.Label lblLeader;
        private System.Windows.Forms.Label lblPopulationCapacity;
        private System.Windows.Forms.Button btnEndDay;
        private System.Windows.Forms.Label lblFoodProduction;
        private System.Windows.Forms.Label lblBusyBuilders;
        private System.Windows.Forms.Label lblBusySoldiers;
        private System.Windows.Forms.Label lblBusyScavengers;
        private System.Windows.Forms.Label lblBusyLeaders;
    }
}

