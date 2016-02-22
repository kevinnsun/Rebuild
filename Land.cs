using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Rebuild
{
    class Land: DrawableObjects
    {
        //sets random generator
        private Random _numberGenerator = new Random();
        //constant integers that sets the min and max amount for zombie level, survivor, food
        private const int MIN_ZOMBIELEVEL = 1;
        private const int MAX_ZOMBIELEVEL = 6;
        private const int MIN_SURVIVOR = 0;
        private const int MAX_SURVIVOR = 3;
        private const int MIN_FOOD = 0;
        private const int MAX_FOOD = 11;

        //the level of zombies
        protected int _zombieLevel;
        public int ZombieLevel
        {
            get
            {
                return _zombieLevel;
            }
            set
            {
                //
                if (value >= MIN_ZOMBIELEVEL && value <= MAX_ZOMBIELEVEL)
                {
                    _zombieLevel = value;
                }
            }
        }
        //amoutn of soilders
        protected int _soliders;
        public int Soldiers
        {
            get
            {
                return _soliders;
            }
            set
            {
                //
                if (value >= MIN_SURVIVOR && value <= MAX_SURVIVOR)
                {
                    _soliders = value;
                }
            }
        }
        //amount of builders
        protected int _builders;
        public int Builders
        {
            get
            {
                return _builders;
            }
            set
            {
                //
                if (value >= MIN_SURVIVOR && value <= MAX_SURVIVOR)
                {
                    _builders = value;
                }
            }
        }
        //amount of scavengers
        protected int _scavengers;
        public int Scavengers
        {
            get
            {
                return _scavengers;
            }
            set
            {
                //
                if (value >= MIN_SURVIVOR && value <= MAX_SURVIVOR)
                {
                    _scavengers = value;
                }
            }
        }
        //amout of leaders
        protected int _leaders;
        public int Leaders
        {
            get
            {
                return _leaders;
            }
            set
            {
                //
                if (value >= MIN_SURVIVOR && value <= MAX_SURVIVOR)
                {
                    _leaders = value;
                }
            }
        }
        //amount of food
        protected int _food;
        public int Food
        {
            get
            {
                return _food;
            }
            set
            {
                //
                if (value >= MIN_FOOD && value <= MAX_FOOD)
                {
                    _food = value;
                }
            }
        }
        //land constructor
        public Land()
        {
            //set following values according to the random generator
            _zombieLevel = _numberGenerator.Next(MIN_ZOMBIELEVEL, MAX_ZOMBIELEVEL);
            _soliders = _numberGenerator.Next(MIN_SURVIVOR, MAX_SURVIVOR);
            _builders = _numberGenerator.Next(MIN_SURVIVOR, MAX_SURVIVOR);
            _scavengers = _numberGenerator.Next(MIN_SURVIVOR, MAX_SURVIVOR);
            _leaders = _numberGenerator.Next(MIN_SURVIVOR, MAX_SURVIVOR);
            _food = _numberGenerator.Next(MIN_FOOD, MAX_FOOD);
        }
    }
}
