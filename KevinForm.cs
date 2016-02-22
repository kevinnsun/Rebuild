using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rebuild
{
    public partial class KevinForm : Form
    {
        //declare the dimensions of grid, building
        //Set the number of rows and cols
        //set a month variable
        public const int GRID_WIDTH = 35;
        public const int BUILDING_WIDTH = 50;
        public int NUM_ROWS;
        public int NUM_COLS;


        //make a rectangle grid
        Rectangle[,] _grid; 
        Rectangle[] _buildingBar = new Rectangle[4];
        //Pen used to draw the outlines of the grid squares 
        Pen blackPen = new Pen(Color.Black);
        //Pen used to draw the outlines of the grid square during searching 
        Pen RedPen = new Pen(Color.Red);
        // Create the size of the rectangle 
        // Create the size of the farm bar
        Size gridRectSize = new Size(GRID_WIDTH, GRID_WIDTH);
        Size barRectSize = new Size(BUILDING_WIDTH, BUILDING_WIDTH);
        //point variable
        Point toolTipXY = new Point();

        //bool tip location 
        bool drawToolTip = false;
        //Declare the font
        Font toolTipFont = null;

        // Value of the BuildingSelectionIndex variable if no product is being made 
        const int BUILDING_NOT_BEING_MADE = -1;
        // Stores the indexs of the product being made, if one is being made 
        int BuildingSelectionIndex = BUILDING_NOT_BEING_MADE;
        // The model to store all of the city's information 
        ModelWrapper _theCity;

        // Stores constants of various product
        const int POLICE_STATION = 0;
        const int RESIDENCE = 1;
        const int FARM = 2;

        //constructor to save the file
        public KevinForm(string name)
        {
            //set the number of cols and rows 
            NUM_COLS = 10;
            NUM_ROWS = 10;
            //make rectangular grid
            _grid = new Rectangle[NUM_COLS, NUM_ROWS];
            _theCity = new ModelWrapper(NUM_COLS, NUM_ROWS);
            //Run the city 
            _theCity.SetPlayerName(name);
            InitializeComponent();
            //Set up the city grid
            SetupCityGrid();
            //Set up the building bar
            SetupBuildingBar();
            //store the toolTipFont a font ariel and a 12 size  
            toolTipFont = new Font("Ariel", 12.0f);
        }

        //constructor to load the file 
        public KevinForm(string name, int numCols, int numRows)
        {
            //set number of cols and rows
            NUM_COLS = numCols;
            NUM_ROWS = numRows;
            //make rectangular grid
            _grid = new Rectangle[NUM_COLS, NUM_ROWS];
            _theCity = new ModelWrapper(NUM_COLS, NUM_ROWS);
            //Set the FileName
            _theCity.SetPlayerName(name);
            InitializeComponent();
            //Set up the grid of the city
            SetupCityGrid();
            //Set up the building bar
            SetupBuildingBar();
            //set the tool tip font
            toolTipFont = new Font("Times New Roman", 12.0f);
            //load the game
            _theCity.LoadFile(name);

            //update the all the display for the user
            lblDay.Text = "Day: " + _theCity._variables.Days.ToString();
            lblFood.Text = "Food: " + _theCity._variables.food.ToString();
            lblDefence.Text = "Defence: " + _theCity._variables.defence.ToString();
            lblPopulation.Text = " Population : " + _theCity._variables.population.ToString() + "/";
            lblPopulationCapacity.Text = _theCity._variables.populationCapacity.ToString();
            lblSoldier.Text = "Soldier: " + _theCity._variables.NumSoldiers.ToString();
            lblBusySoldiers.Text = "Busy Soldier: " + _theCity._variables.NumBusySoldiers.ToString();
            lblScavenger.Text = "Scavenger: " + _theCity._variables.NumScavengers.ToString();
            lblBusyScavengers.Text = "Busy Scavenger: " + _theCity._variables.NumBusyScavengers.ToString();
            lblBuilder.Text = "Builder: " + _theCity._variables.NumBuilders.ToString();
            lblBusyBuilders.Text = "Busy Builder: " + _theCity._variables.NumBusyBuilders.ToString();
            lblLeader.Text = "Leader: " + _theCity._variables.NumLeaders.ToString();
            lblBusyLeaders.Text = "Busy Leader: " + _theCity._variables.NumBusyLeaders.ToString();
        }
        //subprogram that sets up the grid
        void SetupCityGrid()
        {
            // Set up the widths of each rectangle in the grids 
            for (int cols = 0; cols < _grid.GetLength(0); cols++)
            {
                for (int rows = 0; rows < _grid.GetLength(1); rows++)
                {
                    // Create a Point for the left left corner of the rectangle 
                    Point CityLocation = new Point(cols * GRID_WIDTH, rows * GRID_WIDTH);
                    _grid[cols, rows] = new Rectangle(CityLocation, gridRectSize);
                }
            }
        }
        //subprogram that sets up the bar
        void SetupBuildingBar()
        {
            //loops through the length of the bar
            for (int counter = 0; counter < _buildingBar.Length; counter++)
            {
                // creat a point for the left corner of the building bar
                // the building bar is located one unit below the grid
                Point barLocation = new Point(counter * BUILDING_WIDTH, GRID_WIDTH * (NUM_ROWS + 1));
                _buildingBar[counter] = new Rectangle(barLocation, barRectSize);
            }
        }

        // Draw the grid itself 
        void DrawGrid(Graphics canvas)
        {
            //nested loop that goes through each grid
            for (int cols = 0; cols < _grid.GetLength(0); cols++)
            {
                for (int rows = 0; rows < _grid.GetLength(1); rows++)
                {
                    //draws it out
                    canvas.DrawRectangle(blackPen, _grid[cols, rows]);
                }
            }
        }

        //draw the building bar that allows users to drag and drop product onto grid
        void DrawBuildingBar(Graphics canvas)
        {
            canvas.DrawImage(Properties.Resources.PoliceStation, _buildingBar[POLICE_STATION]);
            canvas.DrawImage(Properties.Resources.Residence, _buildingBar[RESIDENCE]);
            canvas.DrawImage(Properties.Resources.Farm, _buildingBar[FARM]);
        }

        //draw the image onto the grid
        void DrawImages(Graphics canvas)
        {
            //draw each image on the grid
            for (int cols = 0; cols < _grid.GetLength(0); cols++)
            {
                for (int rows = 0; rows < _grid.GetLength(1); rows++)
                {
                    canvas.DrawImage(_theCity.GetImage(cols, rows), _grid[cols, rows]);                    
                }
            }
        }

        //Paint form
        private void KevinForm_Paint(object sender, PaintEventArgs e)
        {
            // Draw the grid of rectangle of the form 
            // Draw the building bar
            // place the images
            DrawGrid(e.Graphics);
            DrawBuildingBar(e.Graphics);
            DrawImages(e.Graphics);

            if (drawToolTip == true)
            {
                for (int cols = 0; cols < _grid.GetLength(0); cols++)
                {
                    for (int rows = 0; rows < _grid.GetLength(1); rows++)
                    {
                        if (_grid[cols, rows].Contains(toolTipXY))
                        {
                            //Display all the information on the grid that the mouse is hoverig over
                            string toolTipInfo = "";
                            toolTipInfo = "Cols: " + cols.ToString() + "\r\n" + "Rows: " + rows.ToString() + "\r\n" + "Zombie Level: " + _theCity._variables.Land[cols, rows].ZombieLevel.ToString() + "\r\n" + "Soldiers :" + _theCity._variables.Land[cols, rows].Soldiers.ToString() + "\r\n" + "Builders: " + _theCity._variables.Land[cols,rows].Builders.ToString() + "\r\n" + "Scavenger: " + _theCity._variables.Land[cols,rows].Scavengers.ToString() + "\r\n" + "Leader: " + _theCity._variables.Land[cols,rows].Leaders.ToString() +"\r\n" + "Food :" + _theCity._variables.Land[cols, rows].Food.ToString();
                            e.Graphics.DrawString(toolTipInfo, toolTipFont, Brushes.Yellow, toolTipXY);
                        }
                        //if space is wilderness, we will use binary search to make borders yellow
                        if (_theCity._variables.Land[cols, rows] is Wilderness)
                        {
                            e.Graphics.DrawRectangle(RedPen, _grid[cols, rows]);
                        }
                    }
                }
                
            }
        }

        //when the ouse is clicked down 
        private void KevinForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Set no building being made 
            BuildingSelectionIndex = BUILDING_NOT_BEING_MADE;
            // Check if a building on the building bar has been clicked 
            for (int buildingIndex = 0; buildingIndex < _buildingBar.Length; buildingIndex++)
            {
                // If the mouse was clicked on the building bar it needs to know that a building creation 
                // attempt is being made by the user 
                if (_buildingBar[buildingIndex].Contains(e.Location))
                {
                    //set the building being made
                    BuildingSelectionIndex = buildingIndex;
                }
            }
        }


        //When the mouse goes up 
        private void KevinForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (BuildingSelectionIndex != BUILDING_NOT_BEING_MADE)
            {
                // Go through all grid squares to figure out which one that the user let go of the building 
                for (int cols = 0; cols < _grid.GetLength(0); cols++)
                {
                    for (int rows = 0; rows < _grid.GetLength(1); rows++)
                    {
                        // Find out which grid location the user let go of the mouse 
                        // so that a building can be made 
                        if (_grid[cols, rows].Contains(e.Location))
                        {
                            //Check if the selected building is a police station
                            //Builde a police station and display the number of builders and busy builders
                            if (BuildingSelectionIndex == POLICE_STATION)
                            {
                                if (_theCity.BuildPoliceStation(cols, rows) == true)
                                {
                                    lblDefence.Text = "Defence: " + _theCity._variables.defence.ToString();
                                    lblBuilder.Text = "Builder: " + _theCity._variables.NumBuilders.ToString();
                                    lblBusyBuilders.Text = "Busy Builder: " + _theCity._variables.NumBusyBuilders.ToString();
                                }
                                //otherwise let the user know that there is not enough builders
                                else
                                {
                                    MessageBox.Show("Can not build at this moment");
                                }
                            }
                            //Check if the selected building is a residence
                            //Builde a residence and display the number of builders and busy builders
                            else if (BuildingSelectionIndex == RESIDENCE)
                            {
                                if (_theCity.BuildResidence(cols, rows) == true)
                                {
                                    lblPopulationCapacity.Text = _theCity._variables.populationCapacity.ToString();
                                    lblBuilder.Text = "Builder: " + _theCity._variables.NumBuilders.ToString();
                                    lblBusyBuilders.Text = "Busy Builder: " + _theCity._variables.NumBusyBuilders.ToString();
                                }
                                //otherwise let the user know that there is not enough builders
                                else
                                {
                                    MessageBox.Show("Can not build at this moment");
                                }
                            }
                            //Check if the selected building is a farm
                            //Builde a farm and display the number of builders and busy builders
                            else if (BuildingSelectionIndex == FARM)
                            {
                                if (_theCity.BuildFarm(cols, rows) == true)
                                {
                                    lblBuilder.Text = "Builder: " + _theCity._variables.NumBuilders.ToString();
                                    lblBusyBuilders.Text = "Busy Builder: " + _theCity._variables.NumBusyBuilders.ToString();
                                }
                                //otherwise let the user know that there is not enough builders
                                else
                                {
                                    MessageBox.Show("Can not build at this moment");
                                }
                            }
                            //refreshes program
                            Refresh();
                        }
                    }
                }
            }
        }
            //Once the mouse moves try to locate the position that the mouse is located
        private void KevinForm_MouseMove(object sender, MouseEventArgs e)
        {

            for (int cols = 0; cols < _grid.GetLength(0); cols++)
            {
                for (int rows = 0; rows < _grid.GetLength(1); rows++)
                {
                    //locate the grid that the mouse is on
                    if (_grid[cols,rows].Contains(e.Location))
                    {
                        //set the xy coordinates of the tool tip as the location 
                        toolTipXY = e.Location;
                        //check to see if it is wilderness, if it is return true
                        if (_theCity._variables.Land[cols, rows] is Wilderness)
                        {
                            drawToolTip = true;
                        }
                        //otherwise return false
                        else
                        {
                            drawToolTip = false;
                        }
                    }
                }
            }
        }
        //occurs once user presses attack button
        private void btnAttack_Click(object sender, EventArgs e)
        {
            //if user inputs nothing, outputs that they can't select grid
            if (txtCols.Text == "" || txtRows.Text == "")
            {
                MessageBox.Show("Cannot select that grid!");
            }
            //int variables that stores the x and y coordinates
            int x;
            int y;
            //converst user input into int
            int.TryParse(txtCols.Text, out x);
            int.TryParse(txtRows.Text, out y);
            //calls Attack from model wrapper and assigns returned integer value to attack
            int attack = _theCity.Attack(x, y);
            //if returned value is 0, output to user that its not wilderness
            if (attack == 0)
            {
                MessageBox.Show("Not a wilderness");
            }
            //if returned value is 1, output to user that there is not enough soldiers
            else if (attack == 1)
            {
                MessageBox.Show("Not enough Soldiers");
            }
            //if returned value is 2, output to user that attack failed and update amount of soldier and population
            else if (attack == 2)
            {
                MessageBox.Show("Attack has failed");
                lblSoldier.Text = "Soldier: " + _theCity._variables.NumSoldiers.ToString();
                lblPopulation.Text = ("Population: " + _theCity.UpdatePopulation().ToString() + " /");               
            }
            //otherwise, output to user that attack has succeeded and update amount of soilder
            else
            {
                MessageBox.Show("Attack has Succeeded");
                lblSoldier.Text = "Soldier: " + _theCity._variables.NumSoldiers.ToString();
                lblBusySoldiers.Text = ("Busy Soldier: " + _theCity._variables.NumBusySoldiers.ToString());
            }
        }
        //this subprogram occurs when user clicks on scavenge button
        private void btnScavenge_Click(object sender, EventArgs e)
        {
            //if the user inputs enough, output taht they cant select grid
            if (txtCols.Text == "" || txtRows.Text == "")
            {
                MessageBox.Show("Cannot select that grid!");
            }
            //variables to store coordinates
            int x;
            int y;
            //converst user input into int
            int.TryParse(txtCols.Text, out x);
            int.TryParse(txtRows.Text, out y);
            //calls scavenge from model wrapper and pass in returned int value
            int scavenge = _theCity.Scavenge(x, y);
            //if returned value is 0, output that no food
            if (scavenge == 0)
            {
                MessageBox.Show("No food in this area");
            }
            //if returned value is 1, output not enough scavenegers
            else if (scavenge == 1)
            {
                MessageBox.Show("Not enough Scavengers");
            }
            //if returned value is 2, output that scavenging has failed and update populatino and scavenger
            else if (scavenge == 2)
            {
                MessageBox.Show("Scavenging has failed");
                lblScavenger.Text = "Scavenger: " + _theCity._variables.NumScavengers.ToString();
                lblPopulation.Text = ("Population: " + _theCity.UpdatePopulation().ToString() + " /");
            }
            //otherwise, output scavenge has succeed and update populatino and scavenger
            else
            {
                MessageBox.Show("Scavenge has Succeeded");
                lblScavenger.Text = "Scavenger: " + _theCity._variables.NumScavengers.ToString();
                lblFood.Text = ("Food: " + _theCity.UpdateFood().ToString());
                lblBusyScavengers.Text = ("Busy Scavenger: " + _theCity._variables.NumBusyScavengers.ToString());
            }
        }
        //this will occur if use clicks on recruit soldier
        private void btnRecruitSoldier_Click(object sender, EventArgs e)
        {
            //outputs that use cant select grid if user does not intput anything
            if (txtCols.Text == "" || txtRows.Text == "")
            {
                MessageBox.Show("Cannot select that grid!");
            }
            //variables stores coordinates
            int x;
            int y;
            //converst user intput into int
            int.TryParse(txtCols.Text, out x);
            int.TryParse(txtRows.Text, out y);
            //calls recruit soldiers from modelwrapper and assigns returned value to int
            int recruit = _theCity.RecruitSoldier(x, y);

            //if returned value is 0, output that there are no soilders
            if (recruit == 0)
            {
                MessageBox.Show("No soldiers to recruit in this area");
            }
            //if returned value is 1, output that there are not enough leaders
            else if (recruit == 1)
            {
                MessageBox.Show("Not enough leaders");
            }
            //if returned value is 2, output that recruiting failed and update leaders and population
            else if (recruit == 2)
            {
                MessageBox.Show("Recruiting has failed");
                lblLeader.Text = "Leader: " + _theCity._variables.NumLeaders.ToString();
                lblPopulation.Text = ("Population: " + _theCity.UpdatePopulation().ToString() + " /");
            }
            //if returned value is 3, output that recuiring succeded and update label soilder, population and leader 
            else if (recruit == 3)
            {
                MessageBox.Show("Recruiting has Succeeded");
                lblSoldier.Text = ("Soldier: " + _theCity._variables.NumSoldiers.ToString());
                lblPopulation.Text = ("Population: " + _theCity.UpdatePopulation().ToString() + " /");
                lblLeader.Text = "Leader: " + _theCity._variables.NumLeaders.ToString();
                lblBusyLeaders.Text = ("Busy Leader: " + _theCity._variables.NumBusyLeaders.ToString());
            }
            //otherwise, output there is no rooms for memebers
            else
            {
                MessageBox.Show("Not enough room for new members");
            }
        }
        //this will occur if use clicks on recruit builder
        private void btnRecruitBuilder_Click(object sender, EventArgs e)
        {
            //outputs that use cant select grid if user does not intput anything
            if (txtCols.Text == "" || txtRows.Text == "")
            {
                MessageBox.Show("Cannot select that grid!");
            }
            //variables stores coordinates
            int x;
            int y;
            //converst user intput into int
            int.TryParse(txtCols.Text, out x);
            int.TryParse(txtRows.Text, out y);
            //calls recruit soldiers from modelwrapper and assigns returned value to int
            int recruit = _theCity.RecruitBuilder(x, y);
            //if returned value is 0, output that there are no builders
            if (recruit == 0)
            {
                MessageBox.Show("No builders to recruit in this area");
            }
            //if returned value is 1, output that there are not enough leaders
            else if (recruit == 1)
            {
                MessageBox.Show("Not enough leaders");
            }
            //if returned value is 2, output that recruiting failed and update leaders and population
            else if (recruit == 2)
            {
                MessageBox.Show("Recruiting has failed");
                lblLeader.Text = "Leader: " + _theCity._variables.NumLeaders.ToString();
                lblPopulation.Text = ("Population: " + _theCity.UpdatePopulation().ToString() + " /");
            }
            //if returned value is 3, output that recruiting succeded and update builder, population and leader 
            else if (recruit == 3)
            {
                MessageBox.Show("Recruiting has Succeeded");
                lblBuilder.Text = ("Builder: " + _theCity._variables.NumBuilders.ToString());
                lblPopulation.Text = ("Population: " + _theCity.UpdatePopulation().ToString() + " /");
                lblLeader.Text = "Leader: " + _theCity._variables.NumLeaders.ToString();
                lblBusyLeaders.Text = ("Busy Leader: " + _theCity._variables.NumBusyLeaders.ToString());
            }
            //otherwise, output there is no rooms for memebers
            else
            {
                MessageBox.Show("Not enough room for new members");
            }
        }
        //this will occur if use clicks on recruit scavenger
        private void btnRecruitScavenger_Click(object sender, EventArgs e)
        {
            //outputs that use cant select grid if user does not intput anything
            if (txtCols.Text == "" || txtRows.Text == "")
            {
                MessageBox.Show("Cannot select that grid!");
            }
            //variables stores coordinates
            int x;
            int y;
            //converst user intput into int
            int.TryParse(txtCols.Text, out x);
            int.TryParse(txtRows.Text, out y);
            //calls recruit soldiers from modelwrapper and assigns returned value to int
            int recruit = _theCity.RecruitScavenger(x, y);
            //if returned value is 0, output that there are no scaavengers
            if (recruit == 0)
            {
                MessageBox.Show("No scavengers to recruit in this area");
            }
            //if returned value is 1, output that there are not enough leaders
            else if (recruit == 1)
            {
                MessageBox.Show("Not enough leaders");
            }
            //if returned value is 2, output that recruiting failed and update leaders and population
            else if (recruit == 2)
            {
                MessageBox.Show("Recruiting has failed");
                lblLeader.Text = "Leader: " + _theCity._variables.NumLeaders.ToString();
                lblPopulation.Text = ("Population: " + _theCity.UpdatePopulation().ToString() + " /");
            }
            //if returned value is 3, output that recuiring succeded and update scavenger, population and leader 
            else if (recruit == 3)
            {
                MessageBox.Show("Recruiting has Succeeded");
                lblScavenger.Text = ("Scavenger: " + _theCity._variables.NumScavengers.ToString());
                lblPopulation.Text = ("Population: " + _theCity.UpdatePopulation().ToString() + " /");
                lblLeader.Text = "Leader: " + _theCity._variables.NumLeaders.ToString();
                lblBusyLeaders.Text = ("Busy Leader: " + _theCity._variables.NumBusyLeaders.ToString());
            }
            //otherwise, output there is no rooms for memebers
            else
            {
                MessageBox.Show("Not enough room for new members");
            }
        }
        //this will occur if use clicks on recruit leader
        private void btnRecruitLeader_Click(object sender, EventArgs e)
        {
            //outputs that use cant select grid if user does not intput anything
            if (txtCols.Text == "" || txtRows.Text == "")
            {
                MessageBox.Show("Cannot select that grid!");
            }
            //variables stores coordinates
            int x;
            int y;
            //converst user intput into int
            int.TryParse(txtCols.Text, out x);
            int.TryParse(txtRows.Text, out y);
            //calls recruit soldiers from modelwrapper and assigns returned value to int
            int recruit = _theCity.RecruitLeader(x, y);
            //if returned value is 0, output that there are no leaders
            if (recruit == 0)
            {
                MessageBox.Show("No leaders to recruit in this area");
            }
            //if returned value is 1, output that there are not enough leaders
            else if (recruit == 1)
            {
                MessageBox.Show("Not enough leaders");
            }
            //if returned value is 2, output that recruiting failed and update leaders and population
            else if (recruit == 2)
            {
                MessageBox.Show("Recruiting has failed");
                lblLeader.Text = "Leader: " + _theCity._variables.NumLeaders.ToString();
                lblPopulation.Text = ("Population: " + _theCity.UpdatePopulation().ToString() + " /");
            }
            //if returned value is 3, output that recuiring succeded and update leader, population and leader 
            else if (recruit == 3)
            {
                MessageBox.Show("Recruiting has Succeeded");
                lblLeader.Text = ("Leader: " + _theCity._variables.NumLeaders.ToString());
                lblPopulation.Text = ("Population: " + _theCity.UpdatePopulation().ToString() + " /");
                lblBusyLeaders.Text = ("Busy Leader: " + _theCity._variables.NumBusyLeaders.ToString());
            }
            //otherwise, output there is no rooms for memebers
            else
            {
                MessageBox.Show("Not enough room for new members");
            }
        }

        private void KevinForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //once the user double clicks, select the xy coordinates of that grid
            for (int cols = 0; cols < _grid.GetLength(0); cols++)
            {
                for (int rows = 0; rows < _grid.GetLength(1); rows++)
                {
                    if (_grid[cols, rows].Contains(e.Location))
                    {
                        txtCols.Text = cols.ToString();
                        txtRows.Text = rows.ToString();
                    }
                }
            }
        }
        //this subprogram runs when days ends
        private void btnEndDay_Click(object sender, EventArgs e)
        {
            //update food and days and ouputs to user
            lblDay.Text = ("Days: " + _theCity.UpdateDays().ToString());
            lblFood.Text = ("Food: " + _theCity.UpdateFood().ToString());

            //Check if the number of busy soldiers is not zero
            if (_theCity._variables.NumBusySoldiers != 0)
            {
                //add the amount of busy soldiers to the amount of the avaible ones and then set busy soldiers to zero 
                _theCity._variables.NumSoldiers = _theCity._variables.NumSoldiers + _theCity._variables.NumBusySoldiers;
                _theCity._variables.NumBusySoldiers = 0;
                lblSoldier.Text = "Soldier: " + _theCity._variables.NumSoldiers.ToString();
                lblBusySoldiers.Text = "Busy Soldier: " + _theCity._variables.NumBusySoldiers.ToString();
            }
            //Check if the number of busy scavengers is not zero
            if (_theCity._variables.NumBusyScavengers != 0)
            {
                //add the amount of busy scavengers to the amount of the avaible ones and then set busy scavengers to zero 
                _theCity._variables.NumScavengers = _theCity._variables.NumScavengers + _theCity._variables.NumBusyScavengers;
                _theCity._variables.NumBusyScavengers = 0;
                lblScavenger.Text = "Scavenger: " + _theCity._variables.NumScavengers.ToString();
                lblBusyScavengers.Text = "Busy Scavenger: " + _theCity._variables.NumBusyScavengers.ToString();
            }
            //check to see if number of busy leaders is not zero 
            if (_theCity._variables.NumBusyLeaders != 0)
            {
                //add the amount of busy leaders to the amount of the avaible ones and then set busy leaders to zero 
                _theCity._variables.NumLeaders = _theCity._variables.NumLeaders + _theCity._variables.NumBusyLeaders;
                _theCity._variables.NumBusyLeaders = 0;
                lblLeader.Text = "Leader: " + _theCity._variables.NumLeaders.ToString();
                lblBusyLeaders.Text = "Busy Leader: " + _theCity._variables.NumBusyLeaders.ToString();
            }
            //check to see if the number of busy builders is not 0
            if (_theCity._variables.NumBusyBuilders != 0)
            {
                //add the amount of busy builders to the amount of the avaible ones and then set busy builders to zero 
                _theCity._variables.NumBuilders = _theCity._variables.NumBuilders + _theCity._variables.NumBusyBuilders;
                _theCity._variables.NumBusyBuilders = 0;
                lblBuilder.Text = "Builder: " + _theCity._variables.NumBuilders.ToString();
                lblBusyBuilders.Text = "Busy Builder: " + _theCity._variables.NumBusyBuilders.ToString();
            }

            //if gameisover is true, then output game is over to user and exits the form
            if (_theCity.IsGameOver() == true)
            {
                MessageBox.Show("game over!");
                Application.Exit();
            }
            //if zombieattack returns false, outputs that there has been zombie attack and exits form
            if (_theCity.ZombieAttack() == false)
            {
                MessageBox.Show(_theCity._variables.ZombieAttacker.ToString() + " zombies attacked! Your colony is overun. Game Over!");
                Application.Exit();
            }
            //if zombieattack returns true, outputs that zombie attack has been defended
            else if (_theCity.ZombieAttack() == true)
            {
                MessageBox.Show(_theCity._variables.ZombieAttacker.ToString() + " zombies attacked! You survived another day!");
            }

        }
        //timer that runs every millisecond
        private void tmrGameUpdate_Tick(object sender, EventArgs e)
        {
            //add the plus sign if the food production rate is greater than 0 to indicate that it is increasing 
            if (_theCity.UpdateFoodProduction() > 0)
            {
                lblFoodProduction.Text = "(+" + _theCity.UpdateFoodProduction().ToString() + ")";
            }
            //otherwise, display food production 
            else
            {
                lblFoodProduction.Text = "(" + _theCity.UpdateFoodProduction().ToString() + ")";
            }
            
            //refresh timer
            Refresh();
        }
        //when the form closes the game will automatically closes 
        private void KevinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //save the file and exit the application 
            _theCity.SaveFile();
            Application.Exit();
        }

        }





    }

