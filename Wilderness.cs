using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebuild
{
    class Wilderness: Land
    {
        //constructor for wilderness
        public Wilderness()
            : base()
        {
            //sets image 
            _image = Properties.Resources.Wilderness;
        }
        //
        public override string ToString()
        {
            return SharedVariables.WILDERNESS;
        }
    }
}
