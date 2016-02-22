using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebuild
{
    class Farm: Building
    {
        //constructor of farm
        public Farm()
            : base(1,0,0,5)
        {
            //sets image
            _image = Properties.Resources.Farm;
        }
        public override string ToString()
        {
            return SharedVariables.FARM;
        }
    }
}
