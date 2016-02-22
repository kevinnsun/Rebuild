using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebuild
{
    class MaxModel
    {
        //create a shared variables variables
        SharedVariables _variables;
        //constructor for MaxModel that passes in sharedvariables as parameter
        public MaxModel(SharedVariables variables)
        {
            //save the variables in a variables
            _variables = variables;
        }
        //constant int that sets the max and min amount of zombies for regular attack and horde attack
        const int ZOMBIE_MINIMUM_REGULAR = 5;
        const int ZOMBIE_MAXIMUM_REGULAR = 11;
        const int ZOMBIE_MINIMUM_HORDE = 10;
        const int ZOMBIE_MAXIMUM_HORDE = 16;


        //declare random generator
        Random randomNumberGenerator = new Random();

        //subprogram that determines if game is over or not and returns a bool
        public bool IsGameOver()
        {
            //returns true if population is less than 0 and food is less than 0
            if (_variables.population <= 0 || _variables.food <= 0)
            {
                
                return true;
            }
            //otherwise, returns false
            return false;
        }

        //this subprogram determines what will happen during zombie attack and returns a boolean expression
        public bool ZombieAttack()
        {
            //50% that zombie attack will happen
            if (randomNumberGenerator.Next(0, 2) == 0)
            {
                //sets the chances of either regular zombie or horder zombie attack to occura
                int activeZombieHordeAttack = randomNumberGenerator.Next(1, 11);
                //10% that it will be zombie horde
                if (activeZombieHordeAttack == 0)
                {
                    //creates random number of zombies
                    int numberofRandomZombiesHorde = randomNumberGenerator.Next(ZOMBIE_MINIMUM_HORDE + _variables.Days, ZOMBIE_MAXIMUM_HORDE + _variables.Days);
                    //zombie equation that determines the amount of zombies that will attack
                    _variables.ZombieAttacker = (1 + _variables.Days / 4) * numberofRandomZombiesHorde;
                    //if defense is less than zombies, returns false
                    if (_variables.defence < _variables.ZombieAttacker)
                    {
                        return false;
                    }
                    //otherwise if defense is greaeter, then returns true
                    else
                    {
                        return true;
                    }
                }
                //otherwise, 90% that regular zombie attack will happen
                else
                {
                    //creates random number of zombies
                    int numberofRandomZombies = randomNumberGenerator.Next(ZOMBIE_MINIMUM_REGULAR + _variables.Days, ZOMBIE_MAXIMUM_REGULAR + _variables.Days);
                    //zombie equation that determines the amount of zombies that will attack
                    _variables.ZombieAttacker = (1 + _variables.Days / 4) * numberofRandomZombies;
                    //if defense is less than zombies, returns false
                    if (_variables.defence < _variables.ZombieAttacker)
                    {
                        return false;
                    }
                    //otherwise if defense is greater, then returns true
                    else
                    {
                        return true;
                    }
                }
            }
            //otherwise, returns true
            else
            {
                return true;
            }


        }

    }
}
