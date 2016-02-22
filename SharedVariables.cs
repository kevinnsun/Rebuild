using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebuild
{
    class SharedVariables
    {
        // Create variables of player name 
        // Create and set each variables as a number of population capacity, population, defence, food, and food production
        public string PlayerName;
        public int populationCapacity = 15;
        public int population = 10;
        public int defence = 15;
        public int food = 15;
        public int foodProduction = 10;

        // Create constant variables of each land and buildings
        public const string POLICESTATION = "police";
        public const string RESIDENCE = "residence";
        public const string FARM = "farm";
        public const string EMPTYLAND = "empty";
        public const string WILDERNESS = "wild";

        // Get and set zombieattackers to access it in other models 
        private int _zombieAttacker;
        public int ZombieAttacker
        {
            get
            {
                return _zombieAttacker;
            }
            set
            {
                _zombieAttacker = value;

            } 
        }

        // Get and set the days as 1
        private int _days = 1;
        public int Days
        {
            get
            {
                return _days;
            }
            set
            {
                // And if the days is greater than 0 then it returns 
                if (_days >= 0)
                {
                    _days = value;
                }
            }
        }

        // Get and set the colony as an object that can be drawn and moved
        private DrawableObjects[,] _colony;
        public DrawableObjects[,] Colony
        {
            get
            {
                return _colony;
            }
            set
            {
                _colony = value;
            }
        }
        //get and set building as an object
        private Building[,] _building;
        public Building[,] Building
        {
            get
            {
                return _building;
            }
            set
            {
                _building = value;
            }
        }
        //get and set land as object
        private Land[,] _land;
        public Land[,] Land
        {
            get
            {
                return _land;
            }
            set
            {
                _land = value;
            }
        }

        //property of number of columns 
        //determine the number of columns of the farm    
        private int _numCols;
        public int NumCols
        {
            get
            {
                return _numCols;
            }
            set
            {
                _numCols = value;
            }
        }

        //property of number of rows 
        //determine the number of rows of the farm 
        private int _numRows;
        public int NumRows
        {
            get
            {
                return _numRows;
            }
            set
            {
                _numRows = value;
            }
        }

        //number os soldiers 
        private int _numSoldiers = 4;
        public int NumSoldiers
        {
            get
            {
                return _numSoldiers;
            }
            set
            {
                if (_numSoldiers >= 0)
                {
                    _numSoldiers = value;
                }
            }
        }

        //number of busy soldiers 
        private int _numBusySoldiers;
        public int NumBusySoldiers
        {
            get
            {
                return _numBusySoldiers;
            }
            set
            {
                if (_numBusySoldiers >= 0)
                {
                    _numBusySoldiers = value;
                }
            }
        }

        //number of Builders 
        private int _numBuilders = 3;
        public int NumBuilders
        {
            get
            {
                return _numBuilders;
            }
            set
            {
                if (_numBuilders >= 0)
                {
                    _numBuilders = value; 
                }
            }
        }

        //number of scavengers 
        private int _numBusyBuilders;
        public int NumBusyBuilders
        {
            get
            {
                return _numBusyBuilders;
            }
            set
            {
                if (_numBusyBuilders >= 0)
                {
                    _numBusyBuilders = value;
                }
            }
        }

        //number of scavengers 
        private int _numScavengers = 2;
        public int NumScavengers
        {
            get
            {
                return _numScavengers;
            }
            set
            {
                if (_numScavengers >= 0)
                {
                    _numScavengers = value;
                }
            }
        }
        
        //number of busy scavengers 
        private int _numBusyScavengers;
        public int NumBusyScavengers
        {
            get
            {
                return _numBusyScavengers;
            }
            set
            {
                if (_numBusyScavengers >= 0)
                {
                    _numBusyScavengers = value;
                }
            }
        }

        //number of leaders
        private int _numLeaders= 1;
        public int NumLeaders
        {
            get
            {
                return _numLeaders;
            }
            set
            {
                if (_numLeaders >= 0)
                {
                    _numLeaders = value;
                }
            }
        }

        //to calculate the number of busy leaders 
        private int _numBusyLeaders;
        public int NumBusyLeaders
        {
            get
            {
                return _numBusyLeaders;
            }
            set
            {
                if (_numBusyLeaders >= 0)
                {
                    _numBusyLeaders = value;
                }
            }
        }


        //shared variables constructor 
        public SharedVariables(int numCols, int numRows)
        {
            //pass in the number of rows and columns
            _numRows = numRows;
            _numCols = numCols;
            //create new instance of product
            _colony = new DrawableObjects[numCols, numRows];
            _building = new Building[numCols, numRows];
            _land = new Land[numCols, numRows];
            
            for (int cols = 0; cols < numCols; cols++)
            {
                for (int rows = 0; rows < numRows; rows++)
                {
                    _colony[cols, rows] = new DrawableObjects();
                    _building[cols, rows] = new Building();
                    _land[cols, rows] = new Land();
                }
            }
            
        }
    }
}
