using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rebuild
{
    class KevinModel
    {
        //random generator 
        private Random _numberGenerator = new Random();

        //make reference to shared variables 
        SharedVariables _variables;

        //kevin Model constructor 
        public KevinModel(SharedVariables variables)
        {
            _variables = variables;
        }

        //build the police station
        public bool BuildPoliceStation(int x, int y)
        {
            
                //change the building to a police station 
                _variables.Building[x, y] = new PoliceStation();

                //check if the current num of builders is greater than the required amount of builders for the building
                if (_variables.NumBuilders >= _variables.Building[x, y].RequireBuilders && _variables.Land[x,y] is EmptyLand)
                {
                    //changge the image to a police station
                    _variables.Colony[x, y] = new PoliceStation();
                    //the defence would increase by the defence bonus of the police station
                    _variables.defence = _variables.defence + _variables.Building[x, y].DefenceBonus;
                    //number of busy builders will be equal to the number of required builders for that building 
                    _variables.NumBusyBuilders = _variables.NumBusyBuilders + _variables.Building[x, y].RequireBuilders;
                    //subtract the total number of builders from the number of busy builders 
                    _variables.NumBuilders = _variables.NumBuilders - _variables.Building[x,y].RequireBuilders;
                    return true;
                }
                else
                {
                    _variables.Land[x, y] = new EmptyLand();
                    return false;
                }
            
            
        }

        //build a residence 
        public bool BuildResidence(int x, int y)
        {
            //set the building as a residence 
            _variables.Building[x, y] = new Residence();

            //check if the current num of builders is greater than the required amount of builders for the building
            if (_variables.NumBuilders >= _variables.Building[x, y].RequireBuilders && _variables.Land[x, y] is EmptyLand)
            {
                //change the image to residence 
                _variables.Colony[x, y] = new Residence();
                //the population would increase by the population bonus of the residence 
                _variables.populationCapacity = _variables.populationCapacity + _variables.Building[x, y].PopulationBonus;
                //number of busy builders will be equal to the number of required builders for that building 
                _variables.NumBusyBuilders = _variables.NumBusyBuilders + _variables.Building[x, y].RequireBuilders;
                _variables.NumBuilders = _variables.NumBuilders - _variables.Building[x,y].RequireBuilders;
                return true;
            }
            else
            {
                _variables.Land[x, y] = new EmptyLand();
                return false;
            }
        }

        public bool BuildFarm(int x, int y)
        {
            //set the building as a farm 
            _variables.Building[x, y] = new Farm();

            //check if the current num of builders is greater than the required amount of builders for the building
            if (_variables.NumBuilders >= _variables.Building[x, y].RequireBuilders && _variables.Land[x, y] is EmptyLand)
            {
                //change the image to farm 
                _variables.Colony[x, y] = new Farm();
                _variables.foodProduction += _variables.Building[x, y].FoodBonus;
                //number of busy builders will be equal to the number of required builders for that building 
                _variables.NumBusyBuilders = _variables.NumBusyBuilders + _variables.Building[x, y].RequireBuilders;
                //subtract the total number of builders from the number of busy builders 
                _variables.NumBuilders = _variables.NumBuilders - _variables.Building[x,y].RequireBuilders;
                return true;
            }
            else
            {
                //change the land into an emptyland 
                _variables.Land[x, y] = new EmptyLand();
                return false;
            }
        }

        //Attack method 
        public int Attack(int x, int y)
        {
            int prompt;
            //require soldiers will equal to the amount of zombie levels present 
            int requiredSoldiers = _variables.Land[x,y].ZombieLevel;
            //A 20% fail rate
            int MissonFailed = _numberGenerator.Next(0, 6);

            //check if the land being selected is a wilderness
            if (_variables.Land[x, y] is Wilderness)
            {
                //check if the number of current soldiers is greater or equivlent to the zombie level on the selected land 
                if (_variables.NumSoldiers >= _variables.Land[x, y].ZombieLevel)
                {
                    //check if mission failed
                    //if mission failed, all soilders sent will die 
                    if (MissonFailed == 0)
                    {
                        _variables.NumSoldiers = _variables.NumSoldiers - requiredSoldiers;
                        //set prompt as 2
                        prompt = 2;
                    }
                        //other wise store the number of busy soldiers as the number of required soldiers
                        //subtract the amount of soldiers from the number of required soldiers 
                    else
                    {
                        _variables.NumBusySoldiers = _variables.NumBusySoldiers + requiredSoldiers;
                        _variables.NumSoldiers = _variables.NumSoldiers - requiredSoldiers;
                        //change the land and image from a wilderness to an empty land 
                        _variables.Land[x, y] = new EmptyLand();
                        _variables.Colony[x, y] = new EmptyLand();
                        //set prompt as 3 
                        prompt = 3;
                    }
                }
                    //otherwise set prompt as 1 
                else
                {
                    //set prompt as 1 
                    prompt = 1;
                }
            }
                //otherwise set prompt as 0 
            else
            {
                //set prompt as 1 
                prompt = 0;
            }
            return prompt;
        }

        //scavenge method 
        public int Scavenge(int x, int y)
        {
            int prompt;
            //each scavenger can carry up to 4 units of food 
            int carryingCapacity = 4;
            //set the required number of scavengers as a double first 
            //then pass it in as an int to round the number up
            double reqScavengers = Convert.ToDouble(_variables.Land[x, y].Food) / Convert.ToDouble(carryingCapacity);
            int requiredScavengers = (int)Math.Ceiling(reqScavengers);
            //A 10% fail rate
            int MissonFailed = _numberGenerator.Next(0,11);

            //if there is food on the land 
            if (_variables.Land[x, y].Food != 0)
            {
                //check to see if there is enough scavengers 
                if (_variables.NumScavengers * carryingCapacity >= _variables.Land[x, y].Food)
                {
                    //if the mission has failed
                    if (MissonFailed == 1)
                    {
                        //subtract the amount of require soldiers from the number of scavengers
                        _variables.NumScavengers = _variables.NumScavengers - requiredScavengers;
                        prompt = 2;
                    }
                        //if the misson is a success
                    else
                    {
                        //Add the required scavengers to the number of busy scavengers
                        _variables.NumBusyScavengers = _variables.NumBusyScavengers + requiredScavengers;
                        //the left over scavengers 
                        _variables.NumScavengers = _variables.NumScavengers - requiredScavengers;
                        _variables.food = _variables.food + _variables.Land[x, y].Food;
                        _variables.Land[x, y].Food = 0;
                        
                        prompt = 3;
                    }
                }
                //this happens when there is not enough scavengers avaiable
                else
                {
                    prompt = 1;
                }
            }
            //This happens when there is no food on the land selected
            else
            {
                prompt = 0;
            }
            return prompt;
        }

        //recruit soldier function
        public int RecruitSoldier(int x, int y)
        {
            int prompt;
            int requiredLeaders;
            //A 5% fail rate
            int MissonFailed = _numberGenerator.Next(0, 21);
            //check to see if there is soldiers to recruit on the land 
            if (_variables.Land[x, y].Soldiers != 0)
            {
                //check to see if there is enough leaders to recruit those soldiers
                if (_variables.NumLeaders >= _variables.Land[x, y].Soldiers)
                {
                    requiredLeaders = _variables.Land[x, y].Soldiers;
                    //check the to see if the populaton capacity can accodmadate more people
                    if (_variables.populationCapacity < _variables.population + _variables.Land[x, y].Soldiers)
                    {
                        prompt = 4;
                    }
                    //check to see if mission has failed
                    else if (MissonFailed == 1)
                    {
                        // subtract the requried number of leaders from the total amount
                        _variables.NumLeaders = _variables.NumLeaders - requiredLeaders;
                        prompt = 2;
                    }
                    //if the recruitment succeeded
                    else
                    {
                        //Add to the number of busy leaders 
                        _variables.NumBusyLeaders = _variables.NumBusyLeaders + requiredLeaders; 
                        //subtract from the total amount of leaders
                        _variables.NumLeaders = _variables.NumLeaders - requiredLeaders;
                        //Add to the number of soldiers accordin to the soldiers on the land
                        _variables.NumSoldiers = _variables.NumSoldiers + _variables.Land[x, y].Soldiers;
                        //Set the soldiers on the land to zero 
                        _variables.Land[x, y].Soldiers = 0;
                        prompt = 3;
                    }
                    
                }
                //this happens when there isnt enough leaders
                else 
                {
                    prompt = 1;
                }
            }
            //This happens when there are no soldiers to recruit
            else
            {
                prompt = 0;
            }
            return prompt;
        }

        //Recruit Builder
        public int RecruitBuilder(int x, int y)
        {
            int prompt;
            int requiredLeaders;
            //A 5% fail rate
            int MissonFailed = _numberGenerator.Next(0, 21);
            //Check to see if there are builders on the land 
            if (_variables.Land[x, y].Builders != 0)
            {
                //check to see if there is enough leaders
                if (_variables.NumLeaders >= _variables.Land[x, y].Builders)
                {
                    requiredLeaders = _variables.Land[x, y].Builders;
                    //check the to see if the populaton capacity can accodmadate more people
                    if (_variables.populationCapacity < _variables.population + _variables.Land[x, y].Builders)
                    {
                        prompt = 4;
                    }
                    //check to see if mission has failed
                    else if (MissonFailed == 1)
                    {
                        // subtract the requried number of leaders from the total amount
                        _variables.NumLeaders = _variables.NumLeaders - requiredLeaders;
                        prompt = 2;
                    }
                    //
                    else
                    {
                        //Add to the number of busy leaders 
                        _variables.NumBusyLeaders = _variables.NumBusyLeaders + requiredLeaders;
                        //subtract from the total amount of leaders
                        _variables.NumLeaders = _variables.NumLeaders - requiredLeaders;
                        //Add the number of builders on the land to the total number of builders 
                        _variables.NumBuilders = _variables.NumBuilders + _variables.Land[x, y].Builders;
                        _variables.Land[x, y].Builders = 0;
                        prompt = 3;
                    }

                }
                //this happens when there isnt enough leaders
                else
                {
                    prompt = 1;
                }
            }
            //This happens when there are no builders to recruit
            else
            {
                prompt = 0;
            }
            return prompt;
        }

        //Recruiting Scavenger Funtion
        public int RecruitScavenger(int x, int y)
        {
            int prompt;
            int requiredLeaders;
            //A 5% fail rate
            int MissonFailed = _numberGenerator.Next(0, 21);
            //Check to see if there are scavengers on the land 
            if (_variables.Land[x, y].Scavengers != 0)
            {
                //check to see if there is enough leaders
                if (_variables.NumLeaders >= _variables.Land[x, y].Scavengers)
                {
                    
                    requiredLeaders = _variables.Land[x, y].Scavengers;
                    //check the to see if the populaton capacity can accodmadate more people
                    if (_variables.populationCapacity < _variables.population + _variables.Land[x, y].Scavengers)
                    {
                        prompt = 4;
                    }
                    //check to see if mission has failed
                    else if (MissonFailed == 1)
                    {
                        // subtract the requried number of leaders from the total amount
                        _variables.NumLeaders = _variables.NumLeaders - requiredLeaders;
                        prompt = 2;
                    }
                    //if the mission succeeded
                    else
                    {
                        //Add to the number of busy leaders 
                        _variables.NumBusyLeaders = _variables.NumBusyLeaders + requiredLeaders;
                        //subtract from the total amount of leaders
                        _variables.NumLeaders = _variables.NumLeaders - requiredLeaders;
                        //Add the number of scavengers on the land to the total number of scavengers 
                        _variables.NumScavengers = _variables.NumScavengers + _variables.Land[x, y].Scavengers;
                        //Set the number os scavengers on the land to zero 
                        _variables.Land[x, y].Scavengers = 0;
                        prompt = 3;
                    }
                }
                //this happens when there isnt enough leaders
                else
                {
                    prompt = 1;
                }
            }
            //This happens when there are no scavnegers to recruit
            else
            {
                prompt = 0;
            }
            return prompt;
        }

        //Recruiting Leader function
        public int RecruitLeader(int x, int y)
        {
            //
            int prompt;
            int requiredLeaders;
            //A 5% fail rate
            int MissonFailed = _numberGenerator.Next(0, 21);
            //Check to see if there are leaders on the land 
            if (_variables.Land[x, y].Leaders != 0)
            {
                //check to see if there is enough leaders to recruit
                if (_variables.NumLeaders >= _variables.Land[x, y].Leaders)
                {
                    requiredLeaders = _variables.Land[x, y].Leaders;
                    //check the to see if the populaton capacity can accodmadate more people
                    if (_variables.populationCapacity < _variables.population + _variables.Land[x, y].Leaders)
                    {
                        prompt = 4;
                    }
                    //check to see if mission has failed
                    else if (MissonFailed == 1)
                    {
                        // subtract the requried number of leaders from the total amount
                        _variables.NumLeaders = _variables.NumLeaders - requiredLeaders;
                        prompt = 2;
                    }
                    //if the mission succeded
                    else
                    {
                        //subtract from the total amount of leaders
                        _variables.NumLeaders = _variables.NumLeaders - requiredLeaders;
                        //Add to the number of busy leaders 
                        _variables.NumBusyLeaders = _variables.NumBusyLeaders + requiredLeaders;                       
                        //Add the number of leaders on the land to the total number of leaders 
                        _variables.NumLeaders = _variables.NumLeaders + _variables.Land[x, y].Leaders;
                        _variables.Land[x, y].Leaders = 0;
                        
                        prompt = 3;
                    }
                }
                //this happens when there isnt enough leaders 
                else
                {
                    prompt = 1;
                }
            }
            //This happens when there are no leaders to recruit
            else
            {
                prompt = 0;
            }
            return prompt;
        }

        //Save the file by passing in where the file should be stored and the num of cols and rows
        public void SaveFile(string location, int numCols, int numRows)
        {
            //store the image type in a string variable 
            string _imgType;

             
            using (StreamWriter sw = new StreamWriter(location))
            {
                //Save every variable of the game as a string
                sw.WriteLine(_variables.NumCols.ToString());
                sw.WriteLine(_variables.NumRows.ToString());
                sw.WriteLine(_variables.NumSoldiers.ToString());
                sw.WriteLine(_variables.NumBuilders.ToString());
                sw.WriteLine(_variables.NumScavengers.ToString());
                sw.WriteLine(_variables.NumLeaders.ToString());
                sw.WriteLine(_variables.NumBusySoldiers.ToString());
                sw.WriteLine(_variables.NumBusyBuilders.ToString());
                sw.WriteLine(_variables.NumBusyScavengers.ToString());
                sw.WriteLine(_variables.NumBusyLeaders.ToString());
                sw.WriteLine(_variables.population.ToString());
                sw.WriteLine(_variables.defence.ToString());
                sw.WriteLine(_variables.food.ToString());
                sw.WriteLine(_variables.Days.ToString());

                //Save the image of each grid 
                for (int cols = 0; cols < numCols; cols++)
                {
                    for (int rows = 0; rows < numRows; rows++)
                    {
                        if (_variables.Colony[cols, rows] is EmptyLand)
                        {
                            _imgType = new EmptyLand().ToString();
                        }
                        else if (_variables.Colony[cols, rows] is Wilderness)
                        {
                            _imgType = new Wilderness().ToString();
                        }
                        else if (_variables.Colony[cols, rows] is PoliceStation)
                        {
                            _imgType = new PoliceStation().ToString();
                        }
                        else if (_variables.Colony[cols, rows] is Residence)
                        {
                            _imgType = new Residence().ToString();
                        }
                        else if (_variables.Colony[cols, rows] is Farm)
                        {
                            _imgType = new Farm().ToString();
                        }
                        else
                        {
                            _imgType = "";
                        }
                        //Save each characteristic of each grid 
                        //this includes all the components of a land piece
                        //This includes all the components of a building
                        //Save the image type 
                        sw.WriteLine(_variables.Land[cols, rows].Food.ToString() + "|" + _variables.Land[cols, rows].Soldiers.ToString() + "|" + _variables.Land[cols, rows].Builders.ToString() + "|" + _variables.Land[cols, rows].Scavengers.ToString() + "|" + _variables.Land[cols, rows].Leaders.ToString() + "|" + _variables.Land[cols, rows].ZombieLevel.ToString() + "*" + _variables.Building[cols, rows].RequireBuilders.ToString() + "|" + _variables.Building[cols, rows].DefenceBonus.ToString() + "|" + _variables.Building[cols, rows].PopulationBonus.ToString() + "|" + _variables.Building[cols, rows].FoodBonus.ToString() + "~" + _imgType);                                                
                    }
                }
            }
        }      
  
        public void LoadFile(string location)
        {
            using (StreamReader sr = new StreamReader(location))
            {
                //Declare temperary variables to store the saved variables of the colony
                int numCols;
                int numRows;
                int numSoldiers;
                int numBuilders;
                int numScavengers;
                int numLeaders;
                int numBusySoldier;
                int numBusyBuilder;
                int numBusyScavenger;
                int numBusyLeader;
                int days;

                //convert all the colony varaibles back into integers
                int.TryParse(sr.ReadLine(), out numCols);
                int.TryParse(sr.ReadLine(), out numRows);
                int.TryParse(sr.ReadLine(), out numSoldiers);
                int.TryParse(sr.ReadLine(), out numBuilders);
                int.TryParse(sr.ReadLine(), out numScavengers);
                int.TryParse(sr.ReadLine(), out numLeaders);
                int.TryParse(sr.ReadLine(), out numBusySoldier);
                int.TryParse(sr.ReadLine(), out numBusyBuilder);
                int.TryParse(sr.ReadLine(), out numBusyScavenger);
                int.TryParse(sr.ReadLine(), out numBusyLeader);
                int.TryParse(sr.ReadLine(), out _variables.population);
                int.TryParse(sr.ReadLine(), out _variables.defence);
                int.TryParse(sr.ReadLine(), out _variables.food);
                int.TryParse(sr.ReadLine(), out days);

                //pass in the varaibles that make up the colony into shared variables 
                _variables.NumSoldiers = numSoldiers;
                _variables.NumBuilders = numBuilders;
                _variables.NumScavengers = numScavengers;
                _variables.NumLeaders = numLeaders;
                _variables.NumBusySoldiers = numBusySoldier;
                _variables.NumBusyBuilders = numBusyBuilder;
                _variables.NumBusyScavengers = numBusyScavenger;
                _variables.NumBusyLeaders = numBusyLeader;

                for (int cols = 0; cols < numCols; cols++)
                {    
                    for (int rows = 0; rows < numRows; rows++)
                    {
                        //set an char array 
                        //set a string array for the attributes of the lands
                        //set a string arrat for the attributes of the buildings 
                        //set a string array for the attributes of the images
                        char[] currentLine = sr.ReadLine().ToCharArray();
                        string[] landAttributes = new string[6];
                        string[] buildingAttributes = new string[4];
                        string[] imageAttributes = new string[10];
                        //set counters for landattributes, builind attributes, and image attributes
                        int landAttributesCounter = 0;
                        int buildingAttributesCounter = 0;
                        int imageAttributesCounter = 0;
                        //Set booleans to determine if the grids are lands or buildings, or has an image
                        bool isLand = true;
                        bool isBuilding = false;
                        bool isImage = false;

                        for (int i = 0; i < currentLine.Length; i++)
                        {
                            //check if the grid is a land
                            if (isLand == true)
                            {
                                if (currentLine[i] == '|')
                                {
                                    //Add one to the land array
                                    landAttributesCounter++;
                                }
                                else if (currentLine[i] == '*')
                                {
                                    //if the grid is no a land, then assume it is a building
                                    isLand = false;
                                    isBuilding = true;
                                }
                                else
                                {
                                    //set the size of the array according to the amount of lands there are
                                    landAttributes[landAttributesCounter] += currentLine[i].ToString();
                                }
                            }
                                //If the grid contains a building 
                            else if (isBuilding == true)
                            {
                                //if there is a divider add one to the building attribute
                                if (currentLine[i] == '|')
                                {
                                    buildingAttributesCounter++;
                                }
                                    //If there is a break point, then it has an image
                                else if (currentLine[i] == '~')
                                {
                                    isLand = false;
                                    isBuilding = false;
                                    isImage = true;
                                }
                                //set the size of the building array according to the amount of buildings there are
                                else
                                {
                                    buildingAttributes[buildingAttributesCounter] += currentLine[i].ToString();
                                }
                            }
                                //If the grid is an image
                            else if (isImage == true)
                            {
                                //if there is a divider add one to the image counter
                                if (currentLine[i] == '|')
                                {
                                    imageAttributesCounter++;
                                }
                                //set the size of the image array according to the amount of images there are
                                else
                                {
                                    imageAttributes[imageAttributesCounter] += currentLine[i].ToString();
                                }
                            }
                        }

                        //set the components varaibles of the lands
                        int food = 0;
                        int soldiers = 0;
                        int builders = 0;
                        int scavengers = 0;
                        int leaders = 0;
                        int zombieLevel = 0;

                        int requireBuilders = 0;
                        int defenceBonus = 0;
                        int populationBonus = 0;
                        int foodBonus = 0;

                        //convert all the components of the land into integers
                        int.TryParse(landAttributes[0], out food);
                        int.TryParse(landAttributes[1], out soldiers);
                        int.TryParse(landAttributes[2], out builders);
                        int.TryParse(landAttributes[3], out scavengers);
                        int.TryParse(landAttributes[4], out leaders);
                        int.TryParse(landAttributes[5], out zombieLevel);

                        int.TryParse(buildingAttributes[0], out requireBuilders);
                        int.TryParse(buildingAttributes[1], out defenceBonus);
                        int.TryParse(buildingAttributes[2], out populationBonus);
                        int.TryParse(buildingAttributes[3], out foodBonus);

                        //transfer all the land varibles back into the land class
                        _variables.Land[cols, rows].Food = food;
                        _variables.Land[cols, rows].Soldiers = soldiers;
                        _variables.Land[cols, rows].Builders = builders;
                        _variables.Land[cols, rows].Scavengers = scavengers;
                        _variables.Land[cols, rows].Leaders = leaders;
                        _variables.Land[cols, rows].ZombieLevel = zombieLevel;
                        _variables.Building[cols, rows].RequireBuilders = requireBuilders;
                        _variables.Building[cols, rows].DefenceBonus = defenceBonus;
                        _variables.Building[cols, rows].PopulationBonus = populationBonus;
                        _variables.Building[cols, rows].FoodBonus = foodBonus;


                        for (int i = 0; i < imageAttributes.Length; i++)
                        {
                            //if the image type belongs to empty land, draw the image and input all it's characteristics 
                            if (imageAttributes[i] == SharedVariables.EMPTYLAND)
                            {
                                _variables.Colony[cols, rows] = new EmptyLand();
                                _variables.Land[cols, rows] = new EmptyLand();
                            }
                            //if the image type belongs to Wilderness, draw the image and input all it's characteristics 
                            else if (imageAttributes[i] == SharedVariables.WILDERNESS)
                            {
                                _variables.Colony[cols, rows] = new Wilderness();
                                _variables.Land[cols, rows] = new Wilderness();
                            }
                            //if the image type belongs to police station, draw the image and input all it's characteristics 
                            else if (imageAttributes[i] == SharedVariables.POLICESTATION)
                            {
                                _variables.Colony[cols, rows] = new PoliceStation();
                                _variables.Building[cols, rows] = new PoliceStation();
                            }
                            //if the image type belongs to residence, draw the image and input all it's characteristics 
                            else if (imageAttributes[i] == SharedVariables.RESIDENCE)
                            {
                                _variables.Colony[cols, rows] = new Residence();
                                _variables.Building[cols, rows] = new Residence();
                            }
                            //if the image type belongs to farm land, draw the image and input all it's characteristics 
                            else if (imageAttributes[i] == SharedVariables.FARM)
                            {
                                _variables.Colony[cols, rows] = new Farm();
                                _variables.Building[cols, rows] = new Farm();
                            }
                        }
                    }
                }
            }
        }

    }
}
