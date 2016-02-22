using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebuild
{
    class CindyModel
    {
        //create a shared variables variables
        SharedVariables _variables;
        //constructor for MaxModel that passes in sharedvariables as parameter
        public CindyModel(SharedVariables variables)
        {
            //save the variables in a variables
            _variables = variables;
        }
        //subprogram that calculates population and returns it
        public int CalculatePopulation()
        {
            _variables.population = _variables.NumSoldiers + _variables.NumBusySoldiers + _variables.NumBuilders + _variables.NumBusyBuilders + _variables.NumBusyScavengers + _variables.NumScavengers + _variables.NumLeaders + _variables.NumBusyLeaders;

            return _variables.population;
        }
        //subprogram that calculates food and returns it
        public int CalculateFood()
        {
            int food = _variables.food;

            _variables.food = food + calculateFoodProduction();

            return _variables.food;
        }
        //subprogram that calculates food production and reutrns it
        public int calculateFoodProduction()
        {
            int foodProduction;
            foodProduction = _variables.foodProduction - _variables.population;
            return foodProduction;
        }

    }
}