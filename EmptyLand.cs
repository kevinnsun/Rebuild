using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebuild
{
    class EmptyLand: Land
    {
        //constructor for empty land
        public EmptyLand()
            : base()
        {
            //sets image
            _image = Properties.Resources.EmptyLand;
        }
        //
        public override string ToString()
        {
            return SharedVariables.EMPTYLAND;
        }
    }
}
