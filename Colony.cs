using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Rebuild
{
    class DrawableObjects
    {
        //store imgaes of the buildings
        protected Image _image;
        public Image Image
        {
            //return image
            get
            {
                return _image;
            }
        }
    }
}
