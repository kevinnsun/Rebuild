using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebuild
{
    class School: Building
    {
        public School()
            : base(3,2,0,0,0)
        {
            _image = Properties.Resources.School;
        }
    }
}
