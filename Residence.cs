using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebuild
{
    // 
    class Residence: Building
    {
        // Residence constructor
        public Residence()
            : base(2,0,10,0)
        {
            _image = Properties.Resources.Residence;
        }
        public override string ToString()
        {
            return SharedVariables.RESIDENCE;
        }
    }
}
