using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebuild
{
    class PoliceStation: Building
    {
        //police station constructor
        public PoliceStation()
            : base(3,15,0,0)
        {
            //sets image
            _image = Properties.Resources.PoliceStation;
        }
        //
        public override string ToString()
        {
            return SharedVariables.POLICESTATION;
        }
    }
}
