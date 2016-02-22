using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Rebuild
{
    class ModelWrapper
    {
        //Set each model to a variable model to access later on
        public SharedVariables _variables;
        KevinModel _model1;
        CindyModel _model2;
        MaxModel _model3;

        //modelwrapper constructor
        public ModelWrapper(int numCols, int numRows)
        {
            int farmPosX = numCols / 2;
            int farmPosY = numRows / 2;

            // Set SharedVariables as a variable with parameters passing through
            _variables = new SharedVariables(numCols, numRows);
            // Set each names variables to each of the people's models
            _model1 = new KevinModel(_variables);
            _model2 = new CindyModel(_variables);
            _model3 = new MaxModel(_variables);

            //Loop through all the columns of the grid
            for (int cols = 0; cols < _variables.Land.GetLength(0); cols++)
            {
                //Loop through all the rows of the grid
                for (int rows = 0; rows < _variables.Land.GetLength(1); rows++)
                {
                    // if the the column is in the current farm position x and rows is in the current position of y
                    if (cols == farmPosX && rows == farmPosY)
                    {
                        // Then the colony is a farm
                        _variables.Colony[cols, rows] = new Farm();
                        // and the land is an emptyland
                        _variables.Land[cols, rows] = new EmptyLand();
                    }

                    // if the columns position is left of the current position and rows is still the same position
                    else if (cols == farmPosX - 1 && rows == farmPosY)
                    {
                        // Then the colony is a farm
                        _variables.Colony[cols, rows] = new Farm();
                        // and the land is an emptyland
                        _variables.Land[cols, rows] = new EmptyLand();
                    }

                    // If the column is in current position and rows is below of position
                    else if (cols == farmPosX && rows == farmPosY - 1)
                    {
                        // Then the colony is a residence
                        _variables.Colony[cols, rows] = new Residence();
                        // and the land is an emptyland
                        _variables.Land[cols, rows] = new EmptyLand();
                    }

                    //If columns is left and rows is below of the current position
                    else if (cols == farmPosX - 1 && rows == farmPosY - 1)
                    {
                        // Then the colony is a police station
                        _variables.Colony[cols, rows] = new PoliceStation();
                        // and the land is an emptyland
                        _variables.Land[cols, rows] = new EmptyLand();
                    }
                    else
                    {
                        // Then the colony is a wilderness
                        _variables.Colony[cols, rows] = new Wilderness();
                        // and the land is an wilderness
                        _variables.Land[cols, rows] = new Wilderness();
                    }
                }
            }
        }

        // Subprogram LoadFile to call from the model that has the code
        // of loading the file
        public void LoadFile(string location)
        {
            _model1.LoadFile(location);
        }

        // Subprogram SetPlayerName to call from the model that has the code of setting the player name
        public void SetPlayerName(string name)
        {
            _variables.PlayerName = name;
        }

        // Subprogram to get the images of the colony in the beginning of the game
        public Image GetImage(int x, int y)
        {
            // Colony image will be returned and displayed
            return _variables.Colony[x, y].Image;
        }

        // Subprogram to build the police station, accessing from model1
        public bool BuildPoliceStation(int x, int y)
        {
            return _model1.BuildPoliceStation(x, y);
            
        }

        // Subprogram to build the residence, accessing from model1
        public bool BuildResidence(int x, int y)
        {
            return _model1.BuildResidence(x, y);
        }

        //Subprogram to build the farm, accessing from model1
        public bool BuildFarm(int x, int y)
        {
            return _model1.BuildFarm(x, y);
        } 

        // Subprogram to update days by setting and adding one each time it is updated
        public int UpdateDays()
        {
            int days  = _variables.Days++;
            return days;
        }

        // Subprogram to update food from accessing model2
        public int UpdateFood()
        {
            return _model2.CalculateFood();
        }

        // Subprogram to udpate the poulation from accessing model2
        public int UpdatePopulation()
        {
            int population = _model2.CalculatePopulation();
            return population;
        }

        // Subprogram to update the prodution of food from accessing model2
        public int UpdateFoodProduction()
        {
            return _model2.calculateFoodProduction();
        }

        // Subprogram Attack is accessed from model1
        public int Attack(int x, int y)
        {
            return _model1.Attack(x, y);
        }

        // Subprogram scavenge is accessed from model1
        public int Scavenge(int x, int y)
        {
            return _model1.Scavenge(x, y);
        }

        // Suprogram recruit soldier is accessed from model1
        public int RecruitSoldier(int x, int y)
        {
            return _model1.RecruitSoldier(x, y);
        }

        // Subprogram recruit builder is accessed from model1
        public int RecruitBuilder(int x, int y)
        {
            return _model1.RecruitBuilder(x, y);
        }

        // Subprogram recuit scavenger is accessed from model1
        public int RecruitScavenger(int x, int y)
        {
            return _model1.RecruitScavenger(x, y);
        }

        // Subprogram recruit leader is accessed from model1
        public int RecruitLeader(int x, int y)
        {
            return _model1.RecruitLeader(x, y);
        }

        //Call model1 to save the file 
        public void SaveFile()
        {
            _model1.SaveFile(_variables.PlayerName, _variables.NumCols, _variables.NumRows);
        }
        //Subprogram that determins if games is over
        public bool IsGameOver()
        {
            return _model3.IsGameOver();
        }
        //subprogram that calls zombie attacks
        public bool ZombieAttack()
        {
            return _model3.ZombieAttack();
        }



    }
}
