using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Rebuild
{
    class Building: DrawableObjects
    {
        public Building()
            : base()
        {
        }

        //store builder requirements
        protected int _requireBuilders;
        public int RequireBuilders
        {
            //return purchase price
            get
            {
                return _requireBuilders;
            }
            //set purchasePrice as value
             set
            {
                _requireBuilders = value;
            }
        }

        //store DefenceBonus 
        protected int _defenceBonus;
        public int DefenceBonus
        {
            //return purchase price
            get
            {
                return _defenceBonus;
            }
            //set purchasePrice as value
            set
            {
                _defenceBonus = value;
            }
        }

        //store PopulationBonus 
        protected int _populationBonus;
        public int PopulationBonus
        {
            //return purchase price
            get
            {
                return _populationBonus;
            }
            //set purchasePrice as value
             set
            {
                _populationBonus = value;
            }
        }

        //store Food Bonus 
        protected int _foodBonus;
        public int FoodBonus
        {
            //return purchase price
            get
            {
                return _foodBonus;
            }
            //set purchasePrice as value
             set
            {
                _foodBonus = value;
            }
        }
        //building constructor to pass in variables 
        public Building(int requireBuilder, int defenceBonus, int populationBonus, int foodBonus)
        {
            //Set the value 
            _requireBuilders = requireBuilder;
            _defenceBonus = defenceBonus;
            _populationBonus = populationBonus;
            _foodBonus = foodBonus;
        }

    }
}
